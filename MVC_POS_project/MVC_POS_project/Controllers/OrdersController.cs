using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_POS_project.Data;
using MVC_POS_project.Models;

namespace MVC_POS_project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var mVC_POS_projectContext = _context.Orders
                .Include(o => o.Customer)
                .Include(o=>o.SaleLines)
                .ThenInclude(l=>l.Product);
            return View(await mVC_POS_projectContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o=>o.SaleLines)
                .ThenInclude(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        // GET: Orders/CustomerOrders/5
        public async Task<IActionResult> CustomerOrders(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                .Where(o => o.CustomerId==id)
                .Include(o => o.SaleLines)
                .ThenInclude(l => l.Product);
            if (order == null)
            {
                return NotFound();
            }

            return View("Index",await order.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(string custId, Guid prodId, int col)
        {
            if (ModelState.IsValid)
            {
                    if (custId == null || prodId==Guid.Empty||col==0)
                {
                    return BadRequest();
                }

                var order = await _context.Orders
                    .Where(o => o.CustomerId == custId && o.Paid==false)
                    .Include(o => o.SaleLines)
                    .FirstOrDefaultAsync();
                Customer customer = await _context.Customers.FindAsync(custId);
                Product product = await _context.Products.FindAsync(prodId);
                if (customer == null || product == null)
                {
                    return NotFound();
                }
                if (order == null)
                {
                    SaleLine newLine=new SaleLine()
                    {
                        ProductId = prodId, 
                        UnitPrice = product.Price, 
                        Quantity = col, 
                        LinePrice = product.Price*col
                    };
                    string date = DateTime.UtcNow.ToShortDateString();
                    string time = DateTime.UtcNow.ToShortTimeString();
                    Order newOrder=new Order()
                    {
                        CustomerId = custId, 
                        DocNumber = $"{date}-{time}-{customer.UserName}-{product.Name}", 
                        Paid = false, 
                        TotalPrice = product.Price*col
                    };
                    await _context.Orders.AddAsync(newOrder);
                    newLine.OrderId = newOrder.Id;
                    await _context.SaleLines.AddAsync(newLine);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    SaleLine line = order.SaleLines.FirstOrDefault(l=>l.ProductId==prodId);
                    if (line == null)
                    {
                        SaleLine newLine = new SaleLine()
                        {
                            ProductId = prodId,
                            UnitPrice = product.Price,
                            Quantity = col,
                            LinePrice = product.Price * col,
                            OrderId = order.Id
                        };
                        order.TotalPrice += newLine.LinePrice;
                        order.ModifiedAt=DateTime.UtcNow;
                        await _context.SaleLines.AddAsync(newLine);
                        _context.Orders.Update(order);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        line.Quantity = col;
                        line.LinePrice = line.UnitPrice * col;
                        order.TotalPrice += line.UnitPrice * col;
                        order.ModifiedAt = DateTime.UtcNow;
                        _context.SaleLines.Update(line);
                        _context.Orders.Update(order);
                        await _context.SaveChangesAsync();
                    }
                }
                ViewBag.Order = order;
            }
            return RedirectToAction("Index","Products");
        }
        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocNumber,TotalPrice,Paid,CteatedAt,ModifiedAt,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid();
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DocNumber,TotalPrice,Paid,CteatedAt,ModifiedAt,CustomerId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(Guid id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}

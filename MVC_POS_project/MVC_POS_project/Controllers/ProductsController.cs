using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_POS_project.Data;
using MVC_POS_project.Models;
using MVC_POS_project.ViewModels;

namespace MVC_POS_project.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _manager;

        public ProductsController(ApplicationDbContext context, UserManager<Customer> manager)
        {
            _manager = manager;
            _context = context;
        }
        [AllowAnonymous]
        // GET: Products
        public async Task<IActionResult> Index()
        {
            Customer currentCustomer = await _manager.GetUserAsync(User);
            var products = _context.Products;
            List<UserOrderViewModel> productsUser=new List<UserOrderViewModel>();
            foreach (Product product in products)
            {
                UserOrderViewModel userOrder = new UserOrderViewModel()
                {
                    Product = product,
                    Family = await _context.Families.FirstOrDefaultAsync(f=>f.Id==product.FamilyId),
                    Lines = await _context.SaleLines.Where(l=>l.ProductId==product.Id).Where(l=>l.Order.CustomerId==currentCustomer.Id).ToListAsync(),
                    //Orders = await _context.Orders.Where(o=>o.CustomerId==currentCustomer.Id).Where(o=>o.SaleLines.Contains(product.SaleLines.FirstOrDefault(l=>l.ProductId==product.Id))).ToListAsync(),
                    Orders = await (from order in _context.Orders
                        join line in _context.SaleLines on order.Id equals line.OrderId
                        join pr in _context.Products on line.Product.Id equals pr.Id
                        where pr.Id==product.Id
                        where order.CustomerId==currentCustomer.Id
                             select order).ToListAsync(),
                     Customer = currentCustomer,
                };
                productsUser.Add(userOrder);
            }
            return View(productsUser);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Family)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.AllFamilies = _context.Families.ToList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FamilyId,Description,Price,CteatedBy,CteatedAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                product.CteatedBy = (await _manager.GetUserAsync(User)).UserName;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Name", product.FamilyId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Name", product.FamilyId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,FamilyId,Description,Price,CteatedBy,CteatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Name", product.FamilyId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Family)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

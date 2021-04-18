using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_POS_project.Models;
using MVC_POS_project.ViewModels;

namespace MVC_POS_project.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Customer> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<Customer> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: RolesController
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        } 

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        // GET: RolesController/Edit/5
        public async Task<IActionResult> Edit(string userId)
        {
            // get customer
            Customer customer = await _userManager.FindByIdAsync(userId);
            if (customer != null)
            {
                // get Roles of the customer
                var customerRoles = await _userManager.GetRolesAsync(customer);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = customer.Id,
                    UserEmail = customer.Email,
                    UserRoles = customerRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // get customer
            Customer customer = await _userManager.FindByIdAsync(userId);
            if (customer != null)
            {
                // get list of the roles of the customer
                var userRoles = await _userManager.GetRolesAsync(customer);
                // get all roles
                var allRoles = _roleManager.Roles.ToList();
                // get the added roles
                var addedRoles = roles.Except(userRoles);
                // get the deleted roles
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(customer, addedRoles);

                await _userManager.RemoveFromRolesAsync(customer, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        // GET: RolesController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

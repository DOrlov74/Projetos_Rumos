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
    public class CustomerController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;

        public CustomerController(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Email,UserName,Password,ConfirmPassword")] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer=new Customer(){Email = model.Email, UserName = model.UserName};
                // add user
                var result = await _userManager.CreateAsync(customer, model.Password);
                if (result.Succeeded)
                {
                    // add cookie
                    await _signInManager.SignInAsync(customer, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // check the URL
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Products");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login (or) password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // delete cookie
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            Customer customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = customer.Id, Email = customer.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = await _userManager.FindByIdAsync(model.Id);
                if (customer != null)
                {
                    //var _passwordValidator =
                    //    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<Customer>)) as IPasswordValidator<Customer>;
                    //var _passwordHasher =
                    //    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<Customer>)) as IPasswordHasher<Customer>;

                    //IdentityResult result =
                    //    await _passwordValidator.ValidateAsync(_userManager, customer, model.NewPassword);
                    //if (result.Succeeded)
                    //{
                    //    customer.PasswordHash = _passwordHasher.HashPassword(customer, model.NewPassword);
                    //    await _userManager.UpdateAsync(customer);
                    //    return RedirectToAction("Index");
                    //}
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(customer, model.OldPassword, model.NewPassword);
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
                else
                {
                    ModelState.AddModelError(string.Empty, "Can't find the user");
                }
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        // GET: CustomerController
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            Customer customer = await _userManager.FindByIdAsync(id);
            return View(customer);
        }
        [Authorize(Roles = "admin")]
        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer() { Email = model.Email, UserName = model.Email, Address = model.Address, NIF = model.NIF};
                var result = await _userManager.CreateAsync(customer, model.Password);
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
            return View(model);
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            Customer customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            EditCustomerViewModel model = new EditCustomerViewModel { Id=customer.Id, UserName = customer.UserName, Email = customer.Email, Address = customer.Address, NIF=customer.NIF, PhoneNumber = customer.PhoneNumber};
            return View(model);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer currentUser = await _userManager.GetUserAsync(User);
                Customer customer = await _userManager.FindByIdAsync(model.Id);
                if (customer != null)
                {
                    customer.Email = model.Email;
                    customer.UserName = model.UserName;
                    customer.Address = model.Address;
                    customer.NIF = model.NIF;
                    customer.PhoneNumber = model.PhoneNumber;

                    var result = await _userManager.UpdateAsync(customer);
                    if (result.Succeeded)
                    {
                        if(await _userManager.IsInRoleAsync(currentUser, "admin")) { 
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Products");
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            Customer customer = await _userManager.FindByIdAsync(id);
            if (customer != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(customer);
            }
            return RedirectToAction("Index");
        }

        // POST: CustomerController/Delete/5
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

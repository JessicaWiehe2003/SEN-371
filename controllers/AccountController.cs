using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_4_CampusLearn.Data;
using Project_4_CampusLearn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_4_CampusLearn.ViewModels.AuthVms;

namespace Project_4_CampusLearn.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _users;
        private readonly SignInManager<AppUser> _signIn;

        public AccountController(UserManager<AppUser> users, SignInManager<AppUser> signIn)
        { _users = users; _signIn = signIn; }

        [HttpGet] public IActionResult Login() => View();
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            var user = await _users.FindByEmailAsync(vm.Email);
            if (user == null) { ModelState.AddModelError("", "Invalid"); return View(vm); }
            var result = await _signIn.PasswordSignInAsync(user, vm.Password, true, true);
            if (!result.Succeeded) { ModelState.AddModelError("", "Invalid"); return View(vm); }
            return Redirect("/topics");
        }

        [HttpGet] public IActionResult Register() => View();
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var u = new AppUser { UserName = vm.Email, Email = vm.Email, FullName = vm.FullName, IsTutor = vm.IsTutor };
            var r = await _users.CreateAsync(u, vm.Password);
            if (!r.Succeeded) { foreach (var e in r.Errors) ModelState.AddModelError("", e.Description); return View(vm); }
            await _signIn.SignInAsync(u, true);
            return Redirect("/topics");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();
            return Redirect("/");
        }
    }
}

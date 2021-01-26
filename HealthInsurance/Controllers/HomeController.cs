using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthInsurance.Models;
using HealthInsurance.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HealthInsurance.Data;
using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private HealthInsuranceDbContext _repository;
        private RoleManager<IdentityRole> roleManager;

        public HomeController(HealthInsuranceDbContext repository, RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var ListUsers = _repository.Users.ToList();
            List<ListUserRole> ListUserRoles = new List<ListUserRole>();
            foreach(var user in ListUsers)
            {
                var UserRole = _repository.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).FirstOrDefault();
                ListUserRole listUserRole = new ListUserRole
                {
                    User = user,
                    Role = roleManager.Roles.Where(r => r.Id == UserRole).FirstOrDefault() 
                };
                ListUserRoles.Add(listUserRole);
            }

            await roleManager.CreateAsync(new IdentityRole("Administrator"));
            await roleManager.CreateAsync(new IdentityRole("Manager"));
            await roleManager.CreateAsync(new IdentityRole("Finance Manager"));
            await roleManager.CreateAsync(new IdentityRole("Staff"));
            await roleManager.CreateAsync(new IdentityRole("User"));
                
            return View(new UserListViewModel
            {
                TotalUser = _repository.Users.Count(),
                TotalPolicyRequest = _repository.PolicyRequests.Count(),
                TotalPolicyAction = _repository.PolicyActions.Count(),
                ListUserRoles = ListUserRoles
            });
        }

        [HttpGet]
        public IActionResult EditUser(string UserId)
        {
            return View(_repository.Users.Where(x => x.Id == UserId).FirstOrDefault());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

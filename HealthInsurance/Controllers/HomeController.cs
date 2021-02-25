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
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private HealthInsuranceDbContext _repository;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(HealthInsuranceDbContext repository, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            this.roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var ListUsers = _repository.Users.ToList();
            List<ListUserRole> ListUserRoles = new List<ListUserRole>();
            foreach (var user in ListUsers)
            {
                var UserRole = _repository.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).FirstOrDefault();
                ListUserRole listUserRole = new ListUserRole
                {
                    User = user,
                    Role = roleManager.Roles.Where(r => r.Id == UserRole).FirstOrDefault()
                };
                ListUserRoles.Add(listUserRole);
            }

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
            return View(new SetUserRole {
                User = _repository.Users.Where(x => x.Id == UserId).FirstOrDefault(),
                Roles = roleManager.Roles.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser user, IdentityRole role)
        {
            var User = _repository.Users.Where(x => x.UserName == user.UserName).FirstOrDefault();
            var roles = await _userManager.GetRolesAsync(User);
            var check = await _userManager.RemoveFromRolesAsync(User, roles.ToArray());
            var result = await _userManager.AddToRoleAsync(User, role.Name);
            if (result.Succeeded && check.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult Employee()
        {
            return View(new EmployeeViewModel
            {
                IdentityRoles = _repository.Roles.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel employee, IdentityRole role)
        {
            employee.ApplicationUser.UserName = employee.ApplicationUser.Email;
            var result = await _userManager.CreateAsync(employee.ApplicationUser, "123456Aa@");
            var setRole = await _userManager.AddToRoleAsync(employee.ApplicationUser, role.Name);
            Employee _employee = new Employee();
            _employee.ApplicationUserId = employee.ApplicationUser.Id;
            _employee.FirstName = employee.FirstName;
            _employee.LastName = employee.LastName;
            _repository.Employees.Add(_employee);
            _repository.SaveChanges();;
            return RedirectToAction("Index");
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

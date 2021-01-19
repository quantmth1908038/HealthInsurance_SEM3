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
namespace HealthInsurance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IFHealthInsuranceRepository _repository;

        UserManager<IdentityUser> UserManager;
        RoleManager<IdentityRole> RoleManager;

        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IFHealthInsuranceRepository repository)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            _repository = repository;
        }

        public IActionResult Index() 
            => View(new UserListViewModel 
        { 
            TotalUser = UserManager.Users.Count(),
            TotalPolicyRequest = _repository.PolicyRequests.Count(),
            TotalPolicyAction = _repository.PolicyActions.Count(),

            listUser = UserManager.Users.ToList(),
            listRole = RoleManager.Roles.ToList(),
        });
       

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

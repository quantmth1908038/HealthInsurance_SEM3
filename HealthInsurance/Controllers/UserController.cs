using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthInsurance.Data;
using HealthInsurance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HealthInsurance.Areas.Identity.Data;
using HealthInsurance.Models.ViewModels;

namespace HealthInsurance.Controllers
{
    public class UserController : Controller
    {
        private HealthInsuranceDbContext context;
        private UserManager<ApplicationUser> _userManager;

        public UserController(HealthInsuranceDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            context = ctx;
            _userManager = userManager;
        }
        public IActionResult Hospital()
        {
            return View(context.Hospitals);
        }

        public IActionResult Company()
        {
            return View(context.Companies);
        }
        public IActionResult Policies()
        {
            return View(context.Policies);
        }

        public async Task<IActionResult> Index()
        {
            var customer = context.Customers.Include(x => x.policyRequests);
            var PolicyRequest = context.PolicyRequests.Include(x => x.Policy).Include(x => x.policyApproval);
            var User = await _userManager.GetUserAsync(HttpContext.User);
            UserView userView = new UserView();
            userView.User = User;

            if (User.Customer.policyRequests != null)
            {
                var StatusRequest = User.Customer.policyRequests.FirstOrDefault().Status;
                var StatusApproval = User.Customer.policyRequests.FirstOrDefault().policyApproval.Status;
                if (StatusRequest == "No")
                {
                    userView.Status = "Unsuccess Request";
                }
                if (StatusRequest == "Yes")
                {
                    if (StatusApproval == "No")
                    {
                        userView.Status = "Success Request - Check Payment";
                    }
                    if (StatusApproval == "Yes")
                    {
                        userView.Status = "Successfull";
                    }
                }
            }
            else
            {
                userView.Status = "Fail";
            }

            foreach (var policyRequest in User.Customer.policyRequests)
            {
                userView.Amount += policyRequest.Policy.Amount;
                userView.Emi += policyRequest.Policy.Emi;
            }

            return View(userView);
        }
    }
}

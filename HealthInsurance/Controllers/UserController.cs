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
        

        public async Task<IActionResult> Index()
        {
            var User = await _userManager.GetUserAsync(HttpContext.User);
            UserView userView = new UserView();
            userView.User = User;
            userView.Customer = context.Customers.Where(x => x.ApplicationUserId == User.Id).Include(x => x.policyRequests).FirstOrDefault();
            var PolicyRequest = context.PolicyRequests.Where(x => x.CustomerId == userView.Customer.CustomerId).Include(x => x.Policy).Include(x => x.policyApproval);
            

            if (userView.Customer.policyRequests != null)
            {
                var StatusRequest = userView.Customer.policyRequests.FirstOrDefault().Status;
                
                if (StatusRequest == "No")
                {
                    userView.Status = "Unsuccess Request";
                }
                if (StatusRequest == "Yes")
                {
                    var StatusApproval = userView.Customer.policyRequests.FirstOrDefault().policyApproval.Status;
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

            foreach (var policyRequest in PolicyRequest)
            {
                userView.Amount += policyRequest.Policy.Amount;
                userView.Emi += policyRequest.Policy.Emi;
            }

            return View(userView);
        }
    }
}

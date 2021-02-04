using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Areas.Identity.Data;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.Controllers
{
    public class StaffController : Controller
    {
        private readonly HealthInsuranceDbContext _Db;
        private UserManager<ApplicationUser> _userManager;

        public StaffController(HealthInsuranceDbContext Db, UserManager<ApplicationUser> userManager)
        {
            _Db = Db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var RequestList = _Db.Customers;
            return View(RequestList);
        }

        public IActionResult PolicyList()
        {
            var PolicyLists = _Db.Policies.ToList();
            return View(PolicyLists);
        }

        public IActionResult Create(List<int> ListId)
        {
            return View(ListId);
        }



        [HttpPost]
        public async Task<IActionResult> AddRequest(Customer customer, List<int> ListPolicyIds)
        {
            if (ModelState.IsValid)
            {
                _Db.Customers.Add(customer);
                var User = await _userManager.GetUserAsync(HttpContext.User);
                var Employee = _Db.Employees.Where(x => x.ApplicationUserId == User.Id).FirstOrDefault();
                foreach (var id in ListPolicyIds)
                {
                    PolicyRequest policyRequest = new PolicyRequest();
                    policyRequest.CustomerId = customer.CustomerId;
                    policyRequest.EmployeeId = Employee.EmployeeId;
                    policyRequest.PolicyId = id;
                    policyRequest.RequestDate = DateTime.Today;
                    policyRequest.Status = "No";
                    _Db.PolicyRequests.Add(policyRequest);
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std = await _Db.PolicyRequests.FindAsync(id);
                if (std != null)
                {
                    _Db.PolicyRequests.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
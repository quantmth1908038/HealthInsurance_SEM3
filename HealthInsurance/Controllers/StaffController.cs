using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Areas.Identity.Data;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            var PolicyRequests = _Db.PolicyRequests.Include(m => m.Policy).Include(m => m.policyApproval).ToList();
            var CustomerList = _Db.Customers.Include(m => m.policyRequests).ToList();
            List<CustomerListViewModel> CustomerListViewModel = new List<CustomerListViewModel>();
            foreach( var customer in CustomerList)
            {
                var _customerListViewModel = new CustomerListViewModel();
                _customerListViewModel.Customer = customer;
                var Request = PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
                var StatusRequest = Request.Status;
                var StatusApproval = Request.policyApproval.Status;
                if (StatusRequest == "No")
                {
                    _customerListViewModel.Status = "Unsuccess Request";
                }
                if (StatusRequest == "Yes")
                {
                    if (StatusApproval == "No")
                    {
                        _customerListViewModel.Status = "Success Request - Check Payment";
                    }
                    if (StatusApproval == "Yes")
                    {
                        _customerListViewModel.Status = "Successfull";
                    }
                }
                CustomerListViewModel.Add(_customerListViewModel);
            }
            return View(CustomerListViewModel);
        }

        public IActionResult PolicyList()
        {
            var PolicyLists = _Db.Policies.Include(m => m.hospital).Include(m => m.company).ToList();
            return View(PolicyLists);
        }

        public IActionResult Create(List<int> PolicyId)
        {
            return View(new CreateViewModel 
            {
                ListPolicyIds = PolicyId
            });
        }



        [HttpPost]
        public async Task<IActionResult> AddRequest(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                _Db.Customers.Add(createViewModel.Customer);
                _Db.SaveChanges();
             
                var User = await _userManager.GetUserAsync(HttpContext.User);
                var Employee = _Db.Employees.Where(x => x.ApplicationUserId == User.Id).FirstOrDefault();
                PolicyApproval policyApproval = new PolicyApproval();
                _Db.PolicyApprovals.Add(policyApproval);
                _Db.SaveChanges();

                foreach (var id in createViewModel.ListPolicyIds)
                {
                    PolicyRequest policyRequest = new PolicyRequest();
                    policyRequest.CustomerId = createViewModel.Customer.CustomerId;
                    policyRequest.EmployeeId = Employee.EmployeeId;
                    policyRequest.PolicyId = id;
                    policyRequest.PolicyApprovalId = policyApproval.PolicyApprovalId;
                    policyRequest.RequestDate = DateTime.Today;
                    policyRequest.Status = "No";
                    _Db.PolicyRequests.Add(policyRequest);
                    _Db.SaveChanges();
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
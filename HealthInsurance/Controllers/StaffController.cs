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
    [Authorize]
    [Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        private readonly HealthInsuranceDbContext _Db;
        private UserManager<ApplicationUser> _userManager;

        public StaffController(HealthInsuranceDbContext Db, UserManager<ApplicationUser> userManager)
        {
            _Db = Db;
            _userManager = userManager;
        }

        public IActionResult Index(string searchString)
        {
            List<CustomerListViewModel> CustomerListViewModel = new List<CustomerListViewModel>();
            var PR = _Db.PolicyRequests.Include(m => m.Policy).Include(m => m.policyApproval).ToList();
            var data1 = from table1 in _Db.Customers.Include(m => m.policyRequests)
                        join table2 in _Db.PolicyRequests on table1.CustomerId equals table2.CustomerId into dt2
                        from table2 in dt2.DefaultIfEmpty()
                        select new CustomerListViewModel
                        {
                            Customer = table1                     
                        };

            if (!string.IsNullOrEmpty(searchString))
            {        
                CustomerListViewModel cuslistview = new CustomerListViewModel();
                data1 = data1.Where(data1 => data1.Customer.LastName.Contains(searchString) || data1.Customer.FirstName.Contains(searchString) || data1.Customer.policyRequests.FirstOrDefault().Status.Contains(searchString));
                var viewlistcus = data1.Cast<CustomerListViewModel>();
                foreach( var cus in data1)
                {
                    var Req = cus.Customer.policyRequests.FirstOrDefault();
                    if (Request != null)
                    {
                        var StatusRequest = Req.Status;
                        var StatusApproval = Req.policyApproval.Status;
                        if (StatusRequest == "No")
                        {
                            cus.Status = "Unsuccess Request";
                        }
                        if (StatusRequest == "Yes")
                        {
                            if (StatusApproval == "No")
                            {
                                cus.Status = "Success Request - Check Payment";
                            }
                            if (StatusApproval == "Yes")
                            {
                                cus.Status = "Successfull";
                            }
                        }
                    }
                    else
                    {
                        cus.Status = "Fail";
                    }
                    CustomerListViewModel.Add(cus);
                }

                return View(CustomerListViewModel);
            }
            else
            {
                var PolicyRequests = _Db.PolicyRequests.Include(m => m.Policy).Include(m => m.policyApproval).ToList();
                var CustomerList = _Db.Customers.Include(m => m.policyRequests).ToList();
                List<CustomerListViewModel> customerListViewModels = new List<CustomerListViewModel>();
                foreach (var customer in CustomerList)
                {
                    var _customerListViewModel = new CustomerListViewModel();
                    _customerListViewModel.Customer = customer;
                    var Request = PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
                    if (Request != null)
                    {
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
                    }
                    else
                    {
                        _customerListViewModel.Status = "Fail";
                    }
                    CustomerListViewModel.Add(_customerListViewModel);
                }
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

        public ActionResult Edit(int Id)
        {
            var customer = _Db.Customers.Where(s => s.CustomerId == Id).FirstOrDefault();

            return View(customer);
        }


        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _Db.Update(customer);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Customer customer)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var data = _Db.Customers.Find(customer.CustomerId);
        //        data.FirstName = customer.FirstName;
        //        data.LastName = customer.LastName;
        //        data.Gender = customer.Gender;
        //        data.Address = customer.Address;
        //        data.Contact = customer.Contact;
        //        data.State = customer.State;
        //        data.Country = customer.Country;
        //        data.City = customer.City;

        //        _Db.Entry(data).State = EntityState.Modified;
        //        _Db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    var dataEdit = _Db.Customers.Where(s => s.CustomerId == customer.CustomerId).FirstOrDefault();
        //    return View(dataEdit);
        //}


        [HttpPost]
        public async Task<IActionResult> AddRequest(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.User.UserName = createViewModel.User.Email;
                var result = await _userManager.CreateAsync(createViewModel.User, "123456");
                var setRole = await _userManager.AddToRoleAsync(createViewModel.User, "User");
                createViewModel.Customer.ApplicationUserId = createViewModel.User.Id;
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

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            var customer = _Db.Customers.Find(id);
            _Db.Customers.Remove(customer);
            _Db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
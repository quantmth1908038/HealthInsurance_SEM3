using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.Controllers
{
    [Authorize]
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly HealthInsuranceDbContext _context;

        public ManagerController(HealthInsuranceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string SearchString)
        {
            List<RequestListViewModel> RequestListViewModels = new List<RequestListViewModel>();
            var PR = _context.Customers.Include(m => m.policyRequests).Include(m => m.policyRequests).ToList();
            var data1 = from table1 in _context.Customers
                        join table2 in _context.PolicyRequests on table1.CustomerId equals table2.CustomerId into dt2
                        from table2 in dt2.DefaultIfEmpty()
                        join table3 in _context.Policies on table2.PolicyId equals table3.PolicyId into dt3
                        from table3 in dt3.DefaultIfEmpty()
                        select new RequestListViewModel
                        {
                            Customer = table1 
                            
                        };

            if (!string.IsNullOrEmpty(SearchString))
            {
                RequestListViewModel listCusRequest = new RequestListViewModel();
                data1 = data1.Where(data1 => data1.PolicyRequests.FirstOrDefault().Customer.LastName.Contains(SearchString));
                //var cusrequestlist = data1.Cast<RequestListViewModel>();
                return View(data1.ToList());

                //var _customers = _context.Customers.ToList();
                //foreach (var customer in _customers)
                //{
                //    var Policy = customer.policyRequests.FirstOrDefault().Policy.PolicyName.FirstOrDefault();
                //    RequestListViewModel RequestListViewModel = new RequestListViewModel();
                //    RequestListViewModel.Customer = customer;
                //    RequestListViewModel.PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy);
                //    foreach (var policyRequest in RequestListViewModel.PolicyRequests)
                //    {
                //        RequestListViewModel.Amount += policyRequest.Policy.Amount;
                //        RequestListViewModel.Emi += policyRequest.Policy.Emi;
                //    }
                //    RequestListViewModel.Status = RequestListViewModel.PolicyRequests.Select(x => x.Status).FirstOrDefault();
                //    RequestListViewModels.Add(RequestListViewModel);
                //}
                //return View(cusrequestlist.ToList());
            }
            else
            {
                var _customers = _context.Customers.ToList();
                foreach (var customer in _customers)
                {
                    RequestListViewModel RequestListViewModel = new RequestListViewModel();
                    RequestListViewModel.Customer = customer;
                    RequestListViewModel.PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy);
                    foreach (var policyRequest in RequestListViewModel.PolicyRequests)
                    {
                        RequestListViewModel.Amount += policyRequest.Policy.Amount;
                        RequestListViewModel.Emi += policyRequest.Policy.Emi;
                    }
                    RequestListViewModel.Status = RequestListViewModel.PolicyRequests.Select(x => x.Status).FirstOrDefault();
                    RequestListViewModels.Add(RequestListViewModel);
                }
                return View(RequestListViewModels);
            }
            
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            var _PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy);
            decimal Amount = new decimal();
            decimal Emi = new decimal();
            foreach (var policyRequest in _PolicyRequests)
            {
                Amount += policyRequest.Policy.Amount;
                Emi += policyRequest.Policy.Emi;
            }

            return View(new RequestListViewModel
            {
                Customer = customer,
                PolicyRequests = _PolicyRequests,
                Amount = Amount,
                Emi = Emi,
            });
        }

        public IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            var _PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy).Include(m => m.policyApproval);
            var policyApproval = _PolicyRequests.Select(x => x.policyApproval).FirstOrDefault();
            decimal Amount = new decimal();

            foreach (var policyRequest in _PolicyRequests)
            {
                policyRequest.Status = "Yes";
                _context.PolicyRequests.Update(policyRequest);
                Amount += policyRequest.Policy.Amount;
            }
            policyApproval.Date = DateTime.Today;
            policyApproval.Status = "No";
            policyApproval.Amount = Amount;
            _context.PolicyApprovals.Update(policyApproval);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
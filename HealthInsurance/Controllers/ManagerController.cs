using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsurance.Controllers
{
    public class ManagerController : Controller
    {
        private readonly HealthInsuranceDbContext _context;

        public ManagerController(HealthInsuranceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _customers = _context.Customers.ToList();
            List<RequestListViewModel> RequestListViewModels = new List<RequestListViewModel>();
            foreach (var customer in _customers)
            {
                RequestListViewModel RequestListViewModel = new RequestListViewModel();
                RequestListViewModel.Customer = customer;
                RequestListViewModel.PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId);
                foreach (var policyRequest in RequestListViewModel.PolicyRequests)
                {
                    RequestListViewModel.Amount += policyRequest.Policy.Amount;
                    RequestListViewModel.Emi += policyRequest.Policy.Emi;
                }
                RequestListViewModels.Add(RequestListViewModel);
            }
            return View(RequestListViewModels);
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
            var _PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId);
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
                Emi = Emi
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
            var _PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId);
            foreach (var policyRequest in _PolicyRequests)
            {
                policyRequest.Status = "Yes";
                _context.PolicyRequests.Update(policyRequest);
                _context.SaveChanges();

                PolicyApproval policyApproval = new PolicyApproval();
                policyApproval.PolicyRequestId = policyRequest.PolicyRequestId;
                policyApproval.Amount = policyRequest.Policy.Amount;
                policyApproval.Date = DateTime.Today;
                policyApproval.Status = "No";
                _context.PolicyApprovals.Add(policyApproval);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                RequestListViewModel.PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy);
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
                Status = _PolicyRequests.Select(x => x.Status).FirstOrDefault()
            }) ;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthInsurance.Data;
using Microsoft.EntityFrameworkCore;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HealthInsurance.Controllers
{
    [Authorize]
    [Authorize(Roles = "Finance Manager")]
    public class FinancialmanagrmentController : Controller
    {
        private readonly HealthInsuranceDbContext _context;
        public FinancialmanagrmentController(HealthInsuranceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _PolicyRequest = _context.PolicyRequests.ToList();
            var _PolicyApproval = _context.PolicyApprovals.ToList();
            var _PolicyAction = _context.PolicyActions.ToList();
            var _customers = _context.Customers.ToList();
            List<ApprovalListViewModel> approvalListViewModels = new List<ApprovalListViewModel>();
            foreach(var customer in _customers)
            {
                ApprovalListViewModel approvalListViewModel = new ApprovalListViewModel();
                approvalListViewModel.Customer = customer;
                if (customer.policyRequests != null)
                {
                    var policyApprovalId = customer.policyRequests.FirstOrDefault().PolicyApprovalId;
                    approvalListViewModel.policyApproval = _context.PolicyApprovals.Where(x => x.PolicyApprovalId == customer.policyRequests.FirstOrDefault().PolicyApprovalId).FirstOrDefault();
                }
                approvalListViewModels.Add(approvalListViewModel);
            }
            
            return View(approvalListViewModels);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _policy = _context.Policies.Include(m => m.company).Include(m => m.hospital).ToList();
            var customer = _context.Customers.Find(id);
            var _PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy).Include(m => m.policyApproval);
            if (customer == null)
            {
                return NotFound();
            }
            var _PolicyApproval = _PolicyRequests.FirstOrDefault().policyApproval;

            return View(new ApprovalListViewModel
            {
                Customer = customer,
                policyApproval = _PolicyApproval
            });
        }

        public IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Find(id);
            var _PolicyRequests = _context.PolicyRequests.Where(x => x.CustomerId == customer.CustomerId).Include(m => m.Policy).Include(m => m.policyApproval);
            if (customer == null)
            {
                return NotFound();
            }
            var _PolicyApproval = _PolicyRequests.FirstOrDefault().policyApproval;
            PolicyAction policyAction = new PolicyAction();
            _PolicyApproval.Status = "Yes";
            policyAction.PolicyAmount = _PolicyApproval.Amount;
            policyAction.PolicyApprovalId = _PolicyApproval.PolicyApprovalId;
            policyAction.PolicyName = customer.FirstName + customer.LastName + _PolicyApproval.PolicyApprovalId;
            _context.PolicyApprovals.Update(_PolicyApproval);
            _context.PolicyActions.Add(policyAction);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

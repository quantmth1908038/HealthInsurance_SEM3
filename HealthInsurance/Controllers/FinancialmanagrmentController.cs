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


namespace HealthInsurance.Controllers
{
    public class FinancialmanagrmentController : Controller
    {
        private readonly HealthInsuranceDbContext _context;
        public FinancialmanagrmentController(HealthInsuranceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _customers = _context.Customers.ToList();
            List<ApprovalListViewModel> approvalListViewModels = new List<ApprovalListViewModel>();
            foreach(var customer in _customers)
            {
                ApprovalListViewModel approvalListViewModel = new ApprovalListViewModel();
                approvalListViewModel.Customer = customer;
                var policyApprovalId = customer.policyRequests.FirstOrDefault().PolicyApprovalId;
                approvalListViewModel.policyApproval = _context.PolicyApprovals.Where(x => x.PolicyApprovalId == customer.policyRequests.FirstOrDefault().PolicyApprovalId).FirstOrDefault();
                approvalListViewModels.Add(approvalListViewModel);
            }
            
            return View(approvalListViewModels);
        }
    }
}

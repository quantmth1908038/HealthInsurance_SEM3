using HealthInsurance.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models.ViewModels
{
    public class RequestListViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<PolicyRequest> PolicyRequests { get; set; }
        public decimal Amount { get; set; }
        public decimal Emi { get; set; }
        public string Status { get; set; }
    }

    public class CreateViewModel
    {
        public List<int> ListPolicyIds { get; set; }
        public Customer Customer { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class CustomerListViewModel
    {
        public Customer Customer { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDesc { get; set; }
        public decimal Amount { get; set; }
        public decimal Emi { get; set; }

        public int CompanyId { get; set; }
        public string HospitalId { get; set; }

        public Company company { get; set; }
        public Hospital hospital { get; set; }

        public ICollection<PolicyEmployee> policyEmployees { get; set; }
        public ICollection<PolicyRequest> policyRequests { get; set; }
    }
}

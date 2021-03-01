using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string PolicyName { get; set; }
        [Column(TypeName = "Ntext")]
        public string PolicyDesc { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Emi { get; set; }

        [Column (TypeName = "text")]
        public string UrlDetail { get; set; }

        public int CompanyId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string HospitalId { get; set; }

        public Company company { get; set; }
        public Hospital hospital { get; set; }

        public ICollection<PolicyEmployee> policyEmployees { get; set; }
        public ICollection<PolicyRequest> policyRequests { get; set; }
    }
}

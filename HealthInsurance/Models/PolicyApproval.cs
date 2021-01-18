using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyApproval
    {
        public int PolicyId { get; set; }
        public int RequestId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public char Status {get; set;}
        public string Reason { get; set; }

        public PolicyRequest policyRequest { get; set; }
    }
}

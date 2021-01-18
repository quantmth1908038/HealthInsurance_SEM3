using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyRequest
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        //public string PolicyName { get; set; }
        //public decimal PolicyAmount { get; set; }
        //public decimal Emi { get; set; }
        public string Status { get; set; }

        public int Empno { get; set; }
        public int PolicyId { get; set; }

        public Employee employee { get; set; }
        public Policy policy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyEmployee
    {
        public string Empno { get; set; }
        //public string PolicyName { get; set; }
        //public decimal PolicyAmount { get; set; }
        public decimal PolicyDuration { get; set; }
        //public decimal Emi { get; set; }
        public DateTime PstartDate { get; set; }
        public DateTime pendDate { get; set; }

        public int PolicyId { get; set; }
        public int EmployeeId { get; set; }
        //public string ComanyId { get; set; }
        //public string MedicalId { get; set; }

        public Employee employee { get; set; }
        public Policy policy { get; set; }
    }
}

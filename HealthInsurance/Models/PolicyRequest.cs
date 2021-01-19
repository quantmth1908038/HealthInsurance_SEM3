using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyRequest
    {
        public int PolicyRequestId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }
        //public string PolicyName { get; set; }
        //public decimal PolicyAmount { get; set; }
        //public decimal Emi { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string Status { get; set; }

        public int EmployeeId { get; set; }
        public int PolicyId { get; set; }

        public Employee employee { get; set; }
        public Policy policy { get; set; }
        public PolicyApproval policyApproval { get; set; }
    }
}

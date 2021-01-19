using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyAction
    {
        public int PolicyActionId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string PolicyName { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Policydes { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal PolicyAmount { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Emi { get; set; }
        public int PolicyDurationInMonths { get; set; }

        public int PolicyApprovalId { get; set; }

        public PolicyApproval policyApproval { get; set; }
    }
}

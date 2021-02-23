using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyApproval
    {
        public int PolicyApprovalId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string Status {get; set;}
        [Column(TypeName = "varchar(50)")]
        public string Reason { get; set; }

        public ICollection<PolicyRequest> policyRequest { get; set; }
        public PolicyAction policyAction { get; set; }
    }
}

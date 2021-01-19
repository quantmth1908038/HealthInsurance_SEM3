using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class PolicyEmployee
    {
        public string PolicyEmployeeId { get; set; }
        //public string PolicyName { get; set; }
        //public decimal PolicyAmount { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal PolicyDuration { get; set; }
        //public decimal Emi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PstartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime pendDate { get; set; }

        public int PolicyId { get; set; }
        public int EmployeeId { get; set; }
        //public string ComanyId { get; set; }
        //public string MedicalId { get; set; }

        public Employee employee { get; set; }
        public Policy policy { get; set; }
    }
}

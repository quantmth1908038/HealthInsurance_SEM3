using HealthInsurance.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string ApplicationUserId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Designation { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Joindate { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Salary { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Contact { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string PolicyStatus { get; set; }

        public ApplicationUser applicationUser { get; set; }

        public ICollection<PolicyEmployee> policyEmployees { get; set; }
        public ICollection<PolicyRequest> policyRequests { get; set; }
    }
}

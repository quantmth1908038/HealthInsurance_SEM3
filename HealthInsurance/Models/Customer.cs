using HealthInsurance.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string ApplicationUserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Contact { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string State { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        public ApplicationUser applicationUser { get; set; }
        public ICollection<PolicyRequest> policyRequests { get; set; }
    }
}

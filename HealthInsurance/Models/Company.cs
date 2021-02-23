using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CompanyURL { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }
        [Column(TypeName = "ntext")]
        public string description2 { get; set; }

        public ICollection<Policy> policies { get; set; }
    }
}

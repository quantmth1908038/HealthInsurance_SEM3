using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Hospital
    {
        [Column(TypeName = "varchar(50)")]
        public string HospitalId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string HospitalName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Location { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Url { get; set; }

        [Column(TypeName = "ntext")]
        public string description1 { get; set; }
        [Column(TypeName = "ntext")]
        public string description2 { get; set; }
        [Column(TypeName = "ntext")]
        public string description3 { get; set; }


        public ICollection<Policy> policies { get; set; }
    }
}

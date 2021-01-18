using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Hospital
    {
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }

        public ICollection<Policy> policies { get; set; }
    }
}

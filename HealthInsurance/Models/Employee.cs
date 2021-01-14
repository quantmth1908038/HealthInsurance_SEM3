using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string Designation { get; set; }
        public DateTime Joindate { get; set; }
        public decimal Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

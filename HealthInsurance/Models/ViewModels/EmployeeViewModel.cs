using HealthInsurance.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<IdentityRole> IdentityRoles { get; set; }
    }
}

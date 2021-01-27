using HealthInsurance.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models.ViewModels
{
    public class SetUserRole
    {
        public ApplicationUser User { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}

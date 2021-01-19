using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models.ViewModels
{
    public class UserListViewModel
    {
        public int TotalUser { get; set; }
        public int TotalPolicyRequest { get; set; }
        public int TotalPolicyAction { get; set; }
        public List<IdentityUser> listUser { get; set; }
        public List<IdentityRole> listRole { get; set; }
    }
}

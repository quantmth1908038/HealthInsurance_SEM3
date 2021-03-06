﻿using HealthInsurance.Areas.Identity.Data;
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
        public List<ListUserRole> ListUserRoles { get; set; }
    }

    public class ListUserRole
    {
        public ApplicationUser User { get; set; }
        public IdentityRole Role { get; set; }
    }

    public class UserView
    {
        public ApplicationUser User { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Emi { get; set; }
    }
}

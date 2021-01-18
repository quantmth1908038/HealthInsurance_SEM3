using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthInsurance.Models;

namespace HealthInsurance.Data
{
    public class HealthInsuranceDbContext : IdentityDbContext<ApplicationUser>
    {
        public HealthInsuranceDbContext(DbContextOptions<HealthInsuranceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyAction> PolicyActions { get; set; }
        public DbSet<PolicyApproval> PolicyApprovals { get; set; }
        public DbSet<PolicyEmployee> PolicyEmployees { get; set; }
        public DbSet<PolicyRequest> PolicyRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

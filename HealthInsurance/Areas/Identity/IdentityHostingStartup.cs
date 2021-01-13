using System;
using HealthInsurance.Areas.Identity.Data;
using HealthInsurance.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HealthInsurance.Areas.Identity.IdentityHostingStartup))]
namespace HealthInsurance.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HealthInsuranceDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HealthInsuranceDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HealthInsuranceDbContext>();
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Areas.Identity.Data;

namespace HealthInsurance.Areas.Identity.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            HealthInsuranceDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<HealthInsuranceDbContext>();
            if(context.Database.GetAppliedMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company
                    {
                        CompanyName = "Bao Viet Insurance",
                        Address = "Ha Noi, Viet Nam",
                        Phone = "0396969696",
                        CompanyURL = "",
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        Designation = "",
                        Joindate = DateTime.Parse("2020-12-02"),
                        Salary = 1200,
                        FirstName = "Cristiano",
                        LastName = "Ronaldo",
                        Address = "Turin, Italya",
                        Contact = "056565656",
                        State = "18 Turin CIty",
                        Country = "Italya",
                        City = "Turin"
                    },
                    new Employee
                    {
                        Designation = "",
                        Joindate = DateTime.Parse("2020-10-02"),
                        Salary = 1100,
                        FirstName = "Lionel",
                        LastName = "Messi",
                        Address = "",
                        Contact = "066565656",
                        State = "",
                        Country = "Barcelona",
                        City = "Spain"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Hospitals.Any())
            {
                context.Hospitals.AddRange(
                    new Hospital
                    {
                        HospitalId = "vietduc",
                        HospitalName = "Viet Duc Hospital",
                        Phone = "11111",
                        Location = "Ha Noi, Viet Nam",
                        Url = "https://raw.githubusercontent.com/nddat1908/T1908A_Sem3/master/ImageSubjectHeath/Seed_Data1.jpg",
                    },
                    new Hospital
                    {
                        HospitalId = "bachmai",
                        HospitalName = "Bach Mai Hospital",
                        Phone = "222222",
                        Location = "Ha Noi, Viet Nam",
                        Url = "https://raw.githubusercontent.com/nddat1908/T1908A_Sem3/master/ImageSubjectHeath/Seed_Data2.jpg"
                    },
                    new Hospital
                    {
                        HospitalId = "k",
                        HospitalName = "K Hospital",
                        Phone = "22222212",
                        Location = "Ha Noi, Viet Nam",
                        Url = "https://raw.githubusercontent.com/nddat1908/T1908A_Sem3/master/ImageSubjectHeath/Seed_Data3.jpg"
                    }
                    );
                context.SaveChanges();
            }    

            if (!context.Policies.Any())
            {
                context.Policies.AddRange(
                    new Policy
                    {
                        PolicyName = "Bao Viet An Gia",
                        PolicyDesc = "Insurance packages for individuals and families.All citizens and foreigners residing in Vietnam from 15 days of age to 60 years old, renew until 65 years old",
                        Amount = 12000000,
                        Emi = 1200,
                        CompanyId = 1,
                        HospitalId = "vietduc"
                    },

                    new Policy
                    {
                        PolicyName = "AonCare Insurance",
                        PolicyDesc = "Insurance package for companies, agencies. Insured is any Vietnamese citizen or foreigner residing in Vietnam from 12 months to 65 years old.",
                        Amount = 13000000,
                        Emi = 1300,
                        CompanyId = 1,
                        HospitalId = "bachmai"
                    },

                     new Policy
                     {
                         PolicyName = "Child Insurance",
                         PolicyDesc = "Diversified insurance benefits, suitable for many levels of budgets and needs",
                         Amount = 10000000,
                         Emi = 1000,
                         CompanyId = 1,
                         HospitalId = "vietduc"
                     },

                      new Policy
                      {
                          PolicyName = "Bao Viet Kcare",
                          PolicyDesc = "Insurance benefits are paid in full package for customers. Insurance benefits are paid immediately after the first diagnosis when the customer needs it most ",
                          Amount = 15000000,
                          Emi = 1500,
                          CompanyId = 1,
                          HospitalId = "bachmai"
                      },

                       new Policy
                       {
                           PolicyName = "Super VIP Insurance Aetna",
                           PolicyDesc = "Including 5 packages of programs for individual customers, organizations with medical examination and treatment needs in the world with over 1 million affiliated hospitals. Đa dạng lựa chọn phạm vi bảo hiểm, quyền lợi bảo hiểm tùy theo nhu cầu cụ thể",
                           Amount = 30000000,
                           Emi = 3000,
                           CompanyId = 1,
                           HospitalId = "k"
                       }
                    );
                context.SaveChanges();
            }              
        }
    }
}

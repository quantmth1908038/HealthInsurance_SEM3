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
                //context.Database.Migrate();
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
                        description = "Bao Viet Group (international transaction name: Baoviet Holdings). Established on January 15, 1965, up to now, Bao Viet has become the leading Finance - Insurance Group in Vietnam and is in the List of Top 50 best listed companies in 2020 voted by Forbes Vietnam. Bao Viet is serving about 20 million customers, equivalent to nearly 20% of Vietnam's population. The Group is headquartered in Hanoi with more than 200 branches and affiliated companies across 63 provinces and cities nationwide.",
                        description2 = "Trong 55 năm hình thành và phát triển, Bảo Việt duy trì kết quả kinh doanh khả quan, lĩnh vực kinh doanh bảo hiểm nhân thọ và bảo hiểm phi nhân thọ giữ vị trí số 1 thị trường. Thông qua việc triển khai hiệu quả các giải pháp kinh doanh, Bảo Việt đã duy trì được sự tăng trưởng ổn định, góp phần đảm bảo thực hiện các nghĩa vụ với ngân sách nhà nước cũng như đảm bảo quyền lợi cho khách hàng, cổ đông, người lao động và cộng đồng."

                    }
                    );
                context.SaveChanges();
            }

            //if (!context.Employees.Any())
            //{
            //    context.Employees.AddRange(
            //        new Employee
            //        {
            //            Designation = "",
            //            Joindate = DateTime.Parse("2020-12-02"),
            //            Salary = 1200,
            //            FirstName = "Cristiano",
            //            LastName = "Ronaldo",
            //            Address = "Turin, Italya",
            //            Contact = "056565656",
            //            State = "18 Turin CIty",
            //            Country = "Italya",
            //            City = "Turin"
            //        },
            //        new Employee
            //        {
            //            Designation = "",
            //            Joindate = DateTime.Parse("2020-10-02"),
            //            Salary = 1100,
            //            FirstName = "Lionel",
            //            LastName = "Messi",
            //            Address = "",
            //            Contact = "066565656",
            //            State = "",
            //            Country = "Barcelona",
            //            City = "Spain"
            //        }
            //        );
            //    context.SaveChanges();
            //}

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
                        description1 = "Today Viet Duc Friendship Hospital was established in 1902 with the establishment of the Indochina Medical School, the forerunner of Hanoi Medical University. From 1904 the hospital moved to its present location with the name of the Protection Hospital (Hopital indigène du Protectorat). The hospital has different names through each historical period of the country: Yersin Hospital (1943), Phu Doan Hospital (1954), Vietnam Friendship Hospital - German Democratic Republic (1958-1990) and Viet Duc Friendship Hospital from 1991 to present.",
                        description2 = "During the process of formation and development, the hospital has always been a leading medical center linking medical examination and treatment with medical scientific research and training, the birthplace of leading Vietnamese physicians. In the South, there are many famous medical celebrities: Ho Dac Di, Ton That Tung, Nguyen Trinh Co, Nguyen Duong Quang….",
                        description3 = "Today, the hospital is a specialized medical center, ranked as a Specialized Hospital by Decision No. 1446 / QD-BNV dated September 21, 2015 of the Minister of Home Affairs. The hospital has a scale of 1500 beds with more than 2200 physicians, medical staff and staff, including: 5 professors, 32 associate professors, 40 doctors, 221 masters and postgraduate specialists."

                    },
                    new Hospital
                    {
                        HospitalId = "bachmai",
                        HospitalName = "Bach Mai Hospital",
                        Phone = "222222",
                        Location = "Ha Noi, Viet Nam",
                        Url = "https://raw.githubusercontent.com/nddat1908/T1908A_Sem3/master/ImageSubjectHeath/Seed_Data2.jpg",
                        description1 = "Bach Mai Hospital was the first hospital in the country to be specially identified. At present, Bach Mai Hospital has 1,400 patients, all department heads and center directors have postgraduate qualifications. The patient mortality was only 0.8-0.9% and the disease prevalence rate was 153% (compared with the headline 85%)",
                        description2 = "In October 2009, Health Minister Nguyen Quoc Trieu worked with Bach Mai Hospital on a plan to develop the hospital into a specialized medical center with all medical specialties. In particular, the hospital will focus on developing 7 areas: cardiology, resuscitation - emergency - anti-toxic, neurology, nuclear medicine and cancer, diagnostic imaging, biochemistry, microbiology. science - technology to screen water in the region and internationally.",
                        description3 = "In March and April 2020, Bach Mai Hospital is in the spotlight after becoming the place with the largest number of people infected with COVID-19 in the country. The hospital was quarantined and the patients were transferred to other provinces to reduce the workload for repairs until May to return to normal operations."
                    },
                    new Hospital
                    {
                        HospitalId = "k",
                        HospitalName = "K Hospital",
                        Phone = "22222212",
                        Location = "Ha Noi, Viet Nam",
                        Url = "https://raw.githubusercontent.com/nddat1908/T1908A_Sem3/master/ImageSubjectHeath/Seed_Data3.jpg",
                        description1 = "On July 17, 1969, with the consent of the Government, the Minister of Health issued a decision No. 711 / QD-BYT to establish Hospital K was established from the predecessor of Indochina Curie Institute (Insitut Curie de L 'Indochine) was born in Hanoi on 19/10/1923, in charge of Lawyer Mourlan. The hospital has 3 spacious, clean and modern facilities on par with other countries in the region. field. Currently, 3 medical examination and treatment facilities in Hanoi.",
                        description2 = "According to the targets assigned by the Ministry of Health in 2015, the hospital has 1,800 beds (According to Decision No. 119 / QD-BYT dated January 15, 2015 of the Minister of Health). The hospital currently has 77 hospitals, centers, faculties, departments and divisions with more than 1,700 officials and workers.",
                        description3 = "Total number of hospital quality criteria applied: 79/83 criteria (rate 95%). Total score of the applied criteria: 321 points (coefficient: 350), the average score of the criteria: 4.07 points (compared to 2017 is 3.56 points; in 2018 it is 4, 05 points) is the huge progress of the Hospital."
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
                        Amount = 1200,
                        Emi = 12,
                        CompanyId = 1,
                        HospitalId = "vietduc"
                    },

                    new Policy
                    {
                        PolicyName = "AonCare Insurance",
                        PolicyDesc = "Insurance package for companies, agencies. Insured is any Vietnamese citizen or foreigner residing in Vietnam from 12 months to 65 years old.",
                        Amount = 1300,
                        Emi = 13,
                        CompanyId = 1,
                        HospitalId = "bachmai"
                    },

                     new Policy
                     {
                         PolicyName = "Child Insurance",
                         PolicyDesc = "Diversified insurance benefits, suitable for many levels of budgets and needs",
                         Amount = 1000,
                         Emi = 10,
                         CompanyId = 1,
                         HospitalId = "vietduc"
                     },

                      new Policy
                      {
                          PolicyName = "Bao Viet Kcare",
                          PolicyDesc = "Insurance benefits are paid in full package for customers. Insurance benefits are paid immediately after the first diagnosis when the customer needs it most ",
                          Amount = 1500,
                          Emi = 1500,
                          CompanyId = 1,
                          HospitalId = "bachmai"
                      },

                       new Policy
                       {
                           PolicyName = "Super VIP Insurance Aetna",
                           PolicyDesc = "Including 5 packages of programs for individual customers, organizations with medical examination and treatment needs in the world with over 1 million affiliated hospitals.",
                           Amount = 3000,
                           Emi = 30,
                           CompanyId = 1,
                           HospitalId = "k"
                       }
                    );
                context.SaveChanges();
            }              
        }
    }
}

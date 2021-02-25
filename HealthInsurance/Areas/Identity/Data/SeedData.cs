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
                        Address = "Floor 37, Keangnam Ha Noi Landmark Tower, Pham Hung Street, Nam Tu Liem District, Hanoi",
                        Phone = "0396969696",
                        CompanyURL = "",
                        description = "Bao Viet Group (international transaction name: Baoviet Holdings). Established on January 15, 1965, up to now, Bao Viet has become the leading Finance - Insurance Group in Vietnam and is in the List of Top 50 best listed companies in 2020 voted by Forbes Vietnam. Bao Viet is serving about 20 million customers, equivalent to nearly 20% of Vietnam's population. The Group is headquartered in Hanoi with more than 200 branches and affiliated companies across 63 provinces and cities nationwide.",
                        description2 = "For 55 years of establishment and development, Bao Viet has maintained positive business results, the life insurance and non-life insurance business segments hold the No. 1 position in the market. Through the effective implementation of business solutions, Bao Viet has maintained a steady growth, contributing to ensuring the fulfillment of obligations to the state budget as well as ensuring the interests of customers. crowd, employees and community."
                    },
                    new Company
                    {
                        CompanyName = "Manulife Insurance",
                        Address = "Floor 2, Manulife Plaza Building, 75 Hoang Van Thai, Tan Phu Ward, District 7, City. Ho Chi Minh",
                        Phone = "1900 1776",
                        CompanyURL = "",
                        description = "As a member of Manulife Financial (Established in 1887 - a leading financial group in the world headquartered in Canada), the first foreign life insurer to present in Vietnam since 1999 and owns a private headquarters building with an investment value of more than 10 million USD. With extensive experience, great economic potential and global reputation, Manulife aims to become the most professional life insurance company in Vietnam.",
                        description2 = "In addition to traditional insurance distribution channels through insurance agents, Manulife also cooperates with banks to meet the diverse needs of the market and provide customers with the best services. Currently, Manulife is providing a diversified portfolio of life insurance products from traditional insurance to health insurance, education, investment association, retirement…. for more than 800,000 Vietnamese customers. View details of Manulife's life insurance products, compare fees and benefits to choose the best insurance package for yourself."
                    },
                    new Company
                    {
                        CompanyName = "Dai-ichi Life Insurance Vietnam Company Limited",
                        Address = "DAI-ICHI LIFE Building, 149-151 Nguyen Van Troi, Ward 11, Phu Nhuan District, City. Ho Chi Minh",
                        Phone = "028 3810 0888",
                        CompanyURL = "",
                        description = "Established on January 18, 2007, a member of The Dai-ichi Life Insurance Company, Limited (“Dai-ichi Life”) - Japan, one of the leading life insurance companies in Japan and In the world. According to data provided by Dai-ichi Vietnam, the company's total premium revenue in 2019 is over 13,000 billion VND, up 28 times since its establishment, up 14% compared to 2018 and accounting for 12% of the market. part of total fee revenue, continues to maintain its position as one of the four leading insurance companies in Vietnam. Profit after tax of the Company exceeded 1,000 billion VND, reaching nearly 1,300 billion VND. As of December 31, 2019, the total assets managed by Dai-ichi Life Vietnam reached more than VND 30,000 billion. Currently, Dai-ichi Life Vietnam is serving over 3 million customers nationwide. Dai-ichi Vietnam's life insurance products are diversified in terms of premiums suitable to each family's economic conditions.",
                        description2 = ""
                    },
                    new Company
                    {
                        CompanyName = "Sun Life Vietnam Insurance Company Limited",
                        Address = "Ha Noi, Viet Nam",
                        Phone = "0396969696",
                        CompanyURL = "",
                        description = "In January 2013, PVI Sun Life was established by PVI Joint Stock Company and Sun Life Assurance Company of Canada (Sun Life). As of December 31, 2015, Sun Life increased its holding rate to 75%, and on November 7, 2016, with the approval of the Ministry of Finance, Sun Life bought another 25% of the capital. the remaining contribution from PVI and become a life insurance company with 100% Canadian capital operating in Vietnam with a new brand name Sun Life Vietnam Limited Liability Company (Sun Life Vietnam).",
                        description2 = "Sun Life Vietnam's strategy focuses on Client for Life in which customers are the focus of business activities. The company's mission is to commit to helping Vietnamese customers achieve lifetime financial security with a wide range of savings and protection products. Up to now, Sun Life Vietnam has become one of the leading life insurers in the market and a pioneer in the retirement life insurance industry serving both individual and corporate customers"
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
                        PolicyName = "Bao Viet An Gia - Bronze",
                        PolicyDesc = "Insurance packages for individuals and families.All citizens and foreigners residing in Vietnam from 15 days of age to 60 years old, renew until 65 years old",
                        Amount = 4043,
                        Emi = 2500,
                        UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/04/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-B%E1%BA%A3o-Vi%E1%BB%87t-An-Gia-1.png",
                        CompanyId = 1,
                        HospitalId = "vietduc"
                    },

                    new Policy
                    {
                        PolicyName = "Bao Viet An Gia - Sliver",
                        PolicyDesc = "Insurance package for companies, agencies. Insured is any Vietnamese citizen or foreigner residing in Vietnam from 12 months to 65 years old.",
                        Amount = 6000,
                        Emi = 3000,
                        UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/04/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-B%E1%BA%A3o-Vi%E1%BB%87t-An-Gia-1.png",
                        CompanyId = 1,
                        HospitalId = "vietduc"
                    },

                     new Policy
                     {
                         PolicyName = "Bao Viet An Gia - Gold",
                         PolicyDesc = "Diversified insurance benefits, suitable for many levels of budgets and needs",
                         Amount = 10000,
                         Emi = 4500,
                         UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/04/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-B%E1%BA%A3o-Vi%E1%BB%87t-An-Gia-1.png",
                         CompanyId = 1,
                         HospitalId = "vietduc"
                     },

                      new Policy
                      {
                          PolicyName = "Bao Viet An Gia - Platinum",
                          PolicyDesc = "Insurance benefits are paid in full package for customers. Insurance benefits are paid immediately after the first diagnosis when the customer needs it most ",
                          Amount = 15000,
                          Emi = 6400,
                          UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/04/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-B%E1%BA%A3o-Vi%E1%BB%87t-An-Gia-1.png",
                          CompanyId = 1,
                          HospitalId = "vietduc"
                      },

                       new Policy
                       {
                           PolicyName = "Bao Viet An Gia - Diamond",
                           PolicyDesc = "Including 5 packages of programs for individual customers, organizations with medical examination and treatment needs in the world with over 1 million affiliated hospitals.",
                           Amount = 20000,
                           Emi = 7000,
                           UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/04/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-B%E1%BA%A3o-Vi%E1%BB%87t-An-Gia-1.png",
                           CompanyId = 1,
                           HospitalId = "vietduc"
                       },

                        
                       
                       new Policy
                        {
                            PolicyName = "Manulife infant insurance - Select",
                            PolicyDesc = "",
                            Amount = 50000,
                            Emi = 4000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 2,
                            HospitalId = "bachmai"
                       },
                        new Policy
                        {
                            PolicyName = "Manulife infant insurance - Essential",
                            PolicyDesc = "",
                            Amount = 100000,
                            Emi = 10000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 2,
                            HospitalId = "bachmai"
                        },
                        new Policy
                        {
                            PolicyName = "Manulife infant insurance - Classic",
                            PolicyDesc = "",
                            Amount = 200000,
                            Emi = 18000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 2,
                            HospitalId = "bachmai"
                        },
                        new Policy
                        {
                            PolicyName = "Manulife infant insurance - Gold",
                            PolicyDesc = "",
                            Amount = 250000,
                            Emi = 2100,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 2,
                            HospitalId = "bachmai"
                        },
                        new Policy
                        {
                            PolicyName = "Manulife infant insurance - Diamond",
                            PolicyDesc = "",
                            Amount = 500000,
                            Emi = 4000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 2,
                            HospitalId = "bachmai"
                        },



                        new Policy
                        {
                            PolicyName = "Dai-ichi cancer insurance - I",
                            PolicyDesc = "",
                            Amount = 13000,
                            Emi = 1000,                           
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/07/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-g%C3%B3i-b%E1%BA%A3o-hi%E1%BB%83m-ung-th%C6%B0-B%E1%BA%A3o-Vi%E1%BB%87t.png",
                            CompanyId = 3,
                            HospitalId = "k"
                        },
                        new Policy
                        {
                            PolicyName = "Dai-ichi cancer insurance - II",
                            PolicyDesc = "",
                            Amount = 25400,
                            Emi = 1850,  
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/07/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-g%C3%B3i-b%E1%BA%A3o-hi%E1%BB%83m-ung-th%C6%B0-B%E1%BA%A3o-Vi%E1%BB%87t.png",
                            CompanyId = 3,
                            HospitalId = "vietduc"
                        },
                        new Policy
                        {
                            PolicyName = "Dai-ichi cancer insurance - III",
                            PolicyDesc = "",
                            Amount = 50000,
                            Emi = 3500,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/07/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-g%C3%B3i-b%E1%BA%A3o-hi%E1%BB%83m-ung-th%C6%B0-B%E1%BA%A3o-Vi%E1%BB%87t.png",
                            CompanyId = 3,
                            HospitalId = "vietduc"
                        },



                        new Policy
                        {
                            PolicyName = "Sun Life INTERCARE VIP - Select",
                            PolicyDesc = "",
                            Amount = 44000,
                            Emi = 4400,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 4,
                            HospitalId = "vietduc"
                        },
                        new Policy
                        {
                            PolicyName = "Sun Life INTERCARE VIP - Essential",
                            PolicyDesc = "",
                            Amount = 80000,
                            Emi = 8000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 4,
                            HospitalId = "vietduc"
                        },
                        new Policy
                        {
                            PolicyName = "Sun Life INTERCARE VIP - Classic",
                            PolicyDesc = "",
                            Amount = 160000,
                            Emi = 15000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 4,
                            HospitalId = "vietduc"
                        },
                        new Policy
                        {
                            PolicyName = "Sun Life INTERCARE VIP - Gold",
                            PolicyDesc = "",
                            Amount = 200000,
                            Emi = 20000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 4,
                            HospitalId = "vietduc"
                        },
                        new Policy
                        {
                            PolicyName = "Sun Life INTERCARE VIP - Diamond",
                            PolicyDesc = "",
                            Amount = 400000,
                            Emi = 40000,
                            UrlDetail = "https://ibaohiem.vn/wp-content/uploads/2018/08/B%E1%BA%A3ng-quy%E1%BB%81n-l%E1%BB%A3i-n%E1%BB%99i-tr%C3%BA-g%C3%B3i-B%E1%BA%A3o-Vi%E1%BB%87t-Intercare.png",
                            CompanyId = 4,
                            HospitalId = "vietduc"
                        }

                    );
                context.SaveChanges();
            }              
        }
    }
}

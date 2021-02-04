using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Data;
using HealthInsurance.Models;

namespace HealthInsurance.Areas.Identity.Data
{
    public class EFHealthInsuranceRepository : IFHealthInsuranceRepository
    {
        private HealthInsuranceDbContext context;
        public EFHealthInsuranceRepository(HealthInsuranceDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Company> Companies => context.Companies;
        public IQueryable<Employee> Employees => context.Employees;
        public IQueryable<Customer> Customers => context.Customers;
        public IQueryable<Hospital> Hospitals => context.Hospitals;
        public IQueryable<Policy> Policies => context.Policies;
        public IQueryable<PolicyAction> PolicyActions => context.PolicyActions;
        public IQueryable<PolicyApproval> PolicyApprovals => context.PolicyApprovals;
        public IQueryable<PolicyEmployee> PolicyEmployees => context.PolicyEmployees;
        public IQueryable<PolicyRequest> PolicyRequests => context.PolicyRequests;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Models;

namespace HealthInsurance.Areas.Identity.Data
{
    public interface IFHealthInsuranceRepository
    {
        IQueryable<Company> Companies { get; }
        IQueryable<Employee> Employees { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<Hospital> Hospitals { get; }
        IQueryable<Policy> Policies { get; }
        IQueryable<PolicyAction> PolicyActions { get; }
        IQueryable<PolicyApproval> PolicyApprovals { get; }
        IQueryable<PolicyEmployee> PolicyEmployees { get; }
        IQueryable<PolicyRequest> PolicyRequests { get;  }
    }
}

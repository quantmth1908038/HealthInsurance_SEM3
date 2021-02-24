using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models.ViewModels
{
    public class ApprovalListViewModel
    {
        public Customer Customer { get; set; }
        public PolicyApproval policyApproval { get; set; }
    }
}

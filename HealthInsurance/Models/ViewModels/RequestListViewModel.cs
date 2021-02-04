using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Models.ViewModels
{
    public class RequestListViewModel
    {
        public List<Request> Requests { get; set; }
    }

    public class Request
    {
        public Employee Employee { get; set; }
        public IEnumerable<PolicyRequest> PolicyRequest { get; set; }
    }
}

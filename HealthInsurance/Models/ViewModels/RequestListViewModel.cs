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
        public Customer Customer { get; set; }
        public PolicyRequest PolicyRequest { get; set; }
    }
}

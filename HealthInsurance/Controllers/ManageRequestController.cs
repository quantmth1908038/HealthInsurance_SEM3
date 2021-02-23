using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthInsurance.Data;
using HealthInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.Controllers
   
{
    public class ManageRequestController : Controller
    {
        private HealthInsuranceDbContext context;

        public ManageRequestController(HealthInsuranceDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.PolicyRequests);

        }

       
    }
}

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
    public class UserController : Controller
    {
        private HealthInsuranceDbContext context;
        public UserController(HealthInsuranceDbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Hospital()
        {
            return View(context.Hospitals);
        }

        public IActionResult Company()
        {
            return View(context.Companies);
        }
        public IActionResult Policies()
        {
            return View(context.Policies);
        }
    }
}

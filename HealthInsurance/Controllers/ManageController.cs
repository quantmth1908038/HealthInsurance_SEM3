using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthInsurance.Models;
using HealthInsurance.Areas.Identity.Data;
using HealthInsurance.Data;

namespace HealthInsurance.Controllers
{
    public class ManageController : Controller
    {
        private HealthInsuranceDbContext _repository;

        public ManageController(HealthInsuranceDbContext repository)
        {
            _repository = repository;
           
        }

        // GET: ManageController
        public ActionResult Index() => View(_repository.Hospitals);
        

        // GET: ManageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

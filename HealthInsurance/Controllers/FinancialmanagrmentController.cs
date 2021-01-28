using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthInsurance.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.Controllers
{
    public class FinancialmanagrmentController : Controller
    {
        //private HealthInsuranceDbContext context;

        //public FinancialmanagrmentController(HealthInsuranceDbContext ctx)
        //{
        //    context = ctx;
        //}

        // GET: FinancialmanagrmentController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly HealthInsuranceDbContext _Db;

        public FinancialmanagrmentController(HealthInsuranceDbContext Db)
        {
            _Db = Db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _Db.PolicyApprovals.ToListAsync());
        }

        //public IActionResult Index()
        //{
        //    try
        //    {
        //        var financialmanagrmentList = _Db.PolicyApprovals.ToList();

        //        return View(financialmanagrmentList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return View();
        //    }

        //}

        // GET: FinancialmanagrmentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approval = await _Db.PolicyApprovals
                .FirstOrDefaultAsync(m => m.PolicyApprovalId == id);
            if (approval == null)
            {
                return NotFound();
            }

            return View(approval);
        }

        // GET: FinancialmanagrmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinancialmanagrmentController/Create
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

        // GET: FinancialmanagrmentController/Create
        public ActionResult CreateAction()
        {
            return View();
        }

        // POST: FinancialmanagrmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAction(IFormCollection collection)
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

        // GET: FinancialmanagrmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FinancialmanagrmentController/Edit/5
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

        // GET: FinancialmanagrmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FinancialmanagrmentController/Delete/5
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

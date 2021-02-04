using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthInsurance.Data;
using HealthInsurance.Models;
using HealthInsurance.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.Controllers
{
    public class StaffController : Controller
    {
        private readonly HealthInsuranceDbContext _Db;

        public StaffController(HealthInsuranceDbContext Db)
        {
            _Db = Db;
        }

        public IActionResult Index()
        {
            try
            {
                var RequestList = _Db.Customers;

                return View(RequestList);
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        public IActionResult PolicyList()
        {
            var PolicyLists = _Db.Policies.ToList();
            return View(PolicyLists);
        }

        public IActionResult Create(Customer customer)
        {
            return View(customer);
        }



        [HttpPost]
        public async Task<IActionResult> AddStaff(PolicyRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(obj.PolicyRequestId == 0)
                    {
                        _Db.PolicyRequests.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {   
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std = await _Db.PolicyRequests.FindAsync(id);
                if (std != null)
                {
                    _Db.PolicyRequests.Remove(std);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
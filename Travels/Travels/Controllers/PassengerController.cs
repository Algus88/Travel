using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travels.Mocks;
using Travels.Models;

namespace Travels.Controllers
{
    public class PassengerController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }
        // GET: Passenger
        [HttpPost]
        public ActionResult Search(string searchRequset)
        {
            DriverMock drivers = new DriverMock();
            foreach (var i in drivers.Driver)
            { Console.WriteLine(i.TravelPoint1); }
            List<Employee> result = drivers.Driver.Where(x => x.TravelPoint1.Contains(searchRequset) || x.TravelPoint2.Contains(searchRequset) || x.TravelPoint3.Contains(searchRequset) || x.TravelPoint2.Contains(searchRequset)).ToList();
           //List<Employee> result = drivers.Driver.Select(x=>x).ToList();
             if (result.Count()!=0)
            {
                ViewBag.Result = result;
                return View("SearchResult");
            }
            ViewBag.Message = "There are no drivers for your request";
            return View();
        }

        // GET: Passenger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Passenger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passenger/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Passenger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Passenger/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Passenger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Passenger/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

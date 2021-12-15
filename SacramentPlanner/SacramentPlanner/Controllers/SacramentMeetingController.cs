using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Controllers
{
    public class SacramentMeetingController : Controller
    {
        private MongoContext _dbContext;

        public SacramentMeetingController()
        {
            _dbContext = new MongoContext();
        }


        // GET: SacramentMeetingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SacramentMeetingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SacramentMeetingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SacramentMeetingController/Create
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

        // GET: SacramentMeetingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SacramentMeetingController/Edit/5
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

        // GET: SacramentMeetingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SacramentMeetingController/Delete/5
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

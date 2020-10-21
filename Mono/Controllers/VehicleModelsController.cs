using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mono.Context;
using Mono.Models;

namespace Mono.Controllers
{
    public class VehicleModelsController : Controller
    {
        private VehicleModelContext db = new VehicleModelContext();

        // GET: VehicleModels
        public ActionResult Index()
        {
            var models = db.Models.Include(v => v.VehicleMake);
            return View(models.ToList());
        }

        // GET: VehicleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.Models.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            ViewBag.makeId = new SelectList(db.Makes, "makeId", "makeName");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modelId,makeId,modelName,modelAbrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.Models.Add(vehicleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makeId = new SelectList(db.Makes, "makeId", "makeName", vehicleModel.makeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.Models.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.makeId = new SelectList(db.Makes, "makeId", "makeName", vehicleModel.makeId);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modelId,makeId,modelName,modelAbrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makeId = new SelectList(db.Makes, "makeId", "makeName", vehicleModel.makeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.Models.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleModel vehicleModel = db.Models.Find(id);
            db.Models.Remove(vehicleModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

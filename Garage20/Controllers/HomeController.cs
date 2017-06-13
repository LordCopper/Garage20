using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage20.DataAccess;
using Garage20.Models;

namespace Garage20.Controllers
{
    public class HomeController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Home
        public ActionResult Index()
        {
            //List<IndexViewModel> temp = db.ParkedVehicle.Select(v => new IndexViewModel { Color = v.Color, VehicleType = v.VehicleType, ParkingTime = v.ParkingTime, RegNr = v.RegNr }).ToList();
            List<IndexViewModel> model = new List<IndexViewModel>();
            foreach (var v in db.ParkedVehicle.ToList())
            {
                model.Add(new IndexViewModel(v));
            }
            return View(model);
        }

        // GET: Home/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // ParkedVehicles parkedVehicles = db.ParkedVehicle.Find(id);
            ParkedVehicles parkedVehicles = db.ParkedVehicle.FirstOrDefault(v => v.RegNr == id);

            if (parkedVehicles == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel model = new DetailsViewModel(parkedVehicles);

            return View(model);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleType,RegNr,Color,Make,Model,NrWheels")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                ParkedVehicles parkedVehicles = new ParkedVehicles(vehicle);
                db.ParkedVehicle.Add(parkedVehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicles parkedVehicles = db.ParkedVehicle.FirstOrDefault(v=>v.RegNr == id);
            if (parkedVehicles == null)
            {
                return HttpNotFound();
            }
            EditViewModel model = new EditViewModel { RegNr = parkedVehicles.RegNr,
                Color = parkedVehicles.Color,
                Make = parkedVehicles.Make,
                Model = parkedVehicles.Model,
                NrWheels = parkedVehicles.NrWheels,
                VehicleType = parkedVehicles.VehicleType };

            return View(model);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleType,RegNr,Color,Make,Model,NrWheels")] EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                ParkedVehicles parkedVehicles = db.ParkedVehicle.FirstOrDefault(v => v.RegNr == editViewModel.RegNr);

                parkedVehicles.Make = editViewModel.Make;
                parkedVehicles.Model = editViewModel.Model;
                parkedVehicles.NrWheels = editViewModel.NrWheels;
                parkedVehicles.VehicleType = editViewModel.VehicleType;
                parkedVehicles.Color = editViewModel.Color;

                db.Entry(parkedVehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editViewModel);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicles parkedVehicles = db.ParkedVehicle.FirstOrDefault(v => v.RegNr == id);
            if (parkedVehicles == null)
            {
                return HttpNotFound();
            }
            DeleteViewModel model = new DeleteViewModel(parkedVehicles);
            return View(model);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ParkedVehicles parkedVehicles = db.ParkedVehicle.FirstOrDefault(v => v.RegNr == id);
            db.ParkedVehicle.Remove(parkedVehicles);
            //db.SaveChanges();

            Receit model = new Receit
            {
                
            };

            return RedirectToAction("Receit",model);
        }

        public ActionResult Receit(Receit trial)
        {
            return View(trial);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string RegNr)
        {
            ParkedVehicles pv = db.ParkedVehicle.FirstOrDefault(v => v.RegNr == RegNr);
            if(pv==null)
            {
                return View();
            }
            DetailsViewModel model = new DetailsViewModel(pv);

            return View("Details", model);
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

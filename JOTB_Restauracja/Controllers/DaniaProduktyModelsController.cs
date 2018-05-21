using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JOTB_Restauracja.Cotext;
using JOTB_Restauracja.Models;

namespace JOTB_Restauracja.Controllers
{
    public class DaniaProduktyModelsController : Controller
    {
        private RestauracjaContext db = new RestauracjaContext();

        // GET: DaniaProduktyModels
        public ActionResult Index()
        {
            var daniaProdukty = db.DaniaProdukty.Include(d => d.Danie).Include(d => d.Produkt);
            return View(daniaProdukty.ToList());
        }

        // GET: DaniaProduktyModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaniaProduktyModel daniaProduktyModel = db.DaniaProdukty.Find(id);
            if (daniaProduktyModel == null)
            {
                return HttpNotFound();
            }
            return View(daniaProduktyModel);
        }

        // GET: DaniaProduktyModels/Create
        public ActionResult Create()
        {
            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa");
            ViewBag.IdProdukt = new SelectList(db.Produkty, "ID", "Nazwa");
            return View();
        }

        // POST: DaniaProduktyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdDania,IdProdukt")] DaniaProduktyModel daniaProduktyModel)
        {
            if (ModelState.IsValid)
            {
                db.DaniaProdukty.Add(daniaProduktyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa", daniaProduktyModel.IdDania);
            ViewBag.IdProdukt = new SelectList(db.Produkty, "ID", "Nazwa", daniaProduktyModel.IdProdukt);
            return View(daniaProduktyModel);
        }

        // GET: DaniaProduktyModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaniaProduktyModel daniaProduktyModel = db.DaniaProdukty.Find(id);
            if (daniaProduktyModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa", daniaProduktyModel.IdDania);
            ViewBag.IdProdukt = new SelectList(db.Produkty, "ID", "Nazwa", daniaProduktyModel.IdProdukt);
            return View(daniaProduktyModel);
        }

        // POST: DaniaProduktyModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdDania,IdProdukt")] DaniaProduktyModel daniaProduktyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daniaProduktyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa", daniaProduktyModel.IdDania);
            ViewBag.IdProdukt = new SelectList(db.Produkty, "ID", "Nazwa", daniaProduktyModel.IdProdukt);
            return View(daniaProduktyModel);
        }

        // GET: DaniaProduktyModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaniaProduktyModel daniaProduktyModel = db.DaniaProdukty.Find(id);
            if (daniaProduktyModel == null)
            {
                return HttpNotFound();
            }
            return View(daniaProduktyModel);
        }

        // POST: DaniaProduktyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DaniaProduktyModel daniaProduktyModel = db.DaniaProdukty.Find(id);
            db.DaniaProdukty.Remove(daniaProduktyModel);
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

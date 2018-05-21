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
    public class ProduktyModelsController : Controller
    {
        private RestauracjaContext db = new RestauracjaContext();

        // GET: ProduktyModels
        public ActionResult Index()
        {
            return View(db.Produkty.ToList());
        }

        // GET: ProduktyModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduktyModel produktyModel = db.Produkty.Find(id);
            if (produktyModel == null)
            {
                return HttpNotFound();
            }
            return View(produktyModel);
        }

        // GET: ProduktyModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduktyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Jednostka,Koszt")] ProduktyModel produktyModel)
        {
            if (ModelState.IsValid)
            {
                db.Produkty.Add(produktyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produktyModel);
        }

        // GET: ProduktyModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduktyModel produktyModel = db.Produkty.Find(id);
            if (produktyModel == null)
            {
                return HttpNotFound();
            }
            return View(produktyModel);
        }

        // POST: ProduktyModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Jednostka,Koszt")] ProduktyModel produktyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produktyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produktyModel);
        }

        // GET: ProduktyModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduktyModel produktyModel = db.Produkty.Find(id);
            if (produktyModel == null)
            {
                return HttpNotFound();
            }
            return View(produktyModel);
        }

        // POST: ProduktyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProduktyModel produktyModel = db.Produkty.Find(id);
            db.Produkty.Remove(produktyModel);
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

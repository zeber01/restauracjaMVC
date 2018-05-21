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
    public class DaniaModelsController : Controller
    {
        private RestauracjaContext db = new RestauracjaContext();

        // GET: DaniaModels
        public ActionResult Index()
        {
            return View(db.Dania.ToList());
        }

        // GET: DaniaModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaniaModel daniaModel = db.Dania.Find(id);
            if (daniaModel == null)
            {
                return HttpNotFound();
            }
            return View(daniaModel);
        }

        // GET: DaniaModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DaniaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Cena,Kategoria")] DaniaModel daniaModel)
        {
            if (ModelState.IsValid)
            {
                db.Dania.Add(daniaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daniaModel);
        }

        // GET: DaniaModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaniaModel daniaModel = db.Dania.Find(id);
            if (daniaModel == null)
            {
                return HttpNotFound();
            }
            return View(daniaModel);
        }

        // POST: DaniaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Cena,Kategoria")] DaniaModel daniaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daniaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daniaModel);
        }

        // GET: DaniaModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DaniaModel daniaModel = db.Dania.Find(id);
            if (daniaModel == null)
            {
                return HttpNotFound();
            }
            return View(daniaModel);
        }

        // POST: DaniaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DaniaModel daniaModel = db.Dania.Find(id);
            db.Dania.Remove(daniaModel);
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

        public ActionResult IndexP()
        {
            return View(db.Dania.ToList());
        }
    }
}

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
    public class ZamowienieDanieModelsController : Controller
    {
        private RestauracjaContext db = new RestauracjaContext();

        // GET: ZamowienieDanieModels
        public ActionResult Index()
        {
            var zamowieniaDania = db.ZamowieniaDania.Include(z => z.Danie).Include(z => z.Zamowienie);
            return View(zamowieniaDania.ToList());
        }

        // GET: ZamowienieDanieModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZamowienieDanieModel zamowienieDanieModel = db.ZamowieniaDania.Find(id);
            if (zamowienieDanieModel == null)
            {
                return HttpNotFound();
            }
            return View(zamowienieDanieModel);
        }

        // GET: ZamowienieDanieModels/Create
        public ActionResult Create()
        {
            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa");
            ViewBag.IdZamowienia = new SelectList(db.Zamowienia, "ID", "ID");
            return View();
        }

        // POST: ZamowienieDanieModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdZamowienia,IdDania,Ilosc")] ZamowienieDanieModel zamowienieDanieModel)
        {
            if (ModelState.IsValid)
            {
                db.ZamowieniaDania.Add(zamowienieDanieModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa", zamowienieDanieModel.IdDania);
            ViewBag.IdZamowienia = new SelectList(db.Zamowienia, "ID", "ID", zamowienieDanieModel.IdZamowienia);
            return View(zamowienieDanieModel);
        }

        // GET: ZamowienieDanieModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZamowienieDanieModel zamowienieDanieModel = db.ZamowieniaDania.Find(id);
            if (zamowienieDanieModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa", zamowienieDanieModel.IdDania);
            ViewBag.IdZamowienia = new SelectList(db.Zamowienia, "ID", "ID", zamowienieDanieModel.IdZamowienia);
            return View(zamowienieDanieModel);
        }

        // POST: ZamowienieDanieModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdZamowienia,IdDania,Ilosc")] ZamowienieDanieModel zamowienieDanieModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zamowienieDanieModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDania = new SelectList(db.Dania, "ID", "Nazwa", zamowienieDanieModel.IdDania);
            ViewBag.IdZamowienia = new SelectList(db.Zamowienia, "ID", "ID", zamowienieDanieModel.IdZamowienia);
            return View(zamowienieDanieModel);
        }

        // GET: ZamowienieDanieModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZamowienieDanieModel zamowienieDanieModel = db.ZamowieniaDania.Find(id);
            if (zamowienieDanieModel == null)
            {
                return HttpNotFound();
            }
            return View(zamowienieDanieModel);
        }

        // POST: ZamowienieDanieModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ZamowienieDanieModel zamowienieDanieModel = db.ZamowieniaDania.Find(id);
            db.ZamowieniaDania.Remove(zamowienieDanieModel);
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

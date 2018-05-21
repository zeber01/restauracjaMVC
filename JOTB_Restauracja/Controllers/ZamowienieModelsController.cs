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
using Microsoft.AspNet.Identity;

namespace JOTB_Restauracja.Controllers
{
    public class ZamowienieModelsController : Controller
    {
        private RestauracjaContext db = new RestauracjaContext();

        // GET: ZamowienieModels
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator") == true)
            {
                return View(db.Zamowienia.ToList());
            }
            else
                return View(db.Zamowienia.Where(m => m.idKlienta == User.Identity.GetUserId()));
        }

        // GET: ZamowienieModels/Dodaj
        public ActionResult Dodaj()
        {
            // List<string> daniaId = new List<string>();
            // List<string> daniaNazwa = new List<string>();
            List<ZamowieniePomModel> listaPom = new List<ZamowieniePomModel>();

            var daniaID = db.Dania.OrderBy(m => m.Kategoria).Select(m => m.ID).ToList();
            var daniaNAZWA = db.Dania.OrderBy(m => m.Kategoria).Select(m => m.Nazwa).ToList();

            for (int i = 0; i < daniaID.Count(); i++)
            {
                listaPom.Add
                    (new ZamowieniePomModel()
                    {
                        idDania = daniaID[i],
                        NazwaDania = daniaNAZWA[i]

                    }

                );
            }


            return View(listaPom);
        }

        // POST: ZamowienieModel/Dodaj
        [HttpPost]
        public ActionResult Dodaj(List<ZamowieniePomModel> z)
        {
            var daniaID = db.Dania.OrderBy(m => m.Kategoria).Select(m => m.ID).ToList();

            var idZamowienie = Guid.NewGuid().ToString();
            var userID = User.Identity.GetUserId();
            bool czyBylyZamowienie = false;
            if (z.Count > 0)
                czyBylyZamowienie = true;

            if (czyBylyZamowienie == true)
            {
                ZamowienieModel temp = new ZamowienieModel()
                {
                    data = DateTime.Today,
                    ID = idZamowienie,
                    idKlienta = userID,
                    Zrealizowane = false
                };

                db.Zamowienia.Add(temp);
                db.SaveChanges();

            }

            for (int i = 0; i < z.Count; i++)
            {
                if (z[i].czyZaznaczone == "TAK")
                {
                    czyBylyZamowienie = true;
                    ZamowienieDanieModel temp = new ZamowienieDanieModel()
                    {
                        ID = Guid.NewGuid().ToString(),
                        IdZamowienia = idZamowienie,
                        IdDania = daniaID[i],
                        Ilosc = z[i].Ilosc


                    };
                    db.ZamowieniaDania.Add(temp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: ZamowienieModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var daniaId = db.ZamowieniaDania.Where(m => m.IdZamowienia == id).ToList().ToList(); ;
            List<DaniaModel> nazwy = new List<DaniaModel>();
            double cena = 0;
            int i = 0;
            foreach (var item in daniaId)
            {
                var temp = db.Dania.Where(m => m.ID == item.IdDania).FirstOrDefault();
                nazwy.Add(temp);
                cena += item.Ilosc * nazwy[i].Cena;
                i++;
            }

            ViewBag.nazwy = nazwy;
            ViewBag.dania = daniaId;
            ViewBag.cena = cena;

            //ViewBag.szczeg = szczegoly;
            ZamowienieModel zamowienieModel = db.Zamowienia.Find(id);
            if (zamowienieModel == null)
            {
                return HttpNotFound();
            }
            return View(zamowienieModel);
        }

        // GET: ZamowienieModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZamowienieModel zamowienieModel = db.Zamowienia.Find(id);
            if (zamowienieModel == null)
            {
                return HttpNotFound();
            }
            return View(zamowienieModel);
        }

        // POST: ZamowienieModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,data,Zrealizowane")] ZamowienieModel zamowienieModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zamowienieModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zamowienieModel);
        }

        // GET: ZamowienieModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZamowienieModel zamowienieModel = db.Zamowienia.Find(id);
            if (zamowienieModel == null)
            {
                return HttpNotFound();
            }
            return View(zamowienieModel);
        }

        // POST: ZamowienieModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ZamowienieModel zamowienieModel = db.Zamowienia.Find(id);
            db.Zamowienia.Remove(zamowienieModel);
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

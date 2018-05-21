using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Web.Routing;
using JOTB_Restauracja.Cotext;
using JOTB_Restauracja.Models;
using System.Net;

namespace JOTB_Restauracja.Controllers
{
    public class AdminController : Controller
    {
        private RestauracjaContext db = new RestauracjaContext();
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (!User.IsInRole("Administrator") || !User.Identity.IsAuthenticated)
                RedirectToAction("Index", "HomeController");
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult PracownicyDodaj()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult PracownicyDodaj(PracownikModel pracownik)
        {
            pracownik.ID = Guid.NewGuid().ToString();
            if(ModelState.IsValid)
            {
                db.Pracownicy.Add(pracownik);
                db.SaveChanges();
            }

            return RedirectToAction("PracownicyLista");
        }

        //GET
        public ActionResult PracownicyLista()
        {
            var lista = db.Pracownicy.ToList();

            return View(lista);
        }

        //GET
        public ActionResult PracownicyUsun(string id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pracownik = db.Pracownicy.Find(id);

            if(pracownik == null)
                return HttpNotFound();

            return View(pracownik);
        }

        [HttpPost, ActionName("PracownicyUsun")]
        [ValidateAntiForgeryToken]
        public ActionResult PracownicyUsunConfirmed(string id)
        {
            var pracownik = db.Pracownicy.Find(id);
            db.Pracownicy.Remove(pracownik);
            db.SaveChanges();

            return RedirectToAction("PraconicyLista");
        }

        public ActionResult DaniaLista()
        {
            var dania = db.Dania.ToList();

            return View(dania);
        }

        // GET
        public ActionResult DaniaDodaj()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult DaniaDodaj(DaniaModel danie)
        {
            danie.ID = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.Dania.Add(danie);
                db.SaveChanges();
            }

            return RedirectToAction("DaniaLista");
        }

        //GET
        public ActionResult DaniaUsun(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var danie = db.Dania.Find(id);

            if (danie == null)
                return HttpNotFound();

            return View(danie);
        }

        [HttpPost, ActionName("DaniaUsun")]
        [ValidateAntiForgeryToken]
        public ActionResult DaniaUsunConfirmed(string id)
        {
            var danie = db.Dania.Find(id);
            db.Dania.Remove(danie);
            db.SaveChanges();

            return RedirectToAction("DaniaLista");
        }

        public ActionResult ProduktyLista()
        {
            var produkty = db.Produkty.ToList();

            return View(produkty);
        }

        // GET
        public ActionResult ProduktyDodaj()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult ProduktyDodaj(ProduktyModel produkt)
        {
            produkt.ID = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                db.Produkty.Add(produkt);
                db.SaveChanges();
            }

            return RedirectToAction("ProduktyLista");
        }

        //GET
        public ActionResult ProduktyUsun(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var produkt = db.Produkty.Find(id);

            if (produkt == null)
                return HttpNotFound();

            return View(produkt);
        }

        [HttpPost, ActionName("ProduktyUsun")]
        [ValidateAntiForgeryToken]
        public ActionResult ProduktyUsunConfirmed(string id)
        {
            var produkt = db.Produkty.Find(id);
            db.Produkty.Remove(produkt);
            db.SaveChanges();

            return RedirectToAction("ProduktyLista");
        }
    }
}
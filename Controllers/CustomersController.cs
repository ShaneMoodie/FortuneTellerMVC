using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerEntities db = new FortuneTellerEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.FirstName = customer.FirstName;
            ViewBag.LastName = customer.LastName;
            ViewBag.RetirementYear = "";
            if (customer.Age % 2 == 0)
            {
                ViewBag.RetirementYear = "20 years";
            }
            else
            {
                ViewBag.RetirementYear = "30 years";
            }
            ViewBag.VacaHome = "";
            if (customer.Sibilings == 0)
            {
                ViewBag.VacaHome = "The Citadel of Ricks";
            }
            else if (customer.Sibilings == 1)
            {
                ViewBag.VacaHome = "Winterfell";
            }
            else if (customer.Sibilings == 2)
            {
                ViewBag.VacaHome = "Rivendell";
            }
            else if (customer.Sibilings == 3)
            {
                ViewBag.VacaHome = "Gotham City";
            }
            else if (customer.Sibilings >= 4)
            {
                ViewBag.VacaHome = "Dr. Evil's Top Seceret Moon Base";
            }
            else if (customer.Sibilings < 0)
            {
                ViewBag.VacaHome = "the dumpster behind Arby's";
            }
            ViewBag.Transport = "";
            if (customer.FavoriteColor.ToLower() == "red")
            {
                ViewBag.Transport = "a teleportation gun";
            }
            else if (customer.FavoriteColor.ToLower() == "orange")
            {
                ViewBag.Transport = "a horse";
            }
            else if (customer.FavoriteColor.ToLower() == "yellow")
            {
                ViewBag.Transport = "a pogo stick";
            }
            else if (customer.FavoriteColor.ToLower() == "green")
            {
                ViewBag.Transport = "a Ford Model-T";
            }
            else if (customer.FavoriteColor.ToLower() == "blue")
            {
                ViewBag.Transport = "an old pair of Heelys";
            }
            else if (customer.FavoriteColor.ToLower() == "indigo")
            {
                ViewBag.Transport = "a skateboard missing one wheel";
            }
            else if (customer.FavoriteColor.ToLower() == "violet")
            {
                ViewBag.Transport = "a unicycle, complete with a dancing monkey wearing a hat";
            }

            ViewBag.DollaBillz = "";
            if (customer.BirthMonth == 1 || customer.BirthMonth == 2 || customer.BirthMonth == 3 || customer.BirthMonth == 4)
            {
                ViewBag.DollaBillz = "$150,000";
            }
            else if (customer.BirthMonth == 5 || customer.BirthMonth == 6 || customer.BirthMonth == 7 || customer.BirthMonth == 8)
            {
                ViewBag.DollaBillz = "$500,000";
            }
            else if (customer.BirthMonth == 9 || customer.BirthMonth == 10 || customer.BirthMonth == 11 || customer.BirthMonth == 12)
            {
                ViewBag.DollaBillz = "$1,000,000";
            }
            else
            {
                ViewBag.DollaBillz = "$0.00";
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,Sibilings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,Sibilings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

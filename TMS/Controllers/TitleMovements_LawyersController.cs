using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class TitleMovements_LawyersController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: TitleMovements_Lawyers
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var lawyers = db.TitleMovements_Lawyers.AsNoTracking().ToList();
            ViewBag.datasource = lawyers;
            return View(db.TitleMovements_Lawyers.ToList());
        }

        // GET: TitleMovements_Lawyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleMovements_Lawyers titleMovements_Lawyers = db.TitleMovements_Lawyers.Find(id);
            if (titleMovements_Lawyers == null)
            {
                return HttpNotFound();
            }
            return View(titleMovements_Lawyers);
        }

        // GET: TitleMovements_Lawyers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitleMovements_Lawyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lawyers_ID,Lawyers_Desc")] TitleMovements_Lawyers titleMovements_Lawyers)
        {
            if (ModelState.IsValid)
            {
                db.TitleMovements_Lawyers.Add(titleMovements_Lawyers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titleMovements_Lawyers);
        }

        // GET: TitleMovements_Lawyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleMovements_Lawyers titleMovements_Lawyers = db.TitleMovements_Lawyers.Find(id);
            if (titleMovements_Lawyers == null)
            {
                return HttpNotFound();
            }
            return View(titleMovements_Lawyers);
        }

        // POST: TitleMovements_Lawyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lawyers_ID,Lawyers_Desc")] TitleMovements_Lawyers titleMovements_Lawyers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titleMovements_Lawyers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titleMovements_Lawyers);
        }

        // GET: TitleMovements_Lawyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleMovements_Lawyers titleMovements_Lawyers = db.TitleMovements_Lawyers.Find(id);
            if (titleMovements_Lawyers == null)
            {
                return HttpNotFound();
            }
            return View(titleMovements_Lawyers);
        }

        // POST: TitleMovements_Lawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TitleMovements_Lawyers titleMovements_Lawyers = db.TitleMovements_Lawyers.Find(id);
            db.TitleMovements_Lawyers.Remove(titleMovements_Lawyers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DialogUpdate(TitleMovements_Lawyers value)
        {
            TitleMovements_Lawyers table = db.TitleMovements_Lawyers.FirstOrDefault(o =>
            o.Lawyers_ID == value.Lawyers_ID);

            if (table != null)
            {
                db.Entry(table).CurrentValues.SetValues(value);
                db.Entry(table).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                    TempData["Success"] = "Record Saved Successfully!";
                }
                catch (DbEntityValidationException dbEx)
                {

                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            TempData["Success"] += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogInsert(TitleMovements_Lawyers value)
        {
            TitleMovements_Lawyers table = db.TitleMovements_Lawyers.FirstOrDefault(o =>
            o.Lawyers_ID == value.Lawyers_ID);

            if (table == null)
            {
                db.TitleMovements_Lawyers.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Lawyers_ID)
        {

            TitleMovements_Lawyers result = db.TitleMovements_Lawyers.Where(o => o.Lawyers_ID == Lawyers_ID).FirstOrDefault();
            db.TitleMovements_Lawyers.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
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

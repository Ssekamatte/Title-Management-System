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
    public class OfferStatusController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: OfferStatus
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var offerstatus = db.OfferStatus.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.datasource = offerstatus;

            return View();
            //return View(db.OfferStatus.ToList());
        }

        // GET: OfferStatus/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferStatu offerStatu = db.OfferStatus.Find(id);
            if (offerStatu == null)
            {
                return HttpNotFound();
            }
            return View(offerStatu);
        }

        // GET: OfferStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusCode,StatusDesc")] OfferStatu offerStatu)
        {
            if (ModelState.IsValid)
            {
                db.OfferStatus.Add(offerStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offerStatu);
        }

        // GET: OfferStatus/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferStatu offerStatu = db.OfferStatus.Find(id);
            if (offerStatu == null)
            {
                return HttpNotFound();
            }
            return View(offerStatu);
        }

        // POST: OfferStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusCode,StatusDesc")] OfferStatu offerStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offerStatu);
        }

        // GET: OfferStatus/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferStatu offerStatu = db.OfferStatus.Find(id);
            if (offerStatu == null)
            {
                return HttpNotFound();
            }
            return View(offerStatu);
        }

        // POST: OfferStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            OfferStatu offerStatu = db.OfferStatus.Find(id);
            db.OfferStatus.Remove(offerStatu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DialogUpdate(OfferStatu value)
        {
            OfferStatu table = db.OfferStatus.FirstOrDefault(o =>
            o.StatusCode == value.StatusCode);

            if (table != null)
            {
                UserManagement user = new UserManagement();
                value.Edited_By = user.getCurrentuser();
                value.Edited_Date = DateTime.Now;

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

        public ActionResult DialogInsert(OfferStatu value)
        {

            int new_id = ++db.OfferStatus.AsNoTracking().OrderBy(a => a.StatusCode).ToList().Last().StatusCode;
            value.StatusCode = Convert.ToInt32(new_id);

            OfferStatu table = db.OfferStatus.FirstOrDefault(o =>
            o.StatusCode == value.StatusCode);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.OfferStatus.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int StatusCode)
        {

            OfferStatu result = db.OfferStatus.Where(o => o.StatusCode == StatusCode).FirstOrDefault();
            db.OfferStatus.Remove(result);
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


        public ActionResult DeleteStatus(int value) // Original Delete Function Method
        {
            var propertytitleSummary = db.PropertyTitles.Where(o => o.PropertyStaatus == value).ToList();

            var status = db.OfferStatus.FirstOrDefault(o => o.StatusCode == value);

            var statuscheck = db.OfferStatus.Where(e => (e.StatusDesc.Trim() == status.StatusDesc.Trim()) && e.StatusDesc == status.StatusDesc && e.StatusCode == status.StatusCode).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

            if (propertytitleSummary.Count > 0 && statuscheck.Count <= 1)
            {
                return Json("Status cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else
            {
                foreach (var n in propertytitleSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.OfferStatus.Remove(status);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CheckOfferStatusCodeNo()
        {
            int count = 0;
            var data = db.OfferStatus.OrderByDescending(o => o.StatusCode).FirstOrDefault();
            if (data != null)
            {
                count = data.StatusCode;
            }

            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStatusCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var status = db.OfferStatus.ToList();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveStatus(int ID, string StatusDesc, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (!string.IsNullOrEmpty(StatusDesc))
                {
                    var countcheck = db.OfferStatus.FirstOrDefault(e => (e.StatusDesc.Trim() == StatusDesc.Trim() || e.StatusCode == ID));
                    if (countcheck == null)
                    {
                        OfferStatu region = new OfferStatu() { StatusCode = Convert.ToInt16(ID), StatusDesc = StatusDesc};
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.OfferStatus.Add(region);
                            db.SaveChanges();
                            result = StatusDesc + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }
                    else
                    {
                        result = "This status already exists";
                    }
                }
                else
                {
                    result = "Please fill in the status";
                }
            }
            else if (_type == 2)
            {
                var userexits = db.OfferStatus.FirstOrDefault(e => e.StatusCode == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.StatusDesc = StatusDesc;
                       

                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = StatusDesc + " was updated successfully";
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message.ToString();
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}

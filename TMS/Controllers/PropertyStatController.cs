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
    public class PropertyStatController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: PropertyStat
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var propertystatus = db.PropertyStatus.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.datasource = propertystatus;

            return View();
            //return View(db.PropertyStatus.ToList());

        }

        // GET: PropertyStat/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyStatu propertyStatu = db.PropertyStatus.Find(id);
            if (propertyStatu == null)
            {
                return HttpNotFound();
            }
            return View(propertyStatu);
        }

        // GET: PropertyStat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyStat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusCode,StatusDesc")] PropertyStatu propertyStatu)
        {
            if (ModelState.IsValid)
            {
                db.PropertyStatus.Add(propertyStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyStatu);
        }

        // GET: PropertyStat/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyStatu propertyStatu = db.PropertyStatus.Find(id);
            if (propertyStatu == null)
            {
                return HttpNotFound();
            }
            return View(propertyStatu);
        }

        // POST: PropertyStat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusCode,StatusDesc")] PropertyStatu propertyStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyStatu);
        }

        // GET: PropertyStat/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyStatu propertyStatu = db.PropertyStatus.Find(id);
            if (propertyStatu == null)
            {
                return HttpNotFound();
            }
            return View(propertyStatu);
        }

        // POST: PropertyStat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            PropertyStatu propertyStatu = db.PropertyStatus.Find(id);
            db.PropertyStatus.Remove(propertyStatu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DialogUpdate(PropertyStatu value)
        {
            PropertyStatu table = db.PropertyStatus.FirstOrDefault(o =>
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

        public ActionResult DialogInsert(PropertyStatu value)
        {

            int new_id = ++db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusCode).ToList().Last().StatusCode;
            value.StatusCode = Convert.ToInt32(new_id);

            PropertyStatu table = db.PropertyStatus.FirstOrDefault(o =>
            o.StatusCode == value.StatusCode);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.PropertyStatus.Add(value);
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

            PropertyStatu result = db.PropertyStatus.Where(o => o.StatusCode == StatusCode).FirstOrDefault();
            db.PropertyStatus.Remove(result);
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


        public ActionResult DeletePropertyStatus(int value) // Original Delete Function Method
        {
            var propertystatusSummary = db.PropertyTitles.Where(o => o.PropertyStaatus == value).ToList();

            var status = db.PropertyStatus.FirstOrDefault(o => o.StatusCode == value);

            var statuscheck = db.PropertyStatus.Where(e => (e.StatusDesc.Trim() == status.StatusDesc.Trim()) && e.StatusDesc == status.StatusDesc && e.StatusCode == status.StatusCode).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

            if (propertystatusSummary.Count > 0 && statuscheck.Count <= 1)
            {
                return Json("Status cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else
            {
                foreach (var n in propertystatusSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.PropertyStatus.Remove(status);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CheckPropertyStatusCodeNo()
        {
            int count = 0;
            var data = db.PropertyStatus.OrderByDescending(o => o.StatusCode).FirstOrDefault();

            if (data != null)
            {
                count = data.StatusCode;
            }

            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStatusCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var status = db.PropertyStatus.ToList();
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult SaveCountry(int CountryCode, string CountryName, string NationalityDesc, int _type)
        public ActionResult SavePropertyStatus(int ID, string StatusDesc, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (!string.IsNullOrEmpty(StatusDesc))
                {
                    var countcheck = db.PropertyStatus.FirstOrDefault(e => (e.StatusDesc.Trim() == StatusDesc.Trim() || e.StatusCode == ID) );
                    if (countcheck == null)
                    {
                        PropertyStatu region = new PropertyStatu() { StatusCode = Convert.ToInt16(ID), StatusDesc = StatusDesc};
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.PropertyStatus.Add(region);
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
                var userexits = db.PropertyStatus.FirstOrDefault(e => e.StatusCode == ID);
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

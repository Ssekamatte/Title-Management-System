using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class CountiesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Counties
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var viewcounties = db.ViewCountyDistricts.AsNoTracking().ToList();
            ViewBag.ViewCountyDistricts = viewcounties;

            db.Configuration.ProxyCreationEnabled = false;
            //var districts = db.Districts.AsNoTracking().ToList();
            var districts = db.Districts.AsNoTracking().Select(a => new { a.DistrictID, a.District_Name }).Distinct().OrderBy(a => a.District_Name).ToList();

            ViewBag.Districts = districts;

            db.Configuration.ProxyCreationEnabled = false;
            var regions = db.Regions.AsNoTracking().ToList();
            ViewBag.Regions = regions;
           
            return View(); // return View(db.Counties.ToList());
        }

        // GET: Counties/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.Counties.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // GET: Counties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Counties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "County_ID,District_ID,County_Name,DataModify,DataEntry")] County county)
        {
            if (ModelState.IsValid)
            {
                db.Counties.Add(county);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(county);
        }

        // GET: Counties/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.Counties.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // POST: Counties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "County_ID,District_ID,County_Name,DataModify,DataEntry")] County county)
        {
            if (ModelState.IsValid)
            {
                db.Entry(county).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(county);
        }

        // GET: Counties/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.Counties.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // POST: Counties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            County county = db.Counties.Find(id);
            db.Counties.Remove(county);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DialogUpdate(County value)
        {
            //County table = db.Counties.FirstOrDefault(o =>
            //o.County_ID == value.County_ID);

            County table = db.Counties.FirstOrDefault(o =>
            o.County_ID == value.County_ID);


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

        public ActionResult DialogInsert(County value)
        {
            int new_id = ++db.Counties.AsNoTracking().OrderBy(a => a.County_ID).ToList().Last().County_ID;
            value.County_ID = Convert.ToInt32(new_id);

            County table = db.Counties.FirstOrDefault(o =>
            o.County_ID == value.County_ID);

            if (table == null)
            {
                try
                {
                    UserManagement user = new UserManagement();
                    value.Added_By = user.getCurrentuser();
                    value.Added_Date = DateTime.Now;

                    db.Counties.Add(value);
                    db.SaveChanges();
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
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DialogDelete(int County_ID)
        {

            County result = db.Counties.Where(o => o.County_ID == County_ID).FirstOrDefault();
            db.Counties.Remove(result);
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

        public ActionResult DeleteCounty(int value)
        {
            var SubcountiesSummary = db.Subcounties.Where(o => o.County_ID == value).ToList();
            var PropertyTitlesSummary = db.PropertyTitles.Where(o => o.County_ID == value).ToList();
            var ParishSummary = db.Parishes.Where(o => o.County == value).ToList();
           

            var county = db.Counties.FirstOrDefault(o => o.County_ID == value);

            var countycheck = db.Counties.Where(e => (e.County_Name.Trim() == county.County_Name.Trim()) /*&& e.County_Name == county.County_Name*/ && e.County_ID == county.County_ID).ToList();

            if ((SubcountiesSummary.Count > 0 || PropertyTitlesSummary.Count > 0 || ParishSummary.Count > 0) && countycheck.Count <= 1)
            {
                return Json("County cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }

            else if (SubcountiesSummary.Count <= 0 && countycheck.Count >= 1)
            
            {
                foreach (var n in SubcountiesSummary)
                {
                    db.Subcounties.Remove(n);
                    db.SaveChanges();
                }
                db.Counties.Remove(county);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else if (PropertyTitlesSummary.Count <= 0 && countycheck.Count >= 1)
            {
                foreach (var n in PropertyTitlesSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Counties.Remove(county);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);

            }

            else 
            {
                foreach (var n in ParishSummary)
                {
                    db.Parishes.Remove(n);
                    db.SaveChanges();
                }
                db.Counties.Remove(county);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCountiesCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var county = db.Counties.OrderByDescending(a => a.Added_Date).ToList();
            return Json(county, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckCountyCodeNo()
        {
            int count = 0;
            var data = db.Counties.OrderByDescending(o => o.County_ID).FirstOrDefault();
            if (data != null)
            {
                count = data.County_ID;
            }
                       
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveCounty(int ID, int? District_ID, string County_Name, int _type)
        {
            //int new_id = ++db.Countries.AsNoTracking().OrderBy(a => a.CountryCode).ToList().Last().CountryCode;
            //value.CountryCode = Convert.ToInt32(new_id);

            string result = string.Empty;
            if (_type == 1)
            {
                if (!string.IsNullOrEmpty(County_Name) && District_ID != null)
                
                {
                    var countcheck = db.Counties.FirstOrDefault(e => (e.County_Name.Trim() == County_Name.Trim() || e.County_ID == ID) && e.District_ID == District_ID);

                    if (countcheck == null)
                    {
                        County region = new County() { County_ID = Convert.ToInt16(ID), County_Name = County_Name, District_ID = Convert.ToInt32(District_ID) };

                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Counties.Add(region);
                            db.SaveChanges();
                            result = County_Name + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }

                    else
                    {                      

                        result = "This County ( " + County_Name + " ) already exists";
                    }
                }

                else if (District_ID == null && !string.IsNullOrEmpty(County_Name))
                {
                    //result = "Please fill in the County";
                    result = "Please select a District ";
                }

                else if (District_ID != null && string.IsNullOrEmpty(County_Name))
                {
                    result = "Please fill in the County";
                }

                else
                {
                    result = "Please fill in the District and County";
                }
            }

            //####### Original Starts Here

            else if (_type == 2)
            {
                var userexits = db.Counties.FirstOrDefault(e => e.County_ID == ID);
                int count = db.Counties.Where(e => (e.County_ID == ID)).ToList().Count();

                if (userexits != null)
                {

                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.County_Name = County_Name;
                        userexits.District_ID = Convert.ToInt32(District_ID);

                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        
                        //result = County_Name + " was updated successfully";

                        result = "District for " + County_Name + " has been updated successfully";

                    }
                    catch (Exception ex)
                    {
                        result = ex.Message.ToString();
                    }
                }
            }
            ////####### Original Ends Here

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}

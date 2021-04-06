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
    public class DistrictsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Districts
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            //var districts = db.Districts.ToList();
            //ViewBag.datasource = districts;
            //return View(db.Districts.ToList());
            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().ToList();
            ViewBag.Districts = districts;

            db.Configuration.ProxyCreationEnabled = false;
            var viewdistricts = db.ViewNewRegionDistricts.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.ViewRegionDistricts = viewdistricts;

            db.Configuration.ProxyCreationEnabled = false;
            var regions = db.Regions.AsNoTracking().ToList();
            ViewBag.Regions = regions;
            return View(); // return View(db.Counties.ToList());
        }

        [HttpPost]

        public ActionResult DistrictList2()
        {
            var districts = db.Districts.ToList();
            ViewBag.datasource = districts;
            return View();
        }
        public ActionResult DistrictList()
        {
            var DataSource = db.Districts .ToList();
            ViewBag.dataSource = DataSource;
            var DataSource2 = db.Counties .ToList();
            ViewBag.DataSource2 = DataSource2;

            //return View(db.Districts.ToList());
            return View();
        }
        // GET: Districts/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: Districts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistrictID,District_Name,Region_code,NewDataAudit,EditDataAudit")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(district);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistrictID,District_Name,Region_code,NewDataAudit,EditDataAudit")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(district);
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DialogUpdate(District value)
        {
            District table = db.Districts.FirstOrDefault(o =>
            o.DistrictID == value.DistrictID);

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

        public ActionResult DialogInsert(District value)
        {

            int new_id = ++db.Districts.AsNoTracking().OrderBy(a => a.DistrictID).ToList().Last().DistrictID;
            value.DistrictID = Convert.ToInt32(new_id);

            District table = db.Districts.FirstOrDefault(o =>
            o.DistrictID == value.DistrictID);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.Districts.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }




        public ActionResult DialogDelete(int DistrictID)
        {

            District result = db.Districts.Where(o => o.DistrictID == DistrictID).FirstOrDefault();
            db.Districts.Remove(result);
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FormValue(string selectCar)
        {
            ViewBag.Value = selectCar;
            return View();
        }

        public ActionResult DeleteDistrict(int value)
        {
            var CountiesSummary = db.Counties.Where(o => o.District_ID == value).ToList();
            var PropertyTitlesSummary = db.PropertyTitles.Where(o => o.DistrictID == value).ToList();
            var ParishesSummary = db.Parishes.Where(o => o.District == value).ToList();
            var SubCountiesSummary = db.Subcounties.Where(o => o.District == value).ToList();
          
            var District = db.Districts.FirstOrDefault(o => o.DistrictID == value);

            var districtcheck = db.Districts.Where(e => (e.District_Name.Trim() == District.District_Name.Trim()) && e.Region_code == District.Region_code ).ToList();


            if ((CountiesSummary.Count > 0 || PropertyTitlesSummary.Count > 0 || ParishesSummary.Count > 0 || SubCountiesSummary.Count > 0) && districtcheck.Count <= 1)
            {
                return Json("District cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }

            else if (CountiesSummary.Count <= 0 && districtcheck.Count >= 1)
            {
                foreach (var n in CountiesSummary)
                {
                    db.Counties.Remove(n);
                    db.SaveChanges();
                }
                db.Districts.Remove(District);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else if (PropertyTitlesSummary.Count <= 0 && districtcheck.Count >= 1)
            {
                foreach (var n in PropertyTitlesSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Districts.Remove(District);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else if (ParishesSummary.Count <= 0 && districtcheck.Count >= 1)
            {
                foreach (var n in ParishesSummary)
                {
                    db.Parishes.Remove(n);
                    db.SaveChanges();
                }
                db.Districts.Remove(District);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else 
            {
                foreach (var n in SubCountiesSummary)
                {
                    db.Subcounties.Remove(n);
                    db.SaveChanges();
                }
                db.Districts.Remove(District);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult SaveDistrict(int ID, int? Region_code, string District_Name, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                //if (!string.IsNullOrEmpty(District_Name))
                if (!string.IsNullOrEmpty(District_Name) && Region_code != null)
                {
                    //var countcheck = db.Districts.FirstOrDefault(e => (e.District_Name.Trim() == District_Name.Trim() || e.DistrictID == ID) && e.Region_code == Convert.ToInt32(Region_code));
                      var countcheck = db.Districts.FirstOrDefault(e => (e.District_Name.Trim() == District_Name.Trim() || e.DistrictID == ID) && e.Region_code == Region_code);

                    if (countcheck == null)
                    {
                        District region = new District() { DistrictID = Convert.ToInt16(ID), District_Name = District_Name, Region_code = Convert.ToInt32(Region_code) };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Districts.Add(region);
                            db.SaveChanges();
                            result = District_Name + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }
                    else
                    {                       
                        result = "This district ( " + District_Name + " ) already exists in the region";
                    }
                }

                else if (Region_code == null && !string.IsNullOrEmpty(District_Name))
                {
                    //result = "Please fill in the County";
                    result = "Please select a Region ";
                }

                else if (Region_code != null && string.IsNullOrEmpty(District_Name))
                {
                    result = "Please fill in the District";
                }

                else
                {
                    result = "Please fill in the Region and District";
                }
                
            }
            else if (_type == 2)
            {
                var userexits = db.Districts.FirstOrDefault(e => e.DistrictID == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.District_Name = District_Name;
                        userexits.Region_code = Convert.ToInt32(Region_code);

                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                      
                        result = "Details for " + District_Name + " have been updated successfully";

                    }
                    catch (Exception ex)
                    {
                        result = ex.Message.ToString();
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckDistrictID()
        {
            int count = 0;
            var data = db.Districts.OrderByDescending(o => o.DistrictID).FirstOrDefault();
            if (data != null)
            {
                count = data.DistrictID;
            }
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistrictsCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var country = db.Districts.OrderByDescending(a => a.Added_Date).ToList();
            return Json(country, JsonRequestBehavior.AllowGet);
        }



    }
}

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
    public class LocationController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Location
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Locations = db.Locations.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.datasource = Locations;

            return View();
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DialogUpdate(Location value)
        {
            Location table = db.Locations.FirstOrDefault(o =>
            o.Location_id == value.Location_id);

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

        public ActionResult DialogInsert(Location value)
        {

            int new_id = ++db.Locations.AsNoTracking().OrderBy(a => a.Location_id).ToList().Last().Location_id;
            value.Location_id = Convert.ToInt32(new_id);

            Location table = db.Locations.FirstOrDefault(o =>
            o.Location_id == value.Location_id);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.Locations.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Location_id)
        {

            Location result = db.Locations.Where(o => o.Location_id == Location_id).FirstOrDefault();
            db.Locations.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteLocation(int value) // Original Delete Function Method
        {
            var propertytitleSummary = db.PropertyTitles.Where(o => o.Location_id == value).ToList();

            var location = db.Locations.FirstOrDefault(o => o.Location_id == value);

            var locationcheck = db.Locations.Where(e => (e.Location_Desc.Trim() == location.Location_Desc.Trim()) && e.Location_Desc == location.Location_Desc && e.Location_id == location.Location_id).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

            if (propertytitleSummary.Count > 0 && locationcheck.Count <= 1)
            {
                return Json("Location cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else
            {
                foreach (var n in propertytitleSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Locations.Remove(location);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ChecklocationCodeNo()
        {
            int count = 0;
            var data = db.Locations.OrderByDescending(o => o.Location_id).FirstOrDefault();
            if (data != null) { count = data.Location_id;
            }
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetlocationsCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var location = db.Locations.ToList();
            return Json(location, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveLocation(int ID, string Location_Desc, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (!string.IsNullOrEmpty(Location_Desc))
                {
                    var countcheck = db.Locations.FirstOrDefault(e => (e.Location_Desc.Trim() == Location_Desc.Trim() || e.Location_id == ID));
                    if (countcheck == null)
                    {
                        Location region = new Location() { Location_id = Convert.ToInt16(ID), Location_Desc = Location_Desc };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Locations.Add(region);
                            db.SaveChanges();
                            result = Location_Desc + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }
                    else
                    {
                        result = "This location already exists";
                    }
                }
                else
                {
                    result = "Please fill in the location";
                }
            }
            else if (_type == 2)
            {
                var userexits = db.Locations.FirstOrDefault(e => e.Location_id == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.Location_Desc = Location_Desc;
                      

                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = Location_Desc + " was updated successfully";
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

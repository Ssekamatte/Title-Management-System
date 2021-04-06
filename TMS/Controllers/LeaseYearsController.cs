using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class LeaseYearsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: LeaseYears
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var leaseyears = db.PropertyTitle_LeaseYears.AsNoTracking().ToList();
            ViewBag.datasource = leaseyears;

            return View();
        }

        // GET: LeaseYears/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaseYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaseYears/Create
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

        // GET: LeaseYears/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaseYears/Edit/5
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

        // GET: LeaseYears/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaseYears/Delete/5
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


        public ActionResult DialogUpdate(PropertyTitle_LeaseYears value)
        {
            PropertyTitle_LeaseYears table = db.PropertyTitle_LeaseYears.FirstOrDefault(o =>
            o.LeaseYears_ID == value.LeaseYears_ID);

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

        public ActionResult DialogInsert(PropertyTitle_LeaseYears value)
        {

            int new_id = ++db.PropertyTitle_LeaseYears.AsNoTracking().OrderBy(a => a.LeaseYears_ID).ToList().Last().LeaseYears_ID;
            value.LeaseYears_ID = Convert.ToInt32(new_id);

            PropertyTitle_LeaseYears table = db.PropertyTitle_LeaseYears.FirstOrDefault(o =>
            o.LeaseYears_ID == value.LeaseYears_ID);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.PropertyTitle_LeaseYears.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int LeaseYears_ID)
        {
            PropertyTitle_LeaseYears result = db.PropertyTitle_LeaseYears.Where(o => o.LeaseYears_ID == LeaseYears_ID).FirstOrDefault();
            db.PropertyTitle_LeaseYears.Remove(result);
            db.SaveChanges();
                       
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult DeleteLeaseYear(int value) // Original Delete Function Method
        {
            var propertytitles = db.PropertyTitles.Where(o => o.LeaseYears_ID == value).ToList();

            var PropertyTitleLeaseYears = db.PropertyTitle_LeaseYears.FirstOrDefault(o => o.LeaseYears_ID == value);

            var LeaseYearscheck = db.PropertyTitle_LeaseYears.Where(e => (e.Lease_Years == PropertyTitleLeaseYears.Lease_Years) && e.Lease_Years == PropertyTitleLeaseYears.Lease_Years && e.LeaseYears_ID == PropertyTitleLeaseYears.LeaseYears_ID).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

            if (propertytitles.Count > 0 && LeaseYearscheck.Count <= 1)
            {
                return Json("Lease Year cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else
            {
                foreach (var n in propertytitles)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.PropertyTitle_LeaseYears.Remove(PropertyTitleLeaseYears);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CheckLeaseYearCodeNo()
        {
            var data = db.PropertyTitle_LeaseYears.OrderByDescending(o => o.LeaseYears_ID).FirstOrDefault();
            int count = data.LeaseYears_ID;
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLeaseYearsCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var leaseyear = db.PropertyTitle_LeaseYears.ToList();
            return Json(leaseyear, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveLeaseYear(int ID, int? Lease_Years, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                //if (!string.IsNullOrEmpty(LeaseYears))
                //int? valueleaseyear = GetLeaseYears();
                if (Lease_Years != null)
                {
                    //var countcheck = db.PropertyTitle_LeaseYears.FirstOrDefault(e => (e.LeaseYears.Trim() == LeaseYears.Trim() || e.LeaseYears_ID == ID));
                    var countcheck = db.PropertyTitle_LeaseYears.FirstOrDefault(e => (e.Lease_Years == Lease_Years));
                    if (countcheck == null)
                    {
                        PropertyTitle_LeaseYears region = new PropertyTitle_LeaseYears() { LeaseYears_ID = Convert.ToInt16(ID), Lease_Years = Lease_Years };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.PropertyTitle_LeaseYears.Add(region);
                            db.SaveChanges();
                            result = Lease_Years + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }
                    else
                    {
                        result = "This lease year already exists";
                    }
                }
                else
                {
                    result = "Please fill in the lease year";
                }
            }
            else if (_type == 2)
            {
                var userexits = db.PropertyTitle_LeaseYears.FirstOrDefault(e => e.LeaseYears_ID == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.Lease_Years = Lease_Years;
                       
                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = Lease_Years + " was updated successfully";
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

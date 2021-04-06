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
    public class TitleMovementPurposeController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: TitleMovementPurpose
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var TitleMovementPurpose = db.TitleMovement_Purpose.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.datasource = TitleMovementPurpose;

            return View();
        }

        // GET: TitleMovementPurpose/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TitleMovementPurpose/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitleMovementPurpose/Create
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

        // GET: TitleMovementPurpose/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TitleMovementPurpose/Edit/5
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

        // GET: TitleMovementPurpose/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitleMovementPurpose/Delete/5
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


        public ActionResult DialogUpdate(TitleMovement_Purpose value)
        {
            TitleMovement_Purpose table = db.TitleMovement_Purpose.FirstOrDefault(o =>
            o.Purpose_ID == value.Purpose_ID);

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

        public ActionResult DialogInsert(TitleMovement_Purpose value)
        {

            int new_id = ++db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_ID).ToList().Last().Purpose_ID;
            value.Purpose_ID = Convert.ToInt32(new_id);

            TitleMovement_Purpose table = db.TitleMovement_Purpose.FirstOrDefault(o =>
            o.Purpose_ID == value.Purpose_ID);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.TitleMovement_Purpose.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Purpose_ID)
        {
            TitleMovement_Purpose result = db.TitleMovement_Purpose.Where(o => o.Purpose_ID == Purpose_ID).FirstOrDefault();
            db.TitleMovement_Purpose.Remove(result);
            db.SaveChanges();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeletePurpose(int value) // Original Delete Function Method
        {
            var PropertyTitleMovtsummary = db.PropertyTitleMovts.Where(o => o.Purpose_ID == value).ToList();

            var purpose = db.TitleMovement_Purpose.FirstOrDefault(o => o.Purpose_ID == value);

            var purposecheck = db.TitleMovement_Purpose.Where(e => (e.Purpose_Description.Trim() == purpose.Purpose_Description.Trim()) && e.Purpose_Description == purpose.Purpose_Description && e.Purpose_ID == purpose.Purpose_ID).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

            if (PropertyTitleMovtsummary.Count > 0 && purposecheck.Count <= 1)
            {
                return Json("Purpose cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else
            {
                foreach (var n in PropertyTitleMovtsummary)
                {
                    db.PropertyTitleMovts.Remove(n);
                    db.SaveChanges();
                }
                db.TitleMovement_Purpose.Remove(purpose);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CheckPurposeCodeNo()
        {
            int count = 0;
            var data = db.TitleMovement_Purpose.OrderByDescending(o => o.Purpose_ID).FirstOrDefault();
            if (data != null)
            {
                count = data.Purpose_ID;
            }

            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPurposesCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var purpose = db.TitleMovement_Purpose.ToList();
            return Json(purpose, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult SaveCountry(int CountryCode, string CountryName, string NationalityDesc, int _type)
        public ActionResult SavePurpose(int ID, string Purpose_Description,int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (!string.IsNullOrEmpty(Purpose_Description))
                {
                    var countcheck = db.TitleMovement_Purpose.FirstOrDefault(e => (e.Purpose_Description.Trim() == Purpose_Description.Trim() || e.Purpose_ID == ID));
                    if (countcheck == null)
                    {
                        TitleMovement_Purpose region = new TitleMovement_Purpose() { Purpose_ID = Convert.ToInt16(ID), Purpose_Description = Purpose_Description };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.TitleMovement_Purpose.Add(region);
                            db.SaveChanges();
                            result = Purpose_Description + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }
                    else
                    {
                        result = "This movement purpose already exists";
                    }
                }
                else
                {
                    result = "Please fill in the movement purpose";
                }
            }
            else if (_type == 2)
            {
                var userexits = db.TitleMovement_Purpose.FirstOrDefault(e => e.Purpose_ID == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.Purpose_Description = Purpose_Description;
                        

                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = Purpose_Description + " was updated successfully";
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

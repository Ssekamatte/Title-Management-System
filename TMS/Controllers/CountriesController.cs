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
    public class CountriesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Countries
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            //var countries = db.Countries.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            var countries = db.Countries.AsNoTracking().OrderByDescending(a => a.CountryName).ToList();

            ViewBag.datasource = countries;

            return View();

            //return View(db.Countries.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryCode,CountryName,NationalityDesc")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryCode,CountryName,NationalityDesc")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DialogUpdate(Country value)
        {
            Country table = db.Countries.FirstOrDefault(o =>
            o.CountryCode == value.CountryCode);

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

        public ActionResult DialogInsert(Country value)
        {

            int new_id = ++db.Countries.AsNoTracking().OrderBy(a => a.CountryCode).ToList().Last().CountryCode;
            value.CountryCode = Convert.ToInt32(new_id);

            Country table = db.Countries.FirstOrDefault(o =>
            o.CountryCode == value.CountryCode);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.Countries.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int CountryCode)
        {

            Country result = db.Countries.Where(o => o.CountryCode == CountryCode).FirstOrDefault();
            db.Countries.Remove(result);
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


        //public ActionResult DeleteCountry(int value) // Original Delete Function Method
        //{
        //    var CountriesSummary = db.Countries.Where(o => o.CountryCode == value).ToList();

        //    var county = db.Subcounties.FirstOrDefault(o => o.County_ID == value);

        //    var countycheck = db.Subcounties.Where(e => (e.Subcounty_Name.Trim() == county.Subcounty_Name.Trim()) && e.County_ID == county.County_ID && e.County_ID == county.County_ID).ToList();
            
        //    //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();
            
        //    if (CountriesSummary.Count > 0 && countycheck.Count <= 1)
        //    {
        //        return Json("Country cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

        //    }
        //    else
        //    {
        //        foreach (var n in CountriesSummary)
        //        {
        //            db.Countries.Remove(n);
        //            db.SaveChanges();
        //        }
        //        db.Subcounties.Remove(county);
        //        db.SaveChanges();
        //        return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
        //    }

        //}


        public ActionResult DeleteCountry(int value) // Original Delete Function Method
        {
            var applicantsSummary = db.PropertyApplicants.Where(o => o.Nationality == value).ToList();
            var propertytitlesSummary = db.PropertyTitles.Where(o => o.Nationality == value).ToList();

            var country = db.Countries.FirstOrDefault(o => o.CountryCode == value);

            var countrycheck = db.Countries.Where(e => (e.CountryName.Trim() == country.CountryName.Trim()) && e.CountryName == country.CountryName && e.CountryCode == country.CountryCode).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

                if ((applicantsSummary.Count >0 || propertytitlesSummary.Count > 0 ) && countrycheck.Count <= 1)
            {
                return Json("Country cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }

            else if (applicantsSummary.Count <= 0 && countrycheck.Count >= 1)
            {
                foreach (var n in applicantsSummary)
                {
                    db.PropertyApplicants.Remove(n);
                    db.SaveChanges();
                }
                db.Countries.Remove(country);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else
            {
                foreach (var n in propertytitlesSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Countries.Remove(country);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult CheckCountryCodeNo()
        {
            int count = 0;
            var data = db.Countries.OrderByDescending(o => o.CountryCode).FirstOrDefault();
            if (data != null)
            {
                count = data.CountryCode;
            }
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCountriesCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var country = db.Countries.ToList();
            return Json(country, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult SaveCountry(int CountryCode, string CountryName, string NationalityDesc, int _type)
        public ActionResult SaveCountry(int ID, string CountryName, string NationalityDesc, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                //if (!string.IsNullOrEmpty(CountryName))
                if (!string.IsNullOrEmpty(CountryName) && !string.IsNullOrEmpty(NationalityDesc))
                {
                    var countcheck = db.Countries.FirstOrDefault(e => (e.CountryName.Trim() == CountryName.Trim() || e.CountryCode == ID) && e.NationalityDesc == NationalityDesc);
                    if (countcheck == null)
                    {
                        Country region = new Country() { CountryCode = Convert.ToInt16(ID), CountryName = CountryName, NationalityDesc = NationalityDesc };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Countries.Add(region);
                            db.SaveChanges();
                            result = CountryName + " has been saved successfully........";
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

                        //catch (Exception ex)
                        //{
                        //    result = "Error \n" + ex.Message.ToString();
                        //}
                    }
                    else
                    {
                        result = "This Country ( " +CountryName+ " ) already exists";
                    }
                }
                
                else if (string.IsNullOrEmpty(CountryName) && !string.IsNullOrEmpty(NationalityDesc))
                {
                    //result = "Please fill in the County";
                    result = "Please fill in a Country ";
                }

                else if (!string.IsNullOrEmpty(CountryName) && string.IsNullOrEmpty(NationalityDesc))
                {
                    result = "Please fill in a Nationality";
                }

                else
                {
                    result = "Please fill in the Country and Nationality";
                }
                //else
                //{
                //    result = "Please fill in the Country";
                //}
            }
            else if (_type == 2)
            {
                var userexits = db.Countries.FirstOrDefault(e => e.CountryCode == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.CountryName = CountryName;
                        userexits.NationalityDesc = NationalityDesc;
                       
                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = "Nationality for " + CountryName + " has been updated successfully";
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

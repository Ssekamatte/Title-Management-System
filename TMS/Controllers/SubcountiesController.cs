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
    public class SubcountiesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Subcounties
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var subcounties = db.Subcounties.AsNoTracking().ToList();
            ViewBag.datasource = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().ToList();
            ViewBag.Districts = districts;

            db.Configuration.ProxyCreationEnabled = false;
            var counties  = db.Counties.AsNoTracking().ToList();
            ViewBag.counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var DistrictCountySubCounty = db.ViewNewDistrictCountySubCounties.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.DistrictCountySubCounty = DistrictCountySubCounty;

            return View();

            //return View(db.Subcounties.ToList());
        }

        // GET: Subcounties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcounty subcounty = db.Subcounties.Find(id);
            if (subcounty == null)
            {
                return HttpNotFound();
            }
            return View(subcounty);
        }

        // GET: Subcounties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subcounties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subcounty_ID,County_ID,District,Subcounty_Name")] Subcounty subcounty)
        {
            if (ModelState.IsValid)
            {
                db.Subcounties.Add(subcounty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subcounty);
        }

        // GET: Subcounties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcounty subcounty = db.Subcounties.Find(id);
            if (subcounty == null)
            {
                return HttpNotFound();
            }
            return View(subcounty);
        }

        // POST: Subcounties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subcounty_ID,County_ID,District,Subcounty_Name")] Subcounty subcounty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcounty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subcounty);
        }

        // GET: Subcounties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcounty subcounty = db.Subcounties.Find(id);
            if (subcounty == null)
            {
                return HttpNotFound();
            }
            return View(subcounty);
        }

        // POST: Subcounties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcounty subcounty = db.Subcounties.Find(id);
            db.Subcounties.Remove(subcounty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DialogUpdate(Subcounty value)
        {
            Subcounty table = db.Subcounties.FirstOrDefault(o =>
            o.Subcounty_ID == value.Subcounty_ID);

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

        public ActionResult DialogInsert(Subcounty value)
        {

            int new_id = ++db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_ID).ToList().Last().Subcounty_ID;
            value.Subcounty_ID = Convert.ToInt32(new_id);


            Subcounty table = db.Subcounties.FirstOrDefault(o =>
            o.Subcounty_ID == value.Subcounty_ID);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.Subcounties.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Subcounty_ID)
        {

            Subcounty result = db.Subcounties.Where(o => o.Subcounty_ID == Subcounty_ID).FirstOrDefault();
            db.Subcounties.Remove(result);
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

        public ActionResult GetCounty(int District_ID)
        {
            //var result = db.Counties.Where(o => o.District_ID == District_ID).Select(a => new { a.District_ID, a.County_Name }).Distinct().OrderBy(a => a.County_Name).ToList();

            var result = db.Counties.Where(o => o.District_ID == District_ID).Select(a => new { a.County_ID, a.County_Name }).Distinct().OrderBy(a => a.County_Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteSubCounty(int value) // Original Delete Function Method
        {
            var propertytitlesSummary = db.PropertyTitles.Where(o => o.Subcounty_ID == value).ToList();
            var parishSummary = db.Parishes.Where(o => o.Subcounty_ID == value).ToList();
           
            var subcounty = db.Subcounties.FirstOrDefault(o => o.Subcounty_ID == value);

            var subcountycheck = db.Subcounties.Where(e => (e.Subcounty_Name.Trim() == subcounty.Subcounty_Name.Trim()) && e.Subcounty_Name == subcounty.Subcounty_Name && e.Subcounty_ID == subcounty.Subcounty_ID).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();

            if ((propertytitlesSummary.Count > 0 || parishSummary.Count > 0) && subcountycheck.Count <= 1)
            {
                return Json("Subcounty cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
           
            else if (propertytitlesSummary.Count <= 0 && subcountycheck.Count >= 1)
            {
                foreach (var n in propertytitlesSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Subcounties.Remove(subcounty);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else
            {
                foreach (var n in parishSummary)
                {
                    db.Parishes.Remove(n);
                    db.SaveChanges();
                }
                db.Subcounties.Remove(subcounty);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult CheckSubCountyCodeNo()
        {
            int count = 0;
            var data = db.Subcounties.OrderByDescending(o => o.Subcounty_ID).FirstOrDefault();
            if (data != null)
            {
                count = data.Subcounty_ID;
            }

            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubCountiesCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var subcounty = db.Subcounties.ToList();
            return Json(subcounty, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult SaveCountry(int CountryCode, string CountryName, string NationalityDesc, int _type)
        public ActionResult SaveSubCounty(int ID, int? County_ID, int? District,string Subcounty_Name, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                //if (!string.IsNullOrEmpty(Subcounty_Name))
                if (District != null && County_ID != null && !string.IsNullOrEmpty(Subcounty_Name))
                {
                    var countcheck = db.Subcounties.FirstOrDefault(e => (e.Subcounty_Name.Trim() == Subcounty_Name.Trim() || e.Subcounty_ID == ID) && e.District == District && e.County_ID == County_ID);
                    if (countcheck == null)
                    {
                        Subcounty region = new Subcounty() { Subcounty_ID = Convert.ToInt32(ID), Subcounty_Name = Subcounty_Name, District = District, County_ID = County_ID };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Subcounties.Add(region);
                            db.SaveChanges();
                            result = Subcounty_Name + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }

                    else
                    {
                        //result = "This SubCounty already exists";
                        result = "This SubCounty ( " + Subcounty_Name + " ) already exists";
                    }
                }

                else if (District == null && County_ID != null && !string.IsNullOrEmpty(Subcounty_Name))
                {
                    //result = "Please fill in the County";
                    result = "Please select a District ";
                }

                else if (District != null && County_ID == null && !string.IsNullOrEmpty(Subcounty_Name))
                {
                    result = "Please select a County";
                }
                else if (District != null && County_ID != null && string.IsNullOrEmpty(Subcounty_Name))
                {
                    result = "Please fill in a SubCounty";
                }

                else if (District != null && County_ID == null && string.IsNullOrEmpty(Subcounty_Name))
                {
                    result = "Please fill in a County and enter a SubCounty";
                }

                else
                {
                    result = "Please fill in the District ,County and SubCounty";
                }


            }
            else if (_type == 2)
            {
                var userexits = db.Subcounties.FirstOrDefault(e => e.Subcounty_ID == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                                       
                        try
                        {
                            UserManagement user = new UserManagement();
                            userexits.Edited_By = user.getCurrentuser();
                            userexits.Edited_Date = DateTime.Now;

                            userexits.Subcounty_Name = Subcounty_Name;
                            userexits.County_ID = County_ID;
                            userexits.District = District;

                            //context.Entry(userexits).CurrentValues.SetValues(Region);
                            db.Entry(userexits).State = EntityState.Modified;

                            db.SaveChanges();
                            result = Subcounty_Name + " has been updated successfully";
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

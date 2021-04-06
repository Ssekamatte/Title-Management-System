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
    public class RegionController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Region
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            return View();
        }

        public ActionResult Region()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var region = db.Regions.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.datasource = region;

            return View();
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Region/Create
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

        // GET: Region/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Region/Edit/5
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

        // GET: Region/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Region/Delete/5
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


        public ActionResult DeleteRegion(int value) // Original Delete Function Method
        {
            var propertytitleSummary = db.PropertyTitles.Where(o => o.Region_num == value).ToList();
            var DistrictSummary = db.Districts.Where(o => o.Region_code == value).ToList();

            var region = db.Regions.FirstOrDefault(o => o.Region_num == value);

            var regionscheck = db.Regions.Where(e => (e.Region_name.Trim() == region.Region_name.Trim()) && e.Region_name == region.Region_name && e.Region_num == region.Region_num).ToList();

            if ((propertytitleSummary.Count > 0 || DistrictSummary.Count > 0) && regionscheck.Count <= 1)
              
            {
                return Json("Region cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else if (propertytitleSummary.Count <= 0 && regionscheck.Count >= 1)
            {
                foreach (var n in propertytitleSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Regions.Remove(region);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else
            {
                foreach (var n in DistrictSummary)
                {
                    db.Districts.Remove(n);
                    db.SaveChanges();
                }
                db.Regions.Remove(region);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult CheckRegionCodeNo()
        {
            int count = 0;
            var data = db.Regions.OrderByDescending(o => o.Region_num).FirstOrDefault();
            if (data != null)
            {
                count = data.Region_num;
            }

            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRegionCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var regions = db.Regions.ToList();
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveRegion(int ID, string Regionname, int _type)
        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (!string.IsNullOrEmpty(Regionname))
                {
                    var countcheck = db.Regions.FirstOrDefault(e => (e.Region_name.Trim() == Regionname.Trim() || e.Region_num == ID));
                    if (countcheck == null)
                    {
                        Region region = new Region() { Region_num = Convert.ToInt16(ID), Region_name = Regionname };
                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Regions.Add(region);
                            db.SaveChanges();
                            result = Regionname + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }
                    else
                    {
                        result = "This region already exists";
                    }
                }
                else
                {
                    result = "Please fill in the region";
                }
            }
            else if (_type == 2)
            {
                var userexits = db.Regions.FirstOrDefault(e => e.Region_num == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.Region_name = Regionname;


                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = Regionname + " was updated successfully";
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

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
    public class ProjectsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Projects
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var projects = db.Projects.AsNoTracking().OrderByDescending(a => a.Added_Date).ToList();
            ViewBag.datasource = projects;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            return View();
            //return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_id,Project_Desc,NHCC_Codes")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_id,Project_Desc,NHCC_Codes")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DialogUpdate(Project value)
        {
            Project table = db.Projects.FirstOrDefault(o =>
            o.Project_id == value.Project_id);

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

        public ActionResult DialogInsert(Project value)
        {
            int new_id = ++db.Projects.AsNoTracking().OrderBy(a => a.Project_id).ToList().Last().Project_id;
            value.Project_id = Convert.ToInt32(new_id);

            Project table = db.Projects.FirstOrDefault(o =>
            o.Project_id == value.Project_id);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                db.Projects.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Project_id)
        {

            Project result = db.Projects.Where(o => o.Project_id == Project_id).FirstOrDefault();
            db.Projects.Remove(result);
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


        public ActionResult DeleteProject(int value) // Original Delete Function Method
        {
            var propertytitleSummary = db.PropertyTitles.Where(o => o.Project_Code == value).ToList();
            var PropertyTitleMovtSummary = db.PropertyTitleMovts.Where(o => o.Project_Code == value).ToList();
            var Property_PaymentSummary = db.Property_Payment.Where(o => o.Project_Code == value).ToList();

            var project = db.Projects.FirstOrDefault(o => o.Project_id == value);

            var projectcheck = db.Projects.Where(e => (e.Project_Desc.Trim() == project.Project_Desc.Trim()) && e.Project_Desc == project.Project_Desc && e.Project_id == project.Project_id).ToList();

            //var desccheck = context.A_DrugRegimen.Where(e => (e.RegimenDesc.Trim() == regmen.RegimenDesc.Trim()) && e.RegimenClassification == regmen.RegimenClassification && e.RegimenCategoryCode == regmen.RegimenCategoryCode).ToList();


            if ((propertytitleSummary.Count > 0 || PropertyTitleMovtSummary.Count > 0 || Property_PaymentSummary.Count > 0) && projectcheck.Count <= 1)
            {
                return Json("Project cannot be deleted because it is being referenced in other tables", JsonRequestBehavior.AllowGet);

            }
            else if (propertytitleSummary.Count <= 0 && projectcheck.Count >= 1)
            {
                foreach (var n in propertytitleSummary)
                {
                    db.PropertyTitles.Remove(n);
                    db.SaveChanges();
                }
                db.Projects.Remove(project);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }

            else if (PropertyTitleMovtSummary.Count <= 0 && projectcheck.Count >= 1)
            {
                foreach (var n in PropertyTitleMovtSummary)
                {
                    db.PropertyTitleMovts.Remove(n);
                    db.SaveChanges();
                }
                db.Projects.Remove(project);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var n in Property_PaymentSummary)
                {
                    db.Property_Payment.Remove(n);
                    db.SaveChanges();
                }
                db.Projects.Remove(project);
                db.SaveChanges();
                return Json("Successfully deleted", JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult CheckProjectCodeNo()
        {         

            int count = 0;
            var data = db.Projects.OrderByDescending(o => o.Project_id).FirstOrDefault();
            if (data != null)
            {
                count = data.Project_id;
            }
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProjectsCategory()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var project = db.Projects.ToList();
            return Json(project, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult SaveCountry(int CountryCode, string CountryName, string NationalityDesc, int _type)
        public ActionResult SaveProject(int ID, int? Location_id, string Project_Desc, string NHCC_Codes, int _type)

        {
            string result = string.Empty;
            if (_type == 1)
            {
                //if (!string.IsNullOrEmpty(Project_Desc))
                if (Location_id != null && !string.IsNullOrEmpty(Project_Desc) && !string.IsNullOrEmpty(NHCC_Codes))
                {
                    var countcheck = db.Projects.FirstOrDefault(e => (e.Project_Desc.Trim() == Project_Desc.Trim() || e.Project_id == ID) && e.Location_id == Location_id && e.Project_Desc == Project_Desc || e.NHCC_Codes == NHCC_Codes);
                    if (countcheck == null)
                    {
                        Project region = new Project() { Project_id = Convert.ToInt16(ID), Location_id = Convert.ToInt16(Location_id), Project_Desc = Project_Desc, NHCC_Codes = NHCC_Codes };

                        try
                        {
                            UserManagement user = new UserManagement();
                            region.Added_By = user.getCurrentuser();
                            region.Added_Date = DateTime.Now;

                            db.Projects.Add(region);
                            db.SaveChanges();
                            result = Project_Desc + " has been saved successfully........";
                        }
                        catch (Exception ex)
                        {
                            result = "Error \n" + ex.Message.ToString();
                        }
                    }

                    else
                    {
                        result = "This project already exists";
                    }
                }

                else if (Location_id != null && string.IsNullOrEmpty(Project_Desc) && !string.IsNullOrEmpty(NHCC_Codes))

                {
                    //result = "Please fill in the County";
                    result = "Please select a Project Description ";
                }

                else if (Location_id != null && !string.IsNullOrEmpty(Project_Desc) && string.IsNullOrEmpty(NHCC_Codes))

                {
                    result = "Please fill in an NHCC Code for the project";
                }

                else if (Location_id == null && !string.IsNullOrEmpty(Project_Desc) && !string.IsNullOrEmpty(NHCC_Codes))

                {
                    result = "Please select a location for this project";
                }

                else if (Location_id == null && !string.IsNullOrEmpty(Project_Desc) && string.IsNullOrEmpty(NHCC_Codes))

                {
                    result = "Please select a location and NHCC Code for this project";
                }

                else if (Location_id == null && string.IsNullOrEmpty(Project_Desc) && !string.IsNullOrEmpty(NHCC_Codes))

                {
                    result = "Please select a location and Project Description for this project";
                }

                else if (Location_id != null && string.IsNullOrEmpty(Project_Desc) && string.IsNullOrEmpty(NHCC_Codes))

                {
                    //result = "Please fill in the County";
                    result = "Please select a Project Description and NHCC Code ";
                }

                else
                {
                    result = "Please fill in the Location , Project Description and NHCC Codes";
                }
            }
            else if (_type == 2)
            {
                var userexits = db.Projects.FirstOrDefault(e => e.Project_id == ID);
                if (userexits != null)
                {
                    //A_District region = new A_District() { District_Code = DistrictCode, District_Name = DistrictName, CDCRegionId = CDCRegion, ImplimentingPartnerCode = IP, Region_Id = Region, ISO_Code = ISO_Code, District_Ministry_Code = MinistryCode, Is_Urban = IsUban, Is_Municipality = IsMunicipality };
                    try
                    {
                        UserManagement user = new UserManagement();
                        userexits.Edited_By = user.getCurrentuser();
                        userexits.Edited_Date = DateTime.Now;

                        userexits.Location_id = Convert.ToInt32(Location_id);
                        userexits.Project_Desc = Project_Desc;
                        userexits.NHCC_Codes = NHCC_Codes;

                        //context.Entry(userexits).CurrentValues.SetValues(Region);
                        db.Entry(userexits).State = EntityState.Modified;

                        db.SaveChanges();
                        result = Project_Desc + " has been updated successfully";
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

using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System;
using System.Collections;
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
    public class UnlockPropertyTitleMovtsController : Controller
    {
        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: UnlockPropertyTitleMovts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnlockPropertyTitleMovts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitleMovts.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lawyers = db.TitleMovements_Lawyers.AsNoTracking().OrderBy(a => a.Lawyers_Desc).ToList();
            ViewBag.lawyers = Lawyers;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            //var parenttitles = db.PropertyTitleMovts.AsNoTracking().Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            var parenttitles = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.propertytitlesmovts = parenttitles;

            db.Configuration.ProxyCreationEnabled = false;
            //var volumes = db.PropertyTitleMovts.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            var volumes = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            //var folios = db.PropertyTitleMovts.AsNoTracking().Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            var folios = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();

            ViewBag.propertytitlesfolios = folios;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitles = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.PropertyTitles = PropertyTitles;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

           
            return View();

        }

        public ActionResult UnlockPropertyTitleMovtsAdmin()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitleMovts.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lawyers = db.TitleMovements_Lawyers.AsNoTracking().OrderBy(a => a.Lawyers_Desc).ToList();
            ViewBag.lawyers = Lawyers;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            //var parenttitles = db.PropertyTitleMovts.AsNoTracking().Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            var parenttitles = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.propertytitlesmovts = parenttitles;

            db.Configuration.ProxyCreationEnabled = false;
            //var volumes = db.PropertyTitleMovts.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            var volumes = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            //var folios = db.PropertyTitleMovts.AsNoTracking().Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            var folios = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();

            ViewBag.propertytitlesfolios = folios;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitles = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.PropertyTitles = PropertyTitles;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;


            return View();

        }
        // GET: UnlockPropertyTitleMovts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnlockPropertyTitleMovts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnlockPropertyTitleMovts/Create
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

        // GET: UnlockPropertyTitleMovts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnlockPropertyTitleMovts/Edit/5
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

        // GET: UnlockPropertyTitleMovts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnlockPropertyTitleMovts/Delete/5
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


        public ActionResult DataSourcePropertyTitleMovement(DataManager dm)
        {

            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList().Count();

                DataOperations operation = new DataOperations();
                //Performing filtering operation
                if (dm.Where != null)
                {
                    data = operation.PerformWhereFilter(data, dm.Where, "and");
                    var filtered = (IEnumerable<object>)data;
                    count = filtered.Count();
                }

                //Performing search operation
                if (dm.Search != null)
                {
                    data = operation.PerformSearching(data, dm.Search);
                    var searched = (IEnumerable<object>)data;
                    count = searched.Count();
                }
                //Performing sorting operation
                if (dm.Sorted != null)
                    data = operation.PerformSorting(data, dm.Sorted);

                //Performing paging operations
                if (dm.Skip != 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take != 0)
                    data = operation.PerformTake(data, dm.Take);

                return Json(new { result = data, count = count }, JsonRequestBehavior.AllowGet);

            }
            else 
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

                DataOperations operation = new DataOperations();
                //Performing filtering operation
                if (dm.Where != null)
                {
                    data = operation.PerformWhereFilter(data, dm.Where, "and");
                    var filtered = (IEnumerable<object>)data;
                    count = filtered.Count();
                }

                //Performing search operation
                if (dm.Search != null)
                {
                    data = operation.PerformSearching(data, dm.Search);
                    var searched = (IEnumerable<object>)data;
                    count = searched.Count();
                }
                //Performing sorting operation
                if (dm.Sorted != null)
                    data = operation.PerformSorting(data, dm.Sorted);

                //Performing paging operations
                if (dm.Skip != 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take != 0)
                    data = operation.PerformTake(data, dm.Take);

                return Json(new { result = data, count = count }, JsonRequestBehavior.AllowGet);

            }

        }
       
        public JsonResult GetPurposeData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TitleMovement_Purpose.AsNoTracking().Where(a => a.Purpose_ID == 6).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDestinationData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.DestinationTypes.AsNoTracking().Where(a => a.DestinyCode == 1).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTitleMovementStatus()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.PropertyTitle_Payment_Status.AsNoTracking().Where(a => a.Status_ID == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetParent_Title(int Location_id)
        {
            var result = db.PropertyTitles.Where(o => o.Location_id == Location_id).Select(a => new { a.Location_id, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVolume(string Title_Reference)
        {
            //var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference).Select(a => new { a.Title_Reference, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference).Select(a => new { a.Title_Reference, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFolio(string Title_Reference, string Volume)
        {
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference && o.Volume == Volume).Select(a => new { a.Title_Reference, a.Volume, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectCode(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        {
            //var result = db.PropertyTitles.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new {a.Location_id, a.Title_Reference, a.Volume, a.Folio,a.Project_Code, a.Project_Desc }).Distinct().OrderBy
            //    (/*a => a.Project_Code*/a => a.Project_Desc).ToList();  //For Ordering by Project Description

            var result = db.ViewPropertyTitlesTables.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.Location_id, a.Title_Reference, a.Volume, a.Folio, a.Project_Code, a.ProjectDesc }).Distinct().OrderBy
                (/*a => a.Project_Code*/a => a.ProjectDesc).ToList();  //For Ordering by Project Code

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DialogUpdate(PropertyTitleMovt value)
        {
            PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
             o.Project_Code == value.Project_Code && o.Movt_Serial_No == value.Movt_Serial_No && o.Volume == value.Volume &&
             o.Folio == value.Folio);

            if (table != null)
            {
                UserManagement user = new UserManagement();
                value.Edited_By = user.getCurrentuser();
                value.Edited_Date = DateTime.Now;

                value.TitleMovementStatusID = 1;
                value.FinalSubmission = false;
                value.UnlockTitle = false;

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

        public ActionResult DialogInsert(PropertyTitleMovt value)
        {

            PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
             o.Project_Code == value.Project_Code && o.Movt_Serial_No == value.Movt_Serial_No && o.Volume == value.Volume &&
             o.Folio == value.Folio);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                value.TitleMovementStatusID = 1;
                value.FinalSubmission = false;
                value.UnlockTitle = false;

                db.PropertyTitleMovts.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Project_Code)
        {

            PropertyTitleMovt result = db.PropertyTitleMovts.Where(o => o.Project_Code == Project_Code).FirstOrDefault();
            db.PropertyTitleMovts.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveUnlockTitleMovement(int? Location_id, int? Project_Code, string Title_Reference, bool? Ooutward, string Volume, int? Folio,
           string Movt_Serial_No, bool? TransferInNHCC, DateTime? Movement_Date, DateTime? Return_Date, int? Dest_Category, int? Purpose_ID,
           bool? Additional, string Additional_Information, string FlatNo, string PlotNo, string UnitNo, string Destination_Address,
           string LawyersNames, string Remark, string Directors, string RejectionComment, string UnlockComment, string Added_By, 
           DateTime? Added_Date,decimal? Latitude, decimal? Longitude, int _type)

        {
            string result = string.Empty;
            if (_type == 1)
            {

                if (Location_id == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
              || string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
              || Folio == null || Movt_Serial_No == null || Dest_Category == null || Purpose_ID == null)

                {
                    result = "Fields marked with asterisk (*) are required!";
                }
                else
                {
                    var unltitlemvtcheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Project_Code == Project_Code && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var unltitlemvtcheckprimkeycheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Folio == Folio && e.Volume.Trim() == Volume.Trim()));

                    if (unltitlemvtcheck == null && unltitlemvtcheckprimkeycheck == null)
                    {
                        PropertyTitleMovt unlockproptitlemovt = new PropertyTitleMovt() { Location_id = Convert.ToInt32(Location_id), Movt_Serial_No = Movt_Serial_No, Volume = Volume, Folio = Convert.ToInt32(Folio), Title_Reference = Title_Reference };

                        AuditLog_PropertyTitleMovt unlockproptitlemovtlog = new AuditLog_PropertyTitleMovt() { original_Locationid = Convert.ToInt32(Location_id), original_Movt_Serial_No = Movt_Serial_No, original_Volume = Volume, original_Folio = Convert.ToInt32(Folio), original_Title_Reference = Title_Reference };

                        try

                        {

                            //PropertyTitleMovt unlockproptitlemovt = new PropertyTitleMovt();
                            UserManagement user = new UserManagement();
                            unlockproptitlemovt.Added_By = user.getCurrentuser();
                            unlockproptitlemovt.Added_Date = DateTime.Now;

                            unlockproptitlemovt.TitleMovementStatusID = 1;
                            unlockproptitlemovt.FinalSubmission = false;
                            unlockproptitlemovt.UnlockTitle = false;

                            unlockproptitlemovt.Location_id = Convert.ToInt32(Location_id);
                            unlockproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);
                            unlockproptitlemovt.Title_Reference = Title_Reference;
                            unlockproptitlemovt.Volume = Volume;
                            unlockproptitlemovt.Folio = Convert.ToInt32(Folio);
                            unlockproptitlemovt.TransferInNHCC = TransferInNHCC;
                            unlockproptitlemovt.Movt_Serial_No = Movt_Serial_No;
                            unlockproptitlemovt.Movement_Date = Movement_Date;
                            unlockproptitlemovt.Return_Date = Return_Date;
                            unlockproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            unlockproptitlemovt.Purpose_ID = Purpose_ID;
                            unlockproptitlemovt.Additional = Additional;
                            unlockproptitlemovt.Additional_Information = Additional_Information;
                            unlockproptitlemovt.FlatNo = FlatNo;
                            unlockproptitlemovt.PlotNo = PlotNo;
                            unlockproptitlemovt.UnitNo = UnitNo;
                            unlockproptitlemovt.Destination_Address = Destination_Address;
                            unlockproptitlemovt.LawyersNames = LawyersNames;
                            unlockproptitlemovt.Ooutward = Ooutward;
                            unlockproptitlemovt.Directors = Directors;
                            unlockproptitlemovt.Remark = Remark;
                            unlockproptitlemovt.RejectionComment = RejectionComment;
                            unlockproptitlemovt.UnlockComment = UnlockComment;
                            unlockproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            unlockproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                            
                            //Audit Log Table Save

                            unlockproptitlemovtlog.original_Added_By = user.getCurrentuser();
                            unlockproptitlemovtlog.original_Added_Date = DateTime.Now;

                            unlockproptitlemovtlog.original_TitleMovementStatusID = 1;
                            unlockproptitlemovtlog.original_FinalSubmission = false;
                            unlockproptitlemovtlog.original_UnlockTitle = false;

                            unlockproptitlemovtlog.original_Locationid = Convert.ToInt32(Location_id);
                            unlockproptitlemovtlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            unlockproptitlemovtlog.original_Title_Reference = Title_Reference;
                            unlockproptitlemovtlog.original_Volume = Volume;
                            unlockproptitlemovtlog.original_Folio = Convert.ToInt32(Folio);
                            unlockproptitlemovtlog.original_TransferInNHCC = TransferInNHCC;
                            unlockproptitlemovtlog.original_Movt_Serial_No = Movt_Serial_No;
                            unlockproptitlemovtlog.original_Movement_Date = Movement_Date;
                            unlockproptitlemovtlog.original_Return_Date = Return_Date;
                            unlockproptitlemovtlog.original_Dest_Category = Convert.ToInt32(Dest_Category);
                            unlockproptitlemovtlog.original_Purpose_ID = Purpose_ID;
                            unlockproptitlemovtlog.original_Additional = Additional;
                            unlockproptitlemovtlog.original_Additional_Information = Additional_Information;
                            unlockproptitlemovtlog.original_FlatNo = FlatNo;
                            unlockproptitlemovtlog.original_PlotNo = PlotNo;
                            unlockproptitlemovtlog.original_UnitNo = UnitNo;
                            unlockproptitlemovtlog.original_Destination_Address = Destination_Address;
                            unlockproptitlemovtlog.original_LawyersNames = LawyersNames;
                            unlockproptitlemovtlog.original_Ooutward = Ooutward;
                            unlockproptitlemovtlog.original_Directors = Directors;
                            unlockproptitlemovtlog.original_Remark = Remark;
                            unlockproptitlemovtlog.original_Latitude = Convert.ToDouble(Latitude);
                            unlockproptitlemovtlog.original_Longitude = Convert.ToDouble(Longitude);
                            unlockproptitlemovtlog.original_RejectionComment = RejectionComment;
                            unlockproptitlemovtlog.original_UnlockComment = UnlockComment;

                            db.PropertyTitleMovts.Add(unlockproptitlemovt);
                            db.AuditLog_PropertyTitleMovt.Add(unlockproptitlemovtlog);
                            db.SaveChanges();

                            result = "Record saved successfully......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }


                    else if (unltitlemvtcheck == null && unltitlemvtcheckprimkeycheck != null)                        
                    {

                        result = "Title with the same Location,Volume and Folio arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both freeholdtitlecheck and freeholdprimkeycheck are not null

                    {
                        result = "This title arleady exists in the database (Record not saved)";

                    }

                }
            }

            else if (_type == 2)
            {

                if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null") ||
                     Dest_Category == null || Purpose_ID == null)

                {
                    result = "Please enter a Parent Title (Title Reference)!";
                }

                else
                {
                    var editunlockproptitlemovt = db.PropertyTitleMovts.FirstOrDefault(e => e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Volume == Volume && e.Folio == Folio);

                    var editunlockproptitlemovtlog = db.AuditLog_PropertyTitleMovt.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Movt_Serial_No == Movt_Serial_No && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editunlockproptitlemovt != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editunlockproptitlemovt.Edited_By = user.getCurrentuser();
                            editunlockproptitlemovt.Edited_Date = DateTime.Now;

                            editunlockproptitlemovt.TitleMovementStatusID = 1;
                            editunlockproptitlemovt.FinalSubmission = false;
                            editunlockproptitlemovt.UnlockTitle = false;

                            editunlockproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);
                            editunlockproptitlemovt.Title_Reference = Title_Reference;
                            editunlockproptitlemovt.RejectionComment = RejectionComment;
                            editunlockproptitlemovt.UnlockComment = UnlockComment;

                            editunlockproptitlemovt.TransferInNHCC = TransferInNHCC;
                            editunlockproptitlemovt.Movement_Date = Movement_Date;
                            editunlockproptitlemovt.Return_Date = Return_Date;
                            editunlockproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            editunlockproptitlemovt.Purpose_ID = Purpose_ID;
                            editunlockproptitlemovt.Additional = Additional;
                            editunlockproptitlemovt.Additional_Information = Additional_Information;
                            editunlockproptitlemovt.FlatNo = FlatNo;
                            editunlockproptitlemovt.PlotNo = PlotNo;
                            editunlockproptitlemovt.UnitNo = UnitNo;
                            editunlockproptitlemovt.Destination_Address = Destination_Address;
                            editunlockproptitlemovt.LawyersNames = LawyersNames;
                            editunlockproptitlemovt.Ooutward = Ooutward;
                            editunlockproptitlemovt.Directors = Directors;
                            editunlockproptitlemovt.Remark = Remark;
                            editunlockproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            editunlockproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                            editunlockproptitlemovt.Added_By = Added_By;
                            editunlockproptitlemovt.Added_Date = Added_Date;

                            //Audit Log Table Save
                            editunlockproptitlemovtlog.original_Edited_By = user.getCurrentuser();
                            editunlockproptitlemovtlog.original_Edited_Date = DateTime.Now;

                            editunlockproptitlemovtlog.new_TitleMovementStatusID = 1;
                            editunlockproptitlemovtlog.new_FinalSubmission = false;
                            editunlockproptitlemovtlog.new_UnlockTitle = false;
                            editunlockproptitlemovtlog.new_Locationid = Convert.ToInt32(Location_id);
                            editunlockproptitlemovtlog.new_Volume = Volume;
                            editunlockproptitlemovtlog.new_Folio = Convert.ToInt32(Folio);
                            editunlockproptitlemovtlog.new_Movt_Serial_No = Movt_Serial_No;
                            editunlockproptitlemovtlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editunlockproptitlemovtlog.new_Title_Reference = Title_Reference;
                            editunlockproptitlemovtlog.new_RejectionComment = RejectionComment;
                            editunlockproptitlemovtlog.new_UnlockComment = UnlockComment;
                            editunlockproptitlemovtlog.new_TransferInNHCC = TransferInNHCC;
                            editunlockproptitlemovtlog.new_Movement_Date = Movement_Date;
                            editunlockproptitlemovtlog.new_Return_Date = Return_Date;
                            editunlockproptitlemovtlog.new_Dest_Category = Convert.ToInt32(Dest_Category);
                            editunlockproptitlemovtlog.new_Purpose_ID = Purpose_ID;
                            editunlockproptitlemovtlog.new_Additional = Additional;
                            editunlockproptitlemovtlog.new_Additional_Information = Additional_Information;
                            editunlockproptitlemovtlog.new_FlatNo = FlatNo;
                            editunlockproptitlemovtlog.new_PlotNo = PlotNo;
                            editunlockproptitlemovtlog.new_UnitNo = UnitNo;
                            editunlockproptitlemovtlog.new_Destination_Address = Destination_Address;
                            editunlockproptitlemovtlog.new_LawyersNames = LawyersNames;
                            editunlockproptitlemovtlog.new_Ooutward = Ooutward;
                            editunlockproptitlemovtlog.new_Directors = Directors;
                            editunlockproptitlemovtlog.new_Remark = Remark;
                            editunlockproptitlemovtlog.new_Added_By = Added_By;
                            editunlockproptitlemovtlog.new_Added_Date = Added_Date;
                            editunlockproptitlemovtlog.new_Latitude = Convert.ToDouble(Latitude);
                            editunlockproptitlemovtlog.new_Longitude = Convert.ToDouble(Longitude);

                            db.Entry(editunlockproptitlemovt).CurrentValues.SetValues(editunlockproptitlemovt);
                            db.Entry(editunlockproptitlemovt).State = EntityState.Modified;
                            db.Entry(editunlockproptitlemovtlog).CurrentValues.SetValues(editunlockproptitlemovtlog);
                            db.Entry(editunlockproptitlemovtlog).State = EntityState.Modified;

                            db.SaveChanges();

                            result = Title_Reference.Trim() + " is updated successfully";
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
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public FileResult EvidenceDownloadFile(string DocumentCode)
        {
            byte[] bytes = null;
            string fileName = string.Empty, contentType = string.Empty;
            var file = db.A_DocumentUpload.FirstOrDefault(o => o.DocumentCode == DocumentCode);
            if (file != null)
            {
                bytes = file.DocumentFile;
                fileName = file.DocumentName;
                contentType = file.FileType;
                return File(bytes, contentType, fileName);
            }
            return null;
        }


    }
}

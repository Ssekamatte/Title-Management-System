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
    public class RejectedPropertyTitleMovtsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        // GET: RejectedPropertyTitleMovts
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Destinations = db.DestinationTypes.AsNoTracking().ToList();
            ViewBag.DestinationTypes = Destinations;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitleMovts = db.PropertyTitleMovts.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovts = PropertyTitleMovts;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitles = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.PropertyTitless = PropertyTitles;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;           
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        public ActionResult RejectedpropertyTitleMovtsAdmin()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Destinations = db.DestinationTypes.AsNoTracking().ToList();
            ViewBag.DestinationTypes = Destinations;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitleMovts = db.PropertyTitleMovts.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovts = PropertyTitleMovts;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitles = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.PropertyTitless = PropertyTitles;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        // GET: RejectedPropertyTitleMovts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RejectedPropertyTitleMovts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RejectedPropertyTitleMovts/Create
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

        // GET: RejectedPropertyTitleMovts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RejectedPropertyTitleMovts/Edit/5
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

        // GET: RejectedPropertyTitleMovts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RejectedPropertyTitleMovts/Delete/5
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


        public ActionResult DataSourceRejectedPropertyTitleMovts(DataManager dm)
        {
            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
            else {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && b.Added_By == user)).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && b.Added_By == user)).OrderByDescending(a => a.Added_Date).ToList().Count();

                //&& (b.Added_By = user.getCurrentuser)

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

        public ActionResult DialogUpdate(PropertyTitleMovt value)
        {
            PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.Volume == value.Volume &&
            o.Folio == value.Folio && o.Movt_Serial_No == value.Movt_Serial_No);

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
            else
            {
                this.DialogInsert(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogInsert(PropertyTitleMovt value)
        {
            PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.Volume == value.Volume &&
            o.Folio == value.Folio && o.Movt_Serial_No == value.Movt_Serial_No);

          

            if (table == null)
            {
                try
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

        public JsonResult GetDestinationData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.DestinationTypes.AsNoTracking().Where(a => a.DestinyCode == 1).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurposeData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TitleMovement_Purpose.AsNoTracking().Where(a => a.Purpose_ID == 6).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProjectCode(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        {           
            var result = db.ViewPropertyTitlesTables.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.Location_id, a.Title_Reference, a.Volume, a.Folio, a.Project_Code, a.ProjectDesc }).Distinct().OrderBy
                (/*a => a.Project_Code*/a => a.ProjectDesc).ToList();  //For Ordering by Project Code
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveRejTitleMovement(int? Location_id, int? Project_Code, string Title_Reference, bool? Ooutward, string Volume, int? Folio,
          string Movt_Serial_No, bool? TransferInNHCC, DateTime? Movement_Date, DateTime? Return_Date, int? Dest_Category, int? Purpose_ID,
          bool? Additional, string Additional_Information, string FlatNo, string PlotNo, string UnitNo, string Destination_Address,
          string LawyersNames, string Remark, string Directors, string RejectionComment,string UnlockComment, string Added_By, 
          DateTime? Added_Date, decimal? Latitude, decimal? Longitude, int _type)

        {
            string result = string.Empty;
            if (_type == 1)
            {

              //  if (Location_id == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
              //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
              //|| Folio == null || Movt_Serial_No == null || Dest_Category == null || Purpose_ID == null)

              //  {
              //      result = "Fields marked with asterisk (*) are required!";
                //}

                //else
                //{
                    var rejtitlemvtcheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Project_Code == Project_Code && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var rejtitlemvtcheckprimkeycheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Folio == Folio && e.Volume.Trim() == Volume.Trim()));

                    if (rejtitlemvtcheck == null && rejtitlemvtcheckprimkeycheck == null)

                    {
                        PropertyTitleMovt saverejproptitlemovt = new PropertyTitleMovt() { Location_id = Convert.ToInt32(Location_id), Movt_Serial_No = Movt_Serial_No, Volume = Volume, Folio = Convert.ToInt32(Folio), Title_Reference = Title_Reference };

                        AuditLog_PropertyTitleMovt saverejproptitlemovtlog = new AuditLog_PropertyTitleMovt() { original_Locationid = Convert.ToInt32(Location_id), original_Movt_Serial_No = Movt_Serial_No, original_Volume = Volume, original_Folio = Convert.ToInt32(Folio), original_Title_Reference = Title_Reference };
                        
                        try
                        {
                            //PropertyTitleMovt saverejproptitlemovt = new PropertyTitleMovt();
                            UserManagement user = new UserManagement();
                            saverejproptitlemovt.Added_By = user.getCurrentuser();
                            saverejproptitlemovt.Added_Date = DateTime.Now;

                            saverejproptitlemovt.TitleMovementStatusID = 1;
                            saverejproptitlemovt.FinalSubmission = false;
                            saverejproptitlemovt.UnlockTitle = false;

                            saverejproptitlemovt.Location_id = Convert.ToInt32(Location_id);
                            saverejproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);

                            saverejproptitlemovt.Title_Reference = Title_Reference;
                            saverejproptitlemovt.Volume = Volume;
                            saverejproptitlemovt.Folio = Convert.ToInt32(Folio);
                            saverejproptitlemovt.TransferInNHCC = TransferInNHCC;
                            saverejproptitlemovt.Movt_Serial_No = Movt_Serial_No;
                            saverejproptitlemovt.Movement_Date = Movement_Date;
                            saverejproptitlemovt.Return_Date = Return_Date;
                            saverejproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            saverejproptitlemovt.Purpose_ID = Purpose_ID;
                            saverejproptitlemovt.Additional = Additional;
                            saverejproptitlemovt.Additional_Information = Additional_Information;
                            saverejproptitlemovt.FlatNo = FlatNo;
                            saverejproptitlemovt.PlotNo = PlotNo;
                            saverejproptitlemovt.UnitNo = UnitNo;
                            saverejproptitlemovt.Destination_Address = Destination_Address;
                            saverejproptitlemovt.LawyersNames = LawyersNames;
                            saverejproptitlemovt.Ooutward = Ooutward;
                            saverejproptitlemovt.Directors = Directors;
                            saverejproptitlemovt.Remark = Remark;
                            saverejproptitlemovt.RejectionComment = RejectionComment;
                            saverejproptitlemovt.UnlockComment = UnlockComment;
                            saverejproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            saverejproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                            //Audit Log Table Save

                            saverejproptitlemovtlog.original_Added_By = user.getCurrentuser();
                            saverejproptitlemovtlog.original_Added_Date = DateTime.Now;

                            saverejproptitlemovtlog.original_TitleMovementStatusID = 1;
                            saverejproptitlemovtlog.original_FinalSubmission = false;
                            saverejproptitlemovtlog.original_UnlockTitle = false;

                            saverejproptitlemovtlog.original_Locationid = Convert.ToInt32(Location_id);
                            saverejproptitlemovtlog.original_Project_Code = Convert.ToInt32(Project_Code);

                            saverejproptitlemovtlog.original_Title_Reference = Title_Reference;
                            saverejproptitlemovtlog.original_Volume = Volume;
                            saverejproptitlemovtlog.original_Folio = Convert.ToInt32(Folio);
                            saverejproptitlemovtlog.original_TransferInNHCC = TransferInNHCC;
                            saverejproptitlemovtlog.original_Movt_Serial_No = Movt_Serial_No;
                            saverejproptitlemovtlog.original_Movement_Date = Movement_Date;
                            saverejproptitlemovtlog.original_Return_Date = Return_Date;
                            saverejproptitlemovtlog.original_Dest_Category = Convert.ToInt32(Dest_Category);
                            saverejproptitlemovtlog.original_Purpose_ID = Purpose_ID;
                            saverejproptitlemovtlog.original_Additional = Additional;
                            saverejproptitlemovtlog.original_Additional_Information = Additional_Information;
                            saverejproptitlemovtlog.original_FlatNo = FlatNo;
                            saverejproptitlemovtlog.original_PlotNo = PlotNo;
                            saverejproptitlemovtlog.original_UnitNo = UnitNo;
                            saverejproptitlemovtlog.original_Destination_Address = Destination_Address;
                            saverejproptitlemovtlog.original_LawyersNames = LawyersNames;
                            saverejproptitlemovtlog.original_Ooutward = Ooutward;
                            saverejproptitlemovtlog.original_Directors = Directors;
                            saverejproptitlemovtlog.original_Remark = Remark;
                            saverejproptitlemovtlog.original_RejectionComment = RejectionComment;
                            saverejproptitlemovtlog.original_UnlockComment = UnlockComment;
                            saverejproptitlemovtlog.original_Latitude = Convert.ToDouble(Latitude);
                            saverejproptitlemovtlog.original_Longitude = Convert.ToDouble(Longitude);
                            db.PropertyTitleMovts.Add(saverejproptitlemovt);
                            db.AuditLog_PropertyTitleMovt.Add(saverejproptitlemovtlog);
                            
                            db.SaveChanges();

                            result = "Record Saved Successfully......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (rejtitlemvtcheck == null && rejtitlemvtcheckprimkeycheck != null)
                       
                    {
                        //result = "This title arleady exists in the database (Record not saved)";
                        result = "Title with the same Location,Movement Serial Number,Folio and Volume arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both paycheck and paycheckprimkeycheck are not null

                    {
                        result = "Title movement on (" + Title_Reference + ") has arleady been performed in the database (Record not saved)";
                    }

                //}
            }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null") ||
                //     Dest_Category == null || Purpose_ID == null)

                //{
                //    result = "Please enter a Parent Title (Title Reference)!";
                //}

                //else
                //{
                    var editsaverejproptitlemovt = db.PropertyTitleMovts.FirstOrDefault(e => e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Volume == Volume && e.Folio == Folio);

                    var editsaverejproptitlemovtlog = db.AuditLog_PropertyTitleMovt.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Movt_Serial_No == Movt_Serial_No && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editsaverejproptitlemovt != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editsaverejproptitlemovt.Edited_By = user.getCurrentuser();
                            editsaverejproptitlemovt.Edited_Date = DateTime.Now;

                            editsaverejproptitlemovt.TitleMovementStatusID = 1;
                            editsaverejproptitlemovt.FinalSubmission = false;
                            editsaverejproptitlemovt.UnlockTitle = false;

                            editsaverejproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);
                            editsaverejproptitlemovt.Title_Reference = Title_Reference;

                            
                            editsaverejproptitlemovt.TransferInNHCC = TransferInNHCC;
                            editsaverejproptitlemovt.Movement_Date = Movement_Date;
                            editsaverejproptitlemovt.Return_Date = Return_Date;
                            editsaverejproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            editsaverejproptitlemovt.Purpose_ID = Purpose_ID;
                            editsaverejproptitlemovt.Additional = Additional;
                            editsaverejproptitlemovt.Additional_Information = Additional_Information;
                            editsaverejproptitlemovt.FlatNo = FlatNo;
                            editsaverejproptitlemovt.PlotNo = PlotNo;
                            editsaverejproptitlemovt.UnitNo = UnitNo;
                            editsaverejproptitlemovt.Destination_Address = Destination_Address;
                            editsaverejproptitlemovt.LawyersNames = LawyersNames;
                            editsaverejproptitlemovt.Ooutward = Ooutward;
                            editsaverejproptitlemovt.Directors = Directors;
                            editsaverejproptitlemovt.Remark = Remark;

                            editsaverejproptitlemovt.RejectionComment = RejectionComment;
                            editsaverejproptitlemovt.UnlockComment = UnlockComment;
                            editsaverejproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            editsaverejproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                            editsaverejproptitlemovt.Added_By = Added_By;
                            editsaverejproptitlemovt.Added_Date = Added_Date;

                            //Audit Log Table Save

                            editsaverejproptitlemovtlog.original_Edited_By = user.getCurrentuser();
                            editsaverejproptitlemovtlog.original_Edited_Date = DateTime.Now;

                            editsaverejproptitlemovtlog.new_TitleMovementStatusID = 1;
                            editsaverejproptitlemovtlog.new_FinalSubmission = false;
                            editsaverejproptitlemovtlog.new_UnlockTitle = false;

                            editsaverejproptitlemovtlog.new_Locationid = Convert.ToInt32(Location_id);
                            editsaverejproptitlemovtlog.new_Volume = Volume;
                            editsaverejproptitlemovtlog.new_Folio = Convert.ToInt32(Folio);

                            editsaverejproptitlemovtlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editsaverejproptitlemovtlog.new_Title_Reference = Title_Reference;
                            editsaverejproptitlemovtlog.new_TransferInNHCC = TransferInNHCC;
                            editsaverejproptitlemovtlog.new_Movement_Date = Movement_Date;
                            editsaverejproptitlemovtlog.new_Return_Date = Return_Date;
                            editsaverejproptitlemovtlog.new_Dest_Category = Convert.ToInt32(Dest_Category);
                            editsaverejproptitlemovtlog.new_Purpose_ID = Purpose_ID;
                            editsaverejproptitlemovtlog.new_Additional = Additional;
                            editsaverejproptitlemovtlog.new_Additional_Information = Additional_Information;
                            editsaverejproptitlemovtlog.new_FlatNo = FlatNo;
                            editsaverejproptitlemovtlog.new_PlotNo = PlotNo;
                            editsaverejproptitlemovtlog.new_UnitNo = UnitNo;
                            editsaverejproptitlemovtlog.new_Destination_Address = Destination_Address;
                            editsaverejproptitlemovtlog.new_LawyersNames = LawyersNames;
                            editsaverejproptitlemovtlog.new_Ooutward = Ooutward;
                            editsaverejproptitlemovtlog.new_Directors = Directors;
                            editsaverejproptitlemovtlog.new_Remark = Remark;
                            editsaverejproptitlemovtlog.original_RejectionComment = RejectionComment;
                            editsaverejproptitlemovtlog.original_UnlockComment = UnlockComment;
                            editsaverejproptitlemovtlog.new_Latitude = Convert.ToDouble(Latitude);
                            editsaverejproptitlemovtlog.new_Longitude = Convert.ToDouble(Longitude);

                            editsaverejproptitlemovtlog.new_Added_By = Added_By;
                            editsaverejproptitlemovtlog.new_Added_Date = Added_Date;

                            db.Entry(editsaverejproptitlemovt).CurrentValues.SetValues(editsaverejproptitlemovt);
                            db.Entry(editsaverejproptitlemovt).State = EntityState.Modified;

                            db.Entry(editsaverejproptitlemovtlog).CurrentValues.SetValues(editsaverejproptitlemovtlog);
                            db.Entry(editsaverejproptitlemovtlog).State = EntityState.Modified;

                            db.SaveChanges();
                           
                            result = "Action on " + Title_Reference.Trim() + " is applied successfully";


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
                //}
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

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
using System.Web;
using System.Web.Mvc;
using TMS.Models;


namespace TMS.Controllers
{
    public class ApprovedPropertyTitleMovtsControllerController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApprovedPropertyTitleMovtsController
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Destinations = db.DestinationTypes.AsNoTracking().ToList();
            ViewBag.DestinationTypes = Destinations;

            // db.Configuration.ProxyCreationEnabled = false;
            //// var Outwards = db.Outwards.AsNoTracking().ToList();
            // var Outwards = db.Outwards.AsNoTracking().OrderBy(a => a.Outward_Description).ToList();
            // ViewBag.Outwards = Outwards;

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
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;


            return View();

        }

        public ActionResult ApprovedPropertyTitleMovtsCEO()
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
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;
            return View();

        }

        // GET: ApprovedPropertyTitleMovtsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApprovedPropertyTitleMovtsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedPropertyTitleMovtsController/Create
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

        // GET: ApprovedPropertyTitleMovtsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApprovedPropertyTitleMovtsController/Edit/5
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

        // GET: ApprovedPropertyTitleMovtsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApprovedPropertyTitleMovtsController/Delete/5
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


        public ActionResult DataSourceApprovedPropertyTitleMovts(DataManager dm)
        {

            //Returns all the fields in the table based on the Title Movement Status ID

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false))).ToList().Count();



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

                //value.UnlockTitle = false;

                //value.PropertyPaymentStatusID = 1;
                //value.FinalSubmission = false;

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

                //value.UnlockTitle = false;

                db.PropertyTitleMovts.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Project_Code,string Movt_Serial_No,int Folio,string Volume)
        {

            PropertyTitleMovt result = db.PropertyTitleMovts.Where(o => o.Project_Code == Project_Code && o.Movt_Serial_No == Movt_Serial_No
            && o.Folio == Folio && o.Volume == Volume).FirstOrDefault();
            db.PropertyTitleMovts.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveapprovedTitleMovement(int? Location_id, string Title_Reference,int? Project_Code, bool? Ooutward, string Volume, int? Folio,
          string Movt_Serial_No, bool? TransferInNHCC, DateTime? Movement_Date, DateTime? Return_Date, int? Dest_Category, int? Purpose_ID,
          bool? Additional, string Additional_Information, string FlatNo, string PlotNo, string UnitNo, string Destination_Address,
          string LawyersNames, string Remark, string Directors, string RejectionComment, bool? FinalSubmission,
          int? TitleMovementStatusID, string UnlockComment, string Added_By, DateTime? Added_Date, int _type, bool? UnlockTitle, decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

              //  if (Location_id == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
              //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
              //|| Folio == null || Movt_Serial_No == null || Dest_Category == null || Purpose_ID == null)

              //  {
              //      result = "Fields marked with asterisk (*) are required!";
              //  }

                //else
                //{
                    var approvedproptitlemovtcheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Movt_Serial_No == Movt_Serial_No && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedproptitlemovtprimkeycheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim()&& e.Movt_Serial_No == Movt_Serial_No /*&& e.LandTypeCode == LandTypeCode*/));


                    if (approvedproptitlemovtcheck == null && approvedproptitlemovtprimkeycheck == null)
                    {
                        PropertyTitleMovt approvedproptitlemovt = new PropertyTitleMovt() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Movt_Serial_No = Movt_Serial_No, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitleMovt approvedproptitlemovtlog = new AuditLog_PropertyTitleMovt() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Movt_Serial_No = Movt_Serial_No, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitleMovt approvedproptitlemovt = new PropertyTitleMovt();
                            UserManagement user = new UserManagement();
                            approvedproptitlemovt.Added_By = user.getCurrentuser();
                            approvedproptitlemovt.Added_Date = DateTime.Now;

                            approvedproptitlemovt.UnlockTitle = UnlockTitle;
                            approvedproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);
                            approvedproptitlemovt.Title_Reference = Title_Reference;
                            approvedproptitlemovt.Volume = Volume;
                            approvedproptitlemovt.Folio = Convert.ToInt32(Folio);
                            approvedproptitlemovt.TransferInNHCC = TransferInNHCC;
                            approvedproptitlemovt.Movt_Serial_No = Movt_Serial_No;
                            approvedproptitlemovt.Movement_Date = Movement_Date;
                            approvedproptitlemovt.Return_Date = Return_Date;
                            approvedproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            approvedproptitlemovt.Purpose_ID = Purpose_ID;
                            approvedproptitlemovt.Additional = Additional;
                            approvedproptitlemovt.Additional_Information = Additional_Information;
                            approvedproptitlemovt.FlatNo = FlatNo;
                            approvedproptitlemovt.PlotNo = PlotNo;
                            approvedproptitlemovt.UnitNo = UnitNo;
                            approvedproptitlemovt.Destination_Address = Destination_Address;
                            approvedproptitlemovt.LawyersNames = LawyersNames;
                            approvedproptitlemovt.Ooutward = Ooutward;
                            approvedproptitlemovt.Directors = Directors;
                            approvedproptitlemovt.Remark = Remark;

                            approvedproptitlemovt.FinalSubmission = FinalSubmission;
                            approvedproptitlemovt.TitleMovementStatusID = TitleMovementStatusID;
                            approvedproptitlemovt.RejectionComment = RejectionComment;
                            approvedproptitlemovt.UnlockComment = UnlockComment;
                            approvedproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            approvedproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                        
                            //Audit Log Table

                            approvedproptitlemovtlog.original_Added_By = user.getCurrentuser();
                            approvedproptitlemovtlog.original_Added_Date = DateTime.Now;

                            approvedproptitlemovtlog.original_UnlockTitle = UnlockTitle;
                            approvedproptitlemovtlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approvedproptitlemovtlog.original_Title_Reference = Title_Reference;
                            approvedproptitlemovtlog.original_Volume = Volume;
                            approvedproptitlemovtlog.original_Folio = Convert.ToInt32(Folio);
                            approvedproptitlemovtlog.original_TransferInNHCC = TransferInNHCC;
                            approvedproptitlemovtlog.original_Movt_Serial_No = Movt_Serial_No;
                            approvedproptitlemovtlog.original_Movement_Date = Movement_Date;
                            approvedproptitlemovtlog.original_Return_Date = Return_Date;
                            approvedproptitlemovtlog.original_Dest_Category = Convert.ToInt32(Dest_Category);
                            approvedproptitlemovtlog.original_Purpose_ID = Purpose_ID;
                            approvedproptitlemovtlog.original_Additional = Additional;
                            approvedproptitlemovtlog.original_Additional_Information = Additional_Information;
                            approvedproptitlemovtlog.original_FlatNo = FlatNo;
                            approvedproptitlemovtlog.original_PlotNo = PlotNo;
                            approvedproptitlemovtlog.original_UnitNo = UnitNo;
                            approvedproptitlemovtlog.original_Destination_Address = Destination_Address;
                            approvedproptitlemovtlog.original_LawyersNames = LawyersNames;
                            approvedproptitlemovtlog.original_Ooutward = Ooutward;
                            approvedproptitlemovtlog.original_Directors = Directors;
                            approvedproptitlemovtlog.original_Remark = Remark;

                            approvedproptitlemovtlog.original_FinalSubmission = FinalSubmission;
                            approvedproptitlemovtlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approvedproptitlemovtlog.original_RejectionComment = RejectionComment;
                            approvedproptitlemovtlog.original_UnlockComment = UnlockComment;
                            approvedproptitlemovtlog.original_Latitude = Convert.ToDouble(Latitude);
                            approvedproptitlemovtlog.original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitleMovts.Add(approvedproptitlemovt);
                            db.AuditLog_PropertyTitleMovt.Add(approvedproptitlemovtlog);
                            db.SaveChanges();

                            result = "Record successfully saved......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }
                    else if (approvedproptitlemovtcheck == null && approvedproptitlemovtprimkeycheck != null)
                         
                    {

                        result = "Title with the same Location,Volume,Movement Serial Number and Folio arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both freeholdtitlecheck and freeholdprimkeycheck are not null

                    {
                        result = "This title arleady exists in the database (Record not saved)";

                    }

                //}
            }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null") ||
                //     Dest_Category == null || Purpose_ID == null)

                //{
                //    result = "Please fill in all field marked with asterisk (*)!";
                //}

                //else
                //{
                    var editapprovedproptitlemovt = db.PropertyTitleMovts.FirstOrDefault(e => e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Volume == Volume && e.Folio == Folio);

                    var editapprovedproptitlemovtlog = db.AuditLog_PropertyTitleMovt.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Movt_Serial_No == Movt_Serial_No && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editapprovedproptitlemovt != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editapprovedproptitlemovt.Edited_By = user.getCurrentuser();
                            editapprovedproptitlemovt.Edited_Date = DateTime.Now;

                            editapprovedproptitlemovt.UnlockTitle = UnlockTitle;
                            editapprovedproptitlemovt.FinalSubmission = FinalSubmission;
                            editapprovedproptitlemovt.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedproptitlemovt.RejectionComment = RejectionComment;
                            editapprovedproptitlemovt.UnlockComment = UnlockComment;
                            editapprovedproptitlemovt.Title_Reference = Title_Reference;
                            editapprovedproptitlemovt.TransferInNHCC = TransferInNHCC;
                            editapprovedproptitlemovt.Movement_Date = Movement_Date;
                            editapprovedproptitlemovt.Return_Date = Return_Date;
                            editapprovedproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            editapprovedproptitlemovt.Purpose_ID = Purpose_ID;
                            editapprovedproptitlemovt.Additional = Additional;
                            editapprovedproptitlemovt.Additional_Information = Additional_Information;
                            editapprovedproptitlemovt.FlatNo = FlatNo;
                            editapprovedproptitlemovt.PlotNo = PlotNo;
                            editapprovedproptitlemovt.UnitNo = UnitNo;
                            editapprovedproptitlemovt.Destination_Address = Destination_Address;
                            editapprovedproptitlemovt.LawyersNames = LawyersNames;
                            editapprovedproptitlemovt.Ooutward = Ooutward;
                            editapprovedproptitlemovt.Directors = Directors;
                            editapprovedproptitlemovt.Remark = Remark;

                            editapprovedproptitlemovt.Added_By = Added_By;
                            editapprovedproptitlemovt.Added_Date = Added_Date;
                            editapprovedproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            editapprovedproptitlemovt.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Table

                            //editapprovedproptitlemovtlog.original_Edited_By = user.getCurrentuser();
                            //editapprovedproptitlemovtlog.original_Edited_Date = DateTime.Now;

                            editapprovedproptitlemovtlog.original_UnlockedBy = user.getCurrentuser();
                            editapprovedproptitlemovtlog.original_UnlockDate = DateTime.Now;

                            editapprovedproptitlemovtlog.new_UnlockTitle = UnlockTitle;
                            editapprovedproptitlemovtlog.new_FinalSubmission = FinalSubmission;
                            editapprovedproptitlemovtlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedproptitlemovtlog.new_RejectionComment = RejectionComment;
                            editapprovedproptitlemovtlog.original_UnlockComment = UnlockComment;
                            editapprovedproptitlemovtlog.new_Title_Reference = Title_Reference;
                            editapprovedproptitlemovtlog.new_TransferInNHCC = TransferInNHCC;
                            editapprovedproptitlemovtlog.new_Movement_Date = Movement_Date;
                            editapprovedproptitlemovtlog.new_Return_Date = Return_Date;
                            editapprovedproptitlemovtlog.new_Dest_Category = Convert.ToInt32(Dest_Category);
                            editapprovedproptitlemovtlog.new_Purpose_ID = Purpose_ID;
                            editapprovedproptitlemovtlog.new_Additional = Additional;
                            editapprovedproptitlemovtlog.new_Additional_Information = Additional_Information;
                            editapprovedproptitlemovtlog.new_FlatNo = FlatNo;
                            editapprovedproptitlemovtlog.new_PlotNo = PlotNo;
                            editapprovedproptitlemovtlog.new_UnitNo = UnitNo;
                            editapprovedproptitlemovtlog.new_Destination_Address = Destination_Address;
                            editapprovedproptitlemovtlog.new_LawyersNames = LawyersNames;
                            editapprovedproptitlemovtlog.new_Ooutward = Ooutward;
                            editapprovedproptitlemovtlog.new_Directors = Directors;
                            editapprovedproptitlemovtlog.new_Remark = Remark;
                            editapprovedproptitlemovtlog.new_Latitude = Convert.ToDouble(Latitude);
                            editapprovedproptitlemovtlog.new_Longitude = Convert.ToDouble(Longitude);

                            editapprovedproptitlemovtlog.new_Added_By = Added_By;
                            editapprovedproptitlemovtlog.new_Added_Date = Added_Date;

                            db.Entry(editapprovedproptitlemovt).CurrentValues.SetValues(editapprovedproptitlemovt);
                            db.Entry(editapprovedproptitlemovt).State = EntityState.Modified;

                            db.Entry(editapprovedproptitlemovtlog).CurrentValues.SetValues(editapprovedproptitlemovtlog);
                            db.Entry(editapprovedproptitlemovtlog).State = EntityState.Modified;

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
                            //result = Title_Reference + " is updated successfully";

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

        public ActionResult CEOSaveapprovedTitleMovement(int? Project_Code, string Title_Reference, bool? Ooutward, string Volume, int? Folio,
         string Movt_Serial_No, bool? TransferInNHCC, DateTime? Movement_Date, DateTime? Return_Date, int? Dest_Category, int? Purpose_ID,
         bool? Additional, string Additional_Information, string FlatNo, string PlotNo, string UnitNo, string Destination_Address,
         string LawyersNames, string Remark, string Directors, string RejectionComment, bool? FinalSubmission,
         int? TitleMovementStatusID, string UnlockComment, string Added_By, DateTime? Added_Date, int _type, bool? UnlockTitle,decimal? Latitude,decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

              //  if (Project_Code == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
              //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
              //|| Folio == null || Movt_Serial_No == null || Dest_Category == null || Purpose_ID == null)

                //{
                //    result = "Fields marked with asterisk (*) are required!";
                //}

                //else
                //{
                    try
                    {
                        PropertyTitleMovt approvedproptitlemovt = new PropertyTitleMovt();
                        UserManagement user = new UserManagement();
                        approvedproptitlemovt.Added_By = user.getCurrentuser();
                        approvedproptitlemovt.Added_Date = DateTime.Now;

                        approvedproptitlemovt.UnlockTitle = UnlockTitle;
                        approvedproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);
                        approvedproptitlemovt.Title_Reference = Title_Reference;
                        approvedproptitlemovt.Volume = Volume;
                        approvedproptitlemovt.Folio = Convert.ToInt32(Folio);
                        approvedproptitlemovt.TransferInNHCC = TransferInNHCC;
                        approvedproptitlemovt.Movt_Serial_No = Movt_Serial_No;
                        approvedproptitlemovt.Movement_Date = Movement_Date;
                        approvedproptitlemovt.Return_Date = Return_Date;
                        approvedproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                        approvedproptitlemovt.Purpose_ID = Purpose_ID;
                        approvedproptitlemovt.Additional = Additional;
                        approvedproptitlemovt.Additional_Information = Additional_Information;
                        approvedproptitlemovt.FlatNo = FlatNo;
                        approvedproptitlemovt.PlotNo = PlotNo;
                        approvedproptitlemovt.UnitNo = UnitNo;
                        approvedproptitlemovt.Destination_Address = Destination_Address;
                        approvedproptitlemovt.LawyersNames = LawyersNames;
                        approvedproptitlemovt.Ooutward = Ooutward;
                        approvedproptitlemovt.Directors = Directors;
                        approvedproptitlemovt.Remark = Remark;

                        approvedproptitlemovt.FinalSubmission = FinalSubmission;
                        approvedproptitlemovt.TitleMovementStatusID = TitleMovementStatusID;
                        approvedproptitlemovt.RejectionComment = RejectionComment;
                        approvedproptitlemovt.UnlockComment = UnlockComment;
                        approvedproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                        approvedproptitlemovt.Longitude = Convert.ToDouble(Longitude);

                        db.PropertyTitleMovts.Add(approvedproptitlemovt);
                        db.SaveChanges();

                        result = "Record successfully saved......";

                    }
                    catch (DbEntityValidationException ex)
                    {
                        result = ex.Message.ToString();
                    }


                //}
            }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null") ||
                //     Dest_Category == null || Purpose_ID == null)

                //{
                //    result = "Please fill in all field marked with asterisk (*)!";
                //}

                //else
                //{
                    var editapprovedproptitlemovt = db.PropertyTitleMovts.FirstOrDefault(e => e.Project_Code == Project_Code && e.Movt_Serial_No == Movt_Serial_No && e.Volume == e.Volume && e.Folio == Folio);

                    if (editapprovedproptitlemovt != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            //editapprovedproptitlemovt.Edited_By = user.getCurrentuser();
                            //editapprovedproptitlemovt.Edited_Date = DateTime.Now;

                            editapprovedproptitlemovt.UnlockTitle = UnlockTitle;
                            editapprovedproptitlemovt.FinalSubmission = FinalSubmission;
                            editapprovedproptitlemovt.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedproptitlemovt.RejectionComment = RejectionComment;
                            editapprovedproptitlemovt.UnlockComment = UnlockComment;
                            editapprovedproptitlemovt.Title_Reference = Title_Reference;
                            editapprovedproptitlemovt.TransferInNHCC = TransferInNHCC;
                            editapprovedproptitlemovt.Movement_Date = Movement_Date;
                            editapprovedproptitlemovt.Return_Date = Return_Date;
                            editapprovedproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            editapprovedproptitlemovt.Purpose_ID = Purpose_ID;
                            editapprovedproptitlemovt.Additional = Additional;
                            editapprovedproptitlemovt.Additional_Information = Additional_Information;
                            editapprovedproptitlemovt.FlatNo = FlatNo;
                            editapprovedproptitlemovt.PlotNo = PlotNo;
                            editapprovedproptitlemovt.UnitNo = UnitNo;
                            editapprovedproptitlemovt.Destination_Address = Destination_Address;
                            editapprovedproptitlemovt.LawyersNames = LawyersNames;
                            editapprovedproptitlemovt.Ooutward = Ooutward;
                            editapprovedproptitlemovt.Directors = Directors;
                            editapprovedproptitlemovt.Remark = Remark;
                            editapprovedproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            editapprovedproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                            editapprovedproptitlemovt.Added_By = Added_By;
                            editapprovedproptitlemovt.Added_Date = Added_Date;

                            db.Entry(editapprovedproptitlemovt).CurrentValues.SetValues(editapprovedproptitlemovt);
                            db.Entry(editapprovedproptitlemovt).State = EntityState.Modified;

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

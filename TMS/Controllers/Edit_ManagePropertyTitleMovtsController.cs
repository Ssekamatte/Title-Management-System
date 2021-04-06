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
    public class Edit_ManagePropertyTitleMovtsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: Edit_ManagePropertyTitleMovts
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
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
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

        // GET: Edit_ManagePropertyTitleMovts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyTitleMovt propertyTitleMovt = db.PropertyTitleMovts.Find(id);
            if (propertyTitleMovt == null)
            {
                return HttpNotFound();
            }
            return View(propertyTitleMovt);
        }

        // GET: Edit_ManagePropertyTitleMovts/Create
        public ActionResult Create()
        {
            ViewBag.Dest_Category = new SelectList(db.DestinationTypes, "DestinyCode", "DestinyDesc");
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc");
            ViewBag.Lawyers_ID = new SelectList(db.TitleMovements_Lawyers, "Lawyers_ID", "Lawyers_Desc");
            ViewBag.Purpose_ID = new SelectList(db.TitleMovement_Purpose, "Purpose_ID", "Purpose_Description");
            return View();
        }

        // POST: Edit_ManagePropertyTitleMovts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_Code,Movt_Serial_No,Folio,Volume,Title_Reference,Movement_Date,Dest_Category,Outward,DestinationDesc,Destination_Address,Email,TelNo,WebSite,Remark,NewDataAudit,EditDataAudit,FlatNo,UnitNo,HasVolumeFolio,Added_By,Added_Date,Edited_By,Edited_Date,Purpose_ID,Lawyers_ID,PlotNo")] PropertyTitleMovt propertyTitleMovt)
        {
            if (ModelState.IsValid)
            {
                db.PropertyTitleMovts.Add(propertyTitleMovt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dest_Category = new SelectList(db.DestinationTypes, "DestinyCode", "DestinyDesc", propertyTitleMovt.Dest_Category);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", propertyTitleMovt.Project_Code);
            ViewBag.Lawyers_ID = new SelectList(db.TitleMovements_Lawyers, "Lawyers_ID", "Lawyers_Desc", propertyTitleMovt.Lawyers_ID);
            ViewBag.Purpose_ID = new SelectList(db.TitleMovement_Purpose, "Purpose_ID", "Purpose_Description", propertyTitleMovt.Purpose_ID);
            return View(propertyTitleMovt);
        }

        // GET: Edit_ManagePropertyTitleMovts/Edit/5
        public ActionResult Edit(int? id)
        {
           
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyTitleMovt propertyTitleMovt = db.PropertyTitleMovts.Find(id);
            if (propertyTitleMovt == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dest_Category = new SelectList(db.DestinationTypes, "DestinyCode", "DestinyDesc", propertyTitleMovt.Dest_Category);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", propertyTitleMovt.Project_Code);
            ViewBag.Lawyers_ID = new SelectList(db.TitleMovements_Lawyers, "Lawyers_ID", "Lawyers_Desc", propertyTitleMovt.Lawyers_ID);
            ViewBag.Purpose_ID = new SelectList(db.TitleMovement_Purpose, "Purpose_ID", "Purpose_Description", propertyTitleMovt.Purpose_ID);
            return View(propertyTitleMovt);
        }

        // POST: Edit_ManagePropertyTitleMovts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_Code,Movt_Serial_No,Folio,Volume,Title_Reference,Movement_Date,Dest_Category,Outward,DestinationDesc,Destination_Address,Email,TelNo,WebSite,Remark,NewDataAudit,EditDataAudit,FlatNo,UnitNo,HasVolumeFolio,Added_By,Added_Date,Edited_By,Edited_Date,Purpose_ID,Lawyers_ID,PlotNo")] PropertyTitleMovt propertyTitleMovt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyTitleMovt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dest_Category = new SelectList(db.DestinationTypes, "DestinyCode", "DestinyDesc", propertyTitleMovt.Dest_Category);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", propertyTitleMovt.Project_Code);
            ViewBag.Lawyers_ID = new SelectList(db.TitleMovements_Lawyers, "Lawyers_ID", "Lawyers_Desc", propertyTitleMovt.Lawyers_ID);
            ViewBag.Purpose_ID = new SelectList(db.TitleMovement_Purpose, "Purpose_ID", "Purpose_Description", propertyTitleMovt.Purpose_ID);
            return View(propertyTitleMovt);
        }

        // GET: Edit_ManagePropertyTitleMovts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyTitleMovt propertyTitleMovt = db.PropertyTitleMovts.Find(id);
            if (propertyTitleMovt == null)
            {
                return HttpNotFound();
            }
            return View(propertyTitleMovt);
        }

        // POST: Edit_ManagePropertyTitleMovts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyTitleMovt propertyTitleMovt = db.PropertyTitleMovts.Find(id);
            db.PropertyTitleMovts.Remove(propertyTitleMovt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DataSourcePropertyTitleMovts(DataManager dm)
        {

            //Returns all the fields in the table based on the Title Movement Status ID

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) )).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false))).ToList().Count();
                      

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

                value.UnlockTitle = false;

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


        //public ActionResult DialogUpdate(PropertyTitleMovt value)
        //{
        //    PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
        //    o.Project_Code == value.Project_Code && 
        //    o.Movt_Serial_No == value.Movt_Serial_No &&
        //    o.Folio == value.Folio && 
        //    o.Volume == value.Volume );           

        //    if (table != null)//Original Line
        //    {
        //        UserManagement user = new UserManagement();
        //        value.Edited_By = user.getCurrentuser();
        //        value.Edited_Date = DateTime.Now;

        //        db.Entry(table).CurrentValues.SetValues(value);
        //        db.Entry(table).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //            TempData["Success"] = "Record Saved Successfully!";
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {

        //            foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            {
        //                foreach (var validationError in validationErrors.ValidationErrors)
        //                {
        //                    TempData["Success"] += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
        //                    System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
        //                }
        //            }
        //        }
        //    }

        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult DialogInsert(PropertyTitleMovt value)
        //{
        //    PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
        //    o.Project_Code == value.Project_Code &&
        //    o.Movt_Serial_No == value.Movt_Serial_No &&
        //    o.Folio == value.Folio &&
        //    o.Volume == value.Volume );           

        //    if (table == null)//Original Line
        //    {
        //        UserManagement user = new UserManagement();
        //        value.Added_By = user.getCurrentuser();
        //        value.Added_Date = DateTime.Now;

        //        db.PropertyTitleMovts.Add(value);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        this.DialogUpdate(value);
        //    }
        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult DialogDelete(int Project_Code)
        //{

        //    PropertyTitleMovt result = db.PropertyTitleMovts.Where(o => o.Project_Code == Project_Code).FirstOrDefault();
        //    db.PropertyTitleMovts.Remove(result);
        //    db.SaveChanges();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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

        public ActionResult SaveTitleMovement(int? Location_id,int? Project_Code, string Title_Reference,bool? Ooutward, string Volume, int? Folio,
           string Movt_Serial_No, bool? TransferInNHCC, DateTime? Movement_Date, DateTime? Return_Date, int? Dest_Category, int? Purpose_ID,
           bool? Additional, string Additional_Information, string FlatNo, string PlotNo, string UnitNo, string Destination_Address,
           string LawyersNames,string Remark,string Directors, string RejectionComment, bool? FinalSubmission,
           int? TitleMovementStatusID, string UnlockComment,string Added_By, DateTime? Added_Date, int _type, decimal? Latitude, decimal? Longitude)

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
                    var approveproptitlemovttitlecheck = db.PropertyTitleMovts.FirstOrDefault(e => (
                    e.Location_id == Location_id &&
                    e.Movt_Serial_No == Movt_Serial_No &&
                    e.Folio == Folio &&
                    e.Volume.Trim() == Volume.Trim() &&
                    e.Title_Reference.Trim() == Title_Reference.Trim()));

                    var approveproptitlemovtprimkeycheck = db.PropertyTitleMovts.FirstOrDefault(e => (
                    e.Location_id == Location_id
                    && e.Movt_Serial_No == Movt_Serial_No
                    && e.Folio == Folio
                    && e.Volume.Trim() == Volume.Trim()
                    /*&& e.LandTypeCode == LandTypeCode*/));


                    if (approveproptitlemovttitlecheck == null && approveproptitlemovtprimkeycheck == null)
                    {

                        PropertyTitleMovt approveproptitlemovt = new PropertyTitleMovt()
                        {
                            Location_id = Convert.ToInt32(Location_id),
                            Movt_Serial_No = Movt_Serial_No,
                            Folio = Convert.ToInt32(Folio),
                            Volume = Volume,
                            Title_Reference = Title_Reference
                        };

                        AuditLog_PropertyTitleMovt approveproptitlemovtlog = new AuditLog_PropertyTitleMovt()
                        {
                            original_Locationid = Convert.ToInt32(Location_id),
                            original_Movt_Serial_No = Movt_Serial_No,
                            original_Folio = Convert.ToInt32(Folio),
                            original_Volume = Volume,
                            original_Title_Reference = Title_Reference
                        };

                        try
                        {
                            //PropertyTitleMovt approveproptitlemovt = new PropertyTitleMovt();
                            UserManagement user = new UserManagement();
                            approveproptitlemovt.Added_By = user.getCurrentuser();
                            approveproptitlemovt.Added_Date = DateTime.Now;

                            approveproptitlemovt.TitleMovementStatusID = 1;
                            approveproptitlemovt.FinalSubmission = false;
                            approveproptitlemovt.UnlockTitle = false;

                            approveproptitlemovt.Location_id = Convert.ToInt32(Location_id);
                            approveproptitlemovt.Project_Code = Convert.ToInt32(Project_Code);
                            approveproptitlemovt.Title_Reference = Title_Reference;
                            approveproptitlemovt.Volume = Volume;
                            approveproptitlemovt.Folio = Convert.ToInt32(Folio);
                            approveproptitlemovt.TransferInNHCC = TransferInNHCC;
                            approveproptitlemovt.Movt_Serial_No = Movt_Serial_No;
                            approveproptitlemovt.Movement_Date = Movement_Date;
                            approveproptitlemovt.Return_Date = Return_Date;
                            approveproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            approveproptitlemovt.Purpose_ID = Purpose_ID;
                            approveproptitlemovt.Additional = Additional;
                            approveproptitlemovt.Additional_Information = Additional_Information;
                            approveproptitlemovt.FlatNo = FlatNo;
                            approveproptitlemovt.PlotNo = PlotNo;
                            approveproptitlemovt.UnitNo = UnitNo;
                            approveproptitlemovt.Destination_Address = Destination_Address;
                            approveproptitlemovt.LawyersNames = LawyersNames;
                            approveproptitlemovt.Ooutward = Ooutward;
                            approveproptitlemovt.Directors = Directors;
                            approveproptitlemovt.Remark = Remark;


                            approveproptitlemovt.FinalSubmission = FinalSubmission;
                            approveproptitlemovt.TitleMovementStatusID = TitleMovementStatusID;
                            approveproptitlemovt.RejectionComment = RejectionComment;
                            approveproptitlemovt.UnlockComment = UnlockComment;
                            approveproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            approveproptitlemovt.Longitude = Convert.ToDouble(Longitude);
                            
                            //Audit Log Save Table

                            approveproptitlemovtlog.original_Added_By = user.getCurrentuser();
                            approveproptitlemovtlog.original_Added_Date = DateTime.Now;

                            approveproptitlemovtlog.original_TitleMovementStatusID = 1;
                            approveproptitlemovtlog.original_FinalSubmission = false;
                            approveproptitlemovtlog.original_UnlockTitle = false;

                            approveproptitlemovtlog.original_Locationid = Convert.ToInt32(Location_id);
                            approveproptitlemovtlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approveproptitlemovtlog.original_Title_Reference = Title_Reference;
                            approveproptitlemovtlog.original_Volume = Volume;
                            approveproptitlemovtlog.original_Folio = Convert.ToInt32(Folio);
                            approveproptitlemovtlog.original_TransferInNHCC = TransferInNHCC;
                            approveproptitlemovtlog.original_Movt_Serial_No = Movt_Serial_No;
                            approveproptitlemovtlog.original_Movement_Date = Movement_Date;
                            approveproptitlemovtlog.original_Return_Date = Return_Date;
                            approveproptitlemovtlog.original_Dest_Category = Convert.ToInt32(Dest_Category);
                            approveproptitlemovtlog.original_Purpose_ID = Purpose_ID;
                            approveproptitlemovtlog.original_Additional = Additional;
                            approveproptitlemovtlog.original_Additional_Information = Additional_Information;
                            approveproptitlemovtlog.original_FlatNo = FlatNo;
                            approveproptitlemovtlog.original_PlotNo = PlotNo;
                            approveproptitlemovtlog.original_UnitNo = UnitNo;
                            approveproptitlemovtlog.original_Destination_Address = Destination_Address;
                            approveproptitlemovtlog.original_LawyersNames = LawyersNames;
                            approveproptitlemovtlog.original_Ooutward = Ooutward;
                            approveproptitlemovtlog.original_Directors = Directors;
                            approveproptitlemovtlog.original_Remark = Remark;

                            approveproptitlemovtlog.original_FinalSubmission = FinalSubmission;
                            approveproptitlemovtlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approveproptitlemovtlog.original_RejectionComment = RejectionComment;
                            approveproptitlemovtlog.original_UnlockComment = UnlockComment;
                            approveproptitlemovtlog.original_Latitude = Convert.ToDouble(Latitude);
                            approveproptitlemovtlog.original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitleMovts.Add(approveproptitlemovt);
                            db.AuditLog_PropertyTitleMovt.Add(approveproptitlemovtlog);
                            db.SaveChanges();

                            result = "A new title has been moved......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (approveproptitlemovttitlecheck == null && approveproptitlemovtprimkeycheck != null)
                       
                    {

                        result = "Title with the same Location,Movement Serial Number,Volume and Folio arleady exists in the database (Record not saved)";
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
                //    result = "Please enter a Parent Title (Title Reference)!";
                //}

                //else
                //{                  
                    var editapproveproptitlemovt = db.PropertyTitleMovts.FirstOrDefault(e => e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Volume == Volume && e.Folio == Folio);

                    var editapproveproptitlemovtlog = db.AuditLog_PropertyTitleMovt.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Movt_Serial_No == Movt_Serial_No && e.original_Volume == Volume && e.original_Folio == Folio);


                    if (editapproveproptitlemovt != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editapproveproptitlemovt.Edited_By = user.getCurrentuser();
                            editapproveproptitlemovt.Edited_Date = DateTime.Now;
                                                        
                            editapproveproptitlemovt.UnlockTitle = false;                            

                            editapproveproptitlemovt.Title_Reference = Title_Reference;

                            editapproveproptitlemovt.TransferInNHCC = TransferInNHCC;
                            editapproveproptitlemovt.Movement_Date = Movement_Date;
                            editapproveproptitlemovt.Return_Date = Return_Date;
                            editapproveproptitlemovt.Dest_Category = Convert.ToInt32(Dest_Category);
                            editapproveproptitlemovt.Purpose_ID = Purpose_ID;
                            editapproveproptitlemovt.Additional = Additional;
                            editapproveproptitlemovt.Additional_Information = Additional_Information;
                            editapproveproptitlemovt.FlatNo = FlatNo;
                            editapproveproptitlemovt.PlotNo = PlotNo;
                            editapproveproptitlemovt.UnitNo = UnitNo;
                            editapproveproptitlemovt.Destination_Address = Destination_Address;
                            editapproveproptitlemovt.LawyersNames = LawyersNames;
                            editapproveproptitlemovt.Ooutward = Ooutward;
                            editapproveproptitlemovt.Directors = Directors;
                            editapproveproptitlemovt.Remark = Remark;
                            
                            editapproveproptitlemovt.FinalSubmission = FinalSubmission;
                            editapproveproptitlemovt.TitleMovementStatusID = TitleMovementStatusID;
                            editapproveproptitlemovt.RejectionComment = RejectionComment;
                            editapproveproptitlemovt.UnlockComment = UnlockComment;
                            editapproveproptitlemovt.Latitude = Convert.ToDouble(Latitude);
                            editapproveproptitlemovt.Longitude = Convert.ToDouble(Longitude);

                            editapproveproptitlemovt.Added_By = Added_By;
                            editapproveproptitlemovt.Added_Date = Added_Date;

                            //Audit Log Saving

                            editapproveproptitlemovtlog.original_Edited_By = user.getCurrentuser();
                            editapproveproptitlemovtlog.original_Edited_Date = DateTime.Now;

                            editapproveproptitlemovtlog.new_UnlockTitle = false;

                            editapproveproptitlemovtlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapproveproptitlemovtlog.new_Movt_Serial_No = Movt_Serial_No;
                            editapproveproptitlemovtlog.new_Volume = Volume;
                            editapproveproptitlemovtlog.new_Folio = Convert.ToInt32(Folio);

                            editapproveproptitlemovtlog.new_Title_Reference = Title_Reference;

                            editapproveproptitlemovtlog.new_TransferInNHCC = TransferInNHCC;
                            editapproveproptitlemovtlog.new_Movement_Date = Movement_Date;
                            editapproveproptitlemovtlog.new_Return_Date = Return_Date;
                            editapproveproptitlemovtlog.new_Dest_Category = Convert.ToInt32(Dest_Category);
                            editapproveproptitlemovtlog.new_Purpose_ID = Purpose_ID;
                            editapproveproptitlemovtlog.new_Additional = Additional;
                            editapproveproptitlemovtlog.new_Additional_Information = Additional_Information;
                            editapproveproptitlemovtlog.new_FlatNo = FlatNo;
                            editapproveproptitlemovtlog.new_PlotNo = PlotNo;
                            editapproveproptitlemovtlog.new_UnitNo = UnitNo;
                            editapproveproptitlemovtlog.new_Destination_Address = Destination_Address;
                            editapproveproptitlemovtlog.new_LawyersNames = LawyersNames;
                            editapproveproptitlemovtlog.new_Ooutward = Ooutward;
                            editapproveproptitlemovtlog.new_Directors = Directors;
                            editapproveproptitlemovtlog.new_Remark = Remark;

                            editapproveproptitlemovtlog.new_FinalSubmission = FinalSubmission;
                            editapproveproptitlemovtlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapproveproptitlemovtlog.new_Latitude = Convert.ToDouble(Latitude);
                            editapproveproptitlemovtlog.new_Longitude = Convert.ToDouble(Longitude);

                            editapproveproptitlemovtlog.original_RejectionComment = RejectionComment;
                            editapproveproptitlemovtlog.original_UnlockComment = UnlockComment;

                            editapproveproptitlemovtlog.new_Added_By = Added_By;
                            editapproveproptitlemovtlog.new_Added_Date = Added_Date;

                            db.Entry(editapproveproptitlemovt).CurrentValues.SetValues(editapproveproptitlemovt);
                            db.Entry(editapproveproptitlemovt).State = EntityState.Modified;

                            db.Entry(editapproveproptitlemovtlog).CurrentValues.SetValues(editapproveproptitlemovtlog);
                            db.Entry(editapproveproptitlemovtlog).State = EntityState.Modified;  

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

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
    public class PropertyTitleMovtsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: PropertyTitleMovts
        public ActionResult Index()
        {
            //return View(db.PropertyTitleMovts.ToList());

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
            var PropertyTitles = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.PropertyTitles = PropertyTitles;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }


        //public ActionResult GetFolio(int Project_Code)
        //{
        //    var result = db.PropertyTitle.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

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

        //public ActionResult GetFolio(string Title_Reference)
        //public ActionResult GetFolio(string Volume)
        //{
        //    var result = db.PropertyTitles.Where(o => o.Volume == Volume).Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetFolio(string Title_Reference, string Volume)
        {
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference && o.Volume == Volume).Select(a => new { a.Title_Reference, a.Volume, a.Folio,a.Longitude,a.Latitude}).Distinct().OrderBy(a => a.Folio).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
                 

        public ActionResult GetParent_Title(int Location_id)
        {
            var result = db.PropertyTitles.Where(o=> o.Location_id == Location_id).Select(a=>new {a.Location_id, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVolume(string Title_Reference)
        {
            //var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference).Select(a => new { a.Title_Reference, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference).Select(a => new { a.Title_Reference,a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TitleMovts(Syncfusion.JavaScript.DataManager dataManager, int projcode)
        {
            
            IEnumerable DataSource = db.PropertyTitleMovts .Where(p => p.Project_Code == projcode).ToList();
            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();
            result.result = DataSource;
            result.count = db.PropertyTitleMovts.Where(p => p.Project_Code == projcode).ToList().Count();
            if (dataManager.Skip > 0)
                result.result = operation.PerformSkip(result.result, dataManager.Skip);
            if (dataManager.Take > 0)
                result.result = operation.PerformTake(result.result, dataManager.Take);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TitleMovts(Syncfusion.JavaScript.DataManager dataManager, int projcode, int Folio, string Volume)
        {

            IEnumerable DataSource = db.PropertyTitleMovts.Where(p => p.Project_Code == projcode && p.Folio  == Folio&&p.Volume == Volume).ToList();
            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();
            result.result = DataSource;
            result.count = db.PropertyTitleMovts.Where(p => p.Project_Code == projcode && p.Folio == Folio && p.Volume == Volume).ToList().Count();
            if (dataManager.Skip > 0)
                result.result = operation.PerformSkip(result.result, dataManager.Skip);
            if (dataManager.Take > 0)
                result.result = operation.PerformTake(result.result, dataManager.Take);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class DataResult
        {
            public IEnumerable result { get; set; }
            public int count { get; set; }
        }
        //ForeignKeyGrid
        public ActionResult ForeignKeyGrid()
        {
            //return View(db.PropertyTitleMovts.ToList());
            

            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitleMovts.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var lawyers = db.TitleMovements_Lawyers.AsNoTracking().ToList();
            ViewBag.dataSource2 = lawyers;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().ToList();
            ViewBag.dataSource3 = purposes;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var parenttitles = db.PropertyTitles.OrderBy(a => a.Title_Reference).AsNoTracking().ToList();
            ViewBag.propertytitles = parenttitles;

            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.OrderBy(a => a.Volume).AsNoTracking().ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var folios = db.PropertyTitles.OrderBy(a => a.Folio).AsNoTracking().ToList();
            ViewBag.propertytitlesfolios = folios;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;


            return View();
        }



        public ActionResult DataSourcePropertyTitleMovtsStatus(DataManager dm)
        {
            //Returns all the fields in the table based on the PropertyPaymentStatusID
            var user = User.Identity.Name;
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) /*&& (b.MovementStatus == false)*/ && (b.Added_By == user ))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitleMovts.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) /*&& (b.MovementStatus == false)*/ && (b.Added_By == user))).ToList().Count();


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

        //Dialog Methods
        public ActionResult DialogUpdate(PropertyTitleMovt value)
        {
            PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.Movt_Serial_No == value.Movt_Serial_No &&
            o.Folio == value.Folio && o.Volume == value.Volume);

            //PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
            //o.Project_Code == value.Project_Code && o.Movt_Serial_No == value.Movt_Serial_No);


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
            o.Project_Code == value.Project_Code && o.Movt_Serial_No == value.Movt_Serial_No &&
            o.Folio == value.Folio && o.Volume == value.Volume);

            //PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
            //o.Project_Code == value.Project_Code && o.Movt_Serial_No == value.Movt_Serial_No);

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


        public ActionResult DialogDelete(int Project_Code, string Movt_Serial_No,int Folio, string Volume)
        {

            PropertyTitleMovt result = db.PropertyTitleMovts.Where(o => o.Project_Code == Project_Code && o.Movt_Serial_No == Movt_Serial_No &&
            o.Folio == Folio && o.Volume == Volume).FirstOrDefault();
            db.PropertyTitleMovts.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET: PropertyTitleMovts/Details/5
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

        // GET: PropertyTitleMovts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyTitleMovts/Create
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

            return View(propertyTitleMovt);
        }

        // GET: PropertyTitleMovts/Edit/5
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
            return View(propertyTitleMovt);
        }

        // POST: PropertyTitleMovts/Edit/5
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
            return View(propertyTitleMovt);
        }

        // GET: PropertyTitleMovts/Delete/5
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

        // POST: PropertyTitleMovts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyTitleMovt propertyTitleMovt = db.PropertyTitleMovts.Find(id);
            db.PropertyTitleMovts.Remove(propertyTitleMovt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetParentTitle(int Project_Code)
        {
            //var result = db.PropertyTitleMovts.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            var result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult GetProjectCode(int Location_id, string Title_Reference/*,string Volume*//*, int Folio*/)
        public ActionResult GetProjectCode(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        {            
            //var result = db.PropertyTitles.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.Location_id, a.Title_Reference, a.Volume, a.Folio, a.Project_Code, a.Project_Desc }).Distinct().OrderBy
            //    (/*a => a.Project_Code*/a => a.Project_Code).ToList();  //For Ordering by Project Code

            var result = db.ViewPropertyTitlesTables.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.Location_id, a.Title_Reference, a.Volume, a.Folio, a.Project_Code, a.ProjectDesc,a.Longitude,a.Latitude }).Distinct().OrderBy
               (/*a => a.Project_Code*/a => a.ProjectDesc).ToList();  //For Ordering by Project Desc

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetProjectCode1(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    var data = db.PropertyTitles.AsNoTracking().Where(a => /*a.Project_Code == Project_Code && */a.Location_id == Location_id && a.Title_Reference == Title_Reference && a.Volume == Volume && a.Folio == Folio).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetProjectCode1(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        {
            int? data = 0;
            db.Configuration.ProxyCreationEnabled = false;
            var result = db.PropertyTitles.FirstOrDefault(o => o.Location_id == Location_id);
            if (result.Project_Code != null)
            {
                data = result.Project_Code;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveTitleMovement(int? Location_id,int? Project_Code, string Title_Reference, string Volume, int? Folio,
           bool? TransferInNHCC, string Movt_Serial_No,DateTime? Movement_Date, DateTime? Return_Date,int? Dest_Category,int? Purpose_ID,
           bool? Additional, string Additional_Information,string FlatNo, string PlotNo, string UnitNo,string Destination_Address,
           string LawyersNames, bool? Ooutward,string Directors, string Remark, int _type, decimal? Latitude, decimal? Longitude)
                                 
        {
            string result = string.Empty;
            if (_type == 1)
            {

                //if (Location_id == null || Project_Code == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")|| Folio == null || 
                //Movt_Serial_No == null || Dest_Category == null || Purpose_ID == null)

                //{
                //    result = "Fields marked with asterisk (*) are required!";
                //}

                //else
                //{
                    var titlemvtcheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Project_Code == Project_Code && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var titlemvtcheckprimkeycheck = db.PropertyTitleMovts.FirstOrDefault(e => (e.Location_id == Location_id && e.Movt_Serial_No == Movt_Serial_No && e.Folio == Folio && e.Volume.Trim() == Volume.Trim()));

                    if (titlemvtcheck == null && titlemvtcheckprimkeycheck == null)

                    {

                        PropertyTitleMovt titlemvt = new PropertyTitleMovt() { Location_id = Convert.ToInt32(Location_id), Movt_Serial_No = Movt_Serial_No, Volume = Volume, Folio = Convert.ToInt32(Folio), Title_Reference = Title_Reference };

                        //Audit_Log Table Check
                        AuditLog_PropertyTitleMovt titlemvtlog = new AuditLog_PropertyTitleMovt() { original_Locationid = Convert.ToInt32(Location_id), original_Movt_Serial_No = Movt_Serial_No, original_Volume = Volume, original_Folio = Convert.ToInt32(Folio), original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitleMovt titlemvt = new PropertyTitleMovt();
                            UserManagement user = new UserManagement();
                            titlemvt.Added_By = user.getCurrentuser();
                            titlemvt.Added_Date = DateTime.Now;
                            titlemvt.TitleMovementStatusID = 1;
                            titlemvt.FinalSubmission = false;
                            titlemvt.UnlockTitle = false;
                            //titlemvt.MovementStatus = false;

                            titlemvt.Location_id = Convert.ToInt32(Location_id);
                            titlemvt.Project_Code = Convert.ToInt32(Project_Code);
                            titlemvt.Title_Reference = Title_Reference;
                            titlemvt.Volume = Volume;
                            titlemvt.Folio = Convert.ToInt32(Folio);
                            titlemvt.TransferInNHCC = TransferInNHCC;
                            titlemvt.Movt_Serial_No = Movt_Serial_No;
                            titlemvt.Movement_Date = Movement_Date;
                            titlemvt.Return_Date = Return_Date;
                            titlemvt.Dest_Category = Convert.ToInt32(Dest_Category);
                            titlemvt.Purpose_ID = Purpose_ID;
                            titlemvt.Additional = Additional;
                            titlemvt.Additional_Information = Additional_Information;
                            titlemvt.FlatNo = FlatNo;
                            titlemvt.PlotNo = PlotNo;
                            titlemvt.UnitNo = UnitNo;
                            titlemvt.Destination_Address = Destination_Address;
                            titlemvt.LawyersNames = LawyersNames;
                            titlemvt.Ooutward = Ooutward;
                            titlemvt.Directors = Directors;
                            titlemvt.Remark = Remark;
                            titlemvt.Longitude = Convert.ToDouble(Longitude);
                            titlemvt.Latitude = Convert.ToDouble(Latitude);

                        //Audit Log Table Value Savings are Here

                            titlemvtlog.original_Added_By = user.getCurrentuser();
                            titlemvtlog.original_Added_Date = DateTime.Now;
                            titlemvtlog.original_TitleMovementStatusID = 1;
                            titlemvtlog.original_FinalSubmission = false;
                            titlemvtlog.original_UnlockTitle = false;
                            //titlemvt.MovementStatus = false;

                            titlemvtlog.original_Locationid = Convert.ToInt32(Location_id);
                            titlemvtlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            titlemvtlog.original_Title_Reference = Title_Reference;
                            titlemvtlog.original_Volume = Volume;
                            titlemvtlog.original_Folio = Convert.ToInt32(Folio);
                            titlemvtlog.original_TransferInNHCC = TransferInNHCC;
                            titlemvtlog.original_Movt_Serial_No = Movt_Serial_No;
                            titlemvtlog.original_Movement_Date = Movement_Date;
                            titlemvtlog.original_Return_Date = Return_Date;
                            titlemvtlog.original_Dest_Category = Convert.ToInt32(Dest_Category);
                            titlemvtlog.original_Purpose_ID = Purpose_ID;
                            titlemvtlog.original_Additional = Additional;
                            titlemvtlog.original_Additional_Information = Additional_Information;
                            titlemvtlog.original_FlatNo = FlatNo;
                            titlemvtlog.original_PlotNo = PlotNo;
                            titlemvtlog.original_UnitNo = UnitNo;
                            titlemvtlog.original_Destination_Address = Destination_Address;
                            titlemvtlog.original_LawyersNames = LawyersNames;
                            titlemvtlog.original_Ooutward = Ooutward;
                            titlemvtlog.original_Directors = Directors;
                            titlemvtlog.original_Remark = Remark;
                            titlemvtlog.original_Longitude = Convert.ToDouble(Longitude);
                            titlemvtlog.original_Latitude = Convert.ToDouble(Latitude);

                            db.PropertyTitleMovts.Add(titlemvt);
                            db.AuditLog_PropertyTitleMovt.Add(titlemvtlog);
                            
                            db.SaveChanges();

                            result = "The title has been successfully moved......";

                        }
                        catch (DbEntityValidationException /*ex*/)
                        {
                            //result = ex.Message.ToString();

                            result = "This title does not exist. Please check your field entries";
                        }

                        //catch (DbEntityValidationException dbEx)
                        //{

                        //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                        //    {
                        //        foreach (var validationError in validationErrors.ValidationErrors)
                        //        {
                        //            TempData["Success"] += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        //            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        //        }
                        //    }
                        //}
                    }
                    else if (titlemvtcheck == null && titlemvtcheckprimkeycheck != null)

                    {
                        //result = "This title arleady exists in the database (Record not saved)";
                        result = "Title with the same Location,Movement Serial Number,Folio and Volume arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both paycheck and paycheckprimkeycheck are not null

                    {
                        result = "Title movement on (" + Title_Reference.Trim() + ") has arleady been performed in the database (Record not saved)";
                    }
                //}

                }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null") || 
                //    Dest_Category == null || Purpose_ID == null )

                //{
                //    result = "Please enter all fields marked with asterisk (*)!";
                //}

                //else
                //{
                    var edittitlemvt = db.PropertyTitleMovts.FirstOrDefault(e => e.Project_Code == Project_Code && e.Movt_Serial_No == Movt_Serial_No && e.Volume == Volume && e.Folio == Folio);


                    var edittitlemvtlog = db.AuditLog_PropertyTitleMovt.FirstOrDefault(e => e.original_Project_Code == Project_Code && e.original_Movt_Serial_No == Movt_Serial_No && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (edittitlemvt != null)
                    {

                        try
                        {
                            UserManagement user = new UserManagement();
                            edittitlemvt.Edited_By = user.getCurrentuser();
                            edittitlemvt.Edited_Date = DateTime.Now;
                            edittitlemvt.TitleMovementStatusID = 1;
                            edittitlemvt.FinalSubmission = false;
                            edittitlemvt.UnlockTitle = false;

                            //editleasehold.Location_id = Convert.ToInt32(Location_id);
                            //  edittitlemvt.Project_Code = Convert.ToInt32(Project_Code);
                            edittitlemvt.Title_Reference = Title_Reference;
                            //  edittitlemvt.Volume = Volume;
                            //   edittitlemvt.Folio = Convert.ToInt32(Folio);
                            //  edittitlemvt.Movt_Serial_No = Convert.ToInt32(Movt_Serial_No);
                            edittitlemvt.TransferInNHCC = TransferInNHCC;
                            edittitlemvt.Movement_Date = Movement_Date;
                            edittitlemvt.Return_Date = Return_Date;
                            edittitlemvt.Dest_Category = Convert.ToInt32(Dest_Category);
                            edittitlemvt.Purpose_ID = Purpose_ID;
                            edittitlemvt.Additional = Additional;
                            edittitlemvt.Additional_Information = Additional_Information;
                            edittitlemvt.FlatNo = FlatNo;
                            edittitlemvt.PlotNo = PlotNo;
                            edittitlemvt.UnitNo = UnitNo;
                            edittitlemvt.Destination_Address = Destination_Address;
                            edittitlemvt.LawyersNames = LawyersNames;
                            edittitlemvt.Ooutward = Ooutward;
                            edittitlemvt.Directors = Directors;
                            edittitlemvt.Remark = Remark;
                            edittitlemvt.Longitude = Convert.ToDouble(Longitude);
                            edittitlemvt.Latitude = Convert.ToDouble(Latitude);

                            //Audit_Log Table Saving

                            edittitlemvtlog.original_Edited_By = user.getCurrentuser();
                            edittitlemvtlog.original_Edited_Date = DateTime.Now;
                            edittitlemvtlog.new_TitleMovementStatusID = 1;
                            edittitlemvtlog.new_FinalSubmission = false;
                            edittitlemvtlog.new_UnlockTitle = false;

                            //Primary Keys Edit
                            edittitlemvtlog.new_Locationid = Convert.ToInt32(Location_id);
                            edittitlemvtlog.new_Volume = Volume;
                            edittitlemvtlog.new_Folio = Convert.ToInt32(Folio);
                            edittitlemvtlog.new_Movt_Serial_No = Movt_Serial_No;

                            //Primary Keys Edit End
                            edittitlemvtlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            edittitlemvtlog.new_Title_Reference = Title_Reference;
                            edittitlemvtlog.new_TransferInNHCC = TransferInNHCC;
                            edittitlemvtlog.new_Movement_Date = Movement_Date;
                            edittitlemvtlog.new_Return_Date = Return_Date;
                            edittitlemvtlog.new_Dest_Category = Convert.ToInt32(Dest_Category);
                            edittitlemvtlog.new_Purpose_ID = Purpose_ID;
                            edittitlemvtlog.new_Additional = Additional;
                            edittitlemvtlog.new_Additional_Information = Additional_Information;
                            edittitlemvtlog.new_FlatNo = FlatNo;
                            edittitlemvtlog.new_PlotNo = PlotNo;
                            edittitlemvtlog.new_UnitNo = UnitNo;
                            edittitlemvtlog.new_Destination_Address = Destination_Address;
                            edittitlemvtlog.new_LawyersNames = LawyersNames;
                            edittitlemvtlog.new_Ooutward = Ooutward;
                            edittitlemvtlog.new_Directors = Directors;
                            edittitlemvtlog.new_Remark = Remark;
                            edittitlemvtlog.new_Longitude = Convert.ToDouble(Longitude);
                            edittitlemvtlog.new_Latitude = Convert.ToDouble(Latitude);

                            db.Entry(edittitlemvt).CurrentValues.SetValues(edittitlemvt);
                            db.Entry(edittitlemvt).State = EntityState.Modified;

                            db.Entry(edittitlemvtlog).CurrentValues.SetValues(edittitlemvtlog);
                            db.Entry(edittitlemvtlog).State = EntityState.Modified;

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
                            result = Title_Reference.Trim() +" is updated successfully";


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

        //Generate Movement Serial No.   
        public ActionResult MovementSerialNo(/*string[] values*/)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                var tdate = DateTime.Now;
                string year = tdate.Year.ToString().Trim().Substring(2, 2);
                string month = tdate.Month.ToString();
                string searchCode = "MVT-" + month + "-" + year;
                //var muserrole = User.IsInRole("QualityAssurance");
                //if (muserrole)
                //{
                //    searchCode = "QC-" + month + "-" + year;
                //}

                int count = db.PropertyTitleMovts.Where(o => o.Movt_Serial_No.Contains(searchCode)).ToList().Count;
                int code = (count + 1);
                string result = "MVT-" + month + "-" + year + "-" + code.ToString("D4");
                //if (muserrole)
                //{
                //    result = "QC-" + month + "-" + year + "-" + code.ToString("D4");
                //}

                return Json(new { msg = String.Format("{0}", result) }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        public ActionResult GetDocument(string Title_Reference, string Volume, int? Folio)
        {
            var result = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.TitleReferenceNo, a.Volume, a.Folio, a.UploadDate }).OrderByDescending(a => a.UploadDate).Take(1);
            int count = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.TitleReferenceNo, a.Volume, a.Folio, a.UploadDate }).OrderByDescending(a => a.UploadDate).Take(1).Count();            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }

}

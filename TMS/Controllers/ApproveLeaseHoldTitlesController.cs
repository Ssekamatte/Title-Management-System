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
    public class ApproveLeaseHoldTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApproveLeaseHoldTitles
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var PropTypes = db.PropertyTypes.AsNoTracking().ToList();
            ViewBag.PropertyTypes = PropTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().ToList();
            ViewBag.Districts = districts;

            db.Configuration.ProxyCreationEnabled = false;
            var Edit_ManagePropertyTitles = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.datasource = Edit_ManagePropertyTitles;

            db.Configuration.ProxyCreationEnabled = false;
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var Property = db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusDesc).ToList();
            ViewBag.Property = Property;

            db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().OrderBy(a => a.County_Name).ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.AsNoTracking().OrderBy(a => a.TypeDesc).ToList();
            ViewBag.propertyTypes = PropertyTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var subcounties = db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_Name).ToList();
            ViewBag.Subcounties = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;
            
            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;
            
            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            db.Configuration.ProxyCreationEnabled = false;
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }


        // GET: ApproveLeaseHoldTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApproveLeaseHoldTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApproveLeaseHoldTitles/Create
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

        // GET: ApproveLeaseHoldTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApproveLeaseHoldTitles/Edit/5
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

        // GET: ApproveLeaseHoldTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApproveLeaseHoldTitles/Delete/5
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

        public ActionResult DataSourceApprovedLeaseHoldPropertyTitles(DataManager dm)
        {

            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 3))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 3))).ToList().Count();
                        
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

        public ActionResult DialogUpdate(PropertyTitle value)
        {
            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.Volume == value.Volume &&
            o.Folio == value.Folio);


            if (table != null)
            {
                UserManagement user = new UserManagement();
                value.Edited_By = user.getCurrentuser();
                value.Edited_Date = DateTime.Now;

                value.UnlockTitle = false;
                //value.TitleMovementStatusID = 1;

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

        public ActionResult DialogInsert(PropertyTitle value)
        {

            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o =>
             o.Project_Code == value.Project_Code && o.Volume == value.Volume &&
            o.Folio == value.Folio);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                value.UnlockTitle = false;

                //value.TitleMovementStatusID = 1;

                db.PropertyTitles.Add(value);
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

            PropertyTitle result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code).FirstOrDefault();


            db.PropertyTitles.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTitleMovementStatus()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.PropertyTitle_Payment_Status.AsNoTracking().Where(a => a.Status_ID == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetFinalSubmission()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.PropertyTitles.AsNoTracking().Where(a => a.FinalSubmission == true).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLeaseholdData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 3).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetParent_Title(int Project_Code)
        {
            var result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistrict(int DistrictID)
        {
            var result = db.Districts.Where(o => o.DistrictID == DistrictID).Select(a => new { a.DistrictID, a.District_Name }).Distinct().OrderBy(a => a.District_Name).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCounty(int District_ID)
        {
            var result = db.Counties.Where(o => o.District_ID == District_ID).Select(a => new { a.County_ID, a.County_Name }).Distinct().OrderBy(a => a.County_Name).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubCounty(int County_ID)
        {
            //var result = db.View_A_SubcountyList.Where(o => o.County_Name == County_ID).Distinct().OrderBy(a => a.Subcounty_Name).ToList();
            //var result = db.View_A_SubcountyList.Where(o => o.County_Name == County_ID).Distinct().Select(a => new { a.County_ID, a.Subcounty_Name }).Distinct().OrderBy(a => a.Subcounty_Name).ToList();
            var result = db.View_A_SubcountyList.Where(o => o.County_ID == County_ID).Distinct().Select(a => new { a.Subcounty_ID, a.Subcounty_Name }).Distinct().OrderBy(a => a.Subcounty_Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetProjectCode(int Location_id)
        {
            var result = db.Projects.Where(o => o.Location_id == Location_id).Select(a => new { a.Project_id, a.Project_Desc }).Distinct().OrderBy(a => a.Project_Desc).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveApproveLeaseHoldProperty(int? Location_id,int? Project_Code, string Title_Reference, bool? Verified, int? Folio, string Volume
            , int? LandTypeCode, int? TypeCode, string Unit_No, string Flat_N0, string Block_No, string Plan_No,
            string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID,string LeaseOfferedBy,
            DateTime? Lease_Start_Date, DateTime? Lease_End_Date, int? LeaseYears_ID, string AreaOfUnit, string FloorAreaLeased,
            string UnitFactor, string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,
            bool? PropertySoldorTransferred,string ValueOfProperty, string Valuer, DateTime? DateOfValuation, string GeneralRemarks,
            int _type,bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment, string UnlockComment,
            string Added_By, DateTime? Added_Date, decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

                //if (Location_id == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                //|| Folio == null)

                //{
                //    result = "Fields marked with asterisk (*) are required!";
                //}

                //else
                //{
                    var apprleaseholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var apprleaseholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));
                                        
                    if (apprleaseholdtitlecheck == null && apprleaseholdprimkeycheck == null)
                    {

                        PropertyTitle approveleasehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle approveleaseholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {                            
                            UserManagement user = new UserManagement();
                            approveleasehold.Added_By = user.getCurrentuser();
                            approveleasehold.Added_Date = DateTime.Now;
                            approveleasehold.TitleMovementStatusID = 1;
                            approveleasehold.FinalSubmission = false;
                            approveleasehold.UnlockTitle = false;

                            approveleasehold.Location_id = Convert.ToInt32(Location_id);
                            approveleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            approveleasehold.Title_Reference = Title_Reference;
                            approveleasehold.Verified = Verified;
                            approveleasehold.LandTypeCode = LandTypeCode;
                            approveleasehold.Volume = Volume;
                            approveleasehold.Folio = Convert.ToInt32(Folio);
                            approveleasehold.TypeCode = TypeCode;
                            approveleasehold.Unit_No = Unit_No;
                            approveleasehold.Flat_N0 = Flat_N0;
                            approveleasehold.Block_No = Block_No;
                            approveleasehold.Plan_No = Plan_No;
                            approveleasehold.Plot_No = Plot_No;
                            approveleasehold.DistrictID = DistrictID;
                            approveleasehold.County_ID = County_ID;
                            approveleasehold.Subcounty_ID = Subcounty_ID;
                            approveleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            approveleasehold.Lease_Start_Date = Lease_Start_Date;
                            approveleasehold.Lease_End_Date = Lease_End_Date;
                            approveleasehold.LeaseYears_ID = LeaseYears_ID;
                            approveleasehold.AreaOfUnit = AreaOfUnit;
                            approveleasehold.FloorAreaLeased = FloorAreaLeased;
                            approveleasehold.UnitFactor = UnitFactor;
                            approveleasehold.ActualPlotSize = ActualPlotSize;
                            approveleasehold.PlotSize_ID = PlotSize_ID;
                            approveleasehold.ProprietorAddress = ProprietorAddress;
                            approveleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            approveleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approveleasehold.ValueOfProperty = ValueOfProperty;
                            approveleasehold.Valuer = Valuer;
                            approveleasehold.DateOfValuation = DateOfValuation;
                            approveleasehold.GeneralRemarks = GeneralRemarks;
                            approveleasehold.Latitude = Convert.ToDouble(Latitude);
                            approveleasehold.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Table Saving

                            approveleaseholdlog.original_Added_By = user.getCurrentuser();
                            approveleaseholdlog.original_Added_Date = DateTime.Now;
                            approveleaseholdlog.original_TitleMovementStatusID = 1;
                            approveleaseholdlog.original_FinalSubmission = false;
                            approveleaseholdlog.original_UnlockTitle = false;

                            approveleaseholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            approveleaseholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approveleaseholdlog.original_Title_Reference = Title_Reference;
                            approveleaseholdlog.original_Verified = Verified;
                            approveleaseholdlog.original_LandTypeCode = LandTypeCode;
                            approveleaseholdlog.original_Volume = Volume;
                            approveleaseholdlog.original_Folio = Convert.ToInt32(Folio);
                            approveleaseholdlog.original_TypeCode = TypeCode;
                            approveleaseholdlog.original_Unit_No = Unit_No;
                            approveleaseholdlog.original_Flat_N0 = Flat_N0;
                            approveleaseholdlog.original_Block_No = Block_No;
                            approveleaseholdlog.original_Plan_No = Plan_No;
                            approveleaseholdlog.original_Plot_No = Plot_No;
                            approveleaseholdlog.original_DistrictID = DistrictID;
                            approveleaseholdlog.original_County_ID = County_ID;
                            approveleaseholdlog.original_Subcounty_ID = Subcounty_ID;
                            approveleaseholdlog.original_LeaseOfferedBy = LeaseOfferedBy;
                            approveleaseholdlog.original_Lease_Start_Date = Lease_Start_Date;
                            approveleaseholdlog.original_Lease_End_Date = Lease_End_Date;
                            approveleaseholdlog.original_LeaseYears_ID = LeaseYears_ID;
                            approveleaseholdlog.original_AreaOfUnit = AreaOfUnit;
                            approveleaseholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            approveleaseholdlog.original_UnitFactor = UnitFactor;
                            approveleaseholdlog.original_ActualPlotSize = ActualPlotSize;
                            approveleaseholdlog.original_PlotSize_ID = PlotSize_ID;
                            approveleaseholdlog.original_ProprietorAddress = ProprietorAddress;
                            approveleaseholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            approveleaseholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            approveleaseholdlog.original_valueOfProperty = ValueOfProperty;
                            approveleaseholdlog.original_Valuer = Valuer;
                            approveleaseholdlog.original_DateOfValuation = DateOfValuation;
                            approveleaseholdlog.original_GeneralRemarks = GeneralRemarks;
                            approveleaseholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approveleaseholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(approveleasehold);
                            db.AuditLog_PropertyTitle.Add(approveleaseholdlog);
                            db.SaveChanges();

                            result = "A new LeaseHold title has been successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }

                    }

                    else if (apprleaseholdtitlecheck == null && apprleaseholdprimkeycheck != null)
                        
                    {
                        //result = "This title arleady exists in the database (Record not saved)";
                        result = "Title with the same Location,Volume and Folio arleady exists in the database (Record not saved)";
                    }
                    else //Check for if both leaseholdtitlecheck and leaseholdprimkeycheck are not null

                    {
                        result = "This title arleady exists in the database (Record not saved)";

                    }
                //}
            }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null"))

                //{
                //    result = "Please enter a Parent Title (Title Reference)!";
                //}

                //else
                //{
                    var editapproveleasehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    //Audit Log Check
                    var editapproveleaseholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == e.original_Volume && e.original_Folio == Folio);

                    if (editapproveleasehold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editapproveleasehold.Edited_By = user.getCurrentuser();
                            editapproveleasehold.Edited_Date = DateTime.Now;

                            editapproveleasehold.UnlockTitle = false;

                            //editleasehold.Location_id = Convert.ToInt32(Location_id);
                            editapproveleasehold.Title_Reference = Title_Reference;
                            editapproveleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            editapproveleasehold.Verified = Verified;
                            editapproveleasehold.LandTypeCode = LandTypeCode;
                            editapproveleasehold.TypeCode = TypeCode;
                            editapproveleasehold.Unit_No = Unit_No;
                            editapproveleasehold.Flat_N0 = Flat_N0;
                            editapproveleasehold.Block_No = Block_No;
                            editapproveleasehold.Plan_No = Plan_No;
                            editapproveleasehold.Plot_No = Plot_No;
                            editapproveleasehold.DistrictID = DistrictID;
                            editapproveleasehold.County_ID = County_ID;
                            editapproveleasehold.Subcounty_ID = Subcounty_ID;
                            editapproveleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            editapproveleasehold.Lease_Start_Date = Lease_Start_Date;
                            editapproveleasehold.Lease_End_Date = Lease_End_Date;
                            editapproveleasehold.LeaseYears_ID = LeaseYears_ID;
                            editapproveleasehold.AreaOfUnit = AreaOfUnit;
                            editapproveleasehold.FloorAreaLeased = FloorAreaLeased;
                            editapproveleasehold.UnitFactor = UnitFactor;
                            editapproveleasehold.ActualPlotSize = ActualPlotSize;
                            editapproveleasehold.PlotSize_ID = PlotSize_ID;
                            editapproveleasehold.ProprietorAddress = ProprietorAddress;
                            editapproveleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            editapproveleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapproveleasehold.ValueOfProperty = ValueOfProperty;
                            editapproveleasehold.Valuer = Valuer;
                            editapproveleasehold.DateOfValuation = DateOfValuation;
                            editapproveleasehold.GeneralRemarks = GeneralRemarks;

                            editapproveleasehold.FinalSubmission = FinalSubmission;
                            editapproveleasehold.TitleMovementStatusID = TitleMovementStatusID;
                            editapproveleasehold.RejectionComment = RejectionComment;
                            editapproveleasehold.UnlockComment = UnlockComment;
                            editapproveleasehold.Latitude = Convert.ToDouble(Latitude);
                            editapproveleasehold.Longitude = Convert.ToDouble(Longitude);

                            editapproveleasehold.Added_By = Added_By;
                            editapproveleasehold.Added_Date = Added_Date;

                            //Audit Table Saving

                            editapproveleaseholdlog.original_Edited_By = user.getCurrentuser();
                            editapproveleaseholdlog.original_Edited_Date = DateTime.Now;

                            editapproveleaseholdlog.new_UnlockTitle = false;

                            editapproveleaseholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapproveleaseholdlog.new_Volume = Volume;
                            editapproveleaseholdlog.new_Folio = Convert.ToInt32(Folio);
                            editapproveleaseholdlog.new_Title_Reference = Title_Reference;
                            editapproveleaseholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editapproveleaseholdlog.new_Verified = Verified;
                            editapproveleaseholdlog.new_LandTypeCode = LandTypeCode;
                            editapproveleaseholdlog.new_TypeCode = TypeCode;
                            editapproveleaseholdlog.new_Unit_No = Unit_No;
                            editapproveleaseholdlog.new_Flat_N0 = Flat_N0;
                            editapproveleaseholdlog.new_Block_No = Block_No;
                            editapproveleaseholdlog.new_Plan_No = Plan_No;
                            editapproveleaseholdlog.new_Plot_No = Plot_No;
                            editapproveleaseholdlog.new_DistrictID = DistrictID;
                            editapproveleaseholdlog.new_County_ID = County_ID;
                            editapproveleaseholdlog.new_Subcounty_ID = Subcounty_ID;
                            editapproveleaseholdlog.new_LeaseOfferedBy = LeaseOfferedBy;
                            editapproveleaseholdlog.new_Lease_Start_Date = Lease_Start_Date;
                            editapproveleaseholdlog.new_Lease_End_Date = Lease_End_Date;
                            editapproveleaseholdlog.new_LeaseYears_ID = LeaseYears_ID;
                            editapproveleaseholdlog.new_AreaOfUnit = AreaOfUnit;
                            editapproveleaseholdlog.new_FloorAreaLeased = FloorAreaLeased;
                            editapproveleaseholdlog.new_UnitFactor = UnitFactor;
                            editapproveleaseholdlog.new_ActualPlotSize = ActualPlotSize;
                            editapproveleaseholdlog.new_PlotSize_ID = PlotSize_ID;
                            editapproveleaseholdlog.new_ProprietorAddress = ProprietorAddress;
                            editapproveleaseholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editapproveleaseholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editapproveleaseholdlog.new_valueOfProperty = ValueOfProperty;
                            editapproveleaseholdlog.new_Valuer = Valuer;
                            editapproveleaseholdlog.new_DateOfValuation = DateOfValuation;
                            editapproveleaseholdlog.new_GeneralRemarks = GeneralRemarks;
                            editapproveleaseholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapproveleaseholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapproveleaseholdlog.new_FinalSubmission = FinalSubmission;
                            editapproveleaseholdlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapproveleaseholdlog.original_RejectionComment = RejectionComment;
                            editapproveleaseholdlog.original_UnlockComment = UnlockComment;
                            
                            editapproveleaseholdlog.new_Added_By = Added_By;
                            editapproveleaseholdlog.new_Added_Date = Added_Date;

                            db.Entry(editapproveleasehold).CurrentValues.SetValues(editapproveleasehold);
                            db.Entry(editapproveleasehold).State = EntityState.Modified;

                            db.Entry(editapproveleaseholdlog).CurrentValues.SetValues(editapproveleaseholdlog);
                            db.Entry(editapproveleaseholdlog).State = EntityState.Modified;
                                                                                                            

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
                            //result = Title_Reference + " is updated successfully";

                            //result = "Action on " + Title_Reference.Trim() + " is applied successfully";

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


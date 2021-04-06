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
    public class ApproveFreeHoldTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApproveFreeHoldTitles
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
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().OrderBy(a => a.County_Name).ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var subcounties = db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_Name).ToList();
            ViewBag.Subcounties = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        // GET: ApproveFreeHoldTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApproveFreeHoldTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApproveFreeHoldTitles/Create
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

        // GET: ApproveFreeHoldTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApproveFreeHoldTitles/Edit/5
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

        // GET: ApproveFreeHoldTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApproveFreeHoldTitles/Delete/5
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


        public ActionResult DataSourceApproveFreeHoldPropertyTitles(DataManager dm)
        {

            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 1))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 1))).ToList().Count();
                    


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

        public JsonResult GetFreeHoldData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 1).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetParent_Title(int Project_Code)
        {
            var result = db.PropertyTitles.AsNoTracking().Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectCode(int Location_id)
        {
            var result = db.Projects.AsNoTracking().Where(o => o.Location_id == Location_id).Select(a => new { a.Project_id, a.Project_Desc }).Distinct().OrderBy(a => a.Project_Desc).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistrict(int DistrictID)
        {
            var result = db.Districts.AsNoTracking().Where(o => o.DistrictID == DistrictID).Select(a => new { a.DistrictID, a.District_Name }).Distinct().OrderBy(a => a.District_Name).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCounty(int District_ID)
        {
            var result = db.Counties.AsNoTracking().Where(o => o.District_ID == District_ID).Select(a => new { a.County_ID, a.County_Name }).Distinct().OrderBy(a => a.County_Name).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubCounty(int County_ID)
        {
            //var result = db.View_A_SubcountyList.Where(o => o.County_Name == County_ID).Distinct().OrderBy(a => a.Subcounty_Name).ToList();
            //var result = db.View_A_SubcountyList.Where(o => o.County_Name == County_ID).Distinct().Select(a => new { a.County_ID, a.Subcounty_Name }).Distinct().OrderBy(a => a.Subcounty_Name).ToList();
            var result = db.View_A_SubcountyList.AsNoTracking().Where(o => o.County_ID == County_ID).Distinct().Select(a => new { a.Subcounty_ID, a.Subcounty_Name }).Distinct().OrderBy(a => a.Subcounty_Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SaveApproveFreeHoldProperty(int? Location_id, int? Project_Code, int? Folio, string Title_Reference, string Volume,
            bool? Verified, int? LandTypeCode, int? TypeCode, string Unit_No, string Block_No
            , string Flat_N0, string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID
            , string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease, string ValueOfProperty,
            string Valuer, bool? PropertySoldorTransferred, string GeneralRemarks, DateTime? DateOfValuation, int _type,
            bool? FinalSubmission,int? TitleMovementStatusID,string RejectionComment, string UnlockComment,
            string Added_By,string Plan_No, string AreaOfUnit, string UnitFactor, string FloorAreaLeased, DateTime? Added_Date,decimal? Latitude,decimal? Longitude)

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
                    var approvefreeholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvefreeholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));


                    if (approvefreeholdtitlecheck == null && approvefreeholdprimkeycheck == null)
                    {

                        PropertyTitle approvefreehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        //For Audit log table
                        AuditLog_PropertyTitle approvefreeholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };


                        try
                        {
                            UserManagement user = new UserManagement();
                            approvefreehold.Added_By = user.getCurrentuser();
                            approvefreehold.Added_Date = DateTime.Now;

                            approvefreehold.TitleMovementStatusID = 1;
                            approvefreehold.FinalSubmission = false;
                            approvefreehold.UnlockTitle = false;

                            approvefreehold.Location_id = Convert.ToInt32(Location_id);
                            approvefreehold.Project_Code = Convert.ToInt32(Project_Code);
                            approvefreehold.Title_Reference = Title_Reference;
                            approvefreehold.Verified = Verified;
                            approvefreehold.Volume = Volume;
                            approvefreehold.Folio = Convert.ToInt32(Folio);
                            approvefreehold.LandTypeCode = LandTypeCode;
                            approvefreehold.TypeCode = TypeCode;
                            approvefreehold.Block_No = Block_No;
                            approvefreehold.Unit_No = Unit_No;
                            approvefreehold.Flat_N0 = Flat_N0;
                            approvefreehold.Plot_No = Plot_No;
                            approvefreehold.DistrictID = DistrictID;
                            approvefreehold.County_ID = County_ID;
                            approvefreehold.Subcounty_ID = Subcounty_ID;
                            approvefreehold.ActualPlotSize = ActualPlotSize;
                            approvefreehold.PlotSize_ID = PlotSize_ID;
                            approvefreehold.ProprietorAddress = ProprietorAddress;
                            approvefreehold.BoardMinuteRelease = BoardMinuteRelease;
                            approvefreehold.ValueOfProperty = ValueOfProperty;
                            approvefreehold.Valuer = Valuer;
                            approvefreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approvefreehold.GeneralRemarks = GeneralRemarks;
                            approvefreehold.DateOfValuation = DateOfValuation;

                            approvefreehold.Plan_No = Plan_No;
                            approvefreehold.AreaOfUnit = AreaOfUnit;
                            approvefreehold.UnitFactor = UnitFactor;
                            approvefreehold.FloorAreaLeased = FloorAreaLeased;

                            approvefreehold.FinalSubmission = FinalSubmission;
                            approvefreehold.TitleMovementStatusID = TitleMovementStatusID;
                            approvefreehold.RejectionComment = RejectionComment;
                            approvefreehold.UnlockComment = UnlockComment;
                            approvefreehold.Latitude = Convert.ToDouble(Latitude);
                            approvefreehold.Longitude = Convert.ToDouble(Longitude);

                        //Audit Log Table Value Savings are Here  

                            approvefreeholdlog.original_Added_By = user.getCurrentuser();
                            approvefreeholdlog.original_Added_Date = DateTime.Now;

                            approvefreeholdlog.original_TitleMovementStatusID = 1;
                            approvefreeholdlog.original_FinalSubmission = false;
                            approvefreeholdlog.original_UnlockTitle = false;

                            approvefreeholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            approvefreeholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approvefreeholdlog.original_Title_Reference = Title_Reference;
                            approvefreeholdlog.original_Verified = Verified;
                            approvefreeholdlog.original_Volume = Volume;
                            approvefreeholdlog.original_Folio = Convert.ToInt32(Folio);
                            approvefreeholdlog.original_LandTypeCode = LandTypeCode;
                            approvefreeholdlog.original_TypeCode = TypeCode;
                            approvefreeholdlog.original_Block_No = Block_No;
                            approvefreeholdlog.original_Unit_No = Unit_No;
                            approvefreeholdlog.original_Flat_N0 = Flat_N0;
                            approvefreeholdlog.original_Plot_No = Plot_No;
                            approvefreeholdlog.original_DistrictID = DistrictID;
                            approvefreeholdlog.original_County_ID = County_ID;
                            approvefreeholdlog.original_Subcounty_ID = Subcounty_ID;
                            approvefreeholdlog.original_ActualPlotSize = ActualPlotSize;
                            approvefreeholdlog.original_PlotSize_ID = PlotSize_ID;
                            approvefreeholdlog.original_ProprietorAddress = ProprietorAddress;
                            approvefreeholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            approvefreeholdlog.original_valueOfProperty = ValueOfProperty;
                            approvefreeholdlog.original_Valuer = Valuer;
                            approvefreeholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            approvefreeholdlog.original_GeneralRemarks = GeneralRemarks;
                            approvefreeholdlog.original_DateOfValuation = DateOfValuation;

                            approvefreeholdlog.original_Plan_No = Plan_No;
                            approvefreeholdlog.original_AreaOfUnit = AreaOfUnit;
                            approvefreeholdlog.original_UnitFactor = UnitFactor;
                            approvefreeholdlog.original_FloorAreaLeased = FloorAreaLeased;

                            approvefreeholdlog.original_FinalSubmission = FinalSubmission;
                            approvefreeholdlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approvefreeholdlog.original_RejectionComment = RejectionComment;
                            approvefreeholdlog.original_UnlockComment = UnlockComment;
                            approvefreeholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approvefreeholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(approvefreehold);
                            db.AuditLog_PropertyTitle.Add(approvefreeholdlog);
                            db.SaveChanges();                                                       

                            result = "A new freehold title has been successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (approvefreeholdtitlecheck == null && approvefreeholdprimkeycheck != null)
                    {

                        result = "Title with the same Location,Volume and Folio arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both freeholdtitlecheck and freeholdprimkeycheck are not null

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
                    var editapprovefreehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    //Audit_Log Table Check
                    var editapprovefreeholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editapprovefreehold != null)
                    {
                        try
                        {
                            UserManagement user = new UserManagement();
                            editapprovefreehold.Edited_By = user.getCurrentuser();
                            editapprovefreehold.Edited_Date = DateTime.Now;
                            
                            editapprovefreehold.UnlockTitle = false;

                            editapprovefreehold.Verified = Verified;
                            //editfreehold.Location_id = Convert.ToInt32(Location_id);
                            editapprovefreehold.Project_Code = Convert.ToInt32(Project_Code);
                            editapprovefreehold.Title_Reference = Title_Reference;
                            //editfreehold.Volume = Volume;
                            //editfreehold.Folio = Convert.ToInt32(Folio);
                            editapprovefreehold.LandTypeCode = LandTypeCode;
                            editapprovefreehold.TypeCode = TypeCode;
                            editapprovefreehold.Block_No = Block_No;
                            editapprovefreehold.Unit_No = Unit_No;
                            editapprovefreehold.Flat_N0 = Flat_N0;
                            editapprovefreehold.Plot_No = Plot_No;
                            editapprovefreehold.DistrictID = DistrictID;
                            editapprovefreehold.County_ID = County_ID;
                            editapprovefreehold.Subcounty_ID = Subcounty_ID;
                            editapprovefreehold.ActualPlotSize = ActualPlotSize;
                            editapprovefreehold.PlotSize_ID = PlotSize_ID;
                            editapprovefreehold.ProprietorAddress = ProprietorAddress;
                            editapprovefreehold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovefreehold.ValueOfProperty = ValueOfProperty;
                            editapprovefreehold.Valuer = Valuer;
                            editapprovefreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovefreehold.GeneralRemarks = GeneralRemarks;
                            editapprovefreehold.DateOfValuation = DateOfValuation;

                            editapprovefreehold.Plan_No = Plan_No;
                            editapprovefreehold.AreaOfUnit = AreaOfUnit;
                            editapprovefreehold.UnitFactor = UnitFactor;
                            editapprovefreehold.FloorAreaLeased = FloorAreaLeased;

                            editapprovefreehold.FinalSubmission = FinalSubmission;
                            editapprovefreehold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovefreehold.RejectionComment = RejectionComment;
                            editapprovefreehold.UnlockComment = UnlockComment;

                            editapprovefreehold.Added_By = Added_By;
                            editapprovefreehold.Added_Date = Added_Date;
                            editapprovefreehold.Latitude = Convert.ToDouble(Latitude);
                            editapprovefreehold.Longitude = Convert.ToDouble(Longitude);

                            //Audit_Log Table Saving 

                            editapprovefreeholdlog.original_Edited_By = user.getCurrentuser();
                            editapprovefreeholdlog.original_Edited_Date = DateTime.Now;

                            editapprovefreeholdlog.new_UnlockTitle = false;

                            editapprovefreeholdlog.new_Verified = Verified;
                            editapprovefreeholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapprovefreeholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editapprovefreeholdlog.new_Title_Reference = Title_Reference;
                            editapprovefreeholdlog.new_Volume = Volume;
                            editapprovefreeholdlog.new_Folio = Convert.ToInt32(Folio);
                            editapprovefreeholdlog.new_LandTypeCode = LandTypeCode;
                            editapprovefreeholdlog.new_TypeCode = TypeCode;
                            editapprovefreeholdlog.new_Block_No = Block_No;
                            editapprovefreeholdlog.new_Unit_No = Unit_No;
                            editapprovefreeholdlog.new_Flat_N0 = Flat_N0;
                            editapprovefreeholdlog.new_Plot_No = Plot_No;
                            editapprovefreeholdlog.new_DistrictID = DistrictID;
                            editapprovefreeholdlog.new_County_ID = County_ID;
                            editapprovefreeholdlog.new_Subcounty_ID = Subcounty_ID;
                            editapprovefreeholdlog.new_ActualPlotSize = ActualPlotSize;
                            editapprovefreeholdlog.new_PlotSize_ID = PlotSize_ID;
                            editapprovefreeholdlog.new_ProprietorAddress = ProprietorAddress;
                            editapprovefreeholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editapprovefreeholdlog.new_valueOfProperty = ValueOfProperty;
                            editapprovefreeholdlog.new_Valuer = Valuer;
                            editapprovefreeholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovefreeholdlog.new_GeneralRemarks = GeneralRemarks;
                            editapprovefreeholdlog.new_DateOfValuation = DateOfValuation;

                            editapprovefreeholdlog.new_Plan_No = Plan_No;
                            editapprovefreeholdlog.new_AreaOfUnit = AreaOfUnit;
                            editapprovefreeholdlog.new_UnitFactor = UnitFactor;
                            editapprovefreeholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editapprovefreeholdlog.new_FinalSubmission = FinalSubmission;
                            editapprovefreeholdlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapprovefreeholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapprovefreeholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapprovefreeholdlog.original_RejectionComment = RejectionComment;
                            editapprovefreeholdlog.original_UnlockComment = UnlockComment;

                            editapprovefreeholdlog.new_Added_By = Added_By;
                            editapprovefreeholdlog.new_Added_Date = Added_Date;
                            



                            db.Entry(editapprovefreehold).CurrentValues.SetValues(editapprovefreehold);
                            db.Entry(editapprovefreehold).State = EntityState.Modified;
                            db.Entry(editapprovefreeholdlog).CurrentValues.SetValues(editapprovefreeholdlog);
                            db.Entry(editapprovefreeholdlog).State = EntityState.Modified;

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

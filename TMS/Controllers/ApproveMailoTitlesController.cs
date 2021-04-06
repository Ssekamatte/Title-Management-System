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
    public class ApproveMailoTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        // GET: ApproveMailoTitles
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
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().OrderBy(a => a.County_Name).ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var subcounties = db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_Name).ToList();
            ViewBag.Subcounties = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        // GET: ApproveMailoTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApproveMailoTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApproveMailoTitles/Create
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

        // GET: ApproveMailoTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApproveMailoTitles/Edit/5
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

        // GET: ApproveMailoTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApproveMailoTitles/Delete/5
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


        public ActionResult DataSourceApprovedMailoTitles(DataManager dm)
        {

            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 2))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 2))).ToList().Count();

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


        public ActionResult GetParent_Title(int Project_Code)
        {
            var result = db.PropertyTitles.AsNoTracking().Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
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
        public JsonResult GetMailoData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectCode(int Location_id)
        {
            var result = db.Projects.Where(o => o.Location_id == Location_id).Select(a => new { a.Project_id, a.Project_Desc }).Distinct().OrderBy(a => a.Project_Desc).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveApproveMailoProperty(int? Location_id,int? Project_Code, string Title_Reference, bool? Verified, int? LandTypeCode, string Volume, int? Folio
            , int? TypeCode, string Unit_No, string Block_No, string Flat_N0, string Plan_No, string Plot_No, int? DistrictID, int? County_ID,
            int? Subcounty_ID, string AreaOfUnit, string UnitFactor, string ProprietorAddress, string BoardMinuteRelease,
            bool? PropertySoldorTransferred, string ActualPlotSize, int? PlotSize_ID,string ValueOfProperty, string Valuer,
            DateTime? DateOfValuation, string GeneralRemarks, int _type,bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment, 
            string UnlockComment,string Added_By, string FloorAreaLeased,DateTime? Added_Date,decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

                //if (Location_id == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                //|| Folio == null)

                //{
                //    result = "Fields marked with asterisk (*) are required (Record Not Saved)!";
                //}

                //else if (TypeCode == 2 && string.IsNullOrEmpty(Unit_No))

                //{
                //    result = "All Condominium Properties require a Unit Number (Record Not Saved)!";

                //}

                //else if (TypeCode == 1 && string.IsNullOrEmpty(Plot_No))
                //{
                //    result = "All Stand Alone Properties require a Plot Number (Record Not Saved)!";

                //}

                //else if (TypeCode == 3 && string.IsNullOrEmpty(Plot_No))
                //{
                //    result = "All Unlisted Land Types/ Properties require a Plot Number (Record Not Saved)!";

                //}


                //else
                //{
                    var apprmailotitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var apprmailoprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (apprmailotitlecheck == null && apprmailoprimkeycheck == null)
                    {

                        PropertyTitle approvemailohold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle approvemailoholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                        //PropertyTitle approvemailohold = new PropertyTitle();
                        UserManagement user = new UserManagement();
                        approvemailohold.Added_By = user.getCurrentuser();
                        approvemailohold.Added_Date = DateTime.Now;

                        approvemailohold.UnlockTitle = false;

                        approvemailohold.Location_id = Convert.ToInt32(Location_id);
                        approvemailohold.Project_Code = Convert.ToInt32(Project_Code);
                        approvemailohold.Title_Reference = Title_Reference;
                        approvemailohold.Verified = Verified;
                        approvemailohold.LandTypeCode = LandTypeCode;
                        approvemailohold.Volume = Volume;
                        approvemailohold.Folio = Convert.ToInt32(Folio);
                        approvemailohold.TypeCode = TypeCode;
                        approvemailohold.Unit_No = Unit_No;
                        approvemailohold.Block_No = Block_No;
                        approvemailohold.Flat_N0 = Flat_N0;
                        approvemailohold.Plan_No = Plan_No;
                        approvemailohold.Plot_No = Plot_No;
                        approvemailohold.DistrictID = DistrictID;
                        approvemailohold.County_ID = County_ID;
                        approvemailohold.Subcounty_ID = Subcounty_ID;
                        
                        approvemailohold.AreaOfUnit = AreaOfUnit;
                        approvemailohold.UnitFactor = UnitFactor;
                        approvemailohold.ProprietorAddress = ProprietorAddress;
                        approvemailohold.BoardMinuteRelease = BoardMinuteRelease;
                        approvemailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                        approvemailohold.ActualPlotSize = ActualPlotSize;
                        approvemailohold.PlotSize_ID = PlotSize_ID;
                        approvemailohold.ValueOfProperty = ValueOfProperty;
                        approvemailohold.Valuer = Valuer;
                        approvemailohold.DateOfValuation = DateOfValuation;
                        approvemailohold.GeneralRemarks = GeneralRemarks;

                        approvemailohold.FloorAreaLeased = FloorAreaLeased;
                        approvemailohold.Latitude = Convert.ToDouble(Latitude);
                        approvemailohold.Longitude = Convert.ToDouble(Longitude);

                        approvemailohold.FinalSubmission = FinalSubmission;
                        approvemailohold.TitleMovementStatusID = TitleMovementStatusID;
                        approvemailohold.RejectionComment = RejectionComment;
                        approvemailohold.UnlockComment = UnlockComment;


                            //Audit Log Table Saving

                            approvemailoholdlog.original_Added_By = user.getCurrentuser();
                            approvemailoholdlog.original_Added_Date = DateTime.Now;

                            approvemailoholdlog.original_UnlockTitle = false;

                            approvemailoholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            approvemailoholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approvemailoholdlog.original_Title_Reference = Title_Reference;
                            approvemailoholdlog.original_Verified = Verified;
                            approvemailoholdlog.original_LandTypeCode = LandTypeCode;
                            approvemailoholdlog.original_Volume = Volume;
                            approvemailoholdlog.original_Folio = Convert.ToInt32(Folio);
                            approvemailoholdlog.original_TypeCode = TypeCode;
                            approvemailoholdlog.original_Unit_No = Unit_No;
                            approvemailoholdlog.original_Block_No = Block_No;
                            approvemailoholdlog.original_Flat_N0 = Flat_N0;
                            approvemailoholdlog.original_Plan_No = Plan_No;
                            approvemailoholdlog.original_Plot_No = Plot_No;
                            approvemailoholdlog.original_DistrictID = DistrictID;
                            approvemailoholdlog.original_County_ID = County_ID;
                            approvemailoholdlog.original_Subcounty_ID = Subcounty_ID;

                            approvemailoholdlog.original_AreaOfUnit = AreaOfUnit;
                            approvemailoholdlog.original_UnitFactor = UnitFactor;
                            approvemailoholdlog.original_ProprietorAddress = ProprietorAddress;
                            approvemailoholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            approvemailoholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            approvemailoholdlog.original_ActualPlotSize = ActualPlotSize;
                            approvemailoholdlog.original_PlotSize_ID = PlotSize_ID;
                            approvemailoholdlog.original_valueOfProperty = ValueOfProperty;
                            approvemailoholdlog.original_Valuer = Valuer;
                            approvemailoholdlog.original_DateOfValuation = DateOfValuation;
                            approvemailoholdlog.original_GeneralRemarks = GeneralRemarks;

                            approvemailoholdlog.original_FloorAreaLeased = FloorAreaLeased;

                            approvemailoholdlog.original_FinalSubmission = FinalSubmission;
                            approvemailoholdlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approvemailoholdlog.original_RejectionComment = RejectionComment;
                            approvemailoholdlog.original_UnlockComment = UnlockComment;
                            approvemailoholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approvemailoholdlog.Original_Longitude = Convert.ToDouble(Longitude);
                            
                            db.PropertyTitles.Add(approvemailohold);
                            db.AuditLog_PropertyTitle.Add(approvemailoholdlog);

                            db.SaveChanges();

                        result = "A new Mailo title has been successfully added......";

                    }
                    catch (DbEntityValidationException ex)
                    {
                        result = ex.Message.ToString();
                    }
                }
                    else if (apprmailotitlecheck == null && apprmailoprimkeycheck != null)

                      

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
                //    result = "Please enter a Parent Title (Title Reference) (Record Not Saved)!";
                //}

                //else if (TypeCode == 2 && string.IsNullOrEmpty(Unit_No))

                //{
                //    result = "All Condominium Properties require a Unit Number (Record Not Saved)!";

                //}

                //else if (TypeCode == 1 && string.IsNullOrEmpty(Plot_No))
                //{
                //    result = "All Stand Alone Properties require a Plot Number (Record Not Saved)!";

                //}

                //else if (TypeCode == 3 && string.IsNullOrEmpty(Plot_No))
                //{
                //    result = "All Unlisted Land Types/ Properties require a Plot Number (Record Not Saved)!";

                //}

                //else
                //{                   
                    var editapprovemailo = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    var editapprovemailolog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);


                    if (editapprovemailo != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editapprovemailo.Edited_By = user.getCurrentuser();
                            editapprovemailo.Edited_Date = DateTime.Now;

                            editapprovemailo.UnlockTitle = false;

                            //editapprovemailo.Location_id = Convert.ToInt32(Location_id);

                            editapprovemailo.Title_Reference = Title_Reference;
                            editapprovemailo.Project_Code = Convert.ToInt32(Project_Code);
                            editapprovemailo.Verified = Verified;
                            editapprovemailo.LandTypeCode = LandTypeCode;
                            editapprovemailo.TypeCode = TypeCode;
                            editapprovemailo.Unit_No = Unit_No;
                            editapprovemailo.Block_No = Block_No;
                            editapprovemailo.Flat_N0 = Flat_N0;
                            editapprovemailo.Plan_No = Plan_No;
                            editapprovemailo.Plot_No = Plot_No;
                            editapprovemailo.DistrictID = DistrictID;
                            editapprovemailo.County_ID = County_ID;
                            editapprovemailo.Subcounty_ID = Subcounty_ID;
                            
                            editapprovemailo.AreaOfUnit = AreaOfUnit;
                            editapprovemailo.UnitFactor = UnitFactor;
                            editapprovemailo.ProprietorAddress = ProprietorAddress;
                            editapprovemailo.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovemailo.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovemailo.ActualPlotSize = ActualPlotSize;
                            editapprovemailo.PlotSize_ID = PlotSize_ID;
                            editapprovemailo.ValueOfProperty = ValueOfProperty;
                            editapprovemailo.Valuer = Valuer;
                            editapprovemailo.DateOfValuation = DateOfValuation;
                            editapprovemailo.GeneralRemarks = GeneralRemarks;

                            editapprovemailo.FloorAreaLeased = FloorAreaLeased;

                            editapprovemailo.FinalSubmission = FinalSubmission;
                            editapprovemailo.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovemailo.RejectionComment = RejectionComment;
                            editapprovemailo.UnlockComment = UnlockComment;
                            editapprovemailo.Latitude = Convert.ToDouble(Latitude);
                            editapprovemailo.Longitude = Convert.ToDouble(Longitude);

                            editapprovemailo.Added_By = Added_By;
                            editapprovemailo.Added_Date = Added_Date;


                            //Audit Log Table Saving

                            editapprovemailolog.original_Edited_By = user.getCurrentuser();
                            editapprovemailolog.original_Edited_Date = DateTime.Now;

                            editapprovemailolog.new_UnlockTitle = false;

                            editapprovemailolog.new_Locationid = Convert.ToInt32(Location_id);
                            editapprovemailolog.new_Volume = Volume;
                            editapprovemailolog.new_Folio = Convert.ToInt32(Folio);

                            editapprovemailolog.new_Title_Reference = Title_Reference;
                            editapprovemailolog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editapprovemailolog.new_Verified = Verified;
                            editapprovemailolog.new_LandTypeCode = LandTypeCode;
                            editapprovemailolog.new_TypeCode = TypeCode;
                            editapprovemailolog.new_Unit_No = Unit_No;
                            editapprovemailolog.new_Block_No = Block_No;
                            editapprovemailolog.new_Flat_N0 = Flat_N0;
                            editapprovemailolog.new_Plan_No = Plan_No;
                            editapprovemailolog.new_Plot_No = Plot_No;
                            editapprovemailolog.new_DistrictID = DistrictID;
                            editapprovemailolog.new_County_ID = County_ID;
                            editapprovemailolog.new_Subcounty_ID = Subcounty_ID;

                            editapprovemailolog.new_AreaOfUnit = AreaOfUnit;
                            editapprovemailolog.new_UnitFactor = UnitFactor;
                            editapprovemailolog.new_ProprietorAddress = ProprietorAddress;
                            editapprovemailolog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editapprovemailolog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovemailolog.new_ActualPlotSize = ActualPlotSize;
                            editapprovemailolog.new_PlotSize_ID = PlotSize_ID;
                            editapprovemailolog.new_valueOfProperty = ValueOfProperty;
                            editapprovemailolog.new_Valuer = Valuer;
                            editapprovemailolog.new_DateOfValuation = DateOfValuation;
                            editapprovemailolog.new_GeneralRemarks = GeneralRemarks;

                            editapprovemailolog.new_FloorAreaLeased = FloorAreaLeased;

                            editapprovemailolog.new_FinalSubmission = FinalSubmission;
                            editapprovemailolog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapprovemailolog.New_Latitude = Convert.ToDouble(Latitude);
                            editapprovemailolog.New_Longitude = Convert.ToDouble(Longitude);

                            editapprovemailolog.original_RejectionComment = RejectionComment;
                            editapprovemailolog.original_UnlockComment = UnlockComment;

                            editapprovemailolog.new_Added_By = Added_By;
                            editapprovemailolog.new_Added_Date = Added_Date;


                            db.Entry(editapprovemailo).CurrentValues.SetValues(editapprovemailo);
                            db.Entry(editapprovemailo).State = EntityState.Modified;

                            db.Entry(editapprovemailolog).CurrentValues.SetValues(editapprovemailolog);
                            db.Entry(editapprovemailolog).State = EntityState.Modified;

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


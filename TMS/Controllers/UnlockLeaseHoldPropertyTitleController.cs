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
    public class UnlockLeaseHoldPropertyTitleController : Controller
    {
        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: UnlockLeaseHoldPropertyTitle
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult UnlockLeaseHoldPropertyTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().OrderBy(a => a.District_Name).ToList();
            ViewBag.Districts = districts;

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
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            //db.Configuration.ProxyCreationEnabled = false;
            //var employees = db.A_Employee.AsNoTracking().OrderBy(a => a.Employee_Name).ToList();
            //ViewBag.A_Employee = employees;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

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

        public ActionResult UnlockLeaseHoldPropertyTitlesAdmin()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().OrderBy(a => a.District_Name).ToList();
            ViewBag.Districts = districts;

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
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            //db.Configuration.ProxyCreationEnabled = false;
            //var employees = db.A_Employee.AsNoTracking().OrderBy(a => a.Employee_Name).ToList();
            //ViewBag.A_Employee = employees;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

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
        // GET: UnlockLeaseHoldPropertyTitle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnlockLeaseHoldPropertyTitle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnlockLeaseHoldPropertyTitle/Create
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

        // GET: UnlockLeaseHoldPropertyTitle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnlockLeaseHoldPropertyTitle/Edit/5
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

        // GET: UnlockLeaseHoldPropertyTitle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnlockLeaseHoldPropertyTitle/Delete/5
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


        public ActionResult DataSourceLeaseHold(DataManager dm)
        {
            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 3) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 3) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 3) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 3) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

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

        public ActionResult DialogUpdate(PropertyTitle value)
        {
            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code &&
            o.Volume == value.Volume &&
            o.Folio == value.Folio);

            string strpropname = value.ProprietorName;
            string propname = "";
            //Remove the '\n' from the proprietorname field
            if (string.IsNullOrEmpty(strpropname))
            { }
            else
            {
                propname = Regex.Replace(strpropname, @"\t|\n|\r", "");
            }

            var proprietorname = propname.Trim();
            if (proprietorname.Length > 50)
            {
                value.ProprietorName = proprietorname.Substring(0, 49);
            }
            else
            {
                value.ProprietorName = proprietorname;
            }

            if (table != null)
            {
                //value.Edited_Date = DateTime.Now;
                //value.Edited_By = "Wakayima!!!";

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
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

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
            //if (db.SaveChanges() > 0)
            //{
            //    TempData["Success"] = "Record Saved Successfully!";
            //}
            //else
            //{
            //    TempData["Success"] = "Record Not Saved!";
            //}
            return Json(value, JsonRequestBehavior.AllowGet);

            //return Json(new
            //{
            //    msg = "Successfully added " + value.OrderNumber,
            //    JsonRequestBehavior.AllowGet
            //});
        }

        public ActionResult DialogInsert(PropertyTitle value)
        {
            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code &&
            o.Volume == value.Volume &&
            o.Folio == value.Folio);

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

                    db.PropertyTitles.Add(value);
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

        public ActionResult DialogDelete(int Project_Code, int Folio, string Volume)
        {

            PropertyTitle result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code &&
            o.Folio == Folio && o.Volume == Volume).FirstOrDefault();
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

        public ActionResult SaveUnlockedLeaseHoldProperty(int? Location_id, int? Project_Code, string Title_Reference, bool? Verified, int? Folio, string Volume
              , int? LandTypeCode, int? TypeCode, string Unit_No, string Flat_N0, string Block_No, string Plan_No,
              string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID, string LeaseOfferedBy,
              DateTime? Lease_Start_Date, DateTime? Lease_End_Date, int? LeaseYears_ID, string AreaOfUnit, string FloorAreaLeased,
              string UnitFactor, string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,
              bool? PropertySoldorTransferred,string ValueOfProperty, string Valuer, DateTime? DateOfValuation, string GeneralRemarks,
              int _type, string RejectionComment, string UnlockComment,string Added_By, DateTime? Added_Date, decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (Location_id == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                || string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                || Folio == null)

                {
                    result = "Fields marked with asterisk (*) are required!";
                }

                else
                {
                    var unlockleaseholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var unlockleaseholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    //if (freeholdtitlecheck == null)
                    if (unlockleaseholdtitlecheck == null && unlockleaseholdprimkeycheck == null)
                    {

                        PropertyTitle unlockleasehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle unlockleaseholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle unlockleasehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            unlockleasehold.Added_By = user.getCurrentuser();
                            unlockleasehold.Added_Date = DateTime.Now;

                            unlockleasehold.TitleMovementStatusID = 1;
                            unlockleasehold.FinalSubmission = false;
                            unlockleasehold.UnlockTitle = false;

                            unlockleasehold.Location_id = Convert.ToInt32(Location_id);
                            unlockleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            unlockleasehold.Title_Reference = Title_Reference;
                            unlockleasehold.Verified = Verified;
                            unlockleasehold.LandTypeCode = LandTypeCode;
                            unlockleasehold.Volume = Volume;
                            unlockleasehold.Folio = Convert.ToInt32(Folio);
                            unlockleasehold.TypeCode = TypeCode;
                            unlockleasehold.Unit_No = Unit_No;
                            unlockleasehold.Flat_N0 = Flat_N0;
                            unlockleasehold.Block_No = Block_No;
                            unlockleasehold.Plan_No = Plan_No;
                            unlockleasehold.Plot_No = Plot_No;
                            unlockleasehold.DistrictID = DistrictID;
                            unlockleasehold.County_ID = County_ID;
                            unlockleasehold.Subcounty_ID = Subcounty_ID;

                            unlockleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            unlockleasehold.Lease_Start_Date = Lease_Start_Date;
                            unlockleasehold.Lease_End_Date = Lease_End_Date;
                            unlockleasehold.LeaseYears_ID = LeaseYears_ID;
                            unlockleasehold.AreaOfUnit = AreaOfUnit;
                            unlockleasehold.FloorAreaLeased = FloorAreaLeased;
                            unlockleasehold.UnitFactor = UnitFactor;
                            unlockleasehold.ActualPlotSize = ActualPlotSize;
                            unlockleasehold.PlotSize_ID = PlotSize_ID;
                            unlockleasehold.ProprietorAddress = ProprietorAddress;
                            unlockleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            unlockleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            unlockleasehold.ValueOfProperty = ValueOfProperty;
                            unlockleasehold.Valuer = Valuer;
                            unlockleasehold.DateOfValuation = DateOfValuation;
                            unlockleasehold.GeneralRemarks = GeneralRemarks;

                            unlockleasehold.RejectionComment = RejectionComment;
                            unlockleasehold.UnlockComment = UnlockComment;
                            unlockleasehold.Latitude = Convert.ToDouble(Latitude);
                            unlockleasehold.Longitude = Convert.ToDouble(Longitude);
                            //Audit Log Tables Save

                            unlockleaseholdlog.original_Added_By = user.getCurrentuser();
                            unlockleaseholdlog.original_Added_Date = DateTime.Now;

                            unlockleaseholdlog.original_TitleMovementStatusID = 1;
                            unlockleaseholdlog.original_FinalSubmission = false;
                            unlockleaseholdlog.original_UnlockTitle = false;

                            unlockleaseholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            unlockleaseholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            unlockleaseholdlog.original_Title_Reference = Title_Reference;
                            unlockleaseholdlog.original_Verified = Verified;
                            unlockleaseholdlog.original_LandTypeCode = LandTypeCode;
                            unlockleaseholdlog.original_Volume = Volume;
                            unlockleaseholdlog.original_Folio = Convert.ToInt32(Folio);
                            unlockleaseholdlog.original_TypeCode = TypeCode;
                            unlockleaseholdlog.original_Unit_No = Unit_No;
                            unlockleaseholdlog.original_Flat_N0 = Flat_N0;
                            unlockleaseholdlog.original_Block_No = Block_No;
                            unlockleaseholdlog.original_Plan_No = Plan_No;
                            unlockleaseholdlog.original_Plot_No = Plot_No;
                            unlockleaseholdlog.original_DistrictID = DistrictID;
                            unlockleaseholdlog.original_County_ID = County_ID;
                            unlockleaseholdlog.original_Subcounty_ID = Subcounty_ID;

                            unlockleaseholdlog.original_LeaseOfferedBy = LeaseOfferedBy;
                            unlockleaseholdlog.original_Lease_Start_Date = Lease_Start_Date;
                            unlockleaseholdlog.original_Lease_End_Date = Lease_End_Date;
                            unlockleaseholdlog.original_LeaseYears_ID = LeaseYears_ID;
                            unlockleaseholdlog.original_AreaOfUnit = AreaOfUnit;
                            unlockleaseholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            unlockleaseholdlog.original_UnitFactor = UnitFactor;
                            unlockleaseholdlog.original_ActualPlotSize = ActualPlotSize;
                            unlockleaseholdlog.original_PlotSize_ID = PlotSize_ID;
                            unlockleaseholdlog.original_ProprietorAddress = ProprietorAddress;
                            unlockleaseholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            unlockleaseholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            unlockleaseholdlog.original_valueOfProperty = ValueOfProperty;
                            unlockleaseholdlog.original_Valuer = Valuer;
                            unlockleaseholdlog.original_DateOfValuation = DateOfValuation;
                            unlockleaseholdlog.original_GeneralRemarks = GeneralRemarks;

                            unlockleaseholdlog.original_RejectionComment = RejectionComment;
                            unlockleaseholdlog.original_UnlockComment = UnlockComment;
                            unlockleaseholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            unlockleaseholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(unlockleasehold);
                            db.AuditLog_PropertyTitle.Add(unlockleaseholdlog);
                            db.SaveChanges();

                            result = "Record successfully saved......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (unlockleaseholdtitlecheck == null && unlockleaseholdprimkeycheck != null)
                       
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

                if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null"))

                {
                    result = "Please enter a Parent Title (Title Reference)!";
                }

                else
                {
                    var editunlockleasehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    var editunlockleaseholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editunlockleasehold != null)
                    {
                        try
                        {

                            UserManagement user = new UserManagement();
                            editunlockleasehold.Edited_By = user.getCurrentuser();
                            editunlockleasehold.Edited_Date = DateTime.Now;

                            editunlockleasehold.TitleMovementStatusID = 1;
                            editunlockleasehold.FinalSubmission = false;
                            editunlockleasehold.UnlockTitle = false;

                            editunlockleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            editunlockleasehold.Title_Reference = Title_Reference;
                            editunlockleasehold.Verified = Verified;
                            editunlockleasehold.LandTypeCode = LandTypeCode;
                            editunlockleasehold.TypeCode = TypeCode;
                            editunlockleasehold.Unit_No = Unit_No;
                            editunlockleasehold.Flat_N0 = Flat_N0;
                            editunlockleasehold.Block_No = Block_No;
                            editunlockleasehold.Plan_No = Plan_No;
                            editunlockleasehold.Plot_No = Plot_No;
                            editunlockleasehold.DistrictID = DistrictID;
                            editunlockleasehold.County_ID = County_ID;
                            editunlockleasehold.Subcounty_ID = Subcounty_ID;
                           
                            editunlockleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            editunlockleasehold.Lease_Start_Date = Lease_Start_Date;
                            editunlockleasehold.Lease_End_Date = Lease_End_Date;
                            editunlockleasehold.LeaseYears_ID = LeaseYears_ID;
                            editunlockleasehold.AreaOfUnit = AreaOfUnit;
                            editunlockleasehold.FloorAreaLeased = FloorAreaLeased;
                            editunlockleasehold.UnitFactor = UnitFactor;
                            editunlockleasehold.ActualPlotSize = ActualPlotSize;
                            editunlockleasehold.PlotSize_ID = PlotSize_ID;
                            editunlockleasehold.ProprietorAddress = ProprietorAddress;
                            editunlockleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            editunlockleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editunlockleasehold.ValueOfProperty = ValueOfProperty;
                            editunlockleasehold.Valuer = Valuer;
                            editunlockleasehold.DateOfValuation = DateOfValuation;
                            editunlockleasehold.GeneralRemarks = GeneralRemarks;
                            
                            editunlockleasehold.RejectionComment = RejectionComment;
                            editunlockleasehold.UnlockComment = UnlockComment;
                            editunlockleasehold.Latitude = Convert.ToDouble(Latitude);
                            editunlockleasehold.Longitude = Convert.ToDouble(Longitude);

                            editunlockleasehold.Added_By = Added_By;
                            editunlockleasehold.Added_Date = Added_Date;

                            //Audit Log Table Save

                            editunlockleaseholdlog.original_Edited_By = user.getCurrentuser();
                            editunlockleaseholdlog.original_Edited_Date = DateTime.Now;

                            editunlockleaseholdlog.new_TitleMovementStatusID = 1;
                            editunlockleaseholdlog.new_FinalSubmission = false;
                            editunlockleaseholdlog.new_UnlockTitle = false;

                            editunlockleaseholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editunlockleaseholdlog.new_Volume = Volume;
                            editunlockleaseholdlog.new_Folio = Convert.ToInt32(Folio);

                            editunlockleaseholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editunlockleaseholdlog.new_Title_Reference = Title_Reference;
                            editunlockleaseholdlog.new_Verified = Verified;
                            editunlockleaseholdlog.new_LandTypeCode = LandTypeCode;
                            editunlockleaseholdlog.new_TypeCode = TypeCode;
                            editunlockleaseholdlog.new_Unit_No = Unit_No;
                            editunlockleaseholdlog.new_Flat_N0 = Flat_N0;
                            editunlockleaseholdlog.new_Block_No = Block_No;
                            editunlockleaseholdlog.new_Plan_No = Plan_No;
                            editunlockleaseholdlog.new_Plot_No = Plot_No;
                            editunlockleaseholdlog.new_DistrictID = DistrictID;
                            editunlockleaseholdlog.new_County_ID = County_ID;
                            editunlockleaseholdlog.new_Subcounty_ID = Subcounty_ID;

                            editunlockleaseholdlog.new_LeaseOfferedBy = LeaseOfferedBy;
                            editunlockleaseholdlog.new_Lease_Start_Date = Lease_Start_Date;
                            editunlockleaseholdlog.new_Lease_End_Date = Lease_End_Date;
                            editunlockleaseholdlog.new_LeaseYears_ID = LeaseYears_ID;
                            editunlockleaseholdlog.new_AreaOfUnit = AreaOfUnit;
                            editunlockleaseholdlog.new_FloorAreaLeased = FloorAreaLeased;
                            editunlockleaseholdlog.new_UnitFactor = UnitFactor;
                            editunlockleaseholdlog.new_ActualPlotSize = ActualPlotSize;
                            editunlockleaseholdlog.new_PlotSize_ID = PlotSize_ID;
                            editunlockleaseholdlog.new_ProprietorAddress = ProprietorAddress;
                            editunlockleaseholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editunlockleaseholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editunlockleaseholdlog.new_valueOfProperty = ValueOfProperty;
                            editunlockleaseholdlog.new_Valuer = Valuer;
                            editunlockleaseholdlog.new_DateOfValuation = DateOfValuation;
                            editunlockleaseholdlog.new_GeneralRemarks = GeneralRemarks;

                            editunlockleaseholdlog.new_RejectionComment = RejectionComment;
                            editunlockleaseholdlog.new_UnlockComment = UnlockComment;
                            editunlockleaseholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editunlockleaseholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editunlockleasehold.Added_By = Added_By;
                            editunlockleasehold.Added_Date = Added_Date;

                            db.Entry(editunlockleasehold).CurrentValues.SetValues(editunlockleasehold);
                            db.Entry(editunlockleasehold).State = EntityState.Modified;

                            db.Entry(editunlockleaseholdlog).CurrentValues.SetValues(editunlockleaseholdlog);
                            db.Entry(editunlockleaseholdlog).State = EntityState.Modified;

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

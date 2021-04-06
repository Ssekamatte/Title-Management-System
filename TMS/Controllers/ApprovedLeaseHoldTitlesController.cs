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
    public class ApprovedLeaseHoldTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApprovedLeaseHoldTitles
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
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        public ActionResult ApprovedLeaseHoldCEO()
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
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;
                      
            return View();
        }

        // GET: ApprovedLeaseHoldTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApprovedLeaseHoldTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedLeaseHoldTitles/Create
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

        // GET: ApprovedLeaseHoldTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApprovedLeaseHoldTitles/Edit/5
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

        // GET: ApprovedLeaseHoldTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApprovedLeaseHoldTitles/Delete/5
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


        public ActionResult DataSourceApprovedLeaseHoldTitles(DataManager dm)
        {

            //Returns all the fields in the table based on the Title Movement Status ID

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false) && (b.LandTypeCode == 3))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false) && (b.LandTypeCode == 3))).ToList().Count();



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

                //value.TitleMovementStatusID = 1;
                //value.FinalSubmission = false;

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

                    //value.TitleMovementStatusID = 1;
                    //value.FinalSubmission = false;

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

        public ActionResult SaveApprovedLeaseHoldTitles(int? Location_id, int? Project_Code, string Title_Reference, bool? Verified, int? Folio, string Volume
          , int? LandTypeCode, int? TypeCode, string Unit_No, string Flat_N0, string Block_No, string Plan_No,
          string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID,string LeaseOfferedBy,
          DateTime? Lease_Start_Date, DateTime? Lease_End_Date, int? LeaseYears_ID, string AreaOfUnit, string FloorAreaLeased,
          string UnitFactor, string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,
          bool? PropertySoldorTransferred,string ValueOfProperty, string Valuer, DateTime? DateOfValuation, string GeneralRemarks,
          int _type, bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment, string UnlockComment,
          string Added_By, DateTime? Added_Date, bool? UnlockTitle, decimal? Latitude, decimal? Longitude)

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
                    var approvedleaseholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedleaseholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    //if (freeholdtitlecheck == null)
                    if (approvedleaseholdtitlecheck == null && approvedleaseholdprimkeycheck == null)
                    {

                        PropertyTitle approvedleasehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle approvedleaseholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle approvedleasehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            approvedleasehold.Added_By = user.getCurrentuser();
                            approvedleasehold.Added_Date = DateTime.Now;

                            approvedleasehold.UnlockTitle = UnlockTitle;
                            approvedleasehold.Location_id = Convert.ToInt32(Location_id);
                            approvedleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            approvedleasehold.Title_Reference = Title_Reference;
                            approvedleasehold.Verified = Verified;
                            approvedleasehold.LandTypeCode = LandTypeCode;
                            approvedleasehold.Volume = Volume;
                            approvedleasehold.Folio = Convert.ToInt32(Folio);
                            approvedleasehold.TypeCode = TypeCode;
                            approvedleasehold.Unit_No = Unit_No;
                            approvedleasehold.Flat_N0 = Flat_N0;
                            approvedleasehold.Block_No = Block_No;
                            approvedleasehold.Plan_No = Plan_No;
                            approvedleasehold.Plot_No = Plot_No;
                            approvedleasehold.DistrictID = DistrictID;
                            approvedleasehold.County_ID = County_ID;
                            approvedleasehold.Subcounty_ID = Subcounty_ID;
                            
                            approvedleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            approvedleasehold.Lease_Start_Date = Lease_Start_Date;
                            approvedleasehold.Lease_End_Date = Lease_End_Date;
                            approvedleasehold.LeaseYears_ID = LeaseYears_ID;
                            approvedleasehold.AreaOfUnit = AreaOfUnit;
                            approvedleasehold.FloorAreaLeased = FloorAreaLeased;
                            approvedleasehold.UnitFactor = UnitFactor;
                            approvedleasehold.ActualPlotSize = ActualPlotSize;
                            approvedleasehold.PlotSize_ID = PlotSize_ID;
                            approvedleasehold.ProprietorAddress = ProprietorAddress;
                            approvedleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            approvedleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedleasehold.ValueOfProperty = ValueOfProperty;
                            approvedleasehold.Valuer = Valuer;
                            approvedleasehold.DateOfValuation = DateOfValuation;
                            approvedleasehold.GeneralRemarks = GeneralRemarks;

                            approvedleasehold.Plan_No = Plan_No;
                            approvedleasehold.AreaOfUnit = AreaOfUnit;
                            approvedleasehold.UnitFactor = UnitFactor;
                            approvedleasehold.FloorAreaLeased = FloorAreaLeased;

                            approvedleasehold.FinalSubmission = FinalSubmission;
                            approvedleasehold.TitleMovementStatusID = TitleMovementStatusID;
                            approvedleasehold.RejectionComment = RejectionComment;
                            approvedleasehold.UnlockComment = UnlockComment;
                            approvedleasehold.Latitude = Convert.ToDouble(Latitude);
                            approvedleasehold.Longitude = Convert.ToDouble(Longitude);
                            //Audit Log Saving

                            approvedleaseholdlog.original_Added_By = user.getCurrentuser();
                            approvedleaseholdlog.original_Added_Date = DateTime.Now;

                            approvedleaseholdlog.original_UnlockTitle = UnlockTitle;
                            approvedleaseholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            approvedleaseholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approvedleaseholdlog.original_Title_Reference = Title_Reference;
                            approvedleaseholdlog.original_Verified = Verified;
                            approvedleaseholdlog.original_LandTypeCode = LandTypeCode;
                            approvedleaseholdlog.original_Volume = Volume;
                            approvedleaseholdlog.original_Folio = Convert.ToInt32(Folio);
                            approvedleaseholdlog.original_TypeCode = TypeCode;
                            approvedleaseholdlog.original_Unit_No = Unit_No;
                            approvedleaseholdlog.original_Flat_N0 = Flat_N0;
                            approvedleaseholdlog.original_Block_No = Block_No;
                            approvedleaseholdlog.original_Plan_No = Plan_No;
                            approvedleaseholdlog.original_Plot_No = Plot_No;
                            approvedleaseholdlog.original_DistrictID = DistrictID;
                            approvedleaseholdlog.original_County_ID = County_ID;
                            approvedleaseholdlog.original_Subcounty_ID = Subcounty_ID;
                            
                            approvedleaseholdlog.original_LeaseOfferedBy = LeaseOfferedBy;
                            approvedleaseholdlog.original_Lease_Start_Date = Lease_Start_Date;
                            approvedleaseholdlog.original_Lease_End_Date = Lease_End_Date;
                            approvedleaseholdlog.original_LeaseYears_ID = LeaseYears_ID;
                            approvedleaseholdlog.original_AreaOfUnit = AreaOfUnit;
                            approvedleaseholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            approvedleaseholdlog.original_UnitFactor = UnitFactor;
                            approvedleaseholdlog.original_ActualPlotSize = ActualPlotSize;
                            approvedleaseholdlog.original_PlotSize_ID = PlotSize_ID;
                            approvedleaseholdlog.original_ProprietorAddress = ProprietorAddress;
                            approvedleaseholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            approvedleaseholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedleaseholdlog.original_valueOfProperty = ValueOfProperty;
                            approvedleaseholdlog.original_Valuer = Valuer;
                            approvedleaseholdlog.original_DateOfValuation = DateOfValuation;
                            approvedleaseholdlog.original_GeneralRemarks = GeneralRemarks;

                            approvedleaseholdlog.original_Plan_No = Plan_No;
                            approvedleaseholdlog.original_AreaOfUnit = AreaOfUnit;
                            approvedleaseholdlog.original_UnitFactor = UnitFactor;
                            approvedleaseholdlog.original_FloorAreaLeased = FloorAreaLeased;

                            approvedleaseholdlog.original_FinalSubmission = FinalSubmission;
                            approvedleaseholdlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approvedleaseholdlog.original_RejectionComment = RejectionComment;
                            approvedleaseholdlog.original_UnlockComment = UnlockComment;
                            approvedleaseholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approvedleaseholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(approvedleasehold);
                            db.AuditLog_PropertyTitle.Add(approvedleaseholdlog);

                            
                            db.SaveChanges();

                            result = "Record saved successfully......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (approvedleaseholdtitlecheck == null && approvedleaseholdprimkeycheck != null)
                                               
                    {
                        //result = "This title arleady exists in the database (Record not saved)";
                        result = "Title with the same Location,Volume and Folio arleady exists in the database (Record not saved)";
                    }
                    else //Check for if both leaseholdtitlecheck and leaseholdprimkeycheck are not null

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
                    var editapprovedleasehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    var editapprovedleaseholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editapprovedleasehold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            //editapprovedleasehold.Edited_By = user.getCurrentuser();
                            //editapprovedleasehold.Edited_Date = DateTime.Now;

                            editapprovedleasehold.UnlockedBy = user.getCurrentuser();
                            editapprovedleasehold.UnlockDate = DateTime.Now;

                            editapprovedleasehold.UnlockTitle = UnlockTitle;
                            editapprovedleasehold.Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedleasehold.Title_Reference = Title_Reference;
                            editapprovedleasehold.Verified = Verified;
                            editapprovedleasehold.LandTypeCode = LandTypeCode;
                            editapprovedleasehold.TypeCode = TypeCode;
                            editapprovedleasehold.Unit_No = Unit_No;
                            editapprovedleasehold.Flat_N0 = Flat_N0;
                            editapprovedleasehold.Block_No = Block_No;
                            editapprovedleasehold.Plan_No = Plan_No;
                            editapprovedleasehold.Plot_No = Plot_No;
                            editapprovedleasehold.DistrictID = DistrictID;
                            editapprovedleasehold.County_ID = County_ID;
                            editapprovedleasehold.Subcounty_ID = Subcounty_ID;
                           
                            editapprovedleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            editapprovedleasehold.Lease_Start_Date = Lease_Start_Date;
                            editapprovedleasehold.Lease_End_Date = Lease_End_Date;
                            editapprovedleasehold.LeaseYears_ID = LeaseYears_ID;
                            editapprovedleasehold.AreaOfUnit = AreaOfUnit;
                            editapprovedleasehold.FloorAreaLeased = FloorAreaLeased;
                            editapprovedleasehold.UnitFactor = UnitFactor;
                            editapprovedleasehold.ActualPlotSize = ActualPlotSize;
                            editapprovedleasehold.PlotSize_ID = PlotSize_ID;
                            editapprovedleasehold.ProprietorAddress = ProprietorAddress;
                            editapprovedleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedleasehold.ValueOfProperty = ValueOfProperty;
                            editapprovedleasehold.Valuer = Valuer;
                            editapprovedleasehold.DateOfValuation = DateOfValuation;
                            editapprovedleasehold.GeneralRemarks = GeneralRemarks;

                            editapprovedleasehold.Plan_No = Plan_No;
                            editapprovedleasehold.AreaOfUnit = AreaOfUnit;
                            editapprovedleasehold.UnitFactor = UnitFactor;
                            editapprovedleasehold.FloorAreaLeased = FloorAreaLeased;
                            
                            editapprovedleasehold.FinalSubmission = FinalSubmission;
                            editapprovedleasehold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedleasehold.RejectionComment = RejectionComment;
                            editapprovedleasehold.UnlockComment = UnlockComment;
                            editapprovedleasehold.Latitude = Convert.ToDouble(Latitude);
                            editapprovedleasehold.Longitude = Convert.ToDouble(Longitude);

                            editapprovedleasehold.Added_By = Added_By;
                            editapprovedleasehold.Added_Date = Added_Date;

                            //Audit Table Save

                            editapprovedleaseholdlog.original_UnlockedBy = user.getCurrentuser();
                            editapprovedleaseholdlog.original_UnlockDate = DateTime.Now;

                            editapprovedleaseholdlog.new_UnlockTitle = UnlockTitle;

                            editapprovedleaseholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapprovedleaseholdlog.new_Volume = Volume;
                            editapprovedleaseholdlog.new_Folio = Convert.ToInt32(Folio);


                            editapprovedleaseholdlog.new_Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedleaseholdlog.new_Title_Reference = Title_Reference;
                            editapprovedleaseholdlog.new_Verified = Verified;
                            editapprovedleaseholdlog.new_LandTypeCode = LandTypeCode;
                            editapprovedleaseholdlog.new_TypeCode = TypeCode;
                            editapprovedleaseholdlog.new_Unit_No = Unit_No;
                            editapprovedleaseholdlog.new_Flat_N0 = Flat_N0;
                            editapprovedleaseholdlog.new_Block_No = Block_No;
                            editapprovedleaseholdlog.new_Plan_No = Plan_No;
                            editapprovedleaseholdlog.new_Plot_No = Plot_No;
                            editapprovedleaseholdlog.new_DistrictID = DistrictID;
                            editapprovedleaseholdlog.new_County_ID = County_ID;
                            editapprovedleaseholdlog.new_Subcounty_ID = Subcounty_ID;
                          
                            editapprovedleaseholdlog.new_LeaseOfferedBy = LeaseOfferedBy;
                            editapprovedleaseholdlog.new_Lease_Start_Date = Lease_Start_Date;
                            editapprovedleaseholdlog.new_Lease_End_Date = Lease_End_Date;
                            editapprovedleaseholdlog.new_LeaseYears_ID = LeaseYears_ID;
                            editapprovedleaseholdlog.new_AreaOfUnit = AreaOfUnit;
                            editapprovedleaseholdlog.new_FloorAreaLeased = FloorAreaLeased;
                            editapprovedleaseholdlog.new_UnitFactor = UnitFactor;
                            editapprovedleaseholdlog.new_ActualPlotSize = ActualPlotSize;
                            editapprovedleaseholdlog.new_PlotSize_ID = PlotSize_ID;
                            editapprovedleaseholdlog.new_ProprietorAddress = ProprietorAddress;
                            editapprovedleaseholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedleaseholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedleaseholdlog.new_valueOfProperty = ValueOfProperty;
                            editapprovedleaseholdlog.new_Valuer = Valuer;
                            editapprovedleaseholdlog.new_DateOfValuation = DateOfValuation;
                            editapprovedleaseholdlog.new_GeneralRemarks = GeneralRemarks;

                            editapprovedleaseholdlog.new_Plan_No = Plan_No;
                            editapprovedleaseholdlog.new_AreaOfUnit = AreaOfUnit;
                            editapprovedleaseholdlog.new_UnitFactor = UnitFactor;
                            editapprovedleaseholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editapprovedleaseholdlog.new_FinalSubmission = FinalSubmission;
                            editapprovedleaseholdlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedleaseholdlog.new_RejectionComment = RejectionComment;
                            editapprovedleaseholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapprovedleaseholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapprovedleaseholdlog.original_UnlockComment = UnlockComment;

                            editapprovedleaseholdlog.new_Added_By = Added_By;
                            editapprovedleaseholdlog.new_Added_Date = Added_Date;

                            db.Entry(editapprovedleasehold).CurrentValues.SetValues(editapprovedleasehold);
                            db.Entry(editapprovedleasehold).State = EntityState.Modified;

                            db.Entry(editapprovedleaseholdlog).CurrentValues.SetValues(editapprovedleaseholdlog);
                            db.Entry(editapprovedleaseholdlog).State = EntityState.Modified;
                                                                                   

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
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CEOSaveApprovedLeaseHoldTitles(int? Project_Code, string Title_Reference, bool? Verified, int? Folio, string Volume
          , int? LandTypeCode, int? TypeCode, string Unit_No, string Flat_N0, string Block_No, string Plan_No,
          string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID, int? Location_id, string LeaseOfferedBy,
          DateTime? Lease_Start_Date, DateTime? Lease_End_Date, int? LeaseYears_ID, string AreaOfUnit, string FloorAreaLeased,
          string UnitFactor, string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,
          bool? PropertySoldorTransferred,string ValueOfProperty, string Valuer, DateTime? DateOfValuation, string GeneralRemarks,
          int _type, bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment, string UnlockComment,
          string Added_By, DateTime? Added_Date, bool? UnlockTitle, decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

                    try
                    {
                        PropertyTitle approvedleasehold = new PropertyTitle();
                        UserManagement user = new UserManagement();
                        approvedleasehold.Added_By = user.getCurrentuser();
                        approvedleasehold.Added_Date = DateTime.Now;

                        approvedleasehold.UnlockTitle = UnlockTitle;
                        approvedleasehold.Project_Code = Convert.ToInt32(Project_Code);
                        approvedleasehold.Title_Reference = Title_Reference;
                        approvedleasehold.Verified = Verified;
                        approvedleasehold.LandTypeCode = LandTypeCode;
                        approvedleasehold.Volume = Volume;
                        approvedleasehold.Folio = Convert.ToInt32(Folio);
                        approvedleasehold.TypeCode = TypeCode;
                        approvedleasehold.Unit_No = Unit_No;
                        approvedleasehold.Flat_N0 = Flat_N0;
                        approvedleasehold.Block_No = Block_No;
                        approvedleasehold.Plan_No = Plan_No;
                        approvedleasehold.Plot_No = Plot_No;
                        approvedleasehold.DistrictID = DistrictID;
                        approvedleasehold.County_ID = County_ID;
                        approvedleasehold.Subcounty_ID = Subcounty_ID;
                        approvedleasehold.Location_id = Convert.ToInt32(Location_id);
                        approvedleasehold.LeaseOfferedBy = LeaseOfferedBy;
                        approvedleasehold.Lease_Start_Date = Lease_Start_Date;
                        approvedleasehold.Lease_End_Date = Lease_End_Date;
                        approvedleasehold.LeaseYears_ID = LeaseYears_ID;
                        approvedleasehold.AreaOfUnit = AreaOfUnit;
                        approvedleasehold.FloorAreaLeased = FloorAreaLeased;
                        approvedleasehold.UnitFactor = UnitFactor;
                        approvedleasehold.ActualPlotSize = ActualPlotSize;
                        approvedleasehold.PlotSize_ID = PlotSize_ID;
                        approvedleasehold.ProprietorAddress = ProprietorAddress;
                        approvedleasehold.BoardMinuteRelease = BoardMinuteRelease;
                        approvedleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                        approvedleasehold.ValueOfProperty = ValueOfProperty;
                        approvedleasehold.Valuer = Valuer;
                        approvedleasehold.DateOfValuation = DateOfValuation;
                        approvedleasehold.GeneralRemarks = GeneralRemarks;

                        approvedleasehold.Plan_No = Plan_No;
                        approvedleasehold.AreaOfUnit = AreaOfUnit;
                        approvedleasehold.UnitFactor = UnitFactor;
                        approvedleasehold.FloorAreaLeased = FloorAreaLeased;

                        approvedleasehold.FinalSubmission = FinalSubmission;
                        approvedleasehold.TitleMovementStatusID = TitleMovementStatusID;
                        approvedleasehold.RejectionComment = RejectionComment;
                        approvedleasehold.UnlockComment = UnlockComment;
                        approvedleasehold.Latitude = Convert.ToDouble(Latitude);
                        approvedleasehold.Longitude = Convert.ToDouble(Longitude);

                        db.PropertyTitles.Add(approvedleasehold);
                        db.SaveChanges();

                        result = "Record saved successfully......";

                    }
                    catch (DbEntityValidationException ex)
                    {
                        result = ex.Message.ToString();
                    }


               // }
            }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null"))

                //{
                //    result = "Please enter a Parent Title (Title Reference)!";
                //}

                //else
                //{
                    var editapprovedleasehold = db.PropertyTitles.FirstOrDefault(e => e.Project_Code == Project_Code && e.Volume == e.Volume && e.Folio == Folio);

                    if (editapprovedleasehold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            //editapprovedleasehold.Edited_By = user.getCurrentuser();
                            //editapprovedleasehold.Edited_Date = DateTime.Now;

                            editapprovedleasehold.UnlockTitle = UnlockTitle;
                            editapprovedleasehold.Title_Reference = Title_Reference;
                            editapprovedleasehold.Verified = Verified;
                            editapprovedleasehold.LandTypeCode = LandTypeCode;
                            editapprovedleasehold.TypeCode = TypeCode;
                            editapprovedleasehold.Unit_No = Unit_No;
                            editapprovedleasehold.Flat_N0 = Flat_N0;
                            editapprovedleasehold.Block_No = Block_No;
                            editapprovedleasehold.Plan_No = Plan_No;
                            editapprovedleasehold.Plot_No = Plot_No;
                            editapprovedleasehold.DistrictID = DistrictID;
                            editapprovedleasehold.County_ID = County_ID;
                            editapprovedleasehold.Subcounty_ID = Subcounty_ID;
                            editapprovedleasehold.Location_id = Convert.ToInt32(Location_id);
                            editapprovedleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            editapprovedleasehold.Lease_Start_Date = Lease_Start_Date;
                            editapprovedleasehold.Lease_End_Date = Lease_End_Date;
                            editapprovedleasehold.LeaseYears_ID = LeaseYears_ID;
                            editapprovedleasehold.AreaOfUnit = AreaOfUnit;
                            editapprovedleasehold.FloorAreaLeased = FloorAreaLeased;
                            editapprovedleasehold.UnitFactor = UnitFactor;
                            editapprovedleasehold.ActualPlotSize = ActualPlotSize;
                            editapprovedleasehold.PlotSize_ID = PlotSize_ID;
                            editapprovedleasehold.ProprietorAddress = ProprietorAddress;
                            editapprovedleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedleasehold.ValueOfProperty = ValueOfProperty;
                            editapprovedleasehold.Valuer = Valuer;
                            editapprovedleasehold.DateOfValuation = DateOfValuation;
                            editapprovedleasehold.GeneralRemarks = GeneralRemarks;

                            editapprovedleasehold.Plan_No = Plan_No;
                            editapprovedleasehold.AreaOfUnit = AreaOfUnit;
                            editapprovedleasehold.UnitFactor = UnitFactor;
                            editapprovedleasehold.FloorAreaLeased = FloorAreaLeased;

                            editapprovedleasehold.FinalSubmission = FinalSubmission;
                            editapprovedleasehold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedleasehold.RejectionComment = RejectionComment;
                            editapprovedleasehold.UnlockComment = UnlockComment;
                            editapprovedleasehold.Latitude = Convert.ToDouble(Latitude);
                            editapprovedleasehold.Longitude = Convert.ToDouble(Longitude);

                            editapprovedleasehold.Added_By = Added_By;
                            editapprovedleasehold.Added_Date = Added_Date;

                            db.Entry(editapprovedleasehold).CurrentValues.SetValues(editapprovedleasehold);
                            db.Entry(editapprovedleasehold).State = EntityState.Modified;

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
                            //result = Title_Reference + " is updated successfully";

                            result = "Click Ok to close " + Title_Reference + "safely";

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
               // }
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

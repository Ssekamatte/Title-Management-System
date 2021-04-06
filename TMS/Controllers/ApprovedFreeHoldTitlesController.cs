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
    public class ApprovedFreeHoldTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApprovedFreeHoldTitles
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
            var subcounties = db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_Name).ToList();
            ViewBag.Subcounties = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().OrderBy(a => a.County_Name).ToList();
            ViewBag.Counties = counties;

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
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;


            return View();
        }

        public ActionResult ApprovedFreeHoldCEO()
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
            var subcounties = db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_Name).ToList();
            ViewBag.Subcounties = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().OrderBy(a => a.County_Name).ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;
           
            return View();
        }

        // GET: ApprovedFreeHoldTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApprovedFreeHoldTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedFreeHoldTitles/Create
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

        // GET: ApprovedFreeHoldTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApprovedFreeHoldTitles/Edit/5
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

        // GET: ApprovedFreeHoldTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApprovedFreeHoldTitles/Delete/5
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


        public ActionResult DataSourceApprovedFreeHoldTitles(DataManager dm)
        {

            //Returns all the fields in the table based on the Title Movement Status ID

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false) && (b.LandTypeCode == 1))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false) && (b.LandTypeCode == 1))).ToList().Count();



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


        public JsonResult GetPurposeData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TitleMovement_Purpose.AsNoTracking().Where(a => a.Purpose_ID == 6).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFreeHoldData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 1).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
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

        public ActionResult SaveApprovedFreeHoldProperty(int? Location_id, int? Project_Code, int? Folio, string Title_Reference, string Volume,
           bool? Verified, int? LandTypeCode, int? TypeCode, string Unit_No, string Block_No
           , string Flat_N0, string Plot_No, string ActualPlotSize, int? DistrictID, int? County_ID, int? Subcounty_ID
           , int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,string ValueOfProperty,
           string Valuer, bool? PropertySoldorTransferred, string GeneralRemarks, DateTime? DateOfValuation, int _type,
           bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment, string UnlockComment,
           string Added_By, DateTime? Added_Date, string Plan_No, string AreaOfUnit, string UnitFactor, string FloorAreaLeased,
           bool? UnlockTitle,decimal? Latitude, decimal? Longitude)

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
                    var approvedfreeholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedfreeholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));


                    if (approvedfreeholdtitlecheck == null && approvedfreeholdprimkeycheck == null)
                    {

                        PropertyTitle approvedfreehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle approvedfreeholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {

                            //PropertyTitle approvedfreehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            approvedfreehold.Added_By = user.getCurrentuser();
                            approvedfreehold.Added_Date = DateTime.Now;

                            approvedfreehold.UnlockTitle = UnlockTitle;
                            approvedfreehold.Location_id = Convert.ToInt32(Location_id);
                            approvedfreehold.Project_Code = Convert.ToInt32(Project_Code);
                            approvedfreehold.Title_Reference = Title_Reference;
                            approvedfreehold.Verified = Verified;
                            approvedfreehold.Volume = Volume;
                            approvedfreehold.Folio = Convert.ToInt32(Folio);
                            approvedfreehold.LandTypeCode = LandTypeCode;
                            approvedfreehold.TypeCode = TypeCode;
                            approvedfreehold.Block_No = Block_No;
                            approvedfreehold.Unit_No = Unit_No;
                            approvedfreehold.Flat_N0 = Flat_N0;
                            approvedfreehold.Plot_No = Plot_No;
                            approvedfreehold.DistrictID = DistrictID;
                            approvedfreehold.County_ID = County_ID;
                            approvedfreehold.Subcounty_ID = Subcounty_ID;
                            approvedfreehold.ActualPlotSize = ActualPlotSize;
                            approvedfreehold.PlotSize_ID = PlotSize_ID;
                            approvedfreehold.ProprietorAddress = ProprietorAddress;
                            approvedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            approvedfreehold.ValueOfProperty = ValueOfProperty;
                            approvedfreehold.Valuer = Valuer;
                            approvedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedfreehold.GeneralRemarks = GeneralRemarks;
                            approvedfreehold.DateOfValuation = DateOfValuation;

                            approvedfreehold.Plan_No = Plan_No;
                            approvedfreehold.AreaOfUnit = AreaOfUnit;
                            approvedfreehold.UnitFactor = UnitFactor;
                            approvedfreehold.FloorAreaLeased = FloorAreaLeased;

                            approvedfreehold.FinalSubmission = FinalSubmission;
                            approvedfreehold.TitleMovementStatusID = TitleMovementStatusID;
                            approvedfreehold.RejectionComment = RejectionComment;
                            approvedfreehold.UnlockComment = UnlockComment;
                            approvedfreehold.Latitude = Convert.ToDouble(Latitude);
                            approvedfreehold.Longitude = Convert.ToDouble(Longitude);

                            //approvefreehold.Added_By = Added_By;
                            //approvefreehold.Added_Date = Added_Date;

                            //Audit Table Saving

                            approvedfreeholdlog.original_Added_By = user.getCurrentuser();
                            approvedfreeholdlog.original_Added_Date = DateTime.Now;

                            approvedfreeholdlog.original_UnlockTitle = UnlockTitle;
                            approvedfreeholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            approvedfreeholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approvedfreeholdlog.original_Title_Reference = Title_Reference;
                            approvedfreeholdlog.original_Verified = Verified;
                            approvedfreeholdlog.original_Volume = Volume;
                            approvedfreeholdlog.original_Folio = Convert.ToInt32(Folio);
                            approvedfreeholdlog.original_LandTypeCode = LandTypeCode;
                            approvedfreeholdlog.original_TypeCode = TypeCode;
                            approvedfreeholdlog.original_Block_No = Block_No;
                            approvedfreeholdlog.original_Unit_No = Unit_No;
                            approvedfreeholdlog.original_Flat_N0 = Flat_N0;
                            approvedfreeholdlog.original_Plot_No = Plot_No;
                            approvedfreeholdlog.original_DistrictID = DistrictID;
                            approvedfreeholdlog.original_County_ID = County_ID;
                            approvedfreeholdlog.original_Subcounty_ID = Subcounty_ID;
                            approvedfreeholdlog.original_ActualPlotSize = ActualPlotSize;
                            approvedfreeholdlog.original_PlotSize_ID = PlotSize_ID;
                            approvedfreeholdlog.original_ProprietorAddress = ProprietorAddress;
                            approvedfreeholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            approvedfreeholdlog.original_valueOfProperty = ValueOfProperty;
                            approvedfreeholdlog.original_Valuer = Valuer;
                            approvedfreeholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedfreeholdlog.original_GeneralRemarks = GeneralRemarks;
                            approvedfreeholdlog.original_DateOfValuation = DateOfValuation;

                            approvedfreeholdlog.original_Plan_No = Plan_No;
                            approvedfreeholdlog.original_AreaOfUnit = AreaOfUnit;
                            approvedfreeholdlog.original_UnitFactor = UnitFactor;
                            approvedfreeholdlog.original_FloorAreaLeased = FloorAreaLeased;

                            approvedfreeholdlog.original_FinalSubmission = FinalSubmission;
                            approvedfreeholdlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approvedfreeholdlog.original_RejectionComment = RejectionComment;
                            approvedfreeholdlog.original_UnlockComment = UnlockComment;
                            approvedfreeholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approvedfreeholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(approvedfreehold);
                            db.AuditLog_PropertyTitle.Add(approvedfreeholdlog);
                            
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }
                    else if (approvedfreeholdtitlecheck == null && approvedfreeholdprimkeycheck != null)
                                               
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
                    var editapprovedfreehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    var editapprovedfreeholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editapprovedfreehold != null)
                    {
                        try
                        {
                            UserManagement user = new UserManagement();
                            //editapprovedfreehold.Edited_By = user.getCurrentuser();
                            //editapprovedfreehold.Edited_Date = DateTime.Now;

                            editapprovedfreehold.UnlockedBy = user.getCurrentuser();
                            editapprovedfreehold.UnlockDate = DateTime.Now;

                            editapprovedfreehold.UnlockTitle = UnlockTitle;
                            editapprovedfreehold.Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedfreehold.Title_Reference = Title_Reference;
                            editapprovedfreehold.Verified = Verified;
                            editapprovedfreehold.LandTypeCode = LandTypeCode;
                            editapprovedfreehold.TypeCode = TypeCode;
                            editapprovedfreehold.Block_No = Block_No;
                            editapprovedfreehold.Unit_No = Unit_No;
                            editapprovedfreehold.Flat_N0 = Flat_N0;
                            editapprovedfreehold.Plot_No = Plot_No;
                            editapprovedfreehold.DistrictID = DistrictID;
                            editapprovedfreehold.County_ID = County_ID;
                            editapprovedfreehold.Subcounty_ID = Subcounty_ID;
                            editapprovedfreehold.ActualPlotSize = ActualPlotSize;
                            editapprovedfreehold.PlotSize_ID = PlotSize_ID;
                            editapprovedfreehold.ProprietorAddress = ProprietorAddress;
                            editapprovedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedfreehold.ValueOfProperty = ValueOfProperty;
                            editapprovedfreehold.Valuer = Valuer;
                            editapprovedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedfreehold.GeneralRemarks = GeneralRemarks;
                            editapprovedfreehold.DateOfValuation = DateOfValuation;

                            editapprovedfreehold.Plan_No = Plan_No;
                            editapprovedfreehold.AreaOfUnit = AreaOfUnit;
                            editapprovedfreehold.UnitFactor = UnitFactor;
                            editapprovedfreehold.FloorAreaLeased = FloorAreaLeased;

                            editapprovedfreehold.FinalSubmission = FinalSubmission;
                            editapprovedfreehold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedfreehold.RejectionComment = RejectionComment;
                            editapprovedfreehold.UnlockComment = UnlockComment;
                            editapprovedfreehold.Latitude = Convert.ToDouble(Latitude);
                            editapprovedfreehold.Longitude = Convert.ToDouble(Longitude);

                            editapprovedfreehold.Added_By = Added_By;
                            editapprovedfreehold.Added_Date = Added_Date;

                            //Audit Log Saving

                            editapprovedfreeholdlog.original_UnlockedBy = user.getCurrentuser();
                            editapprovedfreeholdlog.original_UnlockDate = DateTime.Now;

                            editapprovedfreeholdlog.new_UnlockTitle = UnlockTitle;

                            editapprovedfreeholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapprovedfreeholdlog.new_Volume = Volume;
                            editapprovedfreeholdlog.new_Folio = Convert.ToInt32(Folio);

                            editapprovedfreeholdlog.new_Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedfreeholdlog.new_Title_Reference = Title_Reference;
                            editapprovedfreeholdlog.new_Verified = Verified;
                            editapprovedfreeholdlog.new_LandTypeCode = LandTypeCode;
                            editapprovedfreeholdlog.new_TypeCode = TypeCode;
                            editapprovedfreeholdlog.new_Block_No = Block_No;
                            editapprovedfreeholdlog.new_Unit_No = Unit_No;
                            editapprovedfreeholdlog.new_Flat_N0 = Flat_N0;
                            editapprovedfreeholdlog.new_Plot_No = Plot_No;
                            editapprovedfreeholdlog.new_DistrictID = DistrictID;
                            editapprovedfreeholdlog.new_County_ID = County_ID;
                            editapprovedfreeholdlog.new_Subcounty_ID = Subcounty_ID;
                            editapprovedfreeholdlog.new_ActualPlotSize = ActualPlotSize;
                            editapprovedfreeholdlog.new_PlotSize_ID = PlotSize_ID;
                            editapprovedfreeholdlog.new_ProprietorAddress = ProprietorAddress;
                            editapprovedfreeholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedfreeholdlog.new_valueOfProperty = ValueOfProperty;
                            editapprovedfreeholdlog.new_Valuer = Valuer;
                            editapprovedfreeholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedfreeholdlog.new_GeneralRemarks = GeneralRemarks;
                            editapprovedfreeholdlog.new_DateOfValuation = DateOfValuation;

                            editapprovedfreeholdlog.new_Plan_No = Plan_No;
                            editapprovedfreeholdlog.new_AreaOfUnit = AreaOfUnit;
                            editapprovedfreeholdlog.new_UnitFactor = UnitFactor;
                            editapprovedfreeholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editapprovedfreeholdlog.new_FinalSubmission = FinalSubmission;
                            editapprovedfreeholdlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedfreeholdlog.new_RejectionComment = RejectionComment;
                            editapprovedfreeholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapprovedfreeholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapprovedfreeholdlog.original_UnlockComment = UnlockComment;

                            editapprovedfreeholdlog.new_Added_By = Added_By;
                            editapprovedfreeholdlog.new_Added_Date = Added_Date;

                            db.Entry(editapprovedfreehold).CurrentValues.SetValues(editapprovedfreehold);
                            db.Entry(editapprovedfreehold).State = EntityState.Modified;

                            db.Entry(editapprovedfreeholdlog).CurrentValues.SetValues(editapprovedfreeholdlog);
                            db.Entry(editapprovedfreeholdlog).State = EntityState.Modified;
                            
                            
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
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CEOSaveApprovedFreeHoldProperty(int? Location_id, int? Project_Code, int? Folio, string Title_Reference, string Volume,
           bool? Verified, int? LandTypeCode, int? TypeCode, string Unit_No, string Block_No
           , string Flat_N0, string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID
           , string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,string ValueOfProperty,
           string Valuer, bool? PropertySoldorTransferred, string GeneralRemarks, DateTime? DateOfValuation, int _type,
           bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment, string UnlockComment,
           string Added_By, DateTime? Added_Date, string Plan_No, string AreaOfUnit, string UnitFactor, string FloorAreaLeased, 
           bool? UnlockTitle,decimal? Latitude, decimal? Longitude)

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
                    var approvedfreeholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedfreeholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));


                    if (approvedfreeholdtitlecheck == null && approvedfreeholdprimkeycheck == null)
                    {

                        PropertyTitle approvedfreehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle approvedfreehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            approvedfreehold.Added_By = user.getCurrentuser();
                            approvedfreehold.Added_Date = DateTime.Now;

                            approvedfreehold.UnlockTitle = UnlockTitle;
                            approvedfreehold.Location_id = Convert.ToInt32(Location_id);
                            approvedfreehold.Project_Code = Convert.ToInt32(Project_Code);
                            approvedfreehold.Title_Reference = Title_Reference;
                            approvedfreehold.Verified = Verified;
                            approvedfreehold.Volume = Volume;
                            approvedfreehold.Folio = Convert.ToInt32(Folio);
                            approvedfreehold.LandTypeCode = LandTypeCode;
                            approvedfreehold.TypeCode = TypeCode;
                            approvedfreehold.Block_No = Block_No;
                            approvedfreehold.Unit_No = Unit_No;
                            approvedfreehold.Flat_N0 = Flat_N0;
                            approvedfreehold.Plot_No = Plot_No;
                            approvedfreehold.DistrictID = DistrictID;
                            approvedfreehold.County_ID = County_ID;
                            approvedfreehold.Subcounty_ID = Subcounty_ID;
                            approvedfreehold.ActualPlotSize = ActualPlotSize;
                            approvedfreehold.PlotSize_ID = PlotSize_ID;
                            approvedfreehold.ProprietorAddress = ProprietorAddress;
                            approvedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            approvedfreehold.ValueOfProperty = ValueOfProperty;
                            approvedfreehold.Valuer = Valuer;
                            approvedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedfreehold.GeneralRemarks = GeneralRemarks;
                            approvedfreehold.DateOfValuation = DateOfValuation;

                            approvedfreehold.Plan_No = Plan_No;
                            approvedfreehold.AreaOfUnit = AreaOfUnit;
                            approvedfreehold.UnitFactor = UnitFactor;
                            approvedfreehold.FloorAreaLeased = FloorAreaLeased;

                            approvedfreehold.FinalSubmission = FinalSubmission;
                            approvedfreehold.TitleMovementStatusID = TitleMovementStatusID;
                            approvedfreehold.RejectionComment = RejectionComment;
                            approvedfreehold.UnlockComment = UnlockComment;
                            approvedfreehold.Latitude = Convert.ToDouble(Latitude);
                            approvedfreehold.Longitude = Convert.ToDouble(Longitude);

                            //approvefreehold.Added_By = Added_By;
                            //approvefreehold.Added_Date = Added_Date;

                            db.PropertyTitles.Add(approvedfreehold);
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }

                    }

                    else if (approvedfreeholdtitlecheck == null && approvedfreeholdprimkeycheck != null)

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
                    var editapprovedfreehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    if (editapprovedfreehold != null)
                    {
                        try
                        {

                            UserManagement user = new UserManagement();
                            // editapprovedfreehold.Edited_By = user.getCurrentuser();
                            //editapprovedfreehold.Edited_Date = DateTime.Now;

                            editapprovedfreehold.UnlockedBy = user.getCurrentuser();
                            editapprovedfreehold.UnlockDate = DateTime.Now;

                            editapprovedfreehold.UnlockTitle = UnlockTitle;
                            editapprovedfreehold.Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedfreehold.Title_Reference = Title_Reference;
                            editapprovedfreehold.Verified = Verified;
                            editapprovedfreehold.LandTypeCode = LandTypeCode;
                            editapprovedfreehold.TypeCode = TypeCode;
                            editapprovedfreehold.Block_No = Block_No;
                            editapprovedfreehold.Unit_No = Unit_No;
                            editapprovedfreehold.Flat_N0 = Flat_N0;
                            editapprovedfreehold.Plot_No = Plot_No;
                            editapprovedfreehold.DistrictID = DistrictID;
                            editapprovedfreehold.County_ID = County_ID;
                            editapprovedfreehold.Subcounty_ID = Subcounty_ID;
                            editapprovedfreehold.ActualPlotSize = ActualPlotSize;
                            editapprovedfreehold.PlotSize_ID = PlotSize_ID;
                            editapprovedfreehold.ProprietorAddress = ProprietorAddress;
                            editapprovedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedfreehold.ValueOfProperty = ValueOfProperty;
                            editapprovedfreehold.Valuer = Valuer;
                            editapprovedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedfreehold.GeneralRemarks = GeneralRemarks;
                            editapprovedfreehold.DateOfValuation = DateOfValuation;

                            editapprovedfreehold.Plan_No = Plan_No;
                            editapprovedfreehold.AreaOfUnit = AreaOfUnit;
                            editapprovedfreehold.UnitFactor = UnitFactor;
                            editapprovedfreehold.FloorAreaLeased = FloorAreaLeased;

                            editapprovedfreehold.FinalSubmission = FinalSubmission;
                            editapprovedfreehold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedfreehold.RejectionComment = RejectionComment;
                            editapprovedfreehold.UnlockComment = UnlockComment;
                            editapprovedfreehold.Latitude = Convert.ToDouble(Latitude);
                            editapprovedfreehold.Longitude = Convert.ToDouble(Longitude);

                            editapprovedfreehold.Added_By = Added_By;
                            editapprovedfreehold.Added_Date = Added_Date;

                            db.Entry(editapprovedfreehold).CurrentValues.SetValues(editapprovedfreehold);
                            db.Entry(editapprovedfreehold).State = EntityState.Modified;

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
            }
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

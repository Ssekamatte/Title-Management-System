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
    public class UnlockFreeHoldPropertyTitleController : Controller
    {
        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: UnlockFreeHoldPropertyTitle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnlockFreeHoldPropertyTitles()
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
            var Property = db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusDesc).ToList();
            ViewBag.Property = Property;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            return View();
        }

        public ActionResult UnlockFreeHoldPropertyTitlesAdmin()
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
            var Property = db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusDesc).ToList();
            ViewBag.Property = Property;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            return View();
        }


        // GET: UnlockFreeHoldPropertyTitle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnlockFreeHoldPropertyTitle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnlockFreeHoldPropertyTitle/Create
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

        // GET: UnlockFreeHoldPropertyTitle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnlockFreeHoldPropertyTitle/Edit/5
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

        // GET: UnlockFreeHoldPropertyTitle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnlockFreeHoldPropertyTitle/Delete/5
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

        public JsonResult GetFreeHoldData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 1).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DataSourceFreeHold(DataManager dm)
        {            
            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 1) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 1) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 1) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 1) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

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

        public ActionResult SaveUnlockedFreeHoldProperty(int? Location_id, int? Project_Code, int? Folio, string Title_Reference, string Volume,
           bool? Verified, int? LandTypeCode, int? TypeCode, string Unit_No, string Block_No
           , string Flat_N0, string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID
           , string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,string ValueOfProperty,
           string Valuer, bool? PropertySoldorTransferred, string GeneralRemarks, DateTime? DateOfValuation, int _type,
           string RejectionComment, string UnlockComment,string Plan_No, string AreaOfUnit, string UnitFactor, 
           string FloorAreaLeased, string Added_By, DateTime? Added_Date, decimal? Latitude, decimal? Longitude)

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
                    var unlockfreeholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var unlockfreeholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));


                    if (unlockfreeholdtitlecheck == null && unlockfreeholdprimkeycheck == null)
                    {
                        PropertyTitle saveunlockedfreehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle saveunlockedfreeholdlog = new AuditLog_PropertyTitle() {original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle saveunlockedfreehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            saveunlockedfreehold.Added_By = user.getCurrentuser();
                            saveunlockedfreehold.Added_Date = DateTime.Now;

                            saveunlockedfreehold.TitleMovementStatusID = 1;
                            saveunlockedfreehold.FinalSubmission = false;
                            saveunlockedfreehold.UnlockTitle = false;

                            saveunlockedfreehold.Location_id = Convert.ToInt32(Location_id);
                            saveunlockedfreehold.Project_Code = Convert.ToInt32(Project_Code);
                            saveunlockedfreehold.Title_Reference = Title_Reference;
                            saveunlockedfreehold.Verified = Verified;
                            saveunlockedfreehold.Volume = Volume;
                            saveunlockedfreehold.Folio = Convert.ToInt32(Folio);
                            saveunlockedfreehold.LandTypeCode = LandTypeCode;
                            saveunlockedfreehold.TypeCode = TypeCode;
                            saveunlockedfreehold.Block_No = Block_No;
                            saveunlockedfreehold.Unit_No = Unit_No;
                            saveunlockedfreehold.Flat_N0 = Flat_N0;
                            saveunlockedfreehold.Plot_No = Plot_No;
                            saveunlockedfreehold.DistrictID = DistrictID;
                            saveunlockedfreehold.County_ID = County_ID;
                            saveunlockedfreehold.Subcounty_ID = Subcounty_ID;
                            saveunlockedfreehold.ActualPlotSize = ActualPlotSize;
                            saveunlockedfreehold.PlotSize_ID = PlotSize_ID;
                            saveunlockedfreehold.ProprietorAddress = ProprietorAddress;
                            saveunlockedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            saveunlockedfreehold.ValueOfProperty = ValueOfProperty;
                            saveunlockedfreehold.Valuer = Valuer;
                            saveunlockedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            saveunlockedfreehold.GeneralRemarks = GeneralRemarks;
                            saveunlockedfreehold.DateOfValuation = DateOfValuation;

                            saveunlockedfreehold.Plan_No = Plan_No;
                            saveunlockedfreehold.AreaOfUnit = AreaOfUnit;
                            saveunlockedfreehold.UnitFactor = UnitFactor;
                            saveunlockedfreehold.FloorAreaLeased = FloorAreaLeased;

                            saveunlockedfreehold.RejectionComment = RejectionComment;
                            saveunlockedfreehold.UnlockComment = UnlockComment;
                            saveunlockedfreehold.Latitude = Convert.ToDouble(Latitude);
                            saveunlockedfreehold.Longitude = Convert.ToDouble(Longitude);

                            // Audit Log Tables Save

                            saveunlockedfreeholdlog.original_Added_By = user.getCurrentuser();
                            saveunlockedfreeholdlog.original_Added_Date = DateTime.Now;

                            saveunlockedfreeholdlog.original_TitleMovementStatusID = 1;
                            saveunlockedfreeholdlog.original_FinalSubmission = false;
                            saveunlockedfreeholdlog.original_UnlockTitle = false;

                            saveunlockedfreeholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            saveunlockedfreeholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            saveunlockedfreeholdlog.original_Title_Reference = Title_Reference;
                            saveunlockedfreeholdlog.original_Verified = Verified;
                            saveunlockedfreeholdlog.original_Volume = Volume;
                            saveunlockedfreeholdlog.original_Folio = Convert.ToInt32(Folio);
                            saveunlockedfreeholdlog.original_LandTypeCode = LandTypeCode;
                            saveunlockedfreeholdlog.original_TypeCode = TypeCode;
                            saveunlockedfreeholdlog.original_Block_No = Block_No;
                            saveunlockedfreeholdlog.original_Unit_No = Unit_No;
                            saveunlockedfreeholdlog.original_Flat_N0 = Flat_N0;
                            saveunlockedfreeholdlog.original_Plot_No = Plot_No;
                            saveunlockedfreeholdlog.original_DistrictID = DistrictID;
                            saveunlockedfreeholdlog.original_County_ID = County_ID;
                            saveunlockedfreeholdlog.original_Subcounty_ID = Subcounty_ID;
                            saveunlockedfreeholdlog.original_ActualPlotSize = ActualPlotSize;
                            saveunlockedfreeholdlog.original_PlotSize_ID = PlotSize_ID;
                            saveunlockedfreeholdlog.original_ProprietorAddress = ProprietorAddress;
                            saveunlockedfreeholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            saveunlockedfreeholdlog.original_valueOfProperty = ValueOfProperty;
                            saveunlockedfreeholdlog.original_Valuer = Valuer;
                            saveunlockedfreeholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            saveunlockedfreeholdlog.original_GeneralRemarks = GeneralRemarks;
                            saveunlockedfreeholdlog.original_DateOfValuation = DateOfValuation;

                            saveunlockedfreeholdlog.original_Plan_No = Plan_No;
                            saveunlockedfreeholdlog.original_AreaOfUnit = AreaOfUnit;
                            saveunlockedfreeholdlog.original_UnitFactor = UnitFactor;
                            saveunlockedfreeholdlog.original_FloorAreaLeased = FloorAreaLeased;

                            saveunlockedfreeholdlog.original_RejectionComment = RejectionComment;
                            saveunlockedfreeholdlog.original_UnlockComment = UnlockComment;
                            saveunlockedfreeholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            saveunlockedfreeholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(saveunlockedfreehold);
                            db.AuditLog_PropertyTitle.Add(saveunlockedfreeholdlog);
                            db.SaveChanges();

                            result = "Record successfully saved......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (unlockfreeholdtitlecheck == null && unlockfreeholdprimkeycheck != null)
                     
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
                    var editsaveunlockedfreehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    var editsaveunlockedfreeholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editsaveunlockedfreehold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editsaveunlockedfreehold.Edited_By = user.getCurrentuser();
                            editsaveunlockedfreehold.Edited_Date = DateTime.Now;

                            editsaveunlockedfreehold.TitleMovementStatusID = 1;
                            editsaveunlockedfreehold.FinalSubmission = false;
                            editsaveunlockedfreehold.UnlockTitle = false;

                            editsaveunlockedfreehold.Project_Code = Convert.ToInt32(Project_Code);
                            editsaveunlockedfreehold.Title_Reference = Title_Reference;
                            editsaveunlockedfreehold.Verified = Verified;
                            editsaveunlockedfreehold.LandTypeCode = LandTypeCode;
                            editsaveunlockedfreehold.TypeCode = TypeCode;
                            editsaveunlockedfreehold.Block_No = Block_No;
                            editsaveunlockedfreehold.Flat_N0 = Flat_N0;
                            editsaveunlockedfreehold.Plot_No = Plot_No;
                            editsaveunlockedfreehold.DistrictID = DistrictID;
                            editsaveunlockedfreehold.County_ID = County_ID;
                            editsaveunlockedfreehold.Subcounty_ID = Subcounty_ID;
                            editsaveunlockedfreehold.ActualPlotSize = ActualPlotSize;
                            editsaveunlockedfreehold.PlotSize_ID = PlotSize_ID;
                            editsaveunlockedfreehold.ProprietorAddress = ProprietorAddress;
                            editsaveunlockedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            editsaveunlockedfreehold.ValueOfProperty = ValueOfProperty;
                            editsaveunlockedfreehold.Valuer = Valuer;
                            editsaveunlockedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editsaveunlockedfreehold.GeneralRemarks = GeneralRemarks;
                            editsaveunlockedfreehold.DateOfValuation = DateOfValuation;

                            editsaveunlockedfreehold.Plan_No = Plan_No;
                            editsaveunlockedfreehold.AreaOfUnit = AreaOfUnit;
                            editsaveunlockedfreehold.UnitFactor = UnitFactor;
                            editsaveunlockedfreehold.FloorAreaLeased = FloorAreaLeased;

                            editsaveunlockedfreehold.RejectionComment = RejectionComment;
                            editsaveunlockedfreehold.UnlockComment = UnlockComment;
                            editsaveunlockedfreehold.Latitude = Convert.ToDouble(Latitude);
                            editsaveunlockedfreehold.Longitude = Convert.ToDouble(Longitude);

                            editsaveunlockedfreehold.Added_By = Added_By;
                            editsaveunlockedfreehold.Added_Date = Added_Date;

                            //Audit Log Tables

                            editsaveunlockedfreeholdlog.original_Edited_By = user.getCurrentuser();
                            editsaveunlockedfreeholdlog.original_Edited_Date = DateTime.Now;

                            editsaveunlockedfreeholdlog.new_TitleMovementStatusID = 1;
                            editsaveunlockedfreeholdlog.new_FinalSubmission = false;
                            editsaveunlockedfreeholdlog.new_UnlockTitle = false;

                            editsaveunlockedfreeholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editsaveunlockedfreeholdlog.new_Volume = Volume;
                            editsaveunlockedfreeholdlog.new_Folio = Convert.ToInt32(Folio);


                            editsaveunlockedfreeholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editsaveunlockedfreeholdlog.new_Title_Reference = Title_Reference;
                            editsaveunlockedfreeholdlog.new_Verified = Verified;
                            editsaveunlockedfreeholdlog.new_LandTypeCode = LandTypeCode;
                            editsaveunlockedfreeholdlog.new_TypeCode = TypeCode;
                            editsaveunlockedfreeholdlog.new_Block_No = Block_No;
                            editsaveunlockedfreeholdlog.new_Flat_N0 = Flat_N0;
                            editsaveunlockedfreeholdlog.new_Plot_No = Plot_No;
                            editsaveunlockedfreeholdlog.new_DistrictID = DistrictID;
                            editsaveunlockedfreeholdlog.new_County_ID = County_ID;
                            editsaveunlockedfreeholdlog.new_Subcounty_ID = Subcounty_ID;
                            editsaveunlockedfreeholdlog.new_ActualPlotSize = ActualPlotSize;
                            editsaveunlockedfreeholdlog.new_PlotSize_ID = PlotSize_ID;
                            editsaveunlockedfreeholdlog.new_ProprietorAddress = ProprietorAddress;
                            editsaveunlockedfreeholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editsaveunlockedfreeholdlog.new_valueOfProperty = ValueOfProperty;
                            editsaveunlockedfreeholdlog.new_Valuer = Valuer;
                            editsaveunlockedfreeholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editsaveunlockedfreeholdlog.new_GeneralRemarks = GeneralRemarks;
                            editsaveunlockedfreeholdlog.new_DateOfValuation = DateOfValuation;

                            editsaveunlockedfreeholdlog.new_Plan_No = Plan_No;
                            editsaveunlockedfreeholdlog.new_AreaOfUnit = AreaOfUnit;
                            editsaveunlockedfreeholdlog.new_UnitFactor = UnitFactor;
                            editsaveunlockedfreeholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editsaveunlockedfreeholdlog.new_RejectionComment = RejectionComment;
                            editsaveunlockedfreeholdlog.new_UnlockComment = UnlockComment;
                            editsaveunlockedfreeholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editsaveunlockedfreeholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editsaveunlockedfreeholdlog.new_Added_By = Added_By;
                            editsaveunlockedfreeholdlog.new_Added_Date = Added_Date;

                            db.Entry(editsaveunlockedfreehold).CurrentValues.SetValues(editsaveunlockedfreehold);
                            db.Entry(editsaveunlockedfreehold).State = EntityState.Modified;

                            db.Entry(editsaveunlockedfreeholdlog).CurrentValues.SetValues(editsaveunlockedfreeholdlog);
                            db.Entry(editsaveunlockedfreeholdlog).State = EntityState.Modified;

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

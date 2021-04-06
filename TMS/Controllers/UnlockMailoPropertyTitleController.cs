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
    public class UnlockMailoPropertyTitleController : Controller
    {
        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        // GET: UnlockMailoPropertyTitle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnlockMailoPropertyTitles()
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
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            return View();
            
        }

        public ActionResult UnlockMailoPropertyTitlesAdmin()
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
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var LandTypes = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.LandTypes = LandTypes;

            return View();

        }

        // GET: UnlockMailoPropertyTitle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnlockMailoPropertyTitle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnlockMailoPropertyTitle/Create
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

        // GET: UnlockMailoPropertyTitle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnlockMailoPropertyTitle/Edit/5
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

        // GET: UnlockMailoPropertyTitle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnlockMailoPropertyTitle/Delete/5
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

        public JsonResult GetMailoData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DataSourceMailoHold(DataManager dm)
        {

            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 2) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 2) && (b.UnlockTitle == true))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 2) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.LandTypeCode == 2) && (b.UnlockTitle == true) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

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

        public ActionResult SaveUnlockMailoProperty(int? Location_id, string Title_Reference, bool? Verified, int? LandTypeCode, string Volume, int? Folio
           , int? TypeCode, string Unit_No, string Block_No, string Flat_N0, string Plan_No, string Plot_No, int? DistrictID, int? County_ID,
           int? Subcounty_ID, int? Project_Code, string AreaOfUnit, string UnitFactor, string ProprietorAddress, string BoardMinuteRelease,
           bool? PropertySoldorTransferred, string ActualPlotSize, int? PlotSize_ID,string ValueOfProperty, string Valuer,
           DateTime? DateOfValuation, string GeneralRemarks, int _type, string RejectionComment,string UnlockComment, string Added_By,
           string FloorAreaLeased,DateTime? Added_Date, decimal? Latitude, decimal? Longitude)

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
                    var unlockmailotitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var unlockmailoprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (unlockmailotitlecheck == null && unlockmailoprimkeycheck == null)
                    {
                        PropertyTitle unlockmailohold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle unlockmailoholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };


                        try
                        {
                            //PropertyTitle unlockmailohold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            unlockmailohold.Added_By = user.getCurrentuser();
                            unlockmailohold.Added_Date = DateTime.Now;

                            unlockmailohold.TitleMovementStatusID = 1;
                            unlockmailohold.FinalSubmission = false;
                            unlockmailohold.UnlockTitle = false;

                            unlockmailohold.Location_id = Convert.ToInt32(Location_id);
                            unlockmailohold.Project_Code = Convert.ToInt32(Project_Code);
                            unlockmailohold.Title_Reference = Title_Reference;
                            unlockmailohold.Verified = Verified;
                            unlockmailohold.LandTypeCode = LandTypeCode;
                            unlockmailohold.Volume = Volume;
                            unlockmailohold.Folio = Convert.ToInt32(Folio);
                            unlockmailohold.TypeCode = TypeCode;
                            unlockmailohold.Unit_No = Unit_No;
                            unlockmailohold.Block_No = Block_No;
                            unlockmailohold.Flat_N0 = Flat_N0;
                            unlockmailohold.Plan_No = Plan_No;
                            unlockmailohold.Plot_No = Plot_No;
                            unlockmailohold.DistrictID = DistrictID;
                            unlockmailohold.County_ID = County_ID;
                            unlockmailohold.Subcounty_ID = Subcounty_ID;

                            unlockmailohold.AreaOfUnit = AreaOfUnit;
                            unlockmailohold.UnitFactor = UnitFactor;
                            unlockmailohold.ProprietorAddress = ProprietorAddress;
                            unlockmailohold.BoardMinuteRelease = BoardMinuteRelease;
                            unlockmailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                            unlockmailohold.ActualPlotSize = ActualPlotSize;
                            unlockmailohold.PlotSize_ID = PlotSize_ID;
                            unlockmailohold.ValueOfProperty = ValueOfProperty;
                            unlockmailohold.Valuer = Valuer;
                            unlockmailohold.DateOfValuation = DateOfValuation;
                            unlockmailohold.GeneralRemarks = GeneralRemarks;
                            unlockmailohold.FloorAreaLeased = FloorAreaLeased;
                            unlockmailohold.RejectionComment = RejectionComment;
                            unlockmailohold.UnlockComment = UnlockComment;
                            unlockmailohold.Latitude = Convert.ToDouble(Latitude);
                            unlockmailohold.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Table

                            unlockmailoholdlog.original_Added_By = user.getCurrentuser();
                            unlockmailoholdlog.original_Added_Date = DateTime.Now;

                            unlockmailoholdlog.original_TitleMovementStatusID = 1;
                            unlockmailoholdlog.original_FinalSubmission = false;
                            unlockmailoholdlog.original_UnlockTitle = false;

                            unlockmailoholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            unlockmailoholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            unlockmailoholdlog.original_Title_Reference = Title_Reference;
                            unlockmailoholdlog.original_Verified = Verified;
                            unlockmailoholdlog.original_LandTypeCode = LandTypeCode;
                            unlockmailoholdlog.original_Volume = Volume;
                            unlockmailoholdlog.original_Folio = Convert.ToInt32(Folio);
                            unlockmailoholdlog.original_TypeCode = TypeCode;
                            unlockmailoholdlog.original_Unit_No = Unit_No;
                            unlockmailoholdlog.original_Block_No = Block_No;
                            unlockmailoholdlog.original_Flat_N0 = Flat_N0;
                            unlockmailoholdlog.original_Plan_No = Plan_No;
                            unlockmailoholdlog.original_Plot_No = Plot_No;
                            unlockmailoholdlog.original_DistrictID = DistrictID;
                            unlockmailoholdlog.original_County_ID = County_ID;
                            unlockmailoholdlog.original_Subcounty_ID = Subcounty_ID;

                            unlockmailoholdlog.original_AreaOfUnit = AreaOfUnit;
                            unlockmailoholdlog.original_UnitFactor = UnitFactor;
                            unlockmailoholdlog.original_ProprietorAddress = ProprietorAddress;
                            unlockmailoholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            unlockmailoholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            unlockmailoholdlog.original_ActualPlotSize = ActualPlotSize;
                            unlockmailoholdlog.original_PlotSize_ID = PlotSize_ID;
                            unlockmailoholdlog.original_valueOfProperty = ValueOfProperty;
                            unlockmailoholdlog.original_Valuer = Valuer;
                            unlockmailoholdlog.original_DateOfValuation = DateOfValuation;
                            unlockmailoholdlog.original_GeneralRemarks = GeneralRemarks;
                            unlockmailoholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            unlockmailoholdlog.original_RejectionComment = RejectionComment;
                            unlockmailoholdlog.original_UnlockComment = UnlockComment;
                            unlockmailoholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            unlockmailoholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(unlockmailohold);
                            db.AuditLog_PropertyTitle.Add(unlockmailoholdlog);
                            db.SaveChanges();

                            result = "Record saved successfully......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (unlockmailotitlecheck == null && unlockmailoprimkeycheck != null)                       
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
                    var editunlockmailohold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    var editunlockmailoholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editunlockmailohold != null)
                    {
                        try
                        {
                            UserManagement user = new UserManagement();
                            editunlockmailohold.Edited_By = user.getCurrentuser();
                            editunlockmailohold.Edited_Date = DateTime.Now;

                            editunlockmailohold.TitleMovementStatusID = 1;
                            editunlockmailohold.FinalSubmission = false;
                            editunlockmailohold.UnlockTitle = false;

                            editunlockmailohold.Project_Code = Convert.ToInt32(Project_Code);
                            editunlockmailohold.Title_Reference = Title_Reference;
                            editunlockmailohold.Verified = Verified;
                            editunlockmailohold.LandTypeCode = LandTypeCode;
                            editunlockmailohold.TypeCode = TypeCode;
                            editunlockmailohold.Unit_No = Unit_No;
                            editunlockmailohold.Block_No = Block_No;
                            editunlockmailohold.Flat_N0 = Flat_N0;
                            editunlockmailohold.Plan_No = Plan_No;
                            editunlockmailohold.Plot_No = Plot_No;
                            editunlockmailohold.DistrictID = DistrictID;
                            editunlockmailohold.County_ID = County_ID;
                            editunlockmailohold.Subcounty_ID = Subcounty_ID;
                            
                            editunlockmailohold.AreaOfUnit = AreaOfUnit;
                            editunlockmailohold.UnitFactor = UnitFactor;
                            editunlockmailohold.ProprietorAddress = ProprietorAddress;
                            editunlockmailohold.BoardMinuteRelease = BoardMinuteRelease;
                            editunlockmailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editunlockmailohold.ActualPlotSize = ActualPlotSize;
                            editunlockmailohold.PlotSize_ID = PlotSize_ID;
                            editunlockmailohold.ValueOfProperty = ValueOfProperty;
                            editunlockmailohold.Valuer = Valuer;
                            editunlockmailohold.DateOfValuation = DateOfValuation;
                            editunlockmailohold.GeneralRemarks = GeneralRemarks;
                            editunlockmailohold.FloorAreaLeased = FloorAreaLeased;
                            editunlockmailohold.RejectionComment = RejectionComment;
                            editunlockmailohold.UnlockComment = UnlockComment;
                            editunlockmailohold.Latitude = Convert.ToDouble(Latitude);
                            editunlockmailohold.Longitude = Convert.ToDouble(Longitude);

                            editunlockmailohold.Added_By = Added_By;
                            editunlockmailohold.Added_Date = Added_Date;

                            //Audit Log Table Save

                            editunlockmailoholdlog.original_Edited_By = user.getCurrentuser();
                            editunlockmailoholdlog.original_Edited_Date = DateTime.Now;

                            editunlockmailoholdlog.new_TitleMovementStatusID = 1;
                            editunlockmailoholdlog.new_FinalSubmission = false;
                            editunlockmailoholdlog.new_UnlockTitle = false;

                            editunlockmailoholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editunlockmailoholdlog.new_Volume = Volume;
                            editunlockmailoholdlog.new_Folio = Convert.ToInt32(Folio);

                            editunlockmailoholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editunlockmailoholdlog.new_Title_Reference = Title_Reference;
                            editunlockmailoholdlog.new_Verified = Verified;
                            editunlockmailoholdlog.new_LandTypeCode = LandTypeCode;
                            editunlockmailoholdlog.new_TypeCode = TypeCode;
                            editunlockmailoholdlog.new_Unit_No = Unit_No;
                            editunlockmailoholdlog.new_Block_No = Block_No;
                            editunlockmailoholdlog.new_Flat_N0 = Flat_N0;
                            editunlockmailoholdlog.new_Plan_No = Plan_No;
                            editunlockmailoholdlog.new_Plot_No = Plot_No;
                            editunlockmailoholdlog.new_DistrictID = DistrictID;
                            editunlockmailoholdlog.new_County_ID = County_ID;
                            editunlockmailoholdlog.new_Subcounty_ID = Subcounty_ID;

                            editunlockmailoholdlog.new_AreaOfUnit = AreaOfUnit;
                            editunlockmailoholdlog.new_UnitFactor = UnitFactor;
                            editunlockmailoholdlog.new_ProprietorAddress = ProprietorAddress;
                            editunlockmailoholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editunlockmailoholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editunlockmailoholdlog.new_ActualPlotSize = ActualPlotSize;
                            editunlockmailoholdlog.new_PlotSize_ID = PlotSize_ID;
                            editunlockmailoholdlog.new_valueOfProperty = ValueOfProperty;
                            editunlockmailoholdlog.new_Valuer = Valuer;
                            editunlockmailoholdlog.new_DateOfValuation = DateOfValuation;
                            editunlockmailoholdlog.new_GeneralRemarks = GeneralRemarks;

                            editunlockmailoholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editunlockmailoholdlog.new_RejectionComment = RejectionComment;
                            editunlockmailoholdlog.new_UnlockComment = UnlockComment;
                            editunlockmailoholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editunlockmailoholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editunlockmailoholdlog.new_Added_By = Added_By;
                            editunlockmailoholdlog.new_Added_Date = Added_Date;

                            db.Entry(editunlockmailohold).CurrentValues.SetValues(editunlockmailohold);
                            db.Entry(editunlockmailohold).State = EntityState.Modified;

                            db.Entry(editunlockmailoholdlog).CurrentValues.SetValues(editunlockmailoholdlog);
                            db.Entry(editunlockmailoholdlog).State = EntityState.Modified;

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

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
    public class ApprovedMailoTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApprovedMailoTitles
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
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

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
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        public ActionResult ApprovedMailoCEO()
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
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

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
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

          

            return View();
        }


        // GET: ApprovedMailoTitles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApprovedMailoTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedMailoTitles/Create
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

        // GET: ApprovedMailoTitles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApprovedMailoTitles/Edit/5
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

        // GET: ApprovedMailoTitles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApprovedMailoTitles/Delete/5
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
            //Returns all the fields in the table based on the Title Movement Status ID
            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false) && (b.LandTypeCode == 2))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false) && (b.LandTypeCode == 2))).ToList().Count();
                       
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

        public JsonResult GetMailoData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveApprovedMailoProperty(int? Location_id, string Title_Reference,int? Project_Code, bool? Verified, int? LandTypeCode, string Volume, int? Folio
           , int? TypeCode, string Unit_No, string Block_No, string Flat_N0, string Plan_No, string Plot_No, int? DistrictID, int? County_ID,
           int? Subcounty_ID, string AreaOfUnit, string UnitFactor, string ProprietorAddress, string BoardMinuteRelease,
           bool? PropertySoldorTransferred, string ActualPlotSize, int? PlotSize_ID,string ValueOfProperty, string Valuer,
           DateTime? DateOfValuation, string GeneralRemarks, int _type, bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment,
           string UnlockComment, string Added_By, DateTime? Added_Date, string FloorAreaLeased, bool? UnlockTitle, decimal? Latitude, decimal? Longitude)

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
                    var approvedmailotitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedmailoprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (approvedmailotitlecheck == null && approvedmailoprimkeycheck == null)
                    {
                        PropertyTitle approvedmailohold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle approvedmailoholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };


                        try
                        {
                            //PropertyTitle approvedmailohold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            approvedmailohold.Added_By = user.getCurrentuser();
                            approvedmailohold.Added_Date = DateTime.Now;

                            approvedmailohold.UnlockTitle = UnlockTitle;

                            approvedmailohold.Location_id = Convert.ToInt32(Location_id);
                            approvedmailohold.Project_Code = Convert.ToInt32(Project_Code);
                            approvedmailohold.Title_Reference = Title_Reference;
                            approvedmailohold.Verified = Verified;
                            approvedmailohold.LandTypeCode = LandTypeCode;
                            approvedmailohold.Volume = Volume;
                            approvedmailohold.Folio = Convert.ToInt32(Folio);
                            approvedmailohold.TypeCode = TypeCode;
                            approvedmailohold.Unit_No = Unit_No;
                            approvedmailohold.Block_No = Block_No;
                            approvedmailohold.Flat_N0 = Flat_N0;
                            approvedmailohold.Plan_No = Plan_No;
                            approvedmailohold.Plot_No = Plot_No;
                            approvedmailohold.DistrictID = DistrictID;
                            approvedmailohold.County_ID = County_ID;
                            approvedmailohold.Subcounty_ID = Subcounty_ID;

                            approvedmailohold.AreaOfUnit = AreaOfUnit;
                            approvedmailohold.UnitFactor = UnitFactor;
                            approvedmailohold.ProprietorAddress = ProprietorAddress;
                            approvedmailohold.BoardMinuteRelease = BoardMinuteRelease;
                            approvedmailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedmailohold.ActualPlotSize = ActualPlotSize;
                            approvedmailohold.PlotSize_ID = PlotSize_ID;
                            approvedmailohold.ValueOfProperty = ValueOfProperty;
                            approvedmailohold.Valuer = Valuer;
                            approvedmailohold.DateOfValuation = DateOfValuation;
                            approvedmailohold.GeneralRemarks = GeneralRemarks;

                            approvedmailohold.FloorAreaLeased = FloorAreaLeased;

                            approvedmailohold.FinalSubmission = FinalSubmission;
                            approvedmailohold.TitleMovementStatusID = TitleMovementStatusID;
                            approvedmailohold.RejectionComment = RejectionComment;
                            approvedmailohold.UnlockComment = UnlockComment;
                            approvedmailohold.Latitude = Convert.ToDouble(Latitude);
                            approvedmailohold.Longitude = Convert.ToDouble(Longitude);
                            
                            //Audit Log Saving
                            approvedmailoholdlog.original_Added_By = user.getCurrentuser();
                            approvedmailoholdlog.original_Added_Date = DateTime.Now;

                            approvedmailoholdlog.original_UnlockTitle = UnlockTitle;

                            approvedmailoholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            approvedmailoholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approvedmailoholdlog.original_Title_Reference = Title_Reference;
                            approvedmailoholdlog.original_Verified = Verified;
                            approvedmailoholdlog.original_LandTypeCode = LandTypeCode;
                            approvedmailoholdlog.original_Volume = Volume;
                            approvedmailoholdlog.original_Folio = Convert.ToInt32(Folio);
                            approvedmailoholdlog.original_TypeCode = TypeCode;
                            approvedmailoholdlog.original_Unit_No = Unit_No;
                            approvedmailoholdlog.original_Block_No = Block_No;
                            approvedmailoholdlog.original_Flat_N0 = Flat_N0;
                            approvedmailoholdlog.original_Plan_No = Plan_No;
                            approvedmailoholdlog.original_Plot_No = Plot_No;
                            approvedmailoholdlog.original_DistrictID = DistrictID;
                            approvedmailoholdlog.original_County_ID = County_ID;
                            approvedmailoholdlog.original_Subcounty_ID = Subcounty_ID;

                            approvedmailoholdlog.original_AreaOfUnit = AreaOfUnit;
                            approvedmailoholdlog.original_UnitFactor = UnitFactor;
                            approvedmailoholdlog.original_ProprietorAddress = ProprietorAddress;
                            approvedmailoholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            approvedmailoholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedmailoholdlog.original_ActualPlotSize = ActualPlotSize;
                            approvedmailoholdlog.original_PlotSize_ID = PlotSize_ID;
                            approvedmailoholdlog.original_valueOfProperty = ValueOfProperty;
                            approvedmailoholdlog.original_Valuer = Valuer;
                            approvedmailoholdlog.original_DateOfValuation = DateOfValuation;
                            approvedmailoholdlog.original_GeneralRemarks = GeneralRemarks;

                            approvedmailoholdlog.original_FloorAreaLeased = FloorAreaLeased;

                            approvedmailoholdlog.original_FinalSubmission = FinalSubmission;
                            approvedmailoholdlog.original_TitleMovementStatusID = TitleMovementStatusID;
                            approvedmailoholdlog.original_RejectionComment = RejectionComment;
                            approvedmailoholdlog.original_UnlockComment = UnlockComment;
                            approvedmailoholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approvedmailoholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(approvedmailohold);
                            db.AuditLog_PropertyTitle.Add(approvedmailoholdlog);
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }
                    else if (approvedmailotitlecheck == null && approvedmailoprimkeycheck != null)
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
                    var editapprovedmailohold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    var editapprovedmailoholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editapprovedmailohold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            //editapprovedmailohold.Edited_By = user.getCurrentuser();
                            //editapprovedmailohold.Edited_Date = DateTime.Now;

                            editapprovedmailohold.UnlockedBy = user.getCurrentuser();
                            editapprovedmailohold.UnlockDate = DateTime.Now;

                            editapprovedmailohold.UnlockTitle = UnlockTitle;

                            editapprovedmailohold.Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedmailohold.Title_Reference = Title_Reference;
                            editapprovedmailohold.Verified = Verified;
                            editapprovedmailohold.LandTypeCode = LandTypeCode;
                            editapprovedmailohold.TypeCode = TypeCode;
                            editapprovedmailohold.Unit_No = Unit_No;
                            editapprovedmailohold.Block_No = Block_No;
                            editapprovedmailohold.Flat_N0 = Flat_N0;
                            editapprovedmailohold.Plan_No = Plan_No;
                            editapprovedmailohold.Plot_No = Plot_No;
                            editapprovedmailohold.DistrictID = DistrictID;
                            editapprovedmailohold.County_ID = County_ID;
                            editapprovedmailohold.Subcounty_ID = Subcounty_ID;
                            editapprovedmailohold.AreaOfUnit = AreaOfUnit;
                            editapprovedmailohold.UnitFactor = UnitFactor;
                            editapprovedmailohold.ProprietorAddress = ProprietorAddress;
                            editapprovedmailohold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedmailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedmailohold.ActualPlotSize = ActualPlotSize;
                            editapprovedmailohold.PlotSize_ID = PlotSize_ID;
                            editapprovedmailohold.ValueOfProperty = ValueOfProperty;
                            editapprovedmailohold.Valuer = Valuer;
                            editapprovedmailohold.DateOfValuation = DateOfValuation;
                            editapprovedmailohold.GeneralRemarks = GeneralRemarks;

                            editapprovedmailohold.FloorAreaLeased = FloorAreaLeased;

                            editapprovedmailohold.FinalSubmission = FinalSubmission;
                            editapprovedmailohold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedmailohold.RejectionComment = RejectionComment;
                            editapprovedmailohold.UnlockComment = UnlockComment;

                            editapprovedmailohold.Added_By = Added_By;
                            editapprovedmailohold.Added_Date = Added_Date;
                            editapprovedmailohold.Latitude = Convert.ToDouble(Latitude);
                            editapprovedmailohold.Longitude = Convert.ToDouble(Longitude);

                            // Audit Log Tables

                            editapprovedmailoholdlog.original_UnlockedBy = user.getCurrentuser();
                            editapprovedmailoholdlog.original_UnlockDate = DateTime.Now;

                            editapprovedmailoholdlog.new_UnlockTitle = UnlockTitle;

                            editapprovedmailoholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapprovedmailoholdlog.new_Volume = Volume;
                            editapprovedmailoholdlog.new_Folio = Convert.ToInt32(Folio);

                            editapprovedmailoholdlog.new_Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedmailoholdlog.new_Title_Reference = Title_Reference;
                            editapprovedmailoholdlog.new_Verified = Verified;
                            editapprovedmailoholdlog.new_LandTypeCode = LandTypeCode;
                            editapprovedmailoholdlog.new_TypeCode = TypeCode;
                            editapprovedmailoholdlog.new_Unit_No = Unit_No;
                            editapprovedmailoholdlog.new_Block_No = Block_No;
                            editapprovedmailoholdlog.new_Flat_N0 = Flat_N0;
                            editapprovedmailoholdlog.new_Plan_No = Plan_No;
                            editapprovedmailoholdlog.new_Plot_No = Plot_No;
                            editapprovedmailoholdlog.new_DistrictID = DistrictID;
                            editapprovedmailoholdlog.new_County_ID = County_ID;
                            editapprovedmailoholdlog.new_Subcounty_ID = Subcounty_ID;
                            editapprovedmailoholdlog.new_AreaOfUnit = AreaOfUnit;
                            editapprovedmailoholdlog.new_UnitFactor = UnitFactor;
                            editapprovedmailoholdlog.new_ProprietorAddress = ProprietorAddress;
                            editapprovedmailoholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedmailoholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedmailoholdlog.new_ActualPlotSize = ActualPlotSize;
                            editapprovedmailoholdlog.new_PlotSize_ID = PlotSize_ID;
                            editapprovedmailoholdlog.new_valueOfProperty = ValueOfProperty;
                            editapprovedmailoholdlog.new_Valuer = Valuer;
                            editapprovedmailoholdlog.new_DateOfValuation = DateOfValuation;
                            editapprovedmailoholdlog.new_GeneralRemarks = GeneralRemarks;

                            editapprovedmailoholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editapprovedmailoholdlog.new_FinalSubmission = FinalSubmission;
                            editapprovedmailoholdlog.new_TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedmailoholdlog.new_RejectionComment = RejectionComment;
                            editapprovedmailoholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapprovedmailoholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapprovedmailoholdlog.original_UnlockComment = UnlockComment;

                            editapprovedmailoholdlog.new_Added_By = Added_By;
                            editapprovedmailoholdlog.new_Added_Date = Added_Date;


                            db.Entry(editapprovedmailohold).CurrentValues.SetValues(editapprovedmailohold);
                            db.Entry(editapprovedmailohold).State = EntityState.Modified;

                            db.Entry(editapprovedmailoholdlog).CurrentValues.SetValues(editapprovedmailoholdlog);
                            db.Entry(editapprovedmailoholdlog).State = EntityState.Modified;

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

        public ActionResult CEOSaveApprovedMailoProperty(int? Location_id, string Title_Reference, int? Project_Code, bool? Verified, int? LandTypeCode, string Volume, int? Folio
           , int? TypeCode, string Unit_No, string Block_No, string Flat_N0, string Plan_No, string Plot_No, int? DistrictID, int? County_ID,
           int? Subcounty_ID, string AreaOfUnit, string UnitFactor, string ProprietorAddress, string BoardMinuteRelease,
           bool? PropertySoldorTransferred, string ActualPlotSize, int? PlotSize_ID,string ValueOfProperty, string Valuer,
           DateTime? DateOfValuation, string GeneralRemarks, int _type, bool? FinalSubmission, int? TitleMovementStatusID, string RejectionComment,
           string UnlockComment, string Added_By, DateTime? Added_Date, string FloorAreaLeased, bool? UnlockTitle, decimal? Latitude,decimal? Longitude)

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
                    var approvedmailotitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedmailoprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (approvedmailotitlecheck == null && approvedmailoprimkeycheck == null)
                    {

                        PropertyTitle approvedmailohold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle approvedmailohold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            approvedmailohold.Added_By = user.getCurrentuser();
                            approvedmailohold.Added_Date = DateTime.Now;

                            approvedmailohold.UnlockTitle = UnlockTitle;

                            approvedmailohold.Location_id = Convert.ToInt32(Location_id);
                            approvedmailohold.Project_Code = Convert.ToInt32(Project_Code);
                            approvedmailohold.Title_Reference = Title_Reference;
                            approvedmailohold.Verified = Verified;
                            approvedmailohold.LandTypeCode = LandTypeCode;
                            approvedmailohold.Volume = Volume;
                            approvedmailohold.Folio = Convert.ToInt32(Folio);
                            approvedmailohold.TypeCode = TypeCode;
                            approvedmailohold.Unit_No = Unit_No;
                            approvedmailohold.Block_No = Block_No;
                            approvedmailohold.Flat_N0 = Flat_N0;
                            approvedmailohold.Plan_No = Plan_No;
                            approvedmailohold.Plot_No = Plot_No;
                            approvedmailohold.DistrictID = DistrictID;
                            approvedmailohold.County_ID = County_ID;
                            approvedmailohold.Subcounty_ID = Subcounty_ID;

                            approvedmailohold.FloorAreaLeased = FloorAreaLeased;

                            approvedmailohold.AreaOfUnit = AreaOfUnit;
                            approvedmailohold.UnitFactor = UnitFactor;
                            approvedmailohold.ProprietorAddress = ProprietorAddress;
                            approvedmailohold.BoardMinuteRelease = BoardMinuteRelease;
                            approvedmailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                            approvedmailohold.ActualPlotSize = ActualPlotSize;
                            approvedmailohold.PlotSize_ID = PlotSize_ID;
                            approvedmailohold.ValueOfProperty = ValueOfProperty;
                            approvedmailohold.Valuer = Valuer;
                            approvedmailohold.DateOfValuation = DateOfValuation;
                            approvedmailohold.GeneralRemarks = GeneralRemarks;

                            approvedmailohold.FinalSubmission = FinalSubmission;
                            approvedmailohold.TitleMovementStatusID = TitleMovementStatusID;
                            approvedmailohold.RejectionComment = RejectionComment;
                            approvedmailohold.UnlockComment = UnlockComment;
                            approvedmailohold.Latitude = Convert.ToDouble(Latitude);
                            approvedmailohold.Longitude = Convert.ToDouble(Longitude);
                            
                            db.PropertyTitles.Add(approvedmailohold);
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }
                    else if (approvedmailotitlecheck == null && approvedmailoprimkeycheck != null)
                       
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

                var editapprovedmailohold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                if (editapprovedmailohold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            //editapprovedmailohold.Edited_By = user.getCurrentuser();
                            //editapprovedmailohold.Edited_Date = DateTime.Now;

                            editapprovedmailohold.UnlockedBy = user.getCurrentuser();
                            editapprovedmailohold.UnlockDate = DateTime.Now;

                            editapprovedmailohold.UnlockTitle = UnlockTitle;
                            editapprovedmailohold.Project_Code = Convert.ToInt32(Project_Code);

                            editapprovedmailohold.Title_Reference = Title_Reference;
                            editapprovedmailohold.Verified = Verified;
                            editapprovedmailohold.LandTypeCode = LandTypeCode;
                            editapprovedmailohold.TypeCode = TypeCode;
                            editapprovedmailohold.Unit_No = Unit_No;
                            editapprovedmailohold.Block_No = Block_No;
                            editapprovedmailohold.Flat_N0 = Flat_N0;
                            editapprovedmailohold.Plan_No = Plan_No;
                            editapprovedmailohold.Plot_No = Plot_No;
                            editapprovedmailohold.DistrictID = DistrictID;
                            editapprovedmailohold.County_ID = County_ID;
                            editapprovedmailohold.Subcounty_ID = Subcounty_ID;
                        
                            editapprovedmailohold.AreaOfUnit = AreaOfUnit;
                            editapprovedmailohold.UnitFactor = UnitFactor;
                            editapprovedmailohold.ProprietorAddress = ProprietorAddress;
                            editapprovedmailohold.BoardMinuteRelease = BoardMinuteRelease;
                            editapprovedmailohold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editapprovedmailohold.ActualPlotSize = ActualPlotSize;
                            editapprovedmailohold.PlotSize_ID = PlotSize_ID;
                            editapprovedmailohold.ValueOfProperty = ValueOfProperty;
                            editapprovedmailohold.Valuer = Valuer;
                            editapprovedmailohold.DateOfValuation = DateOfValuation;
                            editapprovedmailohold.GeneralRemarks = GeneralRemarks;
                            editapprovedmailohold.FloorAreaLeased = FloorAreaLeased;
                            editapprovedmailohold.FinalSubmission = FinalSubmission;
                            editapprovedmailohold.TitleMovementStatusID = TitleMovementStatusID;
                            editapprovedmailohold.RejectionComment = RejectionComment;
                            editapprovedmailohold.UnlockComment = UnlockComment;
                            editapprovedmailohold.Latitude = Convert.ToDouble(Latitude);
                            editapprovedmailohold.Longitude = Convert.ToDouble(Longitude);

                            editapprovedmailohold.Added_By = Added_By;
                            editapprovedmailohold.Added_Date = Added_Date;

                            db.Entry(editapprovedmailohold).CurrentValues.SetValues(editapprovedmailohold);
                            db.Entry(editapprovedmailohold).State = EntityState.Modified;

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

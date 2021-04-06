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
    public class RejectedPropertyTilesMailo1Controller : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        // GET: RejectedPropertyTilesMailo1
        public ActionResult Index()
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
            var LandTypes = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.LandTypes = LandTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
        }

        public ActionResult RejectedMailoAdmin()
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
            var LandTypes = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.LandTypes = LandTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;



            return View();
        }

        // GET: RejectedPropertyTilesMailo1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RejectedPropertyTilesMailo1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RejectedPropertyTilesMailo1/Create
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

        // GET: RejectedPropertyTilesMailo1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RejectedPropertyTilesMailo1/Edit/5
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

        // GET: RejectedPropertyTilesMailo1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RejectedPropertyTilesMailo1/Delete/5
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


        public ActionResult DataSourceRejectedMailoStatus(DataManager dm)
        {
            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 2))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 2))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 2) && b.Added_By == user)).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 2) && b.Added_By == user)).OrderByDescending(a => a.Added_Date).ToList().Count();

                //&& (b.Added_By = user.getCurrentuser)

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

        public ActionResult DataSourceRejectedMailoStatusAdmin(DataManager dm)
        {

            var user = User.Identity.Name;
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 2))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 2) )).OrderByDescending(a => a.Added_Date).ToList().Count();

            //&& (b.Added_By = user.getCurrentuser)

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

            return Json(value, JsonRequestBehavior.AllowGet);
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

        public ActionResult SaveRejectedMailoProperty(int? Location_id, string Title_Reference, bool? Verified, int? LandTypeCode, string Volume, int? Folio
           , int? TypeCode, string Unit_No, string Block_No, string Flat_N0, string Plan_No, string Plot_No, int? DistrictID, int? County_ID,
           int? Subcounty_ID, int? Project_Code, string AreaOfUnit, string UnitFactor, string ProprietorAddress, string BoardMinuteRelease,
           bool? PropertySoldorTransferred, string ActualPlotSize, int? PlotSize_ID,string ValueOfProperty, string Valuer,DateTime? DateOfValuation, 
           string GeneralRemarks, int _type,string RejectionComment,string UnlockComment, string Added_By, string FloorAreaLeased,DateTime? Added_Date, decimal? Latitude, 
           decimal? Longitude)

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
                    var rejmailotitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var rejmailoprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (rejmailotitlecheck == null && rejmailoprimkeycheck == null)
                    {
                        PropertyTitle rejmailo = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle rejmailolog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };


                        try
                        {
                            //PropertyTitle approvemailohold = new PropertyTitle();
                            UserManagement user = new UserManagement();

                            rejmailo.Added_By = user.getCurrentuser();
                            rejmailo.Added_Date = DateTime.Now;

                            rejmailo.TitleMovementStatusID = 1;
                            rejmailo.FinalSubmission = false;
                            rejmailo.UnlockTitle = false;

                            //rejmailo.UnlockTitle = false;

                            rejmailo.Location_id = Convert.ToInt32(Location_id);
                            rejmailo.Project_Code = Convert.ToInt32(Project_Code);
                            rejmailo.Title_Reference = Title_Reference;
                            rejmailo.Verified = Verified;
                            rejmailo.LandTypeCode = LandTypeCode;
                            rejmailo.Volume = Volume;
                            rejmailo.Folio = Convert.ToInt32(Folio);
                            rejmailo.TypeCode = TypeCode;
                            rejmailo.Unit_No = Unit_No;
                            rejmailo.Block_No = Block_No;
                            rejmailo.Flat_N0 = Flat_N0;
                            rejmailo.Plan_No = Plan_No;
                            rejmailo.Plot_No = Plot_No;
                            rejmailo.DistrictID = DistrictID;
                            rejmailo.County_ID = County_ID;
                            rejmailo.Subcounty_ID = Subcounty_ID;
                            rejmailo.Location_id = Convert.ToInt32(Location_id);
                            rejmailo.AreaOfUnit = AreaOfUnit;
                            rejmailo.UnitFactor = UnitFactor;
                            rejmailo.ProprietorAddress = ProprietorAddress;
                            rejmailo.BoardMinuteRelease = BoardMinuteRelease;
                            rejmailo.PropertySoldorTransferred = PropertySoldorTransferred;
                            rejmailo.ActualPlotSize = ActualPlotSize;
                            rejmailo.PlotSize_ID = PlotSize_ID;
                            rejmailo.ValueOfProperty = ValueOfProperty;
                            rejmailo.Valuer = Valuer;
                            rejmailo.DateOfValuation = DateOfValuation;
                            rejmailo.GeneralRemarks = GeneralRemarks;

                            rejmailo.FloorAreaLeased = FloorAreaLeased;

                            rejmailo.RejectionComment = RejectionComment;
                            rejmailo.UnlockComment = UnlockComment;
                            rejmailo.Latitude = Convert.ToDouble(Latitude);
                            rejmailo.Longitude = Convert.ToDouble(Longitude);
                            
                            //Audit Log Table Save
                            rejmailolog.original_Added_By = user.getCurrentuser();
                            rejmailolog.original_Added_Date = DateTime.Now;

                            rejmailolog.original_TitleMovementStatusID = 1;
                            rejmailolog.original_FinalSubmission = false;
                            rejmailolog.original_UnlockTitle = false;

                            //rejmailo.UnlockTitle = false;

                            rejmailolog.original_Locationid = Convert.ToInt32(Location_id);
                            rejmailolog.original_Project_Code = Convert.ToInt32(Project_Code);
                            rejmailolog.original_Title_Reference = Title_Reference;
                            rejmailolog.original_Verified = Verified;
                            rejmailolog.original_LandTypeCode = LandTypeCode;
                            rejmailolog.original_Volume = Volume;
                            rejmailolog.original_Folio = Convert.ToInt32(Folio);
                            rejmailolog.original_TypeCode = TypeCode;
                            rejmailolog.original_Unit_No = Unit_No;
                            rejmailolog.original_Block_No = Block_No;
                            rejmailolog.original_Flat_N0 = Flat_N0;
                            rejmailolog.original_Plan_No = Plan_No;
                            rejmailolog.original_Plot_No = Plot_No;
                            rejmailolog.original_DistrictID = DistrictID;
                            rejmailolog.original_County_ID = County_ID;
                            rejmailolog.original_Subcounty_ID = Subcounty_ID;
                            
                            rejmailolog.original_AreaOfUnit = AreaOfUnit;
                            rejmailolog.original_UnitFactor = UnitFactor;
                            rejmailolog.original_ProprietorAddress = ProprietorAddress;
                            rejmailolog.original_BoardMinuteRelease = BoardMinuteRelease;
                            rejmailolog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            rejmailolog.original_ActualPlotSize = ActualPlotSize;
                            rejmailolog.original_PlotSize_ID = PlotSize_ID;
                            rejmailolog.original_valueOfProperty = ValueOfProperty;
                            rejmailolog.original_Valuer = Valuer;
                            rejmailolog.original_DateOfValuation = DateOfValuation;
                            rejmailolog.original_GeneralRemarks = GeneralRemarks;

                            rejmailolog.original_FloorAreaLeased = FloorAreaLeased;

                            rejmailolog.original_RejectionComment = RejectionComment;
                            rejmailolog.original_UnlockComment = UnlockComment;
                            rejmailolog.Original_Latitude = Convert.ToDouble(Latitude);
                            rejmailolog.Original_Longitude = Convert.ToDouble(Longitude);
                            
                            db.PropertyTitles.Add(rejmailo);
                            db.AuditLog_PropertyTitle.Add(rejmailolog);
                                                    
                            db.SaveChanges();

                            result = "Record successfully saved......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (rejmailotitlecheck == null && rejmailoprimkeycheck != null)
                       
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
                    var editrejmailo = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    var editrejmailolog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editrejmailo != null)
                    {
                        try
                        {

                            UserManagement user = new UserManagement();
                            editrejmailo.Edited_By = user.getCurrentuser();
                            editrejmailo.Edited_Date = DateTime.Now;

                            //editrejmailo.UnlockTitle = false;

                            editrejmailo.TitleMovementStatusID = 1;
                            editrejmailo.FinalSubmission = false;
                            editrejmailo.UnlockTitle = false;


                            editrejmailo.Project_Code = Convert.ToInt32(Project_Code);
                            editrejmailo.Title_Reference = Title_Reference;

                            editrejmailo.Verified = Verified;
                            editrejmailo.LandTypeCode = LandTypeCode;
                            editrejmailo.TypeCode = TypeCode;
                            editrejmailo.Unit_No = Unit_No;
                            editrejmailo.Block_No = Block_No;
                            editrejmailo.Flat_N0 = Flat_N0;
                            editrejmailo.Plan_No = Plan_No;
                            editrejmailo.Plot_No = Plot_No;
                            editrejmailo.DistrictID = DistrictID;
                            editrejmailo.County_ID = County_ID;
                            editrejmailo.Subcounty_ID = Subcounty_ID;
                          
                            editrejmailo.AreaOfUnit = AreaOfUnit;
                            editrejmailo.UnitFactor = UnitFactor;
                            editrejmailo.ProprietorAddress = ProprietorAddress;
                            editrejmailo.BoardMinuteRelease = BoardMinuteRelease;
                            editrejmailo.PropertySoldorTransferred = PropertySoldorTransferred;
                            editrejmailo.ActualPlotSize = ActualPlotSize;
                            editrejmailo.PlotSize_ID = PlotSize_ID;
                            editrejmailo.ValueOfProperty = ValueOfProperty;
                            editrejmailo.Valuer = Valuer;
                            editrejmailo.DateOfValuation = DateOfValuation;
                            editrejmailo.GeneralRemarks = GeneralRemarks;

                            editrejmailo.FloorAreaLeased = FloorAreaLeased;

                            editrejmailo.RejectionComment = RejectionComment;
                            editrejmailo.UnlockComment = UnlockComment;

                            editrejmailo.Added_By = Added_By;
                            editrejmailo.Added_Date = Added_Date;
                            editrejmailo.Latitude = Convert.ToDouble(Latitude);
                            editrejmailo.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Table Save

                            editrejmailolog.original_Edited_By = user.getCurrentuser();
                            editrejmailolog.original_Edited_Date = DateTime.Now;

                            editrejmailolog.new_TitleMovementStatusID = 1;
                            editrejmailolog.new_FinalSubmission = false;
                            editrejmailolog.new_UnlockTitle = false;

                            editrejmailolog.new_Locationid = Convert.ToInt32(Location_id);
                            editrejmailolog.new_Volume = Volume;
                            editrejmailolog.new_Folio = Convert.ToInt32(Folio);

                            editrejmailolog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editrejmailolog.new_Title_Reference = Title_Reference;

                            editrejmailolog.new_Verified = Verified;
                            editrejmailolog.new_LandTypeCode = LandTypeCode;
                            editrejmailolog.new_TypeCode = TypeCode;
                            editrejmailolog.new_Unit_No = Unit_No;
                            editrejmailolog.new_Block_No = Block_No;
                            editrejmailolog.new_Flat_N0 = Flat_N0;
                            editrejmailolog.new_Plan_No = Plan_No;
                            editrejmailolog.new_Plot_No = Plot_No;
                            editrejmailolog.new_DistrictID = DistrictID;
                            editrejmailolog.new_County_ID = County_ID;
                            editrejmailolog.new_Subcounty_ID = Subcounty_ID;

                            editrejmailolog.new_AreaOfUnit = AreaOfUnit;
                            editrejmailolog.new_UnitFactor = UnitFactor;
                            editrejmailolog.new_ProprietorAddress = ProprietorAddress;
                            editrejmailolog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editrejmailolog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editrejmailolog.new_ActualPlotSize = ActualPlotSize;
                            editrejmailolog.new_PlotSize_ID = PlotSize_ID;
                            editrejmailolog.new_valueOfProperty = ValueOfProperty;
                            editrejmailolog.new_Valuer = Valuer;
                            editrejmailolog.new_DateOfValuation = DateOfValuation;
                            editrejmailolog.new_GeneralRemarks = GeneralRemarks;

                            editrejmailolog.original_RejectionComment = RejectionComment;
                            editrejmailolog.original_UnlockComment = UnlockComment;

                            editrejmailolog.new_FloorAreaLeased = FloorAreaLeased;
                            editrejmailolog.New_Latitude = Convert.ToDouble(Latitude);
                            editrejmailolog.New_Longitude = Convert.ToDouble(Longitude);

                            editrejmailolog.new_Added_By = Added_By;
                            editrejmailolog.new_Added_Date = Added_Date;

                            db.Entry(editrejmailo).CurrentValues.SetValues(editrejmailo);
                            db.Entry(editrejmailo).State = EntityState.Modified;

                            db.Entry(editrejmailolog).CurrentValues.SetValues(editrejmailolog);
                            db.Entry(editrejmailolog).State = EntityState.Modified;

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
                            //result = Title_Reference + " is updated successfully";

                            result = Title_Reference.Trim() + " saved successfully";
                            
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

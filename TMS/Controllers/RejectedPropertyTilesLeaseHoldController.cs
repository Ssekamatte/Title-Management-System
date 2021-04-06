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
    public class RejectedPropertyTilesLeaseHoldController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: RejectedPropertyTilesLeaseHold
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            //var propertyTitles = db.PropertyTitles.Include(p => p.County).Include(p => p.District).Include(p => p.Lease_Type).Include(p => p.Location).Include(p => p.Project).Include(p => p.PropertyTitle2).Include(p => p.PropertyTitle_LeaseYears).Include(p => p.PropertyTitle_PlotSize).Include(p => p.PropertyType);
            //return View(propertyTitles.ToList());

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

            db.Configuration.ProxyCreationEnabled = false;
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;


            return View();
        }

        public ActionResult RejectedLeaseHoldAdmin()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            //var propertyTitles = db.PropertyTitles.Include(p => p.County).Include(p => p.District).Include(p => p.Lease_Type).Include(p => p.Location).Include(p => p.Project).Include(p => p.PropertyTitle2).Include(p => p.PropertyTitle_LeaseYears).Include(p => p.PropertyTitle_PlotSize).Include(p => p.PropertyType);
            //return View(propertyTitles.ToList());

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

            db.Configuration.ProxyCreationEnabled = false;
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;


            return View();
        }

        // GET: RejectedPropertyTilesLeaseHold/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyTitle propertyTitle = db.PropertyTitles.Find(id);
            if (propertyTitle == null)
            {
                return HttpNotFound();
            }
            return View(propertyTitle);
        }

        // GET: RejectedPropertyTilesLeaseHold/Create
        public ActionResult Create()
        {
            ViewBag.County_ID = new SelectList(db.Counties, "County_ID", "County_Name");
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "District_Name");
            ViewBag.LandTypeCode = new SelectList(db.Lease_Type, "LandTypeCode", "LandDesc");
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Location_Desc");
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc");
            ViewBag.Project_CodeParent = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference");
            ViewBag.LeaseYears_ID = new SelectList(db.PropertyTitle_LeaseYears, "LeaseYears_ID", "LeaseYears");
            ViewBag.PlotSize_ID = new SelectList(db.PropertyTitle_PlotSize, "PlotSize_ID", "PlotSize_Desc");
            ViewBag.TypeCode = new SelectList(db.PropertyTypes, "TypeCode", "TypeDesc");
            return View();
        }

        // POST: RejectedPropertyTilesLeaseHold/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_Code,Volume,Folio,Project_id,Title_Reference,TypeCode,LandTypeCode,Unit_No,Plan_No,Block_No,Flat_N0,Region_num,DistrictID,County_ID,Subcounty_ID,Parish_ID,Town_Village,Location_id,Street,Plot_No,Lease_Start_Date,Lease_End_Date,Ground_Rent,Rates,OfferNo,Purchaser_Name,Nationality,Purchasers_Address,Purchasers_TelNo,Purchasers_Email,PurchaserEmployer,Offer_Value,OfferDate,OfferExpiryDate,OfferPaymentDate,OfferPaidUP,TitleTransferred,TransferDate,PurchaserRemark,NewDataAudit,EditDataAudit,PropertyStaatus,AreaOfUnit,FloorAreaLeased,UnitFactor,Date,RegDate,InstrumentNo,ProprietorName,ProprietorAddress,FathersName,Clan,Registrar,BoardMinuteRelease,Directors,Added_By,Added_Date,Edited_By,Edited_Date,PlotSize_ID,ValueOfProperty,LeaseYears_ID,ActualPlotSize,SourceOfLease,GroundRentNarrative,GroundRentDueDate,GeneralRemarks,Valuer,DateOfValuation,PropertySoldorTransferred,Project_CodeParent,VolumeParent,FolioParent,TitleMovementStatusID,TitleSentBackToEntrant,FinalSubmission")] PropertyTitle propertyTitle)
        {
            if (ModelState.IsValid)
            {
                db.PropertyTitles.Add(propertyTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.County_ID = new SelectList(db.Counties, "County_ID", "County_Name", propertyTitle.County_ID);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "District_Name", propertyTitle.DistrictID);
            ViewBag.LandTypeCode = new SelectList(db.Lease_Type, "LandTypeCode", "LandDesc", propertyTitle.LandTypeCode);
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Location_Desc", propertyTitle.Location_id);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", propertyTitle.Project_Code);
            ViewBag.Project_CodeParent = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference", propertyTitle.Project_CodeParent);
            ViewBag.LeaseYears_ID = new SelectList(db.PropertyTitle_LeaseYears, "LeaseYears_ID", "LeaseYears", propertyTitle.LeaseYears_ID);
            ViewBag.PlotSize_ID = new SelectList(db.PropertyTitle_PlotSize, "PlotSize_ID", "PlotSize_Desc", propertyTitle.PlotSize_ID);
            ViewBag.TypeCode = new SelectList(db.PropertyTypes, "TypeCode", "TypeDesc", propertyTitle.TypeCode);
            return View(propertyTitle);
        }

        // GET: RejectedPropertyTilesLeaseHold/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyTitle propertyTitle = db.PropertyTitles.Find(id);
            if (propertyTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.County_ID = new SelectList(db.Counties, "County_ID", "County_Name", propertyTitle.County_ID);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "District_Name", propertyTitle.DistrictID);
            ViewBag.LandTypeCode = new SelectList(db.Lease_Type, "LandTypeCode", "LandDesc", propertyTitle.LandTypeCode);
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Location_Desc", propertyTitle.Location_id);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", propertyTitle.Project_Code);
            ViewBag.Project_CodeParent = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference", propertyTitle.Project_CodeParent);
            ViewBag.LeaseYears_ID = new SelectList(db.PropertyTitle_LeaseYears, "LeaseYears_ID", "LeaseYears", propertyTitle.LeaseYears_ID);
            ViewBag.PlotSize_ID = new SelectList(db.PropertyTitle_PlotSize, "PlotSize_ID", "PlotSize_Desc", propertyTitle.PlotSize_ID);
            ViewBag.TypeCode = new SelectList(db.PropertyTypes, "TypeCode", "TypeDesc", propertyTitle.TypeCode);
            return View(propertyTitle);
        }

        // POST: RejectedPropertyTilesLeaseHold/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_Code,Volume,Folio,Project_id,Title_Reference,TypeCode,LandTypeCode,Unit_No,Plan_No,Block_No,Flat_N0,Region_num,DistrictID,County_ID,Subcounty_ID,Parish_ID,Town_Village,Location_id,Street,Plot_No,Lease_Start_Date,Lease_End_Date,Ground_Rent,Rates,OfferNo,Purchaser_Name,Nationality,Purchasers_Address,Purchasers_TelNo,Purchasers_Email,PurchaserEmployer,Offer_Value,OfferDate,OfferExpiryDate,OfferPaymentDate,OfferPaidUP,TitleTransferred,TransferDate,PurchaserRemark,NewDataAudit,EditDataAudit,PropertyStaatus,AreaOfUnit,FloorAreaLeased,UnitFactor,Date,RegDate,InstrumentNo,ProprietorName,ProprietorAddress,FathersName,Clan,Registrar,BoardMinuteRelease,Directors,Added_By,Added_Date,Edited_By,Edited_Date,PlotSize_ID,ValueOfProperty,LeaseYears_ID,ActualPlotSize,SourceOfLease,GroundRentNarrative,GroundRentDueDate,GeneralRemarks,Valuer,DateOfValuation,PropertySoldorTransferred,Project_CodeParent,VolumeParent,FolioParent,TitleMovementStatusID,TitleSentBackToEntrant,FinalSubmission")] PropertyTitle propertyTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.County_ID = new SelectList(db.Counties, "County_ID", "County_Name", propertyTitle.County_ID);
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "District_Name", propertyTitle.DistrictID);
            ViewBag.LandTypeCode = new SelectList(db.Lease_Type, "LandTypeCode", "LandDesc", propertyTitle.LandTypeCode);
            ViewBag.Location_id = new SelectList(db.Locations, "Location_id", "Location_Desc", propertyTitle.Location_id);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", propertyTitle.Project_Code);
            ViewBag.Project_CodeParent = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference", propertyTitle.Project_CodeParent);
            ViewBag.LeaseYears_ID = new SelectList(db.PropertyTitle_LeaseYears, "LeaseYears_ID", "LeaseYears", propertyTitle.LeaseYears_ID);
            ViewBag.PlotSize_ID = new SelectList(db.PropertyTitle_PlotSize, "PlotSize_ID", "PlotSize_Desc", propertyTitle.PlotSize_ID);
            ViewBag.TypeCode = new SelectList(db.PropertyTypes, "TypeCode", "TypeDesc", propertyTitle.TypeCode);
            return View(propertyTitle);
        }

        // GET: RejectedPropertyTilesLeaseHold/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyTitle propertyTitle = db.PropertyTitles.Find(id);
            if (propertyTitle == null)
            {
                return HttpNotFound();
            }
            return View(propertyTitle);
        }

        // POST: RejectedPropertyTilesLeaseHold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyTitle propertyTitle = db.PropertyTitles.Find(id);
            db.PropertyTitles.Remove(propertyTitle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DataSourceRejectedLeaseHoldStatus(DataManager dm)
        {
            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 3))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 3))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 3) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 3) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

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

        public ActionResult SaveRejectedLeaseHoldProperty(int? Location_id, int? Project_Code, string Title_Reference, bool? Verified, int? Folio, string Volume
            , int? LandTypeCode, int? TypeCode, string Unit_No, string Flat_N0, string Block_No, string Plan_No,
            string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID, string LeaseOfferedBy,
            DateTime? Lease_Start_Date, DateTime? Lease_End_Date, int? LeaseYears_ID, string AreaOfUnit, string FloorAreaLeased,
            string UnitFactor, string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,
            bool? PropertySoldorTransferred,string ValueOfProperty, string Valuer, DateTime? DateOfValuation, string GeneralRemarks,
            int _type, string UnlockComment,string RejectionComment, string Added_By, DateTime? Added_Date, decimal? Latitude, decimal? Longitude)

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
                    var rejleaseholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var rejleaseholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (rejleaseholdtitlecheck == null && rejleaseholdprimkeycheck == null)
                    {

                        PropertyTitle saverejleasehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle saverejleaseholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle saverejleasehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            saverejleasehold.Added_By = user.getCurrentuser();
                            saverejleasehold.Added_Date = DateTime.Now;

                            saverejleasehold.TitleMovementStatusID = 1;
                            saverejleasehold.FinalSubmission = false;
                            saverejleasehold.UnlockTitle = false;

                            saverejleasehold.Location_id = Convert.ToInt32(Location_id);
                            saverejleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            saverejleasehold.Title_Reference = Title_Reference;
                            saverejleasehold.Verified = Verified;
                            saverejleasehold.LandTypeCode = LandTypeCode;
                            saverejleasehold.Volume = Volume;
                            saverejleasehold.Folio = Convert.ToInt32(Folio);
                            saverejleasehold.TypeCode = TypeCode;
                            saverejleasehold.Unit_No = Unit_No;
                            saverejleasehold.Flat_N0 = Flat_N0;
                            saverejleasehold.Block_No = Block_No;
                            saverejleasehold.Plan_No = Plan_No;
                            saverejleasehold.Plot_No = Plot_No;
                            saverejleasehold.DistrictID = DistrictID;
                            saverejleasehold.County_ID = County_ID;
                            saverejleasehold.Subcounty_ID = Subcounty_ID;
                            saverejleasehold.Location_id = Convert.ToInt32(Location_id);
                            saverejleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            saverejleasehold.Lease_Start_Date = Lease_Start_Date;
                            saverejleasehold.Lease_End_Date = Lease_End_Date;
                            saverejleasehold.LeaseYears_ID = LeaseYears_ID;
                            saverejleasehold.AreaOfUnit = AreaOfUnit;
                            saverejleasehold.FloorAreaLeased = FloorAreaLeased;
                            saverejleasehold.UnitFactor = UnitFactor;
                            saverejleasehold.ActualPlotSize = ActualPlotSize;
                            saverejleasehold.PlotSize_ID = PlotSize_ID;
                            saverejleasehold.ProprietorAddress = ProprietorAddress;
                            saverejleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            saverejleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            saverejleasehold.ValueOfProperty = ValueOfProperty;
                            saverejleasehold.Valuer = Valuer;
                            saverejleasehold.DateOfValuation = DateOfValuation;
                            saverejleasehold.GeneralRemarks = GeneralRemarks;
                            saverejleasehold.UnlockComment = UnlockComment;
                            saverejleasehold.RejectionComment = RejectionComment;
                            saverejleasehold.Latitude = Convert.ToDouble(Latitude);
                            saverejleasehold.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Tables

                            saverejleaseholdlog.original_Added_By = user.getCurrentuser();
                            saverejleaseholdlog.original_Added_Date = DateTime.Now;

                            saverejleaseholdlog.original_TitleMovementStatusID = 1;
                            saverejleaseholdlog.original_FinalSubmission = false;
                            saverejleaseholdlog.original_UnlockTitle = false;

                            saverejleaseholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            saverejleaseholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            saverejleaseholdlog.original_Title_Reference = Title_Reference;
                            saverejleaseholdlog.original_Verified = Verified;
                            saverejleaseholdlog.original_LandTypeCode = LandTypeCode;
                            saverejleaseholdlog.original_Volume = Volume;
                            saverejleaseholdlog.original_Folio = Convert.ToInt32(Folio);
                            saverejleaseholdlog.original_TypeCode = TypeCode;
                            saverejleaseholdlog.original_Unit_No = Unit_No;
                            saverejleaseholdlog.original_Flat_N0 = Flat_N0;
                            saverejleaseholdlog.original_Block_No = Block_No;
                            saverejleaseholdlog.original_Plan_No = Plan_No;
                            saverejleaseholdlog.original_Plot_No = Plot_No;
                            saverejleaseholdlog.original_DistrictID = DistrictID;
                            saverejleaseholdlog.original_County_ID = County_ID;
                            saverejleaseholdlog.original_Subcounty_ID = Subcounty_ID;
                            
                            saverejleaseholdlog.original_LeaseOfferedBy = LeaseOfferedBy;
                            saverejleaseholdlog.original_Lease_Start_Date = Lease_Start_Date;
                            saverejleaseholdlog.original_Lease_End_Date = Lease_End_Date;
                            saverejleaseholdlog.original_LeaseYears_ID = LeaseYears_ID;
                            saverejleaseholdlog.original_AreaOfUnit = AreaOfUnit;
                            saverejleaseholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            saverejleaseholdlog.original_UnitFactor = UnitFactor;
                            saverejleaseholdlog.original_ActualPlotSize = ActualPlotSize;
                            saverejleaseholdlog.original_PlotSize_ID = PlotSize_ID;
                            saverejleaseholdlog.original_ProprietorAddress = ProprietorAddress;
                            saverejleaseholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            saverejleaseholdlog.original_valueOfProperty = ValueOfProperty;
                            saverejleaseholdlog.original_Valuer = Valuer;
                            saverejleaseholdlog.original_DateOfValuation = DateOfValuation;
                            saverejleaseholdlog.original_GeneralRemarks = GeneralRemarks;
                            saverejleaseholdlog.original_UnlockComment = UnlockComment;
                            saverejleaseholdlog.original_RejectionComment = RejectionComment;
                            saverejleaseholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            saverejleaseholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(saverejleasehold);
                            db.AuditLog_PropertyTitle.Add(saverejleaseholdlog);
                            db.SaveChanges();

                            result = "Record added successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (rejleaseholdtitlecheck == null && rejleaseholdprimkeycheck != null)
                       
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
                    var editrejleasehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    var editrejleaseholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editrejleasehold != null)
                    {
                        try
                        {

                            UserManagement user = new UserManagement();
                            editrejleasehold.Edited_By = user.getCurrentuser();
                            editrejleasehold.Edited_Date = DateTime.Now;

                            editrejleasehold.TitleMovementStatusID = 1;
                            editrejleasehold.FinalSubmission = false;
                            editrejleasehold.UnlockTitle = false;  

                            editrejleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            editrejleasehold.Title_Reference = Title_Reference;
                            editrejleasehold.Verified = Verified;
                            editrejleasehold.LandTypeCode = LandTypeCode;
                            editrejleasehold.TypeCode = TypeCode;
                            editrejleasehold.Unit_No = Unit_No;
                            editrejleasehold.Flat_N0 = Flat_N0;
                            editrejleasehold.Block_No = Block_No;
                            editrejleasehold.Plan_No = Plan_No;
                            editrejleasehold.Plot_No = Plot_No;
                            editrejleasehold.DistrictID = DistrictID;
                            editrejleasehold.County_ID = County_ID;
                            editrejleasehold.Subcounty_ID = Subcounty_ID;
                          
                            editrejleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            editrejleasehold.Lease_Start_Date = Lease_Start_Date;
                            editrejleasehold.Lease_End_Date = Lease_End_Date;
                            editrejleasehold.LeaseYears_ID = LeaseYears_ID;
                            editrejleasehold.AreaOfUnit = AreaOfUnit;
                            editrejleasehold.FloorAreaLeased = FloorAreaLeased;
                            editrejleasehold.UnitFactor = UnitFactor;
                            editrejleasehold.ActualPlotSize = ActualPlotSize;
                            editrejleasehold.PlotSize_ID = PlotSize_ID;
                            editrejleasehold.ProprietorAddress = ProprietorAddress;
                            editrejleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            editrejleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editrejleasehold.ValueOfProperty = ValueOfProperty;
                            editrejleasehold.Valuer = Valuer;
                            editrejleasehold.DateOfValuation = DateOfValuation;
                            editrejleasehold.GeneralRemarks = GeneralRemarks;
                            editrejleasehold.UnlockComment = UnlockComment;
                            editrejleasehold.RejectionComment = RejectionComment;
                            editrejleasehold.Latitude = Convert.ToDouble(Latitude);
                            editrejleasehold.Longitude = Convert.ToDouble(Longitude);

                            editrejleasehold.Added_By = Added_By;
                            editrejleasehold.Added_Date = Added_Date;

                            //Audit Table Save

                            editrejleaseholdlog.original_Edited_By = user.getCurrentuser();
                            editrejleaseholdlog.original_Edited_Date = DateTime.Now;

                            editrejleaseholdlog.new_TitleMovementStatusID = 1;
                            editrejleaseholdlog.new_FinalSubmission = false;
                            editrejleaseholdlog.new_UnlockTitle = false;

                            editrejleaseholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editrejleaseholdlog.new_Volume = Volume;
                            editrejleaseholdlog.new_Folio = Convert.ToInt32(Folio);

                            editrejleaseholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editrejleaseholdlog.new_Title_Reference = Title_Reference;
                            editrejleaseholdlog.new_Verified = Verified;
                            editrejleaseholdlog.new_LandTypeCode = LandTypeCode;
                            editrejleaseholdlog.new_TypeCode = TypeCode;
                            editrejleaseholdlog.new_Unit_No = Unit_No;
                            editrejleaseholdlog.new_Flat_N0 = Flat_N0;
                            editrejleaseholdlog.new_Block_No = Block_No;
                            editrejleaseholdlog.new_Plan_No = Plan_No;
                            editrejleaseholdlog.new_Plot_No = Plot_No;
                            editrejleaseholdlog.new_DistrictID = DistrictID;
                            editrejleaseholdlog.new_County_ID = County_ID;
                            editrejleaseholdlog.new_Subcounty_ID = Subcounty_ID;

                            editrejleaseholdlog.new_LeaseOfferedBy = LeaseOfferedBy;
                            editrejleaseholdlog.new_Lease_Start_Date = Lease_Start_Date;
                            editrejleaseholdlog.new_Lease_End_Date = Lease_End_Date;
                            editrejleaseholdlog.new_LeaseYears_ID = LeaseYears_ID;
                            editrejleaseholdlog.new_AreaOfUnit = AreaOfUnit;
                            editrejleaseholdlog.new_FloorAreaLeased = FloorAreaLeased;
                            editrejleaseholdlog.new_UnitFactor = UnitFactor;
                            editrejleaseholdlog.new_ActualPlotSize = ActualPlotSize;
                            editrejleaseholdlog.new_PlotSize_ID = PlotSize_ID;
                            editrejleaseholdlog.new_ProprietorAddress = ProprietorAddress;
                            editrejleaseholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editrejleaseholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editrejleaseholdlog.new_valueOfProperty = ValueOfProperty;
                            editrejleaseholdlog.new_Valuer = Valuer;
                            editrejleaseholdlog.new_DateOfValuation = DateOfValuation;
                            editrejleaseholdlog.new_GeneralRemarks = GeneralRemarks;
                            editrejleaseholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editrejleaseholdlog.New_Longitude = Convert.ToDouble(Longitude);
                            editrejleaseholdlog.original_UnlockComment = UnlockComment;
                            editrejleaseholdlog.original_RejectionComment = RejectionComment;                           
                            editrejleaseholdlog.new_Added_By = Added_By;
                            editrejleaseholdlog.new_Added_Date = Added_Date;

                            db.Entry(editrejleasehold).CurrentValues.SetValues(editrejleasehold);
                            db.Entry(editrejleasehold).State = EntityState.Modified;

                            db.Entry(editrejleaseholdlog).CurrentValues.SetValues(editrejleaseholdlog);
                            db.Entry(editrejleaseholdlog).State = EntityState.Modified;

                            
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

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
    public class RejectedPropertyTitles1Controller : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: RejectedPropertyTitles1
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
            var Property = db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusDesc).ToList();
            ViewBag.Property = Property;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            return View();
        }

        public ActionResult RejectedFreeHoldAdmin()
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
            var Property = db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusDesc).ToList();
            ViewBag.Property = Property;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            return View();
        }

        // GET: RejectedPropertyTitles1/Details/5
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

        // GET: RejectedPropertyTitles1/Create
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

        // POST: RejectedPropertyTitles1/Create
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

        // GET: RejectedPropertyTitles1/Edit/5
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

        // POST: RejectedPropertyTitles1/Edit/5
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

        // GET: RejectedPropertyTitles1/Delete/5
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

        // POST: RejectedPropertyTitles1/Delete/5
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


        public ActionResult DataSourceRejectedFreeHoldStatus(DataManager dm)
        {            
            var user = User.Identity.Name;
            if ((User.IsInRole("Administrators") || (User.IsInRole("Super Administrator"))))
            {
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 1))).OrderByDescending(a => a.Added_Date).ToList();
                int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 1))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
            else { 
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 1) && b.Added_By == user)).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 3) && (b.FinalSubmission == false) && (b.LandTypeCode == 1) && b.Added_By == user)).OrderByDescending(a => a.Added_Date).ToList().Count();

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

        public ActionResult GetProjectCode(int Location_id)
        {
            var result = db.Projects.AsNoTracking().Where(o => o.Location_id == Location_id).Select(a => new { a.Project_id, a.Project_Desc }).Distinct().OrderBy(a => a.Project_Desc).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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

        public ActionResult SaveRejectedFreeHoldProperty(int? Location_id, int? Project_Code, int? Folio, string Title_Reference, bool? Verified
           , string Volume, int? LandTypeCode, int? TypeCode, string Unit_No, string Block_No
           , string Flat_N0, string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID
           , string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,string ValueOfProperty,
           string Valuer, bool? PropertySoldorTransferred, string GeneralRemarks, DateTime? DateOfValuation,
           string Added_By, DateTime? Added_Date, string UnlockComment,string RejectionComment,
           string Plan_No, string AreaOfUnit, string UnitFactor, string FloorAreaLeased, decimal? Latitude, decimal? Longitude, int _type)

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
                    var rejectedfreeholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var rejectedfreeholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));


                    if (rejectedfreeholdtitlecheck == null && rejectedfreeholdprimkeycheck == null)
                    {
                        PropertyTitle rejectedfreehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        AuditLog_PropertyTitle rejectedfreeholdlog = new AuditLog_PropertyTitle() {original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle rejectedfreehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            rejectedfreehold.Added_By = user.getCurrentuser();
                            rejectedfreehold.Added_Date = DateTime.Now;

                            rejectedfreehold.TitleMovementStatusID = 1;
                            rejectedfreehold.FinalSubmission = false;
                            rejectedfreehold.UnlockTitle = false;

                            rejectedfreehold.Location_id = Convert.ToInt32(Location_id);
                            rejectedfreehold.Project_Code = Convert.ToInt32(Project_Code);

                            rejectedfreehold.Title_Reference = Title_Reference;
                            rejectedfreehold.Verified = Verified;
                            rejectedfreehold.Volume = Volume;
                            rejectedfreehold.Folio = Convert.ToInt32(Folio);
                            rejectedfreehold.LandTypeCode = LandTypeCode;
                            rejectedfreehold.TypeCode = TypeCode;
                            rejectedfreehold.Block_No = Block_No;
                            rejectedfreehold.Unit_No = Unit_No;
                            rejectedfreehold.Flat_N0 = Flat_N0;
                            rejectedfreehold.Plot_No = Plot_No;
                            rejectedfreehold.DistrictID = DistrictID;
                            rejectedfreehold.County_ID = County_ID;
                            rejectedfreehold.Subcounty_ID = Subcounty_ID;
                            rejectedfreehold.ActualPlotSize = ActualPlotSize;
                            rejectedfreehold.PlotSize_ID = PlotSize_ID;
                            rejectedfreehold.ProprietorAddress = ProprietorAddress;
                            rejectedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            rejectedfreehold.ValueOfProperty = ValueOfProperty;
                            rejectedfreehold.Valuer = Valuer;
                            rejectedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            rejectedfreehold.GeneralRemarks = GeneralRemarks;
                            rejectedfreehold.DateOfValuation = DateOfValuation;
                            rejectedfreehold.UnlockComment = UnlockComment;
                            rejectedfreehold.RejectionComment = RejectionComment;


                            rejectedfreehold.Plan_No = Plan_No;
                            rejectedfreehold.AreaOfUnit = AreaOfUnit;
                            rejectedfreehold.UnitFactor = UnitFactor;
                            rejectedfreehold.FloorAreaLeased = FloorAreaLeased;
                            rejectedfreehold.Latitude = Convert.ToDouble(Latitude);
                            rejectedfreehold.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Table Saving

                            rejectedfreeholdlog.original_Added_By = user.getCurrentuser();
                            rejectedfreeholdlog.original_Added_Date = DateTime.Now;

                            rejectedfreeholdlog.original_TitleMovementStatusID = 1;
                            rejectedfreeholdlog.original_FinalSubmission = false;
                            rejectedfreeholdlog.original_UnlockTitle = false;

                            rejectedfreeholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            rejectedfreeholdlog.original_Project_Code = Convert.ToInt32(Project_Code);

                            rejectedfreeholdlog.original_Title_Reference = Title_Reference;
                            rejectedfreeholdlog.original_Verified = Verified;
                            rejectedfreeholdlog.original_Volume = Volume;
                            rejectedfreeholdlog.original_Folio = Convert.ToInt32(Folio);
                            rejectedfreeholdlog.original_LandTypeCode = LandTypeCode;
                            rejectedfreeholdlog.original_TypeCode = TypeCode;
                            rejectedfreeholdlog.original_Block_No = Block_No;
                            rejectedfreeholdlog.original_Unit_No = Unit_No;
                            rejectedfreeholdlog.original_Flat_N0 = Flat_N0;
                            rejectedfreeholdlog.original_Plot_No = Plot_No;
                            rejectedfreeholdlog.original_DistrictID = DistrictID;
                            rejectedfreeholdlog.original_County_ID = County_ID;
                            rejectedfreeholdlog.original_Subcounty_ID = Subcounty_ID;
                            rejectedfreeholdlog.original_ActualPlotSize = ActualPlotSize;
                            rejectedfreeholdlog.original_PlotSize_ID = PlotSize_ID;
                            rejectedfreeholdlog.original_ProprietorAddress = ProprietorAddress;
                            rejectedfreeholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            rejectedfreeholdlog.original_valueOfProperty = ValueOfProperty;
                            rejectedfreeholdlog.original_Valuer = Valuer;
                            rejectedfreeholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            rejectedfreeholdlog.original_GeneralRemarks = GeneralRemarks;
                            rejectedfreeholdlog.original_DateOfValuation = DateOfValuation;
                            rejectedfreeholdlog.original_UnlockComment = UnlockComment;
                            rejectedfreeholdlog.original_RejectionComment = RejectionComment;

                            rejectedfreeholdlog.original_Plan_No = Plan_No;
                            rejectedfreeholdlog.original_AreaOfUnit = AreaOfUnit;
                            rejectedfreeholdlog.original_UnitFactor = UnitFactor;
                            rejectedfreeholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            rejectedfreeholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            rejectedfreeholdlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.PropertyTitles.Add(rejectedfreehold);
                            db.AuditLog_PropertyTitle.Add(rejectedfreeholdlog);
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (rejectedfreeholdtitlecheck == null && rejectedfreeholdprimkeycheck != null)
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
                    var editrejectedfreehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    var editrejectedfreeholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editrejectedfreehold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editrejectedfreehold.Edited_By = user.getCurrentuser();
                            editrejectedfreehold.Edited_Date = DateTime.Now;

                            editrejectedfreehold.TitleMovementStatusID = 1;
                            editrejectedfreehold.FinalSubmission = false;
                            editrejectedfreehold.UnlockTitle = false;

                            editrejectedfreehold.Verified = Verified;

                            editrejectedfreehold.Project_Code = Convert.ToInt32(Project_Code);
                            editrejectedfreehold.Title_Reference = Title_Reference;
                            
                            editrejectedfreehold.LandTypeCode = LandTypeCode;
                            editrejectedfreehold.TypeCode = TypeCode;
                            editrejectedfreehold.Block_No = Block_No;
                            editrejectedfreehold.Unit_No = Unit_No;
                            editrejectedfreehold.Flat_N0 = Flat_N0;
                            editrejectedfreehold.Plot_No = Plot_No;
                            editrejectedfreehold.DistrictID = DistrictID;
                            editrejectedfreehold.County_ID = County_ID;
                            editrejectedfreehold.Subcounty_ID = Subcounty_ID;
                            editrejectedfreehold.ActualPlotSize = ActualPlotSize;
                            editrejectedfreehold.PlotSize_ID = PlotSize_ID;
                            editrejectedfreehold.ProprietorAddress = ProprietorAddress;
                            editrejectedfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            editrejectedfreehold.ValueOfProperty = ValueOfProperty;
                            editrejectedfreehold.Valuer = Valuer;
                            editrejectedfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editrejectedfreehold.GeneralRemarks = GeneralRemarks;
                            editrejectedfreehold.DateOfValuation = DateOfValuation;

                            editrejectedfreehold.Plan_No = Plan_No;
                            editrejectedfreehold.AreaOfUnit = AreaOfUnit;
                            editrejectedfreehold.UnitFactor = UnitFactor;
                            editrejectedfreehold.FloorAreaLeased = FloorAreaLeased;

                            editrejectedfreehold.Added_By = Added_By;
                            editrejectedfreehold.Added_Date = Added_Date;
                            editrejectedfreehold.UnlockComment = UnlockComment;
                            editrejectedfreehold.RejectionComment = RejectionComment;
                            editrejectedfreehold.Latitude = Convert.ToDouble(Latitude);
                            editrejectedfreehold.Longitude = Convert.ToDouble(Longitude);

                            db.Entry(editrejectedfreehold).CurrentValues.SetValues(editrejectedfreehold);
                            db.Entry(editrejectedfreehold).State = EntityState.Modified;

                            db.Entry(editrejectedfreeholdlog).CurrentValues.SetValues(editrejectedfreeholdlog);
                            db.Entry(editrejectedfreeholdlog).State = EntityState.Modified;

                            //AuditTable Log Save 

                            editrejectedfreeholdlog.original_Edited_By = user.getCurrentuser();
                            editrejectedfreeholdlog.original_Edited_Date = DateTime.Now;

                            editrejectedfreeholdlog.new_TitleMovementStatusID = 1;
                            editrejectedfreeholdlog.new_FinalSubmission = false;
                            editrejectedfreeholdlog.new_UnlockTitle = false;

                            editrejectedfreeholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editrejectedfreeholdlog.new_Volume = Volume;
                            editrejectedfreeholdlog.new_Folio = Convert.ToInt32(Folio);

                            editrejectedfreeholdlog.new_Verified = Verified;

                            editrejectedfreeholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editrejectedfreeholdlog.new_Title_Reference = Title_Reference;

                            editrejectedfreeholdlog.new_LandTypeCode = LandTypeCode;
                            editrejectedfreeholdlog.new_TypeCode = TypeCode;
                            editrejectedfreeholdlog.new_Block_No = Block_No;
                            editrejectedfreeholdlog.new_Unit_No = Unit_No;
                            editrejectedfreeholdlog.new_Flat_N0 = Flat_N0;
                            editrejectedfreeholdlog.new_Plot_No = Plot_No;
                            editrejectedfreeholdlog.new_DistrictID = DistrictID;
                            editrejectedfreeholdlog.new_County_ID = County_ID;
                            editrejectedfreeholdlog.new_Subcounty_ID = Subcounty_ID;
                            editrejectedfreeholdlog.new_ActualPlotSize = ActualPlotSize;
                            editrejectedfreeholdlog.new_PlotSize_ID = PlotSize_ID;
                            editrejectedfreeholdlog.new_ProprietorAddress = ProprietorAddress;
                            editrejectedfreeholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editrejectedfreeholdlog.new_valueOfProperty = ValueOfProperty;
                            editrejectedfreeholdlog.new_Valuer = Valuer;
                            editrejectedfreeholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editrejectedfreeholdlog.new_GeneralRemarks = GeneralRemarks;
                            editrejectedfreeholdlog.new_DateOfValuation = DateOfValuation;

                            editrejectedfreeholdlog.new_Plan_No = Plan_No;
                            editrejectedfreeholdlog.new_AreaOfUnit = AreaOfUnit;
                            editrejectedfreeholdlog.new_UnitFactor = UnitFactor;
                            editrejectedfreeholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editrejectedfreeholdlog.new_Added_By = Added_By;
                            editrejectedfreeholdlog.new_Added_Date = Added_Date;
                            editrejectedfreeholdlog.New_Latitude = Convert.ToDouble(Latitude);
                            editrejectedfreeholdlog.New_Longitude = Convert.ToDouble(Longitude);

                            editrejectedfreeholdlog.original_UnlockComment = UnlockComment;
                            editrejectedfreeholdlog.original_RejectionComment = RejectionComment;

                            db.Entry(editrejectedfreehold).CurrentValues.SetValues(editrejectedfreehold);
                            db.Entry(editrejectedfreehold).State = EntityState.Modified;

                            db.Entry(editrejectedfreeholdlog).CurrentValues.SetValues(editrejectedfreeholdlog);
                            db.Entry(editrejectedfreeholdlog).State = EntityState.Modified;
                            db.SaveChanges();
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

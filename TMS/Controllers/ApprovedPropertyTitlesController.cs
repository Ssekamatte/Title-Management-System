using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class ApprovedPropertyTitlesController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: CEOApprovedTitles
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            //var propertyTitles = db.PropertyTitles.Include(p => p.County).Include(p => p.District).Include(p => p.Lease_Type).Include(p => p.Location).Include(p => p.Project).Include(p => p.PropertyTitle2).Include(p => p.PropertyTitle_LeaseYears).Include(p => p.PropertyTitle_PlotSize).Include(p => p.PropertyType);
            //return View(propertyTitles.ToList());

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
            var DataSource = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

           
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
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;


            return View();
            //return View(propertyTitles.ToList());
        }

        // GET: CEOApprovedTitles/Details/5
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

        // GET: CEOApprovedTitles/Create
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

        // POST: CEOApprovedTitles/Create
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

        // GET: CEOApprovedTitles/Edit/5
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

        // POST: CEOApprovedTitles/Edit/5
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

        // GET: CEOApprovedTitles/Delete/5
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

        // POST: CEOApprovedTitles/Delete/5
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


        public ActionResult DataSourceApprovedPropertyTitles(DataManager dm)
        {

            //Returns all the fields in the table based on the Title Movement Status ID

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 2) && (b.FinalSubmission == true))).ToList().Count();

           

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
}

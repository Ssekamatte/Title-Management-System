using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class PropertyTitlesController : Controller
    {
        UserManagement user = new UserManagement();
        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        public ActionResult PropertyTitle()
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
            var projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.AsNoTracking().OrderBy(a => a.TypeDesc).ToList();
            ViewBag.propertyTypes = PropertyTypes;

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


            return View();
            //return View(db.PropertyTitles.ToList());
        }


        public ActionResult FreeHoldProperty()
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
            var Property = db.PropertyStatus.AsNoTracking().OrderBy(a => a.StatusDesc).ToList();
            ViewBag.Property = Property;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
            //return View(db.PropertyTitles.ToList());
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


        public ActionResult GetProjectCode(int Location_id)
        {
            var result = db.Projects.Where(o => o.Location_id == Location_id).Select(a => new { a.Project_id, a.Project_Desc }).Distinct().OrderBy(a => a.Project_Desc).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubCounty(int County_ID)
        {
            //var result = db.View_A_SubcountyList.Where(o => o.County_Name == County_ID).Distinct().OrderBy(a => a.Subcounty_Name).ToList();
            //var result = db.View_A_SubcountyList.Where(o => o.County_Name == County_ID).Distinct().Select(a => new { a.County_ID, a.Subcounty_Name }).Distinct().OrderBy(a => a.Subcounty_Name).ToList();
            var result = db.View_A_SubcountyList.Where(o => o.County_ID == County_ID).Distinct().Select(a => new { a.Subcounty_ID, a.Subcounty_Name }).Distinct().OrderBy(a => a.Subcounty_Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);            
        }

    
        public ActionResult LeaseHoldProperty()
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
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
            //return View(db.PropertyTitles.ToList());
        }

        public ActionResult MailoProperty()
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
            
            return View();
            //return View(db.PropertyTitles.ToList());
        }
        public ActionResult ConfirmationDialog()
        {
            return View();
        }
        // GET: PropertyTitles
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;
            
            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a=>a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().OrderBy(a => a.District_Name).ToList();
            ViewBag.Districts = districts;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().OrderBy(a => a.County_Name).ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var subcounties = db.Subcounties.AsNoTracking().OrderBy(a => a.Subcounty_Name).ToList();
            ViewBag.Subcounties = subcounties;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.AsNoTracking().OrderBy(a => a.TypeDesc).ToList();
            ViewBag.propertyTypes = PropertyTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lawyers = db.TitleMovements_Lawyers.AsNoTracking().OrderBy(a => a.Lawyers_Desc).ToList();
            ViewBag.lawyers = Lawyers;

            //db.Configuration.ProxyCreationEnabled = false;
            //var employees = db.A_Employee.AsNoTracking().OrderBy(a => a.Employee_Name).ToList();
            //ViewBag.A_Employee = employees;

            db.Configuration.ProxyCreationEnabled = false;
            var Directors = db.A_Employee.AsNoTracking().ToList();
            ViewBag.Directors = Directors;

            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;


            return View();
            //return View(db.PropertyTitles.ToList());
        }
        /// <summary>
        /// Using the Ternary Operator to search for records
        /// This approach is recommended for few records in the Database
        /// </summary>
        /// <param name="ProjCode"></param>
        /// <param name="LeaseCode"></param>
        /// <param name="TypeCode"></param>
        /// <param name="LocationCode"></param>
        /// <param name="titRef"></param>
        /// <returns></returns>

        //lease hold
        public ActionResult DataSourceLeaseHold(DataManager dm)
        {
            db.Configuration.ProxyCreationEnabled = false;
             IEnumerable data = db.PropertyTitles.Where(a => a.LandTypeCode == 3).ToList();
            int count = 0;
            db.Configuration.ProxyCreationEnabled = false;
            
                db.Configuration.ProxyCreationEnabled = false;
                data = db.PropertyTitles.Where(a => a.LandTypeCode == 3).ToList();
                count = db.PropertyTitles.Where(a => a.LandTypeCode == 3).ToList().Count();
          
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
        //mailo
        public ActionResult DataSourceMailo(DataManager dm)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.Where(a => a.LandTypeCode == 2).ToList();
            int count = 0;
            db.Configuration.ProxyCreationEnabled = false;

            db.Configuration.ProxyCreationEnabled = false;
            data = db.PropertyTitles.Where(a => a.LandTypeCode == 2).ToList();
            count = db.PropertyTitles.Where(a => a.LandTypeCode == 2).ToList().Count();

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
        //free hold
        public ActionResult DataSourceFreeHold(DataManager dm)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.Where(a=>a.LandTypeCode==1).ToList();
            int count = 0;
            db.Configuration.ProxyCreationEnabled = false;

            db.Configuration.ProxyCreationEnabled = false;
            data = db.PropertyTitles.Where(a => a.LandTypeCode == 1).ToList();
            count = db.PropertyTitles.Where(a => a.LandTypeCode == 1).ToList().Count();

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

        public ActionResult DataSourceFreeHoldStatus(DataManager dm)
        {            
            var user = User.Identity.Name;
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 1)&& (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 1) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

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

        public ActionResult DataSourceMailoStatus(DataManager dm)
        {

            //db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ( (b.TitleMovementStatusID == 1) && (b.FinalSubmission == false || b.TitleSentBackToEntrant == true))).OrderByDescending(a => a.Added_Date).ToList();
            //int count = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false || b.TitleSentBackToEntrant == true))).ToList().Count();
            var user = User.Identity.Name;
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 2) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 2) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();

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
                       
        public ActionResult DataSourceLeaseHoldStatus(DataManager dm)
        {

            //db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ( (b.TitleMovementStatusID == 1) && (b.FinalSubmission == false || b.TitleSentBackToEntrant == true))).OrderByDescending(a => a.Added_Date).ToList();
            //int count = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false || b.TitleSentBackToEntrant == true))).ToList().Count();
            var user = User.Identity.Name;

            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 3) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.AsNoTracking().Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 3) && (b.Added_By == user ))).OrderByDescending(a => a.Added_Date).ToList().Count();
            
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


        public ActionResult DataSourceProperty_Titles(DataManager dm)
        {

            //Returns all the fields in the table based on the Title Movement Status ID

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false))).ToList().Count();
                     

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

        public IEnumerable<PropertyTitle> PropertyTitles(int ProjCode, int LeaseCode, int TypeCode, int LocationCode, string titRef)
        { 
            var results = db.PropertyTitles.Where(t => ((ProjCode != 0) ? t.Project_Code == ProjCode : true)
            && ((LeaseCode != 0) ? t.LandTypeCode == LeaseCode : true) && ((TypeCode != 0) ? t.TypeCode == TypeCode : true)
            && ((LocationCode != 0) ? t.Location_id == LocationCode : true) && ((titRef != string.Empty) ? t.Title_Reference.Contains(titRef) : true) 
            ).ToList();
            return (results);
        }
     

        public ActionResult DialogUpdate(PropertyTitle value)
        {
            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code &&
            o.Volume  == value.Volume &&
            o.Folio == value.Folio  );

             
            string strpropname = value.ProprietorName;
            string propname = "";
            //Remove the '\n' from the proprietorname field
            if (string.IsNullOrEmpty(strpropname))
            { }
            else
            {
                propname = Regex.Replace(strpropname, @"\t|\n|\r", "");
            } 
 
            var proprietorname=propname.Trim();
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

            String result = string.Empty;

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

                  //  result = "Successfully Created!";
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

        public ActionResult TitleMovts(Syncfusion.JavaScript.DataManager dataManager, int projcode, int Folio, string Volume)
        {
            IEnumerable DataSource = db.PropertyTitleMovts.Where(p => p.Project_Code == projcode && p.Folio == Folio && p.Volume == Volume).ToList();
            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();
            result.result = DataSource;
            result.count = db.PropertyTitleMovts.Where(p => p.Project_Code == projcode && p.Folio == Folio && p.Volume == Volume).ToList().Count();
            if (dataManager.Skip > 0)
                result.result = operation.PerformSkip(result.result, dataManager.Skip);
            if (dataManager.Take > 0)
                result.result = operation.PerformTake(result.result, dataManager.Take);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BoardMembers(Syncfusion.JavaScript.DataManager dataManager, int? projcode, int? Folio, string Directors)
        {
            IEnumerable DataSource = db.PropertyTitles.Where(p => p.Project_Code == projcode && p.Folio == Folio && p.Directors == Directors).ToList();
            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();
            result.result = DataSource;
            result.count = db.PropertyTitles.Where(p => p.Project_Code == projcode && p.Folio == Folio && p.Directors == Directors).ToList().Count();
            if (dataManager.Skip > 0)
                result.result = operation.PerformSkip(result.result, dataManager.Skip);
            if (dataManager.Take > 0)
                result.result = operation.PerformTake(result.result, dataManager.Take);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        #region "Dialog Updates for the Board Members"

        public ActionResult DialogUpdateBoardMembers(PropertyTitle value, int Project_Code, int Folio, string Directors)
        {
            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o =>
            o.Project_Code == Project_Code &&
            o.Project_id == value.Project_id &&
            o.Folio == Folio &&
            o.Directors == Directors);

            if (table != null)
            {
                value.Project_Code = Project_Code;
                value.Folio = Folio;
                value.Directors = Directors;
                //value.Edited_Date = DateTime.Now;
                //value.Edited_By = "Wakayima!!!";
                db.Entry(table).CurrentValues.SetValues(value);
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogInsertBoardMembers(PropertyTitle value, int Project_Code, int Folio, string Directors)
        {
            // var folio = Request["Folio2"].ToString();
            value.Project_Code = Project_Code;
            value.Folio = Folio;
            value.Directors = Directors;
            db.PropertyTitles.Add(value);
            db.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDeleteMovtBoardMembers(int Project_Code, int Movt_Serial_No, int Folio, string Directors)
        {

            PropertyTitle result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code &&
            o.Project_id == Movt_Serial_No && o.Folio == Folio && o.Directors == Directors).FirstOrDefault();
            db.PropertyTitles.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public class DataResult
        {
            public IEnumerable result { get; set; }
            public int count { get; set; }
        }
        public ActionResult DialogDelete(int Project_Code,  int Folio, string Volume)
        {

            PropertyTitle result = db.PropertyTitles .Where(o => o.Project_Code == Project_Code &&
             o.Folio == Folio && o.Volume == Volume).FirstOrDefault();
            db.PropertyTitles.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
               
        #region "Dialog Updates for the Title Movements"

        public ActionResult DialogUpdateMovt(PropertyTitleMovt value, int Project_Code, int Folio, string Volume)
        {
            PropertyTitleMovt table = db.PropertyTitleMovts.FirstOrDefault(o =>
            o.Project_Code == Project_Code &&
            o.Movt_Serial_No == value.Movt_Serial_No &&
            o.Folio == Folio &&
            o.Volume == Volume);

            if (table != null)
            {
                value.Project_Code = Project_Code;
                value.Folio = Folio;
                value.Volume = Volume;
                //value.Edited_Date = DateTime.Now;
                //value.Edited_By = "Wakayima!!!";
                db.Entry(table).CurrentValues.SetValues(value);
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogInsertMovt(PropertyTitleMovt value,int Project_Code, int Folio,  string Volume)
        {
            // var folio = Request["Folio2"].ToString();
            value.Project_Code = Project_Code;
            value.Folio = Folio;
            value.Volume = Volume;
            db.PropertyTitleMovts.Add(value);
            db.SaveChanges();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDeleteMovt(int Project_Code, string Movt_Serial_No, int Folio, string Volume)
        {

            PropertyTitleMovt result = db.PropertyTitleMovts.Where(o => o.Project_Code == Project_Code &&
            o.Movt_Serial_No == Movt_Serial_No && o.Folio == Folio && o.Volume == Volume).FirstOrDefault();
            db.PropertyTitleMovts.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult GridFeatures()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.PropertyTitles.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var districts = db.Districts.AsNoTracking().ToList();
            ViewBag.Districts = districts;

            db.Configuration.ProxyCreationEnabled = false;
            var counties = db.Counties.AsNoTracking().ToList();
            ViewBag.Counties = counties;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.AsNoTracking().ToList();
            ViewBag.propertyTypes = PropertyTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().ToList();
            ViewBag.Locations = locations;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var propertytitleplotsizes = db.PropertyTitle_PlotSize.AsNoTracking().OrderBy(a => a.PlotSize_Desc).ToList();
            ViewBag.PropertyTitle_PlotSizes = propertytitleplotsizes;

            db.Configuration.ProxyCreationEnabled = false;
            var leaseyrs = db.PropertyTitle_LeaseYears.AsNoTracking().ToList(); ;
            ViewBag.propertyTitle_LeaseYears = leaseyrs;

            db.Configuration.ProxyCreationEnabled = false;
            var employees = db.A_Employee.AsNoTracking().OrderBy(a => a.Employee_Name).ToList();
            ViewBag.A_Employee = employees;

            db.Configuration.ProxyCreationEnabled = false;
            var positions = db.A_Position.AsNoTracking().OrderBy(a => a.Position_Description).ToList();
            ViewBag.A_Position = positions;

            //var DetailData = db.PropertyTitleMovts.Where(pro => pro.Project_Code == 1 && pro.Folio == 1).Take(5).ToList();
            //ViewBag.dataSource2 = DetailData;


            return View();
            //return View(db.PropertyTitles.ToList());
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

        public JsonResult GetMailoData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLeaseholdData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Lease_Type.AsNoTracking().Where(a => a.LandTypeCode == 3).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #region "Load Meta data tables by an acgtion result"
        /*
         * /var datapropertyTypes = @Html.Raw(Json.Encode(ViewBag.propertyTypes));
    var datadistricts = @Html.Raw(Json.Encode(ViewBag.districts));
    var dataLease_Type = @Html.Raw(Json.Encode(ViewBag.Lease_Type));
    var datalocations = @Html.Raw(Json.Encode(ViewBag.locations));
    var dataprojects = @Html.Raw(Json.Encode(ViewBag.projects));

    var datacounties = @Html.Raw(Json.Encode(ViewBag.counties));
    var datasubcounties = @Html.Raw(Json.Encode(ViewBag.subcounties));
    var dataparishes = @Html.Raw(Json.Encode(ViewBag.parishes));

    var datapropertyTitle_LeaseYears = @Html.Raw(Json.Encode(ViewBag.propertyTitle_LeaseYears));
*/
        //public ActionResult Parishes()
        public ActionResult PropertyTypes()
        {
            var results = db.PropertyTypes ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Districts()
        {
            var results = db.Districts ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Lease_Type()
        {
            var results = db.Lease_Type.ToList() ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Locations()
        {
            var results = db.Locations ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Projects()
        {
            var results = db.Projects ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }

         public ActionResult Counties()
        {
            var results = db.Counties  ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Subcounties()
        {
            var results = db.Subcounties;
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Parishes()
        {
            var results = db.Parishes ;
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LeaseYears()
        {
            var results = db.PropertyTitle_LeaseYears;
            return Json(results, JsonRequestBehavior.AllowGet);
        }
        #endregion "Load Meta data tables by an acgtion result"



        public ActionResult PropertyTitlePlotSize()
        {
            var results = db.PropertyTitle_PlotSize.ToList();
            return Json(results, JsonRequestBehavior.AllowGet);
        }
                     
        // GET: PropertyTitles/Details/5
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

        // GET: PropertyTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_Code,Volume,Folio,No_Parent_Title,Title_Reference,TypeCode,LandTypeCode,Unit_No,Plan_No,Block_No,Flat_N0,Region_num,DistrictID,County_ID,Subcounty_ID,Parish_ID,Town_Village,Location_id,Street,Plot_No,Lease_Start_Date,Lease_End_Date,Ground_Rent,Rates,OfferNo,Purchaser_Name,Nationality,Purchasers_Address,Purchasers_TelNo,Purchasers_Email,PurchaserEmployer,Offer_Value,OfferDate,OfferExpiryDate,OfferPaymentDate,OfferPaidUP,TitleTransferred,TransferDate,PurchaserRemark,NewDataAudit,EditDataAudit,PropertyStatus,AreaOfUnit,FloorAreaLeased,UnitFactor,Directors_,Board_Minute_Release,GeneralRemarks,Date,RegDate,,Plot_Size,Value_of_Property,InstrumentNo,ProprietorName,ProprietorAddress,FathersName,Clan,Registrar,BoardMinuteRelease,Directors,Added_By,Added_Date,Edited_By,Edited_Date,PlotSize_ID,ValueOfProperty,Plot_Size_Units,LeaseYears_ID,ActualPlotSize,SourceOfLease,GroundRentNarrative,GroundRentDueDate,GeneralRemarks,Valuer,DateOfValuation,PropertySoldorTransferred")] PropertyTitle propertyTitle)
        {
            if (ModelState.IsValid)
            {
                db.PropertyTitles.Add(propertyTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyTitle);
        }

        // GET: PropertyTitles/Edit/5
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
            return View(propertyTitle);
        }

        // POST: PropertyTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_Code,Volume,Folio,Title_Reference,TypeCode,LandTypeCode,Unit_No,Plan_No,Block_No,Flat_N0,Region_num,DistrictID,County_ID,Subcounty_ID,Parish_ID,Town_Village,Location_id,Street,Plot_No,Lease_Start_Date,Lease_End_Date,Ground_Rent,Rates,OfferNo,Purchaser_Name,Nationality,Purchasers_Address,Purchasers_TelNo,Purchasers_Email,PurchaserEmployer,Offer_Value,OfferDate,OfferExpiryDate,OfferPaymentDate,OfferPaidUP,TitleTransferred,TransferDate,PurchaserRemark,NewDataAudit,EditDataAudit,PropertyStatus,AreaOfUnit,FloorAreaLeased,UnitFactor,Date,RegDate,InstrumentNo,ProprietorName,ProprietorAddress,FathersName,Clan,Registrar,BoardMinuteRelease,Directors,Added_By,Added_Date,Edited_By,Edited_Date,PlotSize_ID,ValueOfProperty,LeaseYears_ID,ActualPlotSize,SourceOfLease,GroundRentNarrative,GroundRentDueDate,GeneralRemarks,Valuer,DateOfValuation,PropertySoldorTransferred")] PropertyTitle propertyTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyTitle);
        }

        // GET: PropertyTitles/Delete/5
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

        // POST: PropertyTitles/Delete/5
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

       public ActionResult GetFreeHoldProperties()
        {
            var user = User.Identity.Name;
            db.Configuration.ProxyCreationEnabled = false;
            var freeholdproperties = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 1) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.LandTypeCode == 1) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList().Count();
            return Json(freeholdproperties, JsonRequestBehavior.AllowGet);

        }
        public ActionResult SaveFreeHoldProperty(int? Location_id, int? Project_Code, int? Folio, string Title_Reference, bool? Verified
            ,string Volume,int? LandTypeCode, int? TypeCode, string Unit_No, string Block_No
            , string Flat_N0, string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID
            , string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,string ValueOfProperty,
            string Valuer, bool? PropertySoldorTransferred, string GeneralRemarks, DateTime? DateOfValuation,
            string Plan_No, string AreaOfUnit, string UnitFactor, string FloorAreaLeased,decimal? Longitude, decimal? Latitude, int _type)
            
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
                    var freeholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var freeholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                   
                        if (freeholdtitlecheck == null && freeholdprimkeycheck == null)
                        {
                       
                        PropertyTitle freehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };

                        //For Audit log table
                        AuditLog_PropertyTitle freeholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {

                            //int new_id = ++db.PropertyTitles.AsNoTracking().OrderBy(a => a.ID).ToList().Last().ID;
                            ////value.Location_id = Convert.ToInt32(new_id);

                            PropertyTitlesModels obj = new PropertyTitlesModels();

                            UserManagement user = new UserManagement();
                            freehold.Added_By = user.getCurrentuser();
                            freehold.Added_Date = DateTime.Now;
                            freehold.TitleMovementStatusID = 1;
                            freehold.FinalSubmission = false;
                            freehold.UnlockTitle = false;


                            //freehold.ID = Convert.ToInt32(new_id);
                            freehold.Location_id = Convert.ToInt32(Location_id);
                            freehold.Project_Code = Convert.ToInt32(Project_Code);
                            freehold.Title_Reference = Title_Reference;
                            freehold.Verified = Verified;
                            freehold.Volume = Volume;
                            freehold.Folio = Convert.ToInt32(Folio);
                            freehold.LandTypeCode = LandTypeCode;
                            freehold.TypeCode = TypeCode;
                            freehold.Block_No = Block_No;
                            freehold.Unit_No = Unit_No;
                            freehold.Flat_N0 = Flat_N0;
                            freehold.Plot_No = Plot_No;
                            freehold.DistrictID = DistrictID;
                            freehold.County_ID = County_ID;
                            freehold.Subcounty_ID = Subcounty_ID;
                            freehold.ActualPlotSize = ActualPlotSize;
                            freehold.PlotSize_ID = PlotSize_ID;
                            freehold.ProprietorAddress = ProprietorAddress;
                            freehold.BoardMinuteRelease = BoardMinuteRelease;
                            freehold.ValueOfProperty = ValueOfProperty;
                            freehold.Valuer = Valuer;
                            freehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            freehold.GeneralRemarks = GeneralRemarks;
                            freehold.DateOfValuation = DateOfValuation;

                            freehold.Plan_No = Plan_No;
                            freehold.AreaOfUnit = AreaOfUnit;
                            freehold.UnitFactor = UnitFactor;
                            freehold.FloorAreaLeased = FloorAreaLeased;
                            freehold.Longitude = Convert.ToDouble(Longitude);
                            freehold.Latitude = Convert.ToDouble(Latitude);

                        //Audit Log Table Value Savings are Here

                            freeholdlog.original_Added_By = user.getCurrentuser();
                            freeholdlog.original_Added_Date = DateTime.Now;
                            freeholdlog.original_TitleMovementStatusID = 1;
                            freeholdlog.original_FinalSubmission = false;
                            freeholdlog.original_UnlockTitle = false;


                            freeholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            freeholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            freeholdlog.original_Title_Reference = Title_Reference;
                            freeholdlog.original_Verified = Verified;
                            freeholdlog.original_Volume = Volume;
                            freeholdlog.original_Folio = Convert.ToInt32(Folio);
                            freeholdlog.original_LandTypeCode = LandTypeCode;
                            freeholdlog.original_TypeCode = TypeCode;
                            freeholdlog.original_Block_No = Block_No;
                            freeholdlog.original_Unit_No = Unit_No;
                            freeholdlog.original_Flat_N0 = Flat_N0;
                            freeholdlog.original_Plot_No = Plot_No;
                            freeholdlog.original_DistrictID = DistrictID;
                            freeholdlog.original_County_ID = County_ID;
                            freeholdlog.original_Subcounty_ID = Subcounty_ID;
                            freeholdlog.original_ActualPlotSize = ActualPlotSize;
                            freeholdlog.original_PlotSize_ID = PlotSize_ID;
                            freeholdlog.original_ProprietorAddress = ProprietorAddress;
                            freeholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            freeholdlog.original_valueOfProperty = ValueOfProperty;
                            freeholdlog.original_Valuer = Valuer;
                            freeholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            freeholdlog.original_GeneralRemarks = GeneralRemarks;
                            freeholdlog.original_DateOfValuation = DateOfValuation;

                            freeholdlog.original_Plan_No = Plan_No;
                            freeholdlog.original_AreaOfUnit = AreaOfUnit;
                            freeholdlog.original_UnitFactor = UnitFactor;
                            freeholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            freeholdlog.Original_Longitude = Convert.ToDouble(Longitude);
                            freeholdlog.Original_Latitude = Convert.ToDouble(Latitude);
                            db.PropertyTitles.Add(freehold);
                            db.AuditLog_PropertyTitle.Add(freeholdlog);//Saves Into Audit Log Table
                            db.SaveChanges();

                            result = "A new freehold title has been successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();                            
                        }
                    }                   

                    else if (freeholdtitlecheck == null && freeholdprimkeycheck != null)
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
                    var editfreehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    //Audit_Log Table Check
                    var editfreeholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);


                    if (editfreehold != null)
                    {

                        try
                        {

                            UserManagement user = new UserManagement();
                            editfreehold.Edited_By = user.getCurrentuser();
                            editfreehold.Edited_Date = DateTime.Now;

                            editfreehold.TitleMovementStatusID = 1;
                            editfreehold.FinalSubmission = false;
                            editfreehold.UnlockTitle = false;

                            editfreehold.Verified = Verified;
                           
                            //editfreehold.Location_id = Convert.ToInt32(Location_id);
                            editfreehold.Project_Code = Convert.ToInt32(Project_Code);
                            editfreehold.Title_Reference = Title_Reference;
                            //editfreehold.Volume = Volume;
                            //editfreehold.Folio = Convert.ToInt32(Folio);
                            editfreehold.LandTypeCode = LandTypeCode;
                            editfreehold.TypeCode = TypeCode;
                            editfreehold.Block_No = Block_No;
                            editfreehold.Unit_No = Unit_No;
                            editfreehold.Flat_N0 = Flat_N0;
                            editfreehold.Plot_No = Plot_No;
                            editfreehold.DistrictID = DistrictID;
                            editfreehold.County_ID = County_ID;
                            editfreehold.Subcounty_ID = Subcounty_ID;
                            editfreehold.ActualPlotSize = ActualPlotSize;
                            editfreehold.PlotSize_ID = PlotSize_ID;
                            editfreehold.ProprietorAddress = ProprietorAddress;
                            editfreehold.BoardMinuteRelease = BoardMinuteRelease;
                            editfreehold.ValueOfProperty = ValueOfProperty;
                            editfreehold.Valuer = Valuer;
                            editfreehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editfreehold.GeneralRemarks = GeneralRemarks;
                            editfreehold.DateOfValuation = DateOfValuation;

                            editfreehold.Plan_No = Plan_No;
                            editfreehold.AreaOfUnit = AreaOfUnit;
                            editfreehold.UnitFactor = UnitFactor;
                            editfreehold.FloorAreaLeased = FloorAreaLeased;

                            editfreehold.Longitude = Convert.ToDouble(Longitude);
                            editfreehold.Latitude = Convert.ToDouble(Latitude);

                        //Audit_Log Table Saving

                            editfreeholdlog.original_Edited_By = user.getCurrentuser();
                            editfreeholdlog.original_Edited_Date = DateTime.Now;

                            editfreeholdlog.new_TitleMovementStatusID = 1;
                            editfreeholdlog.new_FinalSubmission = false;
                            editfreeholdlog.new_UnlockTitle = false;

                            editfreeholdlog.new_Verified = Verified;

                            //Primary Keys Edit
                            editfreeholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editfreeholdlog.new_Volume = Volume;
                            editfreeholdlog.new_Folio = Convert.ToInt32(Folio);
                            //Primary Keys Edit End

                            editfreeholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editfreeholdlog.new_Title_Reference = Title_Reference;
                            //editfreehold.Volume = Volume;
                            //editfreehold.Folio = Convert.ToInt32(Folio);
                            editfreeholdlog.new_LandTypeCode = LandTypeCode;
                            editfreeholdlog.new_TypeCode = TypeCode;
                            editfreeholdlog.new_Block_No = Block_No;
                            editfreeholdlog.new_Unit_No = Unit_No;
                            editfreeholdlog.new_Flat_N0 = Flat_N0;
                            editfreeholdlog.new_Plot_No = Plot_No;
                            editfreeholdlog.new_DistrictID = DistrictID;
                            editfreeholdlog.new_County_ID = County_ID;
                            editfreeholdlog.new_Subcounty_ID = Subcounty_ID;
                            editfreeholdlog.new_ActualPlotSize = ActualPlotSize;
                            editfreeholdlog.new_PlotSize_ID = PlotSize_ID;
                            editfreeholdlog.new_ProprietorAddress = ProprietorAddress;
                            editfreeholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editfreeholdlog.new_valueOfProperty = ValueOfProperty;
                            editfreeholdlog.new_Valuer = Valuer;
                            editfreeholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editfreeholdlog.new_GeneralRemarks = GeneralRemarks;
                            editfreeholdlog.new_DateOfValuation = DateOfValuation;

                            editfreeholdlog.new_Plan_No = Plan_No;
                            editfreeholdlog.new_AreaOfUnit = AreaOfUnit;
                            editfreeholdlog.new_UnitFactor = UnitFactor;
                            editfreeholdlog.new_FloorAreaLeased = FloorAreaLeased;

                            editfreeholdlog.New_Longitude = Convert.ToDouble(Longitude);
                            editfreeholdlog.New_Latitude = Convert.ToDouble(Latitude);

                            db.Entry(editfreehold).CurrentValues.SetValues(editfreehold);
                            db.Entry(editfreehold).State = EntityState.Modified;
                            db.Entry(editfreeholdlog).CurrentValues.SetValues(editfreeholdlog); //Saves into Audit Log Table
                            db.Entry(editfreeholdlog).State = EntityState.Modified;//Saves into Audit Log Table

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

        public ActionResult SaveLeaseHoldProperty(int? Location_id,int? Project_Code, string Title_Reference,bool? Verified, int? Folio, string Volume
            , int? LandTypeCode, int? TypeCode, string Unit_No, string Flat_N0, string Block_No, string Plan_No,
            string Plot_No, int? DistrictID, int? County_ID, int? Subcounty_ID, string LeaseOfferedBy,
            DateTime? Lease_Start_Date, DateTime? Lease_End_Date, int? LeaseYears_ID, string AreaOfUnit, string FloorAreaLeased,
            string UnitFactor, string ActualPlotSize, int? PlotSize_ID, string ProprietorAddress, string BoardMinuteRelease,
            bool? PropertySoldorTransferred,string ValueOfProperty, string Valuer, DateTime? DateOfValuation, string GeneralRemarks,
            decimal? Longitude, decimal? Latitude,int _type)           

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


                //else if (Lease_Start_Date > Lease_End_Date)

                //{
                //    result = "The lease end date can not be earlier than the lease start date!";

                //}

                //else
                //{
                    var leaseholdtitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var leaseholdprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    //if (freeholdtitlecheck == null)
                    if (leaseholdtitlecheck == null && leaseholdprimkeycheck == null)
                    {

                        PropertyTitle leasehold = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };
                        
                        //For Audit log table
                        AuditLog_PropertyTitle leaseholdlog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle leasehold = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            leasehold.Added_By = user.getCurrentuser();
                            leasehold.Added_Date = DateTime.Now;
                            leasehold.TitleMovementStatusID = 1;
                            leasehold.FinalSubmission = false;
                            leasehold.UnlockTitle = false;

                            leasehold.Location_id = Convert.ToInt32(Location_id);
                            leasehold.Project_Code = Convert.ToInt32(Project_Code);
                            leasehold.Title_Reference = Title_Reference;
                            leasehold.Verified = Verified;
                            leasehold.LandTypeCode = LandTypeCode;
                            leasehold.Volume = Volume;
                            leasehold.Folio = Convert.ToInt32(Folio);
                            leasehold.TypeCode = TypeCode;
                            leasehold.Unit_No = Unit_No;
                            leasehold.Flat_N0 = Flat_N0;
                            leasehold.Block_No = Block_No;
                            leasehold.Plan_No = Plan_No;
                            leasehold.AreaOfUnit = AreaOfUnit;
                            leasehold.UnitFactor = UnitFactor;
                            leasehold.FloorAreaLeased = FloorAreaLeased;
                            leasehold.Plot_No = Plot_No;
                            leasehold.DistrictID = DistrictID;
                            leasehold.County_ID = County_ID;
                            leasehold.Subcounty_ID = Subcounty_ID;
                            leasehold.LeaseOfferedBy = LeaseOfferedBy;
                            leasehold.Lease_Start_Date = Lease_Start_Date;
                            leasehold.Lease_End_Date = Lease_End_Date;
                            leasehold.LeaseYears_ID = LeaseYears_ID; 
                            leasehold.ActualPlotSize = ActualPlotSize;
                            leasehold.PlotSize_ID = PlotSize_ID;
                            leasehold.ProprietorAddress = ProprietorAddress;
                            leasehold.BoardMinuteRelease = BoardMinuteRelease;
                            leasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            leasehold.ValueOfProperty = ValueOfProperty;
                            leasehold.Valuer = Valuer;
                            leasehold.DateOfValuation = DateOfValuation;
                            leasehold.GeneralRemarks = GeneralRemarks;

                            leasehold.Longitude = Convert.ToDouble(Longitude);
                            leasehold.Latitude = Convert.ToDouble(Latitude);
                        //Audit Log Table Value Savings are Here

                        leaseholdlog.original_Added_By = user.getCurrentuser();
                            leaseholdlog.original_Added_Date = DateTime.Now;
                            leaseholdlog.original_TitleMovementStatusID = 1;
                            leaseholdlog.original_FinalSubmission = false;
                            leaseholdlog.original_UnlockTitle = false;

                            leaseholdlog.original_Locationid = Convert.ToInt32(Location_id);
                            leaseholdlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            leaseholdlog.original_Title_Reference = Title_Reference;
                            leaseholdlog.original_Verified = Verified;
                            leaseholdlog.original_LandTypeCode = LandTypeCode;
                            leaseholdlog.original_Volume = Volume;
                            leaseholdlog.original_Folio = Convert.ToInt32(Folio);
                            leaseholdlog.original_TypeCode = TypeCode;
                            leaseholdlog.original_Unit_No = Unit_No;
                            leaseholdlog.original_Flat_N0 = Flat_N0;
                            leaseholdlog.original_Block_No = Block_No;
                            leaseholdlog.original_Plan_No = Plan_No;
                            leaseholdlog.original_Plot_No = Plot_No;
                            leaseholdlog.original_DistrictID = DistrictID;
                            leaseholdlog.original_County_ID = County_ID;
                            leaseholdlog.original_Subcounty_ID = Subcounty_ID;
                            leaseholdlog.original_LeaseOfferedBy = LeaseOfferedBy;
                            leaseholdlog.original_Lease_Start_Date = Lease_Start_Date;
                            leaseholdlog.original_Lease_End_Date = Lease_End_Date;
                            leaseholdlog.original_LeaseYears_ID = LeaseYears_ID;
                            leaseholdlog.original_AreaOfUnit = AreaOfUnit;
                            leaseholdlog.original_FloorAreaLeased = FloorAreaLeased;
                            leaseholdlog.original_UnitFactor = UnitFactor;
                            leaseholdlog.original_ActualPlotSize = ActualPlotSize;
                            leaseholdlog.original_PlotSize_ID = PlotSize_ID;
                            leaseholdlog.original_ProprietorAddress = ProprietorAddress;
                            leaseholdlog.original_BoardMinuteRelease = BoardMinuteRelease;
                            leaseholdlog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            leaseholdlog.original_valueOfProperty = ValueOfProperty;
                            leaseholdlog.original_Valuer = Valuer;
                            leaseholdlog.original_DateOfValuation = DateOfValuation;
                            leaseholdlog.original_GeneralRemarks = GeneralRemarks;
                            leaseholdlog.Original_Longitude = Convert.ToDouble(Longitude);
                            leaseholdlog.Original_Latitude = Convert.ToDouble(Latitude);

                            db.PropertyTitles.Add(leasehold);
                            db.AuditLog_PropertyTitle.Add(leaseholdlog);//Saves Into Audit Log Table
                            db.SaveChanges();

                            result = "A new LeaseHold title has been successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }

                    }

                    else if (leaseholdtitlecheck == null && leaseholdprimkeycheck != null)
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

                //else if (Lease_Start_Date > Lease_End_Date)

                //{
                //    result = "The lease end date can not be earlier than the lease start date!";
                //}

                //else
                //{
                    var editleasehold = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == Volume && e.Folio == Folio);

                    //Audit_Log Table Check
                    var editleaseholdlog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editleasehold != null)
                    {
                        try
                        {
                            UserManagement user = new UserManagement();
                            editleasehold.Edited_By = user.getCurrentuser();
                            editleasehold.Edited_Date = DateTime.Now;
                            editleasehold.TitleMovementStatusID = 1;
                            editleasehold.FinalSubmission = false;
                            editleasehold.UnlockTitle = false;

                            //editleasehold.Location_id = Convert.ToInt32(Location_id);
                            editleasehold.Project_Code = Convert.ToInt32(Project_Code);
                            editleasehold.Title_Reference = Title_Reference;
                            editleasehold.Verified = Verified;
                            editleasehold.LandTypeCode = LandTypeCode;
                            editleasehold.TypeCode = TypeCode;
                            editleasehold.Unit_No = Unit_No;
                            editleasehold.Flat_N0 = Flat_N0;
                            editleasehold.Block_No = Block_No;
                            editleasehold.Plan_No = Plan_No;
                            editleasehold.Plot_No = Plot_No;
                            editleasehold.DistrictID = DistrictID;
                            editleasehold.County_ID = County_ID;
                            editleasehold.Subcounty_ID = Subcounty_ID;
                            editleasehold.LeaseOfferedBy = LeaseOfferedBy;
                            editleasehold.Lease_Start_Date = Lease_Start_Date;
                            editleasehold.Lease_End_Date = Lease_End_Date;
                            editleasehold.LeaseYears_ID = LeaseYears_ID;
                            editleasehold.AreaOfUnit = AreaOfUnit;
                            editleasehold.FloorAreaLeased = FloorAreaLeased;
                            editleasehold.UnitFactor = UnitFactor;
                            editleasehold.ActualPlotSize = ActualPlotSize;
                            editleasehold.PlotSize_ID = PlotSize_ID;
                            editleasehold.ProprietorAddress = ProprietorAddress;
                            editleasehold.BoardMinuteRelease = BoardMinuteRelease;
                            editleasehold.PropertySoldorTransferred = PropertySoldorTransferred;
                            editleasehold.ValueOfProperty = ValueOfProperty;
                            editleasehold.Valuer = Valuer;
                            editleasehold.DateOfValuation = DateOfValuation;
                            editleasehold.GeneralRemarks = GeneralRemarks;
                            editleasehold.Longitude = Convert.ToDouble(Longitude);
                            editleasehold.Latitude = Convert.ToDouble(Latitude);


                        //Audit_Log Table Saving                            

                            editleaseholdlog.original_Edited_By = user.getCurrentuser();
                            editleaseholdlog.original_Edited_Date = DateTime.Now;
                            editleaseholdlog.new_TitleMovementStatusID = 1;
                            editleaseholdlog.new_FinalSubmission = false;
                            editleaseholdlog.new_UnlockTitle = false;

                            //Primary Keys Edit
                            editleaseholdlog.new_Locationid = Convert.ToInt32(Location_id);
                            editleaseholdlog.new_Volume = Volume;
                            editleaseholdlog.new_Folio = Convert.ToInt32(Folio);
                            //Primary Keys Edit End

                            editleaseholdlog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editleaseholdlog.new_Title_Reference = Title_Reference;
                            editleaseholdlog.new_Verified = Verified;
                            editleaseholdlog.new_LandTypeCode = LandTypeCode;
                            editleaseholdlog.new_TypeCode = TypeCode;
                            editleaseholdlog.new_Unit_No = Unit_No;
                            editleaseholdlog.new_Flat_N0 = Flat_N0;
                            editleaseholdlog.new_Block_No = Block_No;
                            editleaseholdlog.new_Plan_No = Plan_No;
                            editleaseholdlog.new_Plot_No = Plot_No;
                            editleaseholdlog.new_DistrictID = DistrictID;
                            editleaseholdlog.new_County_ID = County_ID;
                            editleaseholdlog.new_Subcounty_ID = Subcounty_ID;
                            editleaseholdlog.new_LeaseOfferedBy = LeaseOfferedBy;
                            editleaseholdlog.new_Lease_Start_Date = Lease_Start_Date;
                            editleaseholdlog.new_Lease_End_Date = Lease_End_Date;
                            editleaseholdlog.new_LeaseYears_ID = LeaseYears_ID;
                            editleaseholdlog.new_AreaOfUnit = AreaOfUnit;
                            editleaseholdlog.new_FloorAreaLeased = FloorAreaLeased;
                            editleaseholdlog.new_UnitFactor = UnitFactor;
                            editleaseholdlog.new_ActualPlotSize = ActualPlotSize;
                            editleaseholdlog.new_PlotSize_ID = PlotSize_ID;
                            editleaseholdlog.new_ProprietorAddress = ProprietorAddress;
                            editleaseholdlog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editleaseholdlog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editleaseholdlog.new_valueOfProperty = ValueOfProperty;
                            editleaseholdlog.new_Valuer = Valuer;
                            editleaseholdlog.new_DateOfValuation = DateOfValuation;
                            editleaseholdlog.new_GeneralRemarks = GeneralRemarks;
                            editleaseholdlog.New_Longitude = Convert.ToDouble(Longitude);
                            editleaseholdlog.New_Latitude = Convert.ToDouble(Latitude);

                            db.Entry(editleasehold).CurrentValues.SetValues(editleasehold);
                            db.Entry(editleasehold).State = EntityState.Modified;
                            db.Entry(editleaseholdlog).CurrentValues.SetValues(editleaseholdlog); //Saves into Audit Log Table
                            db.Entry(editleaseholdlog).State = EntityState.Modified;//Saves into Audit Log Table

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

        public ActionResult CheckMailoVolume()
        {
            //string volume = "No Volume";

            string volume = string.Empty;

            //var data = db.Projects.OrderByDescending(o => o.Project_id).FirstOrDefault();

            var data = db.PropertyTitles.OrderByDescending(o => o.Volume).Where(b => ((b.LandTypeCode == 2))).ToList();
            if (data != null)
            {
                //count = data.Volume;
                 volume = "No Volume"; 
            }
            return Json(volume, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult CheckMailoFolioNo()
        //{
        //    int count = 50000;
        //    // var data = db.Projects.OrderByDescending(o => o.Project_id).FirstOrDefault();
        //    var data = db.PropertyTitles.OrderByDescending(o => o.Folio).Where(b => ((b.LandTypeCode == 2))).FirstOrDefault();
        //    if (data != null)
        //    {
        //        count = data.Folio;
        //    }
        //    return Json(count, JsonRequestBehavior.AllowGet);
        //}

        //Folio DayMonthYearTime

        public ActionResult CheckMailoFolioConcat()
        {
            string hr = System.DateTime.Now.Hour.ToString();
            string min = System.DateTime.Now.Minute.ToString();
            string sec = System.DateTime.Now.Second.ToString();
            string microsec = System.DateTime.Now.Millisecond.ToString();
            string submicrosec = microsec; 
            //string submicrosec = microsec.Substring(2, 1); //Returns the last digit for the microsec
            //string submicrosec = microsec.Substring(1, 1);
            string month = Convert.ToString(System.DateTime.Now.Month);
            string year = Convert.ToString(System.DateTime.Now.Year);
            string y = year.Substring(2, 2);//Returns the last two  digits of the year only

            if (microsec.Length > 3)
            {
                submicrosec = microsec.Substring(2, 2);
                 
            }
            else if (microsec.Length < 3 && microsec.Length>1) {
                submicrosec = microsec.Substring(1, 1);
                
            }
            else if (microsec.Length < 2)
            {
                submicrosec = microsec.Substring(0, 1);                
            }

            else if (microsec.Length > 2 && microsec.Length < 4)
            {
                submicrosec = microsec.Substring(2, 1);
            }
            string time = hr+ submicrosec;
            string monthh = month;
            string foliomailo = time+ sec;

            int foliomailosave = 0 /*Convert.ToInt32(foliomailo)*/;

            var data = db.PropertyTitles.OrderByDescending(o => o.Folio).Where(b => ((b.LandTypeCode == 2))).ToList();
            
            if (data != null)
            {
                foliomailosave = Convert.ToInt32(foliomailo);
            }
            return Json(foliomailosave, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveMailoHoldProperty(int? Location_id, string Title_Reference, bool? Verified,int? LandTypeCode, string Volume, int? Folio
            ,int? TypeCode, string Unit_No, string Block_No, string Flat_N0, string Plan_No,string Plot_No, int? DistrictID, int? County_ID, 
            int? Subcounty_ID, int? Project_Code, string AreaOfUnit, string UnitFactor,string ProprietorAddress, string BoardMinuteRelease,
            bool? PropertySoldorTransferred, string ActualPlotSize, int? PlotSize_ID,string ValueOfProperty, string Valuer,
            DateTime? DateOfValuation, string GeneralRemarks, string FloorAreaLeased,decimal? Latitude,decimal? Longitude,int _type)
          
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

                //else if (TypeCode ==2 && string.IsNullOrEmpty(Unit_No))

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
                    var mailotitlecheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var mailoprimkeycheck = db.PropertyTitles.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() /*&& e.LandTypeCode == LandTypeCode*/));

                    if (mailotitlecheck == null && mailoprimkeycheck == null)
                    {

                        PropertyTitle mailo = new PropertyTitle() { Location_id = Convert.ToInt32(Location_id), Folio = Convert.ToInt32(Folio), Volume = Volume, Title_Reference = Title_Reference };
                        
                        //For Audit log table
                        AuditLog_PropertyTitle mailolog = new AuditLog_PropertyTitle() { original_Locationid = Convert.ToInt32(Location_id), original_Folio = Convert.ToInt32(Folio), original_Volume = Volume, original_Title_Reference = Title_Reference };

                        try
                        {
                            //PropertyTitle mailo = new PropertyTitle();
                            UserManagement user = new UserManagement();
                            mailo.Added_By = user.getCurrentuser();
                            mailo.Added_Date = DateTime.Now;

                            mailo.TitleMovementStatusID = 1;
                            mailo.FinalSubmission = false;
                            mailo.UnlockTitle = false;

                            mailo.Project_Code = Convert.ToInt32(Project_Code);
                            mailo.Title_Reference = Title_Reference;
                            mailo.Verified = Verified;
                            mailo.LandTypeCode = LandTypeCode;
                            mailo.Volume = Volume;
                            mailo.Folio = Convert.ToInt32(Folio);
                            mailo.TypeCode = TypeCode;
                            mailo.Unit_No = Unit_No;
                            mailo.Block_No = Block_No;
                            mailo.Flat_N0 = Flat_N0;
                            mailo.Plan_No = Plan_No;
                            mailo.Plot_No = Plot_No;
                            mailo.DistrictID = DistrictID;
                            mailo.County_ID = County_ID;
                            mailo.Subcounty_ID = Subcounty_ID;
                            mailo.Location_id = Convert.ToInt32(Location_id);
                            mailo.AreaOfUnit = AreaOfUnit;
                            mailo.UnitFactor = UnitFactor;
                            mailo.ProprietorAddress = ProprietorAddress;
                            mailo.BoardMinuteRelease = BoardMinuteRelease;
                            mailo.PropertySoldorTransferred = PropertySoldorTransferred;
                            mailo.ActualPlotSize = ActualPlotSize;
                            mailo.PlotSize_ID = PlotSize_ID;
                            mailo.ValueOfProperty = ValueOfProperty;
                            mailo.Valuer = Valuer;
                            mailo.DateOfValuation = DateOfValuation;
                            mailo.GeneralRemarks = GeneralRemarks;

                            mailo.FloorAreaLeased = FloorAreaLeased;
                            mailo.Longitude = Convert.ToDouble(Longitude);
                            mailo.Latitude = Convert.ToDouble(Latitude);

                        //Audit Log Table Value Savings are Here                            

                            mailolog.original_Added_By = user.getCurrentuser();
                            mailolog.original_Added_Date = DateTime.Now;
                            mailolog.original_TitleMovementStatusID = 1;
                            mailolog.original_FinalSubmission = false;
                            mailolog.original_UnlockTitle = false;

                            mailolog.original_Project_Code = Convert.ToInt32(Project_Code);
                            mailolog.original_Title_Reference = Title_Reference;
                            mailolog.original_Verified = Verified;
                            mailolog.original_LandTypeCode = LandTypeCode;
                            mailolog.original_Volume = Volume;
                            mailolog.original_Folio = Convert.ToInt32(Folio);
                            mailolog.original_TypeCode = TypeCode;
                            mailolog.original_Unit_No = Unit_No;
                            mailolog.original_Block_No = Block_No;
                            mailolog.original_Flat_N0 = Flat_N0;
                            mailolog.original_Plan_No = Plan_No;
                            mailolog.original_Plot_No = Plot_No;
                            mailolog.original_DistrictID = DistrictID;
                            mailolog.original_County_ID = County_ID;
                            mailolog.original_Subcounty_ID = Subcounty_ID;
                            mailolog.original_Locationid = Convert.ToInt32(Location_id);
                            mailolog.original_AreaOfUnit = AreaOfUnit;
                            mailolog.original_UnitFactor = UnitFactor;
                            mailolog.original_ProprietorAddress = ProprietorAddress;
                            mailolog.original_BoardMinuteRelease = BoardMinuteRelease;
                            mailolog.original_PropertySoldorTransferred = PropertySoldorTransferred;
                            mailolog.original_ActualPlotSize = ActualPlotSize;
                            mailolog.original_PlotSize_ID = PlotSize_ID;
                            mailolog.original_valueOfProperty = ValueOfProperty;
                            mailolog.original_Valuer = Valuer;
                            mailolog.original_DateOfValuation = DateOfValuation;
                            mailolog.original_GeneralRemarks = GeneralRemarks;

                            mailolog.original_FloorAreaLeased = FloorAreaLeased;
                            mailolog.Original_Longitude = Convert.ToDouble(Longitude);
                            mailolog.Original_Latitude = Convert.ToDouble(Latitude);
                            
                            db.PropertyTitles.Add(mailo);
                            db.AuditLog_PropertyTitle.Add(mailolog);//Saves Into Audit Log Table
                            db.SaveChanges();

                            result = "A new Mailo title has been successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (mailotitlecheck == null && mailoprimkeycheck != null)
                        
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
                    var editmailo = db.PropertyTitles.FirstOrDefault(e => e.Location_id == Location_id && e.Volume == e.Volume && e.Folio == Folio);

                    //Audit_Log Table Check
                    var editmailolog = db.AuditLog_PropertyTitle.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_Volume == Volume && e.original_Folio == Folio);

                    if (editmailo != null)
                    {
                        try
                        {
                            UserManagement user = new UserManagement();
                            editmailo.Edited_By = user.getCurrentuser();
                            editmailo.Edited_Date = DateTime.Now;
                            editmailo.TitleMovementStatusID = 1;
                            editmailo.FinalSubmission = false;
                            editmailo.UnlockTitle = false;

                            //editmailo.Location_id = Convert.ToInt32(Location_id);
                            editmailo.Project_Code = Convert.ToInt32(Project_Code);
                            editmailo.Title_Reference = Title_Reference;
                            editmailo.Verified = Verified;
                            editmailo.LandTypeCode = LandTypeCode;
                            editmailo.TypeCode = TypeCode;
                            editmailo.Unit_No = Unit_No;
                            editmailo.Block_No = Block_No;
                            editmailo.Flat_N0 = Flat_N0;
                            editmailo.Plan_No = Plan_No;
                            editmailo.Plot_No = Plot_No;
                            editmailo.DistrictID = DistrictID;
                            editmailo.County_ID = County_ID;
                            editmailo.Subcounty_ID = Subcounty_ID;
                            
                            editmailo.AreaOfUnit = AreaOfUnit;
                            editmailo.UnitFactor = UnitFactor;
                            editmailo.ProprietorAddress = ProprietorAddress;
                            editmailo.BoardMinuteRelease = BoardMinuteRelease;
                            editmailo.PropertySoldorTransferred = PropertySoldorTransferred;
                            editmailo.ActualPlotSize = ActualPlotSize;
                            editmailo.PlotSize_ID = PlotSize_ID;
                            editmailo.ValueOfProperty = ValueOfProperty;
                            editmailo.Valuer = Valuer;
                            editmailo.DateOfValuation = DateOfValuation;
                            editmailo.GeneralRemarks = GeneralRemarks;

                            editmailo.FloorAreaLeased = FloorAreaLeased;
                            editmailo.Longitude = Convert.ToDouble(Longitude);
                            editmailo.Latitude = Convert.ToDouble(Latitude);

                        //Audit_Log Table Saving                            

                            editmailolog.original_Edited_By = user.getCurrentuser();
                            editmailolog.original_Edited_Date = DateTime.Now;
                            editmailolog.new_TitleMovementStatusID = 1;
                            editmailolog.new_FinalSubmission = false;
                            editmailolog.new_UnlockTitle = false;

                            //Primary Keys Edit
                            editmailolog.new_Locationid = Convert.ToInt32(Location_id);
                            editmailolog.new_Volume = Volume;
                            editmailolog.new_Folio = Convert.ToInt32(Folio);
                            //Primary Keys Edit End

                            editmailolog.new_Project_Code = Convert.ToInt32(Project_Code);
                            editmailolog.new_Title_Reference = Title_Reference;
                            editmailolog.new_Verified = Verified;
                            editmailolog.new_LandTypeCode = LandTypeCode;
                            editmailolog.new_TypeCode = TypeCode;
                            editmailolog.new_Unit_No = Unit_No;
                            editmailolog.new_Block_No = Block_No;
                            editmailolog.new_Flat_N0 = Flat_N0;
                            editmailolog.new_Plan_No = Plan_No;
                            editmailolog.new_Plot_No = Plot_No;
                            editmailolog.new_DistrictID = DistrictID;
                            editmailolog.new_County_ID = County_ID;
                            editmailolog.new_Subcounty_ID = Subcounty_ID;

                            editmailolog.new_AreaOfUnit = AreaOfUnit;
                            editmailolog.new_UnitFactor = UnitFactor;
                            editmailolog.new_ProprietorAddress = ProprietorAddress;
                            editmailolog.new_BoardMinuteRelease = BoardMinuteRelease;
                            editmailolog.new_PropertySoldorTransferred = PropertySoldorTransferred;
                            editmailolog.new_ActualPlotSize = ActualPlotSize;
                            editmailolog.new_PlotSize_ID = PlotSize_ID;
                            editmailolog.new_valueOfProperty = ValueOfProperty;
                            editmailolog.new_Valuer = Valuer;
                            editmailolog.new_DateOfValuation = DateOfValuation;
                            editmailolog.new_GeneralRemarks = GeneralRemarks;

                            editmailolog.new_FloorAreaLeased = FloorAreaLeased;
                            editmailolog.New_Longitude = Convert.ToDouble(Longitude);
                            editmailolog.New_Latitude = Convert.ToDouble(Latitude);

                            db.Entry(editmailo).CurrentValues.SetValues(editmailo);
                            db.Entry(editmailo).State = EntityState.Modified;
                            db.Entry(editmailolog).CurrentValues.SetValues(editmailolog); //Saves into Audit Log Table
                            db.Entry(editmailolog).State = EntityState.Modified;//Saves into Audit Log Table

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
                            result = Title_Reference.Trim() + " is updated successfully";


                            //db.Entry(editfreehold).State = EntityState.Modified;
                            //db.SaveChanges();
                            //result = Title_Reference + " was updated successfully";

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

        public ActionResult DeleteRecord(PropertyTitle value, int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            PropertyTitle table = db.PropertyTitles.FirstOrDefault(o => o.Project_Code == id);
            //PropertyTitle table = db.PropertyTitles.FirstOrDefault(o => o.Project_Code == Project_Code &&
            // o.Folio == Folio && o.Volume == Volume);

            if (table != null)
            {
                db.Entry(table).State = EntityState.Deleted;
                try
                {
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
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        #region TitleUpload
        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
        public ActionResult SaveScan(IEnumerable<HttpPostedFileBase> UploadInput, string Title_Reference, string Volume, int Folio)
        {
            A_DocumentUpload ordfilup = db.A_DocumentUpload.FirstOrDefault(o => (o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio));
            if (ordfilup == null)
            {
                try
                {
                    foreach (var file in UploadInput)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        file.SaveAs(destinationPath);
                        string filePath = destinationPath; // getting the file path of uploaded file
                        string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file
                        string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file
                        string type = String.Empty;
                        Stream fs = file.InputStream;
                        BinaryReader br = new BinaryReader(fs); //reads the binary files
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes
                        ((IObjectContextAdapter)this.db).ObjectContext.CommandTimeout = 3000;

                        A_DocumentUpload doc = new A_DocumentUpload()
                        {
                            DocumentCode = Guid.NewGuid().ToString(),
                            TitleReferenceNo = Title_Reference,
                            Volume = Volume,
                            Folio = Folio,
                            DocumentFile = bytes,
                            DocumentName = filename1,
                            FileType = ext,
                            UploadDate = DateTime.Now,
                            UploadedBy = user.getCurrentuser(),
                        };
                        db.A_DocumentUpload.Add(doc);
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (ordfilup != null)
            {                
                try
                {
                    foreach (var file in UploadInput)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        file.SaveAs(destinationPath);
                        string filePath = destinationPath; // getting the file path of uploaded file
                        string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file
                        string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file
                        string type = String.Empty;
                        Stream fs = file.InputStream;
                        BinaryReader br = new BinaryReader(fs); //reads the binary files
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes
                        ((IObjectContextAdapter)this.db).ObjectContext.CommandTimeout = 3000;

                        A_DocumentUpload doc = new A_DocumentUpload()
                        {
                            DocumentCode = Guid.NewGuid().ToString(),
                            TitleReferenceNo = Title_Reference,
                            Volume = Volume,
                            Folio = Folio,
                            DocumentFile = bytes,
                            DocumentName = filename1,
                            FileType = ext,
                            UploadDate = DateTime.Now,
                            UploadedBy = user.getCurrentuser(),
                        };
                        db.A_DocumentUpload.Add(doc);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Content("");
        }

        //Clears the old file and replaces with new one
        //public ActionResult SaveScan(IEnumerable<HttpPostedFileBase> UploadInput, string Title_Reference, string Volume, int Folio)
        //{
        //    A_DocumentUpload ordfilup = db.A_DocumentUpload.FirstOrDefault(o => (o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio));
        //    if (ordfilup == null)
        //    {
        //        try
        //        {
        //            foreach (var file in UploadInput)
        //            {
        //                var fileName = Path.GetFileName(file.FileName);
        //                var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
        //                file.SaveAs(destinationPath);
        //                string filePath = destinationPath; // getting the file path of uploaded file
        //                string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file
        //                string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file
        //                string type = String.Empty;
        //                Stream fs = file.InputStream;
        //                BinaryReader br = new BinaryReader(fs); //reads the binary files
        //                Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes
        //                ((IObjectContextAdapter)this.db).ObjectContext.CommandTimeout = 3000;

        //                A_DocumentUpload doc = new A_DocumentUpload()
        //                {
        //                    DocumentCode = Guid.NewGuid().ToString(),
        //                    TitleReferenceNo = Title_Reference,
        //                    Volume = Volume,
        //                    Folio = Folio,
        //                    DocumentFile = bytes,
        //                    DocumentName = filename1,
        //                    FileType = ext,
        //                    UploadDate = DateTime.Now,
        //                    UploadedBy = user.getCurrentuser(),
        //                };
        //                db.A_DocumentUpload.Add(doc);
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //    else if (ordfilup != null) 
        //    {
        //        var titleexits = db.A_DocumentUpload.FirstOrDefault(o => (o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio));
        //        try
        //        {
        //            foreach (var file in UploadInput)
        //            {
        //                var fileName = Path.GetFileName(file.FileName);
        //                var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
        //                file.SaveAs(destinationPath);
        //                string filePath = destinationPath; // getting the file path of uploaded file
        //                string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file
        //                string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file
        //                string type = String.Empty;
        //                Stream fs = file.InputStream;
        //                BinaryReader br = new BinaryReader(fs); //reads the binary files
        //                Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes
        //                ((IObjectContextAdapter)this.db).ObjectContext.CommandTimeout = 3000;

        //                titleexits.TitleReferenceNo = Title_Reference;
        //                titleexits.Volume = Volume;
        //                titleexits.Folio = Folio;
        //                titleexits.DocumentFile = bytes;
        //                titleexits.DocumentName = filename1;
        //                titleexits.FileType = ext;
        //                titleexits.DateEdited = DateTime.Now;
        //                titleexits.EditedBy = user.getCurrentuser();

        //                db.Entry(titleexits).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    return Content("");
        //}

        public ActionResult DataSourceScans(DataManager dm, string Title_Reference, string Volume, int? Folio)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //var _data = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).ToList();   
            var _data = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).OrderByDescending(e=>e.UploadDate).Take(1);
            IEnumerable data = _data;
            int count = _data.Count();
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
        
        public List<FileList> GetUploadedFileList(string TitleReference)
        {          
            List<FileList> objfilelist = new List<FileList>();
            NHCC_NHCC_TMSEntities objnhcc = new NHCC_NHCC_TMSEntities();
           
            var datacollection = objnhcc.A_DocumentUpload.ToList();

            // select data;
            foreach (var item in datacollection)
            {
                if (item.TitleReferenceNo == TitleReference)
                {
                    objfilelist.Add(new FileList { FileURL = item.FileURL, FileType = item.FileType, Detail = item.DocumentName, TitleReference = item.TitleReferenceNo });                   
                }
            }
            return objfilelist;
        }
       
        public ActionResult DownloadFile(string fileNamePath)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"/";           
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileNamePath);
            string fileName = fileNamePath;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
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
       
        public ActionResult EvidenceDeletFile(string DocumentCode)
        {
            var file = db.A_DocumentUpload.FirstOrDefault(o => o.DocumentCode == DocumentCode);
            if (file != null)
            {
                db.A_DocumentUpload.Remove(file);
                db.SaveChanges();
            }
            return Json(DocumentCode, JsonRequestBehavior.AllowGet);
        }

        #endregion TitleUpload

        public ActionResult PatientCodeString()
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                var tdate = DateTime.Now;
                string year = tdate.Year.ToString().Trim().Substring(2, 2);
                string month = tdate.Month.ToString();
                //var facility = new UserManagement().getCurrentuserFacility();                
                //var facilitysapCode = context.View_A_Facilities_AspNetUsers.Where(o => o.FacilityId == facility).Take(1).Select(f => f.SAP_Code).FirstOrDefault();
                //var facilitysapCode = db.PropertyTitles.Where(o => o.LandTypeCode == landtype).Take(1).Select(f => f.SAP_Code).FirstOrDefault();
                string searchCode = "MVT-" + month;
                string searchserialCode = "MVT-" + year;
                //int count = context.pclm_A_Patients.Where(o => o.PatientNumber.Contains(searchCode)).ToList().Count;
                int count = db.PropertyTitleMovts.Where(o => o.Movt_Serial_No.Contains(searchserialCode)).ToList().Count;

                int code = (count + 1);
                //string result = "PCLM-" + facility + "-" + code.ToString("D4") + "-" + month + "-" + year;
                //string result = searchCode + "-" + code.ToString("D4");
                string result = searchserialCode + "-" + code.ToString("D4");
                return Json(new { msg = String.Format("{0}", result) }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

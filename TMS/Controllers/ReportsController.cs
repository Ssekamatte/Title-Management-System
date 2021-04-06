using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS_Reports.Controllers
{
    public class ReportsController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        // GET: Reports

        public ActionResult AllTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            return View();
        }


        public ActionResult AllTitlesPartial(string Location_id, string Lease_Type)
        {
           
            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            var datasource = db.spReport_Split_New_AllPropertyTitlesGetAll(Location_id, Lease_Type).ToList();
            var datasourcesum = db.spReport_SplitSummary_New_AllPropertyTitlesGetAll(Location_id, Lease_Type).ToList();
            var datasourceproptype = db.spReport_SplitSummaryPropType_New_AllPropertyTitlesGetAll(Location_id, Lease_Type).ToList();

            var count = db.spReport_SplitSummary_New_AllPropertyTitlesGetAll(Location_id, Lease_Type).ToList().Count(); // Counts the number of returned items
            var countsum = db.spReport_SplitSummary_New_AllPropertyTitlesGetAll(Location_id, Lease_Type).ToList().Count(); // Counts the number of returned items
            var countproptype = db.spReport_SplitSummaryPropType_New_AllPropertyTitlesGetAll(Location_id, Lease_Type).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AllTitles.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AllTitles", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AllTitlesSummary", datasourcesum));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PropTypes", datasourceproptype));

            ViewBag.ReportViewer = reportViewer;

            return View();


            //Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            //reportViewer.ProcessingMode = ProcessingMode.Local;
            //reportViewer.SizeToReportContent = true;

            //reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AllTitles.rdlc";
            ////reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AllTitles", db.spReport_Split_New_AllPropertyTitlesGetAll(Project_Code, Lease_Type).ToList()));

            //reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AllTitles", db.spReport_Split_New_AllPropertyTitlesGetAll(Project_Code, Lease_Type).ToList()));
            //ViewBag.ReportViewer = reportViewer;

            //return View();
        }

        public ActionResult Condomonium_Properties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;

            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;


            return View();
        }

        public ActionResult _Condomonium_Properties(int? Folio_Range_1, int? Folio_Range_2, string Location_id, string Lease_Type, string Volume)
        {

            if (Folio_Range_1 == null)
            {
                Folio_Range_1 = null;
            }
            if (Folio_Range_2 == null)
            {
                Folio_Range_2 = null;
            }

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }
            if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            {
                Volume = null;
            }
           

            var datasource = db.spReport_Split_New_New_CondomoniumPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Lease_Type, Location_id).Where(b=>(b.TypeCode==2)).ToList();

            var count = db.spReport_Split_New_New_CondomoniumPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Lease_Type, Location_id).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\CondominiumReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("CondoRep", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();
        }

        public ActionResult UnlistedProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;

            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            return View();
        }

        public ActionResult UnlistedPropertiesPartial(int? Folio_Range_1, int? Folio_Range_2, string Location_id, string Lease_Type, string Volume)
        {

            if (Folio_Range_1 == null)
            {
                Folio_Range_1 = null;
            }
            if (Folio_Range_2 == null)
            {
                Folio_Range_2 = null;
            }

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }
            if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            {
                Volume = null;
            }
            
            var datasource = db.spReport_Split_New_New_UnlistedPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Lease_Type, Location_id).Where(b => (b.TypeCode == 3)).ToList();

            var count = db.spReport_Split_New_New_UnlistedPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Lease_Type, Location_id).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\UnlistedReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("UnlistedRep", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();
        }



        public ActionResult NoTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            return View();
        }


        public ActionResult NoTitlesPartial(string Location_id, string Lease_Type)
        {

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            var datasource = db.spReport_Split_New_New_NoTitlesGetAll(Location_id, Lease_Type)/*.Where(b=>(b.Title_Reference.Contains("No Title") ))*/.ToList();
            var datasourcesumlandtype = db.spReport_SplitLandTypes_New_New_NoTitlesGetAll(Location_id, Lease_Type).ToList();
            var datasourcesumproptype = db.spReport_SplitPropTypes_New_New_NoTitlesGetAll(Location_id, Lease_Type).ToList();

            var count = db.spReport_Split_New_New_NoTitlesGetAll(Location_id, Lease_Type).ToList().Count(); // Counts the number of returned items
            var countsumlandtype = db.spReport_SplitLandTypes_New_New_NoTitlesGetAll(Location_id, Lease_Type).ToList().Count(); // Counts the number of returned items
            var countsumproptype = db.spReport_SplitPropTypes_New_New_NoTitlesGetAll(Location_id, Lease_Type).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\NoTitlesReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("NoTitles", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTypes", datasourcesumlandtype));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropTypes", datasourcesumproptype));

            ViewBag.ReportViewer = reportViewer;

            return View();
                    
        }

        public ActionResult ReportSoldProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;

            //db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTypes = db.PropertyTypes.ToList();
            //ViewBag.PropertyTypess = PropertyTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            return View();
        }


        public ActionResult ReportSoldPropertiesPartial(string Title_Reference, string Location_id, string Lease_Type)
        {                    
            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Title_Reference.Contains("null") || string.IsNullOrEmpty(Title_Reference))
            {
                Title_Reference = null;

            }

            if (Title_Reference != null)
            {
                Title_Reference = Title_Reference.TrimEnd(); //Trims white space at the end of the word

                Title_Reference = Title_Reference.TrimStart(); //Trims white space at the start of the word

            }


            //if (Title_Reference != null)
            //{
            //    Title_Reference = Title_Reference.Replace(" ", "");
            //}

            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            var datasource = db.spReport_Split_New_New_New_SoldPropertiesGetAll(Title_Reference, Lease_Type, Location_id)/*.Where(b => b.PropertySoldorTransferred==true)*/.ToList();
            var datasourcesumLandType = db.spReport_SplitLandTypes_New_New_New_SoldPropertiesGetAll(Title_Reference, Lease_Type, Location_id).ToList();
            var datasourcesumPropType = db.spReport_SplitPropTypes_New_New_New_SoldPropertiesGetAll(Title_Reference, Lease_Type, Location_id).ToList();

            var count = db.spReport_Split_New_New_New_SoldPropertiesGetAll(Title_Reference, Lease_Type, Location_id).Where(b => b.PropertySoldorTransferred == true).ToList().Count(); // Counts the number of returned items
            var countsumLandType = db.spReport_SplitLandTypes_New_New_New_SoldPropertiesGetAll(Title_Reference, Lease_Type, Location_id).ToList().Count(); // Counts the number of returned items
            var countsumPropType = db.spReport_SplitPropTypes_New_New_New_SoldPropertiesGetAll(Title_Reference, Lease_Type, Location_id).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\SoldPropertiesReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SoldReports", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandType", datasourcesumLandType));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropType", datasourcesumPropType));

            ViewBag.ReportViewer = reportViewer;

            return View();
        }


        public ActionResult NHCCProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            return View();
        }


        public ActionResult NHCCPropertiesPartial(string Title_Reference, string Location_id, string Lease_Type)
        {                             

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Title_Reference.Contains("null") || string.IsNullOrEmpty(Title_Reference))
            {
                Title_Reference = null;
            }

            if (Title_Reference != null)
            {
                Title_Reference = Title_Reference.Replace(" ", "");
            }

            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            var datasource = db.spReport_Split_New_New_NHCCPropertiesGetAll(Title_Reference, Lease_Type, Location_id).ToList();

            var count = db.spReport_Split_New_New_NHCCPropertiesGetAll(Title_Reference, Lease_Type, Location_id).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\NHCCReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("NHCCReport", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();
        }

        public ActionResult TitleMovement()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;
            
            return View();
        }                  

        public ActionResult TitleMovementPartial(string sdate, string edate, string Volume, string Location_id, 
            string Lease_Type, string DestinyCode, string Purpose_ID)
        {

            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }
                  
            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }
            if (DestinyCode.Contains("null") || string.IsNullOrEmpty(DestinyCode))
            {
                DestinyCode = null;
            }
            if (Purpose_ID.Contains("null") || string.IsNullOrEmpty(Purpose_ID))
            {
                Purpose_ID = null;
            }

            if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            {
                Volume = null;
            }            

            var datasource = db.spReport_Split_New_New_New_TitleMovements_Dates_GetAll(startDate, endDate, Volume,Location_id, DestinyCode, Purpose_ID, Lease_Type).ToList();

            var count = db.spReport_Split_New_New_New_TitleMovements_Dates_GetAll(startDate, endDate, Volume,Location_id, DestinyCode, Purpose_ID, Lease_Type).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\TitleMovementReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("TitleMovement", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();


        }

        public ActionResult PropertyPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;
            
            return View();
        }

        public ActionResult PrpertyPaymentPartial(int? Folio_Range_1, int? Folio_Range_2, string sdate, string edate, string Volume, string Location_id,
            string Lease_Type, string PayMethodCode, string Title_Reference)
        {

            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (Folio_Range_1 == null)
            {
                Folio_Range_1 = null;
            }
            if (Folio_Range_2 == null)
            {
                Folio_Range_2 = null;
            }

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }

            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            {
                Volume = null;
            }

            if (PayMethodCode.Contains("null") || string.IsNullOrEmpty(PayMethodCode))
            {
                PayMethodCode = null;
            }
            if (Title_Reference.Contains("null") || string.IsNullOrEmpty(Title_Reference))
            {
                Title_Reference = null;
              
            }

            if (Title_Reference !=null)
            {
                Title_Reference = Title_Reference.Replace(" ", "");
            }

            var datasource = db.spReport_Split_New_PropertyPayment_GetAll(Folio_Range_1, Folio_Range_2,startDate, endDate, Title_Reference, Volume, Location_id, PayMethodCode, Lease_Type).ToList();

            var count = db.spReport_Split_New_PropertyPayment_GetAll(Folio_Range_1, Folio_Range_2, startDate, endDate, Title_Reference, Volume, Location_id, PayMethodCode, Lease_Type).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\ReportPropertyPayment.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PropertyPayment", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        public ActionResult FreeHoldProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;


            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;


            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.ToList();
            ViewBag.PropertyTypess = PropertyTypes;

            return View();
        }

        public ActionResult FreeHoldPropertiesPartial(int? Folio_Range_1, int? Folio_Range_2, string Location_id, string TypeCode, string Volume)
        {

            if (Folio_Range_1 == null)
            {
                Folio_Range_1 = null;
            }
            if (Folio_Range_2 == null)
            {
                Folio_Range_2 = null;
            }

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (TypeCode.Contains("null") || string.IsNullOrEmpty(TypeCode))
            {
                TypeCode = null;
            }
            if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            {
                Volume = null;
            }

            var datasource = db.spReport_Split_New_New_FreeholdPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Location_id, TypeCode).Where(b => (b.LandTypeCode == 1)).ToList();
            var datasourcesum = db.spReport_SplitSummary_New_New_FreeholdPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Location_id, TypeCode)/*.Where(b => (b.LandTypeCode == 1))*/.ToList();
            
            var count = db.spReport_Split_New_New_FreeholdPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Location_id, TypeCode).ToList().Count(); // Counts the number of returned items
            var countsum = db.spReport_SplitSummary_New_New_FreeholdPropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Location_id, TypeCode).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\FreeHoldReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("FreeHold", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("FreeHoldSummary", datasourcesum));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        public ActionResult LeaseHoldProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;


            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.ToList();
            ViewBag.PropertyTypess = PropertyTypes;

            return View();
        }

        public ActionResult LeaseHoldPropertiesPartial(string sdate, string edate, string Location_id, string TypeCode)
        {

            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            
            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (TypeCode.Contains("null") || string.IsNullOrEmpty(TypeCode))
            {
                TypeCode = null;
            }
            
            
            var datasource = db.spReport_Split_New_LeaseHoldPropertyTitlesGetAll(startDate, endDate, Location_id, TypeCode).Where(b=>(b.LandTypeCode ==3)).ToList();
            var datasourcesum = db.spReport_Split_NewLandType_LeaseHoldPropertyTitlesGetAll(startDate, endDate, Location_id, TypeCode).ToList();

            var count = db.spReport_Split_New_LeaseHoldPropertyTitlesGetAll(startDate, endDate, Location_id, TypeCode).ToList().Count(); // Counts the number of returned items
            var countsum = db.spReport_Split_NewLandType_LeaseHoldPropertyTitlesGetAll(startDate, endDate, Location_id, TypeCode).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\LeaseHoldPropertyTitlesReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("LeaseHold", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLeaseHold", datasourcesum));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        public ActionResult StandAloneProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;

            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;


            return View();
        }

        public ActionResult StandAlonePropertiesPartial(int? Folio_Range_1, int? Folio_Range_2, string Location_id, string Lease_Type, string Volume)
        {

            if (Folio_Range_1 == null)
            {
                Folio_Range_1 = null;
            }
            if (Folio_Range_2 == null)
            {
                Folio_Range_2 = null;
            }

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            {
                Volume = null;
            }

            var datasource = db.spReport_Split_New_StandAlone_PropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Lease_Type, Location_id).Where(b=> (b.TypeCode ==1)).ToList();

            var count = db.spReport_Split_New_StandAlone_PropertiesGetAll(Folio_Range_1, Folio_Range_2, Volume, Lease_Type, Location_id).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\StandAloneReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("StandAlone", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }


        public ActionResult MailoLandProperties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;


            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.ToList();
            ViewBag.PropertyTypess = PropertyTypes;

            return View();
        }

        public ActionResult MailoLandPropertiesPartial(string Location_id, string TypeCode/*, string Volume*/)
        {

            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (TypeCode.Contains("null") || string.IsNullOrEmpty(TypeCode))
            {
                TypeCode = null;
            }

            //if (Volume.Contains("null") || string.IsNullOrEmpty(Volume))
            //{
            //    Volume = null;
            //}

            var datasource = db.spReport_Split_New_New_MailoLandPropertyTitlesGetAll(Location_id, TypeCode).Where(b => (b.LandTypeCode == 2)).ToList();
            var datasourcesum = db.spReport_Split_New_New_MailoLandSummaryPropertyTitlesGetAll(Location_id, TypeCode).ToList();

            var count = db.spReport_Split_New_New_MailoLandPropertyTitlesGetAll(Location_id, TypeCode).ToList().Count(); // Counts the number of returned items
            var countsum = db.spReport_Split_New_New_MailoLandSummaryPropertyTitlesGetAll(Location_id, TypeCode).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\MailoPropertiesReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("MailoProperty", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumMailo", datasourcesum));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        public ActionResult ManagementReport()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;


            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;


            db.Configuration.ProxyCreationEnabled = false;
            var detinations = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.Detinations = detinations;

            db.Configuration.ProxyCreationEnabled = false;
            var purposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.Purposes = purposes;
            
            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTypes = db.PropertyTypes.ToList();
            ViewBag.PropertyTypess = PropertyTypes;

            return View();
        }

       public ActionResult ManagementReportPartial(string Location_id, string TypeCode)
       // public ActionResult ManagementReportPartial(int? Project_Code, int? TypeCode)
        {

           if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
           // if (Project_Code==null)
            {
                Location_id = null;
            }

            if (TypeCode.Contains("null") || string.IsNullOrEmpty(TypeCode))
            // if (TypeCode==null)
            {
                TypeCode = null;
            }


            var datasource = db.spReport_Split_New_New_New_ManagementReportGetAll(Location_id, TypeCode).ToList();

            var count = db.spReport_Split_New_New_New_ManagementReportGetAll(Location_id, TypeCode).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\ManagementReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("ManagementReport", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }
              
        public ActionResult AuditlogLandTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitle.Select(a => new {a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }                   

        public ActionResult AuditlogLandTitlesPartial(string Edited_By,string LandTypeCode, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Edited_By.Contains("null") || string.IsNullOrEmpty(Edited_By))
            {
                Edited_By = null;
            }

            if (LandTypeCode.Contains("null") || string.IsNullOrEmpty(LandTypeCode))
            {
                LandTypeCode = null;
            }


            var datasource = db.spReport_NewAllTitles_AuditLog_PropertyTitleGetAll(Edited_By, LandTypeCode, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_Edited_By)))).ToList();
            var datasourcelandtitles = db.spReport_NewAllTitlesLandTitles_AuditLog_PropertyTitleGetAll(Edited_By, LandTypeCode, startDate, endDate).ToList();
            var datasourceproptype = db.spReport_NewAllTitlesPropTypes_AuditLog_PropertyTitleGetAll(Edited_By, LandTypeCode, startDate, endDate).ToList();

            var count = db.spReport_NewAllTitles_AuditLog_PropertyTitleGetAll(Edited_By, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countlandtitles = db.spReport_NewAllTitlesLandTitles_AuditLog_PropertyTitleGetAll(Edited_By, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countproptype = db.spReport_NewAllTitlesPropTypes_AuditLog_PropertyTitleGetAll(Edited_By, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditPropertyTitles.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitles", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTitles", datasourcelandtitles));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropTypes", datasourceproptype));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }


        //Audit Log All Added Land Titles

        public ActionResult AuditlogAddedLandTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            //db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            //ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AuditlogAddedLandTitlesPartial(string Added_By, string LandTypeCode, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }

            if (LandTypeCode.Contains("null") || string.IsNullOrEmpty(LandTypeCode))
            {
                LandTypeCode = null;
            }

            var datasource = db.spReport_NewAllAddedTitles_AuditLog_PropertyTitleGetAll(Added_By, LandTypeCode, startDate, endDate).ToList();
            var datasourcelandtitles = db.spReport_NewAllAddedTitlesSumLandTitles_AuditLog_PropertyTitleGetAll(Added_By, LandTypeCode, startDate, endDate).ToList();
            var datasourceproptypes = db.spReport_NewAllAddedTitlesSumPropTypes_AuditLog_PropertyTitleGetAll(Added_By, LandTypeCode, startDate, endDate).ToList();

            var count = db.spReport_NewAllAddedTitles_AuditLog_PropertyTitleGetAll(Added_By, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countlandtitles = db.spReport_NewAllAddedTitlesSumLandTitles_AuditLog_PropertyTitleGetAll(Added_By, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countproptypes = db.spReport_NewAllAddedTitlesSumPropTypes_AuditLog_PropertyTitleGetAll(Added_By, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditAddedPropertyTitles.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditAddedPropertyTitles", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTitles", datasourcelandtitles));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropTypes", datasourceproptypes));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Free Hold Titles
        public ActionResult AuditlogFreeHoldTitlesEdited()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;           
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }
        public ActionResult AuditlogFreeHoldTitlesPartialEdited(string Edited_By, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Edited_By.Contains("null") || string.IsNullOrEmpty(Edited_By))
            {
                Edited_By = null;
            }
          
            var datasource = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).Where(b => ((b.original_LandTypeCode == 1))).OrderByDescending(a => a.original_Added_Date).ToList();

            var count = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditFreeHoldTitlesAdded.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditFreeHoldTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Added Free Hold Titles
        public ActionResult AuditlogFreeHoldTitlesAdded()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }
        public ActionResult AuditlogFreeHoldTitlesPartialAdded(string Added_By, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }

            var datasource = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).Where(b => ((b.original_LandTypeCode == 1))).OrderByDescending(a => a.original_Added_Date).ToList();

            var count = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditFreeHoldTitlesAdded.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditFreeHoldTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Lease Hold Titles
        public ActionResult AuditlogLeaseHoldTitlesEdited()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AuditlogLeaseHoldTitlesPartialEdited(string Edited_By, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Edited_By.Contains("null") || string.IsNullOrEmpty(Edited_By))
            {
                Edited_By = null;
            }

           // var datasource = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).ToList();

            var datasource = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).Where(b => ((b.original_LandTypeCode == 3)) && !string.IsNullOrEmpty(b.original_Edited_By)).OrderByDescending(a => a.original_Added_Date).ToList();

            var count = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditLeaseHoldTitlesEdited.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditLeaseHoldTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Lease Hold Titles Added
        public ActionResult AuditlogLeaseHoldTitlesAdded()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AuditlogLeaseHoldTitlesPartialAdded(string Added_By, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }

            // var datasource = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).ToList();

            var datasource = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).Where(b => ((b.original_LandTypeCode == 3)) && !string.IsNullOrEmpty(b.original_Edited_By)).OrderByDescending(a => a.original_Added_Date).ToList();

            var count = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditLeaseHoldTitlesAdded.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditLeaseHoldTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Edited Mailo Titles
        public ActionResult AuditlogMailoTitlesEdited()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AuditlogMailoTitlesPartialEdited(string Added_By, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }

            var datasource = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).Where(b => ((b.original_LandTypeCode == 2))).OrderByDescending(a => a.original_Added_Date).ToList();

            var count = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditMailoTitlesAdded.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditMailoTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }


        //Audit Log Added Mailo Titles
        public ActionResult AuditlogMailoTitlesAdded()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AuditlogMailoTitlesPartialAdded(string Added_By, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }

            var datasource = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).Where(b => ((b.original_LandTypeCode == 2) && !string.IsNullOrEmpty(b.original_Added_By))).OrderByDescending(a => a.original_Added_Date).ToList();
           
            var count = db.spReport_New_Added_AuditLog_PropertyTitleGetAll(Added_By, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditMailoTitlesAdded.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditMailoTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Edited Property Payments 
        public ActionResult AAuditpayments()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyPayment.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AAuditpaymentsPartial(string Edited_By, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Edited_By.Contains("null") || string.IsNullOrEmpty(Edited_By))
            {
                Edited_By = null;
            }
           
            var datasource = db.spReport_NewAllEdited_AuditLog_PropertyPaymentGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).Where(b => ((!string.IsNullOrEmpty(b.original_Edited_By)))).ToList();
            var datasourcelandtitle = db.spReport_NewAllEditedLandType_AuditLog_PropertyPaymentGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList();
            var datasourceproptype = db.spReport_NewAllEditedPropType_AuditLog_PropertyPaymentGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList();

            var count = db.spReport_NewAllEdited_AuditLog_PropertyPaymentGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countlandtitle = db.spReport_NewAllEditedLandType_AuditLog_PropertyPaymentGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countproptype = db.spReport_NewAllEditedPropType_AuditLog_PropertyPaymentGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditPropertyPayment.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyPayment", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("LandTypes", datasourcelandtitle));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PropTypes", datasourceproptype));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }


        //Audit Log Added Property Payments 
        public ActionResult AAuditpaymentsAdded()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyPayment.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyPayment.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AAuditpaymentsPartialAdded(string Added_By, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }
           
            var datasource = db.spReport_NewAllAdded_AuditLog_PropertyPaymentGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).Where(b => ((!string.IsNullOrEmpty(b.original_Added_By)))).ToList();
            var datasourcelandtitle = db.spReport_NewAllAddedLandTitles_AuditLog_PropertyPaymentGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList();
            var datasourceproptype = db.spReport_NewAllAddedPropTypes_AuditLog_PropertyPaymentGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList();

            var count = db.spReport_NewAllAdded_AuditLog_PropertyPaymentGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countlandtitle = db.spReport_NewAllAddedLandTitles_AuditLog_PropertyPaymentGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countproptype = db.spReport_NewAllAddedPropTypes_AuditLog_PropertyPaymentGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditAddedPropertyPayment.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyPayment", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTitles", datasourcelandtitle));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropTypes", datasourceproptype));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Edited Property Title Movts
        public ActionResult AuditLogPropertyTitleMovements()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitleMovt.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AuditLogPropertyTitleMovementsPartial(string Edited_By, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Edited_By.Contains("null") || string.IsNullOrEmpty(Edited_By))
            {
                Edited_By = null;
            }
          
            var datasource = db.spReport_New_AuditLog_PropertyTitleMovtGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).Where(b => ((!string.IsNullOrEmpty(b.original_Edited_By)))).ToList();
            var datasourcelandtitle = db.spReport_New_AuditLogLandTitles_PropertyTitleMovtGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList();
            var datasourceproptitle = db.spReport_New_AuditLogPropTypes_PropertyTitleMovtGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList();

            var count = db.spReport_New_AuditLog_PropertyTitleMovtGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countlandtitle = db.spReport_New_AuditLogLandTitles_PropertyTitleMovtGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countproptitle = db.spReport_New_AuditLogPropTypes_PropertyTitleMovtGetAll(Edited_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditPropertyTitleMovements.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitleMovements", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("LandTitles", datasourcelandtitle));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PropTitles", datasourceproptitle));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Added Property Title Movts
        public ActionResult AuditLogPropertyTitleMovementsAdded()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitleMovt.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitleMovt.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AuditLogPropertyTitleMovementsPartialAdded(string Added_By, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (Added_By.Contains("null") || string.IsNullOrEmpty(Added_By))
            {
                Added_By = null;
            }
          
            var datasource = db.spReport_NewAdded_AuditLog_PropertyTitleMovtGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).Where(b => ((!string.IsNullOrEmpty(b.original_Added_By)))).ToList();
            var datasourcelandtitle = db.spReport_NewAddedLandTitles_AuditLog_PropertyTitleMovtGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList();
            var datasourceproptitle = db.spReport_NewAddedPropTypes_AuditLog_PropertyTitleMovtGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList();
            
            var count = db.spReport_NewAdded_AuditLog_PropertyTitleMovtGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countlandtitle = db.spReport_NewAddedLandTitles_AuditLog_PropertyTitleMovtGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countproptitle = db.spReport_NewAddedPropTypes_AuditLog_PropertyTitleMovtGetAll(Added_By, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditAddedPropertyTitleMovements.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitleMovements", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTitles", datasourcelandtitle));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropTypes", datasourceproptitle));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Unlocked General Titles
        public ActionResult UnlockedTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.AuditLog_PropertyTitle.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.auditactionss = auditactions;

            return View();

        }

        public ActionResult UnlockedTitlesPartial(string UnlockedBy, string LandTypeCode, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (UnlockedBy.Contains("null") || string.IsNullOrEmpty(UnlockedBy))
            {
                UnlockedBy = null;
            }

            if (LandTypeCode.Contains("null") || string.IsNullOrEmpty(LandTypeCode))
            {
                LandTypeCode = null;
            }
          
            var datasource = db.spReport_UnlockedAllTitles_AuditLog_PropertyTitleGetAll(UnlockedBy, LandTypeCode, startDate, endDate/*, AuditAction_Description*/).Where(b => ((!string.IsNullOrEmpty(b.original_UnlockedBy)&&(b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == true)))).ToList();
            var datasourcelandtitles = db.spReport_UnlockedAllTitlessummary_AuditLog_PropertyTitleGetAll(UnlockedBy, LandTypeCode, startDate, endDate/*, AuditAction_Description*/).ToList();
            var datasourceproptypes = db.spReport_UnlockedAllTitlesPropTypeSummary_AuditLog_PropertyTitleGetAll(UnlockedBy, LandTypeCode, startDate, endDate/*, AuditAction_Description*/).ToList();

            var count = db.spReport_UnlockedAllTitles_AuditLog_PropertyTitleGetAll(UnlockedBy, LandTypeCode, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countlandtitles = db.spReport_UnlockedAllTitlessummary_AuditLog_PropertyTitleGetAll(UnlockedBy, LandTypeCode, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countproptypes = db.spReport_UnlockedAllTitlesPropTypeSummary_AuditLog_PropertyTitleGetAll(UnlockedBy, LandTypeCode, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditUnlockedPropertyTitles.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitles", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumUnlLandTitles", datasourcelandtitles));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumUnlPropTitles", datasourceproptypes));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Unlocked Free Hold Titles
        public ActionResult AuditlogFreeHoldTitlesUnlocked()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.AuditLog_PropertyTitle.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }
        public ActionResult AuditlogFreeHoldTitlesPartialUnlocked(string UnlockedBy, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (UnlockedBy.Contains("null") || string.IsNullOrEmpty(UnlockedBy))
            {
                UnlockedBy = null;
            }

            // var datasource = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy, startDate, endDate).Where(b => ((b.original_LandTypeCode == 1))).OrderByDescending(a => a.original_Added_Date).ToList();

            var datasource = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy,startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_UnlockedBy) && (b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == true)&& (b.original_LandTypeCode == 1)))).ToList();

            var count = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditFreeHoldTitlesUnlocked.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditFreeHoldTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Lease Hold Titles Unlocked
        public ActionResult AuditlogLeaseHoldTitlesUnlocked()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.AuditLog_PropertyTitle.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AuditlogLeaseHoldTitlesPartialUnlocked(string UnlockedBy, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (UnlockedBy.Contains("null") || string.IsNullOrEmpty(UnlockedBy))
            {
                UnlockedBy = null;
            }

            // var datasource = db.spReport_New_Edited_AuditLog_PropertyTitleGetAll(Edited_By, startDate, endDate).ToList();

            var datasource = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_UnlockedBy) && (b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == true) && (b.original_LandTypeCode == 3)))).ToList();

            var count = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditLeaseHoldTitlesUnlocked.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditLeaseHoldTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();
          }
        
        //Audit Log Added Mailo Titles
        public ActionResult AuditlogMailoTitlesUnlocked()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.AuditLog_PropertyTitle.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();
        }

        public ActionResult AuditlogMailoTitlesPartialUnlocked(string UnlockedBy, string sdate, string edate)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (UnlockedBy.Contains("null") || string.IsNullOrEmpty(UnlockedBy))
            {
                UnlockedBy = null;
            }

            var datasource = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_UnlockedBy) && (b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == true) && (b.original_LandTypeCode == 2)))).ToList();

            var count = db.spReport_UnlockedFreeHold_AuditLog_PropertyTitleGetAll(UnlockedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditMailoTitlesUnlocked.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditMailoTitlesEdited", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Unlocked Property Payments 
        public ActionResult AAuditpaymentsUnlocked()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.AuditLog_PropertyPayment.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyPayment.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyPayment.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AAuditpaymentsPartialUnlocked(string UnlockedBy, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (UnlockedBy.Contains("null") || string.IsNullOrEmpty(UnlockedBy))
            {
                UnlockedBy = null;
            }          

            var datasource = db.spReport_UnlockedNewAll_AuditLog_PropertyPaymentGetAll(UnlockedBy, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_UnlockedBy) && (b.new_PropertyPaymentStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == true)))).ToList();
            var datasourcelandtitles = db.spReport_UnlockedLandTitlesNewAll_AuditLog_PropertyPaymentGetAll(UnlockedBy, startDate, endDate).ToList();
            var datasourceproptypes = db.spReport_UnlockedPropTitlesNewAll_AuditLog_PropertyPaymentGetAll(UnlockedBy, startDate, endDate).ToList();

            var count = db.spReport_UnlockedNewAll_AuditLog_PropertyPaymentGetAll(UnlockedBy, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countlandtitles = db.spReport_UnlockedLandTitlesNewAll_AuditLog_PropertyPaymentGetAll(UnlockedBy, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items
            var countproptypes = db.spReport_UnlockedPropTitlesNewAll_AuditLog_PropertyPaymentGetAll(UnlockedBy, startDate, endDate/*, AuditAction_Description*/).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditUnlockedPropertyPayment.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyPayment", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTitles", datasourcelandtitles));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropertyTypes", datasourceproptypes));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Unlocked Property Title Movts
        public ActionResult AuditLogPropertyTitleMovementsUnlocked()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.ViewAudPropTitleMvtAspNetUsersFullNames.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitleMovt.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitleMovt.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AuditLogPropertyTitleMovementsPartialUnlocked(string UnlockedBy, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (UnlockedBy.Contains("null") || string.IsNullOrEmpty(UnlockedBy))
            {
                UnlockedBy = null;
            }
          
            var datasource = db.spReport_UnlockedNewAdded_AuditLog_PropertyTitleMovtGetAll(UnlockedBy, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_UnlockedBy) && (b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == true)))).ToList();
            var datasourcelandtitles = db.spReport_UnlockedNewAddedlandtitles_AuditLog_PropertyTitleMovtGetAll(UnlockedBy, startDate, endDate).ToList();
            var datasourceproptypes = db.spReport_UnlockedNewAddedPropTypes_AuditLog_PropertyTitleMovtGetAll(UnlockedBy, startDate, endDate).ToList();

            var count = db.spReport_UnlockedNewAdded_AuditLog_PropertyTitleMovtGetAll(UnlockedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countlandtitles = db.spReport_UnlockedNewAddedlandtitles_AuditLog_PropertyTitleMovtGetAll(UnlockedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countproptypes = db.spReport_UnlockedNewAddedPropTypes_AuditLog_PropertyTitleMovtGetAll(UnlockedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditUnlockedPropertyTitleMovements.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitleMovements", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumLandTitles", datasourcelandtitles));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumPropTypes", datasourceproptypes));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }   

        //Approved Audit Log General Titles
        public ActionResult ApprovedTitles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var approvedby = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.approvedby = approvedby;

            db.Configuration.ProxyCreationEnabled = false;
            var unlockedby = db.AuditLog_PropertyTitle.Select(a => new { a.original_UnlockedBy }).Distinct().OrderBy(a => a.original_UnlockedBy).ToList();
            ViewBag.unlockedby = unlockedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitle.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitle.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.auditactionss = auditactions;

            return View();

        }

        public ActionResult ApprovedTitlesPartial(string ApprovedBy, string LandTypeCode, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (ApprovedBy.Contains("null") || string.IsNullOrEmpty(ApprovedBy))
            {
                ApprovedBy = null;
            }

            if (LandTypeCode.Contains("null") || string.IsNullOrEmpty(LandTypeCode))
            {
                LandTypeCode = null;
            }
           
            var datasource = db.spReport_ApprovedAllTitles_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_Edited_By) && (b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == false)))).ToList();
           var datasourcesum = db.spReport_ApprovedAllTitlesSummary_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).ToList();
            var datasourceproptitles = db.spReport_ApprovedAllTitlesPropTypeSummary_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).ToList();

            //var datasourcesum = db.spReport_ApprovedAllTitlesSummary_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).ToList();

            var count = db.spReport_ApprovedAllTitles_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countsum = db.spReport_ApprovedAllTitlesSummary_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countproptitlesum = db.spReport_ApprovedAllTitlesPropTypeSummary_AuditLog_PropertyTitleGetAll(ApprovedBy, LandTypeCode, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditApprovedPropertyTitles.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitles", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SumApprovedLandTitles", datasourcesum));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("TotalApprovedPropTypes", datasourceproptitles));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        //Audit Log Approved Property Payments 
        public ActionResult AAuditpaymentsApproved()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var approvedby = db.AuditLog_PropertyPayment.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.approvedby = approvedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyPayment.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            var editors = db.AuditLog_PropertyPayment.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AAuditpaymentsPartialApproved(string ApprovedBy, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (ApprovedBy.Contains("null") || string.IsNullOrEmpty(ApprovedBy))
            {
                ApprovedBy = null;
            }
           
            var datasource = db.spReport_NewAllApproved_AuditLog_PropertyPaymentGetAll(ApprovedBy, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_Edited_By) && (b.new_PropertyPaymentStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == false)))).ToList();
            var datasourcesum = db.spReport_NewAllApprovedSummary_AuditLog_PropertyPaymentGetAll(ApprovedBy, startDate, endDate).ToList();
            var datasourceproptypesum = db.spReport_NewAllApprovedSummaryPropType_AuditLog_PropertyPaymentGetAll(ApprovedBy, startDate, endDate).ToList();

            var count = db.spReport_NewAllApproved_AuditLog_PropertyPaymentGetAll(ApprovedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countsum = db.spReport_NewAllApprovedSummary_AuditLog_PropertyPaymentGetAll(ApprovedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countproptypesum = db.spReport_NewAllApprovedSummaryPropType_AuditLog_PropertyPaymentGetAll(ApprovedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditApprovedPropertyPayment.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyPayment", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("TotalApprovedPayments", datasourcesum));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("TotalApprovedPropTypePayments", datasourceproptypesum));


            ViewBag.ReportViewer = reportViewer;

            return View();

        }
      
        //Audit Log Approved Property Title Movts
        public ActionResult AuditLogPropertyTitleMovementsApproved()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var approvedby = db.ViewAudPropTitleMvtAspNetUsersFullNames.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            ViewBag.approvedby = approvedby;

            db.Configuration.ProxyCreationEnabled = false;
            var addedby = db.AuditLog_PropertyTitleMovt.AsNoTracking().Select(a => new { a.original_Added_By }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            ViewBag.addedby = addedby;

            db.Configuration.ProxyCreationEnabled = false;
            //var editors = db.AuditLog_PropertyTitle.AsNoTracking().OrderBy(a => a.Edited_By).ToList();
            var editors = db.AuditLog_PropertyTitleMovt.Select(a => new { a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();

            ViewBag.editorss = editors;

            db.Configuration.ProxyCreationEnabled = false;
            var auditactions = db.Audit_Action.AsNoTracking().OrderBy(a => a.AuditAction_Description).ToList();
            ViewBag.editorss = auditactions;

            return View();

        }

        public ActionResult AuditLogPropertyTitleMovementsPartialApproved(string ApprovedBy, string sdate, string edate/*, string AuditAction_Description*/)
        {
            DateTime passeddate = DateTime.Now;
            DateTime? startDate = null, endDate = null;

            if (DateTime.TryParse(sdate, out passeddate))
            {
                startDate = passeddate;
            }
            if (DateTime.TryParse(edate, out passeddate))
            {
                endDate = passeddate;
            }

            if (ApprovedBy.Contains("null") || string.IsNullOrEmpty(ApprovedBy))
            {
                ApprovedBy = null;
            }
         
            var datasource = db.spReport_NewApproved_AuditLog_PropertyTitleMovtGetAll(ApprovedBy, startDate, endDate).Where(b => ((!string.IsNullOrEmpty(b.original_Edited_By) && (b.new_TitleMovementStatusID == 2) && (b.new_FinalSubmission == true) && (b.new_UnlockTitle == false)))).ToList();

            var datasourcelandtype = db.spReport_NewApprovedSummary_AuditLog_PropertyTitleMovtGetAll(ApprovedBy, startDate, endDate).ToList();
            var datasourceproptype = db.spReport_NewApprovedSummaryPropType_AuditLog_PropertyTitleMovtGetAll(ApprovedBy, startDate, endDate).ToList();

            var count = db.spReport_NewApproved_AuditLog_PropertyTitleMovtGetAll(ApprovedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countlandtype = db.spReport_NewApprovedSummary_AuditLog_PropertyTitleMovtGetAll(ApprovedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items
            var countproptype = db.spReport_NewApprovedSummaryPropType_AuditLog_PropertyTitleMovtGetAll(ApprovedBy, startDate, endDate).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\AuditApprovedPropertyTitleMovements.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("AuditPropertyTitleMovements", datasource));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("LandTypeSummary", datasourcelandtype));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PropertyTypeSummary", datasourceproptype));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        public ActionResult LeaseNotifications()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var Lease_Type = db.Lease_Type.AsNoTracking().OrderBy(a => a.LandDesc).ToList();
            ViewBag.Lease_Type = Lease_Type;

            return View();

        }

        public ActionResult LeaseNotificationsPartial(string Location_id, string Lease_Type)
        {
            if (Location_id.Contains("null") || string.IsNullOrEmpty(Location_id))
            {
                Location_id = null;
            }
            if (Lease_Type.Contains("null") || string.IsNullOrEmpty(Lease_Type))
            {
                Lease_Type = null;
            }

            var datasource = db.spReport_New_LeaseNotificationsGetAll(Location_id, Lease_Type).Where(a=> a.LandTypeCode == 3).ToList();

            var count = db.spReport_New_LeaseNotificationsGetAll(Location_id, Lease_Type).Where(a => a.LandTypeCode == 3).ToList().Count(); // Counts the number of returned items

            Microsoft.Reporting.WebForms.ReportViewer reportViewer = new Microsoft.Reporting.WebForms.ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\LeaseNotifications.rdlc";
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("LeaseNotifications", datasource));

            ViewBag.ReportViewer = reportViewer;

            return View();

        }

        public JsonResult GetLease_Type()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Lease_Type.ToList().OrderBy(a => a.LandDesc);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLease_TypePropTitMvt()
        {
            db.Configuration.ProxyCreationEnabled = false;
          //  IEnumerable data = db.Report_TitleMovements.ToList().Distinct().OrderBy(a => a.LandTypeCodeDescPropTitle);

            IEnumerable data = db.Report_TitleMovements.Select(x => new { x.LandTypeCodePropTitle, x.LandTypeCodeDescPropTitle }).Distinct().OrderBy(x => x.LandTypeCodeDescPropTitle).ToList();


            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjectCode()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Projects.ToList().OrderBy(x => x.Project_Desc);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLocationCode()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Locations.ToList().OrderBy(x => x.Location_Desc);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVolume()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.Select(x => new { x.Project_Code, x.Volume }).Distinct().Where(a => a.Volume != "No Volume").OrderBy(x => x.Volume).ToList();
           
            return Json(data, JsonRequestBehavior.AllowGet);            
        }

        public JsonResult GetVolumeTitleMovt()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitleMovts.Select(x => new { x.Project_Code, x.Volume }).Distinct().Where(a => a.Volume != "No Volume").OrderBy(x => x.Volume).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVolumePropPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Property_Payment.Select(x => new { x.Project_Code, x.Volume }).Distinct().Where(a => a.Volume != "No Volume").OrderBy(x => x.Volume).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPropertyType()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTypes.ToList().OrderBy(a => a.TypeDesc);

            return Json(data, JsonRequestBehavior.AllowGet);                        
        }

        public JsonResult GetTitleReference()
        {
            db.Configuration.ProxyCreationEnabled = false;            
            IEnumerable data = db.PropertyTitles.Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTitRefSoldProp()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PropertyTitles.Select(a => new { a.Project_Code,a.PropertySoldorTransferred, a.Title_Reference }).Where(a=>a.PropertySoldorTransferred==true).Distinct().OrderBy(a => a.Title_Reference).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTitleReferencePropPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Property_Payment.Select(a => new { a.Project_Code, a.Title_Reference}).Distinct().OrderBy(a => a.Title_Reference.Trim()).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPaymentMethod()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.PayMethods.Select(a => new { a.PayMethodCode, a.PayMethodDesc }).Distinct().OrderBy(a => a.PayMethodDesc).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetDestinations()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.DestinationTypes.ToList().OrderBy(a => a.DestinyDesc);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurposes()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.TitleMovement_Purpose.ToList().OrderBy(a => a.Purpose_Description);
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Edited By for Property Title 
        public JsonResult GetEditedBy()
        {
            db.Configuration.ProxyCreationEnabled = false;

            //  IEnumerable data = db.AuditLog_PropertyTitle.Select(a => new {a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            //return Json(data, JsonRequestBehavior.AllowGet);

            IEnumerable data = db.ViewAudPropTitleAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Edited_By))).Select(a => new { a.original_Edited_By, a.OrigEditedByFullName }).Distinct().OrderBy(a => a.OrigEditedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Added By for Property Title 
        public JsonResult GetAddedBy()
        {
            db.Configuration.ProxyCreationEnabled = false;

            IEnumerable data = db.ViewAudPropTitleAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Added_By))).Select(a => new { a.original_Added_By, a.OrigAddedByFullName }).Distinct().OrderBy(a => a.OrigAddedByFullName).ToList();

            //IEnumerable data = db.ViewAudPropTitleAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Added_By))).Select(a => new { a.original_Added_By, a.OrigAddedByFullName }).Distinct().OrderBy(a => a.original_Added_By).ToList();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Edited By for Property Payment 
        public JsonResult GetEditedByPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //  IEnumerable data = db.AuditLog_PropertyTitle.Select(a => new {a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            //return Json(data, JsonRequestBehavior.AllowGet);

            IEnumerable data = db.ViewAudPropPaymentAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Edited_By))).Select(a => new { a.original_Edited_By, a.OrigEditedByFullnames }).Distinct().OrderBy(a => a.OrigEditedByFullnames).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAddedByPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            //  IEnumerable data = db.AuditLog_PropertyTitle.Select(a => new {a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            //return Json(data, JsonRequestBehavior.AllowGet);

            IEnumerable data = db.ViewAudPropPaymentAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Added_By))).Select(a => new { a.original_Added_By, a.OrigAddedByFullnames }).Distinct().OrderBy(a => a.OrigAddedByFullnames).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Edited By for Property Title Movt 
        public JsonResult GetEditedByTitleMovt()
        {
            db.Configuration.ProxyCreationEnabled = false;

            //  IEnumerable data = db.AuditLog_PropertyTitle.Select(a => new {a.original_Edited_By }).Distinct().OrderBy(a => a.original_Edited_By).ToList();
            //return Json(data, JsonRequestBehavior.AllowGet);

            IEnumerable data = db.ViewAudPropTitleMvtAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Edited_By))).Select(a => new { a.original_Edited_By, a.OrigEditedByFullName }).Distinct().OrderBy(a => a.OrigEditedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Added By for Property Title Movt 
        public JsonResult GetAddedByTitleMovt()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropTitleMvtAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Added_By))).Select(a => new { a.original_Added_By, a.OrigAddedByFullName }).Distinct().OrderBy(a => a.OrigAddedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Approved By for Property Title Movt 
        public JsonResult GetApprovedByTitleMovt()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropTitleMvtAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Edited_By))).Select(a => new { a.original_Edited_By, a.OrigEditedByFullName }).Distinct().OrderBy(a => a.OrigEditedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Unlocked Property Titles
        public JsonResult GetUnlockedBy()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropTitleAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_UnlockedBy))).Select(a => new { a.original_UnlockedBy, a.OriginalUnlockedByFullName }).Distinct().OrderBy(a => a.OriginalUnlockedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Approved Property Titles
        public JsonResult GetApprovedBy()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropTitleAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Edited_By))).Select(a => new { a.original_Edited_By, a.OrigEditedByFullName }).Distinct().OrderBy(a => a.OrigEditedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //Approved Property Payments
        public JsonResult GetApprovedByPropPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropPaymentAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_Edited_By))).Select(a => new { a.original_Edited_By, a.OrigEditedByFullnames }).Distinct().OrderBy(a => a.OrigEditedByFullnames).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }


        //Unlocked Property Payments
        public JsonResult GetUnlockedByPayments()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropPaymentAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_UnlockedBy))).Select(a => new { a.original_UnlockedBy, a.OrigUnlockedByFullnames }).Distinct().OrderBy(a => a.OrigUnlockedByFullnames).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Unlocked Property Title Movts
        public JsonResult GetUnlockedByPropMvts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.ViewAudPropTitleMvtAspNetUsersFullNames.Where(b => (!string.IsNullOrEmpty(b.original_UnlockedBy))).Select(a => new { a.original_UnlockedBy, a.OrigUnlockedByFullName }).Distinct().OrderBy(a => a.OrigUnlockedByFullName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAuditActionDescriptions()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Audit_Action.ToList().OrderBy(a => a.AuditAction_Description);
            //IEnumerable data = db.Audit_Action.Select(a => new { a.AuditAction_ID, a.AuditAction_Description }).Distinct().OrderBy(a => a.AuditAction_Description).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetLandType()
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Lease_Type.AsNoTracking().ToList().OrderBy(a => a.LandDesc);
            //IEnumerable data = db.Audit_Action.Select(a => new { a.AuditAction_ID, a.AuditAction_Description }).Distinct().OrderBy(a => a.AuditAction_Description).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

    }






}
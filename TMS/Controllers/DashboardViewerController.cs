using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class DashboardViewerController : Controller
    {
        private NHCC_NHCC_TMSEntities context = new NHCC_NHCC_TMSEntities();
        // GET: DashboardViewer
        // GET: DashboardViewer
        public ActionResult Index()
        {
            ViewBag.DashboardPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "\\\\") + "bin\\\\WorldWideCarSalesDashboard.sydx"; // Or use the remote (online) Dashboard Path. For example, https://dashboardsdk.syncfusion.com//Dashboards//WorldWideCarSalesDashboard.sydx
            ViewBag.ServiceUrl = "http://localhost:52317/DashboardService.svc"; // Or use the remote (online) Dashboard Service. For example, https://dashboardsdk.syncfusion.com/DashboardService/DashboardService.svc;
            return View();

            //ViewBag.DashboardPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "\\\\") + "bin\\\\WorldWideCarSalesDashboard.sydx"; // Or use the remote (online) Dashboard Path. For example, https://dashboardsdk.syncfusion.com//Dashboards//WorldWideCarSalesDashboard.sydx
            //ViewBag.ServiceUrl = "http://localhost:52317"; // Or use the remote (online) Dashboard Service. For example, https://dashboardsdk.syncfusion.com/DashboardService/DashboardService.svc;
            //return View();

        }

        public ActionResult Dashboard()
        {
            //ViewBag.DashboardPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "\\\\") + "Dashboards\\\\mascis_home.sydx";
            ViewBag.DashboardPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "\\\\") + "Dashboards\\\\NHCCHome.sydx";

            DashboardWindowsServiceInfo dashboardViewer = new DashboardWindowsServiceInfo();
            ViewBag.Errormessage = dashboardViewer.Errormessage;
            ViewBag.ServiceUrl = dashboardViewer.ServiceUrl;
            return View();
        }
    }
}
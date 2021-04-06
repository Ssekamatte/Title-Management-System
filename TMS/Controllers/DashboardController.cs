using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class DashboardController : Controller
    {
        private NHCC_NHCC_TMSEntities context = new NHCC_NHCC_TMSEntities();
               
        //HomeDashBoard
        public ActionResult HomeDashboardIndex()
        {
            ViewBag.Dash = "YES";
            ViewBag.DashboardPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "\\\\") + "Dashboards\\\\NHCCHome.sydx";
            DashboardWindowsServiceInfo dashboardViewer = new DashboardWindowsServiceInfo();
            ViewBag.Errormessage = dashboardViewer.Errormessage;
            ViewBag.ServiceUrl = dashboardViewer.ServiceUrl;
            //ViewBag.ServiceUrl = "http://localhost:52317/en-US/dashboards?category=TMS&dashboard=NHCCHome&view=all";

            return View();

        }

        public ActionResult HomeDashboard()
        {

            context.Configuration.ProxyCreationEnabled = false;
            var _logins = context.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            ViewBag.Dash = "YES";

            // Get and display the friendly name of the default AppDomain.
            string callingDomainName = AppDomain.CurrentDomain.BaseDirectory;// Thread.GetDomain().FriendlyName;
            Console.WriteLine(callingDomainName);
            ViewBag.path = callingDomainName;

            ViewBag.DashboardPath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "\\\\") + "Dashboards\\\\NHCCHome.sydx";
            //NHCC Production Environment
            ViewBag.ServiceUrl = new UriBuilder("http", "nhccldc4/TMS").ToString().TrimEnd('/') + ("/DashboardService");
            //NHCC Test Environment
            //ViewBag.ServiceUrl = new UriBuilder("http", "nhccldc6/TMS").ToString().TrimEnd('/') + ("/DashboardService");
            //IBS Microsoft Azure
            //ViewBag.ServiceUrl = new UriBuilder("http", "52.188.137.38:8080/TMS").ToString().TrimEnd('/') + ("/DashboardService");
            return View();

        }
        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => c != '"').ToArray());
        }
      

    }
    public class DashboardParameterSettings
    {
        public bool ShowIcon;

        public List<DashboardParameterData> Data;
    }

    public class DashboardParameterData
    {
        public string ParameterName;

        public bool ShowInParameterDialog;

        public bool ShowInPromptDialog;

        public string Value;

        public List<ParameterValue> Values;

        public ParameterValueRange DateValue;
    }

    public class ParameterValueRange
    {
        public string Start;

        public string End;
    }

    public class ParameterValue
    {
        public string Value;
    }
}
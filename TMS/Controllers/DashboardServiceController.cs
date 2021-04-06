using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

using Syncfusion.DashboardService.Base;

namespace TMS.Controllers
{
    public class DashboardServiceController : Controller
    {
        [HttpPost]
        public ActionResult ProcessRequestForPost(DashboardServiceArguments arguments)
        {
            DashboardServiceBase serviceBase = new DashboardServiceBase();
            return Json(serviceBase.GetServiceResponse(arguments));
        }

        [HttpGet]
        public HttpResponseMessage ProcessRequestForGet(string arguments)
        {
            DashboardServiceBase serviceBase = new DashboardServiceBase();
            var stream = serviceBase.GetServiceResponse(arguments);
            return serviceBase.GetResponseFromStream(stream);
        }

        [HttpGet]
        public string IsServiceExists()
        {
            DashboardServiceBase serviceBase = new DashboardServiceBase();
            return serviceBase.IsServiceExists();
        }

        [HttpGet]
        public string Version()
        {
            DashboardServiceBase serviceBase = new DashboardServiceBase();
            return serviceBase.Version();
        }
    }
}
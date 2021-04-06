using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class ApplicationBaseController : Controller
    {
        NHCC_NHCC_TMSEntities Context = new NHCC_NHCC_TMSEntities();
        // GET: ApplicationBase
        public ActionResult Index()
        {
            return View();
        }

        protected override void OnActionExecuted(ActionExecutedContextfilterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();

                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = Context.Users_AccountStatus.SingleOrDefault(u => u.Username = username);
                }

                //string fullName = string.Concat(new string[] { User.FirstName, "", User.LastName }); //Original Line there
                string fullName = string.Concat(new string[] { user.NameOfUserAccountHolder });
                ViewData.Add("FullName", fullName);

            }

        }

         base.onActionExecuted(filterContext);
    }

    public ApplicationBaseController() { }

    }

      
}
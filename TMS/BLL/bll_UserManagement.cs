using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TMS.Models;

namespace TMS.BLL
{
    public class bll_UserManagement
    {
        Models.ApplicationDbContext context = new Models.ApplicationDbContext();
        IdentityResult IdRoleResult;

        public object IdentityModels { get; private set; }

        public Boolean createRole(string role)
        {
            try
            {

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                if (!roleManager.RoleExists(role))
                {
                    IdRoleResult = roleManager.Create(new IdentityRole(role));
                    if (!IdRoleResult.Succeeded)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception x)
            {
                throw (x);
            }
        }       

        public string getCurrentuser()
        {
            return HttpContext.Current.User.Identity.GetUserName();
        }
                
        public string getCurrentuserRole()
        {
            string role = "";
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                role = "Administrator";

            }
            return role;
        }
        //public int? getCurrentuserDirectorate()
        //{
        //    string UserName = HttpContext.Current.User.Identity.GetUserName();
        //    var userStore = new UserStore<ApplicationUser>(context);
        //    var x = new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName);
        //    if (x != null)
        //        return new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName).Directorate;
        //    else
        //        return null;
        //}

        //public int? getCurrentuserSector()
        //{
        //    string UserName = HttpContext.Current.User.Identity.GetUserName();
        //    var userStore = new UserStore<ApplicationUser>(context);
        //    var x = new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName);
        //    if (x != null)
        //        return new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName).Sector;
        //    else
        //        return null;
        //}

        //public int? getCurrentuserSectoralCouncil()
        //{
        //    string UserName = HttpContext.Current.User.Identity.GetUserName();
        //    var userStore = new UserStore<ApplicationUser>(context);
        //    return new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName).SectoralCouncilID;
        //}

        //public int? getCurrentuserSectoralCouncilAdmin()
        //{
        //    string UserName = HttpContext.Current.User.Identity.GetUserName();
        //    var userStore = new UserStore<ApplicationUser>(context);
        //    return new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName).SectoralCouncilAdmin;
        //}

        //public IQueryable<View_User_List> getListOfUsers()
        //{
        //    YoungLivilihoodsProgrammeEntities context = new YoungLivilihoodsProgrammeEntities();
        //    return context.View_User_List;
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TMS.Models
{
    
        public class UserManagement
        {
            ApplicationDbContext context = new ApplicationDbContext();
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


        ////lockout users for 10 minutes
        //UserManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);

        //// takes 6 incorrect attempts to lockout 
        //this.MaxFailedAccessAttemptsBeforeLockout = 6;

        //// when new user is created, they will be "lockable". 
        //this.UserLockoutEnabledByDefault = true;
            
      


       

        //public int? getCurrentuserTMS()
        //{
        //    string UserName = HttpContext.Current.User.Identity.GetUserName();
        //    var userStore = new UserStore<ApplicationUser>(context);
        //    var x = new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName);
        //    if (x != null)
        //        return new UserManager<ApplicationUser>(userStore).Users.SingleOrDefault(a => a.UserName == UserName).FacilityId;
        //    else
        //        return null;
        //}

    }

    }

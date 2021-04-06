#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TMS.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections;
using Syncfusion.XlsIO;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;

using System.Data;
using TMS;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace TMS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        ApplicationDbContext context;

        //db.Configuration.ProxyCreationEnabled = false;
        public AccountController()
        {
            context = new ApplicationDbContext();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            
            switch (result)
            {
                case SignInStatus.Success:
                    {
                        
                        //NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
                       
                        var roles = db.View_UsersRoles.SingleOrDefault(a => a.UserName == model.Email);
                        if (roles != null)
                        {
                            SaveLog(model.Email);

                            if (roles.Name.Contains("Super Administrator"))
                                return RedirectToAction("HomeDashboard", "Dashboard");

                            if (roles.Name.Contains("Administrator"))
                                return RedirectToAction("HomeDashboard", "Dashboard");

                            if (roles.Name.Contains("Authorizer/ Approver"))
                                return RedirectToAction("HomeDashboard", "Dashboard");

                            if (roles.Name.Contains("Data Entrant"))
                                return RedirectToAction("HomeDashboard", "Dashboard");

                            if (roles.Name.Contains("Report Viewers"))
                                return RedirectToAction("HomeDashboard", "Dashboard");

                            if (roles.Name.Contains("CEO"))
                                return RedirectToAction("HomeDashboard", "Dashboard");
                            //if (roles.Name.Contains("LMISCordinator"))
                            //    return RedirectToAction("IndexCodinator", "Home");

                            else
                                // return RedirectToLocal(returnUrl);
                                return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            //return RedirectToLocal(returnUrl);
                            return RedirectToAction("Login", "Account");
                        }
                    }
            
                case SignInStatus.LockedOut:
                    return View("Lockout");

                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });

                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //Geo Coordinates Starts Here

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GeoCoodinates(string latitude, string longitude)
        {
            Session["long"] = longitude;
            Session["lat"] = latitude;
            string data = "sesson created";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        static string baseUri = "https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key=AIzaSyAU2KSghYM3T4zYeKzEvJTDbgspDwz2Kwo";
        public string RetrieveFormatedAddress(string lat, string lng)
        {

            string location = string.Empty;
            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lng))
            {
                string requestUri = string.Format(baseUri, lat, lng);

                using (WebClient wc = new WebClient())
                {
                    string result = wc.DownloadString(requestUri);
                    var xmlElm = XElement.Parse(result);
                    var status = (from elm in xmlElm.Descendants()
                                  where
                    elm.Name == "status"
                                  select elm).FirstOrDefault();
                    if (status.Value.ToLower() == "ok")
                    {
                        var res = (from elm in xmlElm.Descendants()
                                   where
                        elm.Name == "formatted_address"
                                   select elm).FirstOrDefault();
                        location = res.Value;

                    }
                }
            }

            return location;
        }
        //public void SaveLog(string email)
        //{
        //    try
        //    {
        //        NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        //        var user = db.AspNetUsers.FirstOrDefault(o => o.UserName == email || o.Email == email);
        //        //string userIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
        //        //string Url = "https://freegeoip.net/json/" + userIP;
        //        //WebClient client = new WebClient();
        //        //string _result = client.DownloadString(Url);
        //        //dynamic dynobj = JsonConvert.DeserializeObject(_result);
        //        double lat = Convert.ToDouble(Session["lat"].ToString());
        //        double longitude = Convert.ToDouble(Session["long"].ToString());
        //        string location = RetrieveFormatedAddress(Session["lat"].ToString(), Session["long"].ToString());
        //        int count = db.A_LoginLog.ToList().Count;
        //        var login = new A_LoginLog();
        //        login.ID = (count + 1);
        //        login.UserID = user.Id;
        //        login.UserName = user.UserName;
        //        login.LoginDate = DateTime.Now;
        //        login.Latitude = lat;
        //        login.Longitude = longitude;
        //        login.Loc_Description = location;
        //        db.A_LoginLog.Add(login);
        //        context.SaveChanges();
        //    }
        //    catch
        //    {
        //        //throw;
        //        //NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        //        var user = db.AspNetUsers.FirstOrDefault(o => o.UserName == email || o.Email == email);

        //        int count = db.A_LoginLog.ToList().Count;
        //        var login = new A_LoginLog();
        //        login.ID = (count + 1);
        //        login.UserID = user.Id;
        //        login.UserName = user.UserName;
        //        login.LoginDate = DateTime.Now;
        //        db.A_LoginLog.Add(login);
        //        db.SaveChanges();
        //    }
        //}

        public void SaveLog(string email)
        {
            try
            {
                NHCC_NHCC_TMSEntities context = new NHCC_NHCC_TMSEntities();
                var user = context.AspNetUsers.FirstOrDefault(o => o.UserName == email || o.Email == email);
                double? lat = null;
                double? longitude = null;
                if (Session["lat"] != null && !string.IsNullOrEmpty(Session["lat"].ToString()))
                {
                    lat = Convert.ToDouble(Session["lat"].ToString());
                }
                if (Session["long"] != null && !string.IsNullOrEmpty(Session["long"].ToString()))
                {
                    longitude = Convert.ToDouble(Session["long"].ToString());
                }
                if (lat != null && longitude != null)
                {
                    string location = RetrieveFormatedAddress(Session["lat"].ToString(), Session["long"].ToString());
                    int count = context.A_LoginLog.ToList().Count;
                    var login = new A_LoginLog();
                    login.ID = (count + 1);
                    login.UserID = user.Id;
                    login.UserName = user.UserName;
                    login.LoginDate = DateTime.Now;
                    login.Latitude = lat;
                    login.Longitude = longitude;
                    login.Loc_Description = location;
                    context.A_LoginLog.Add(login);
                    context.SaveChanges();
                }
                else
                {
                    int count = context.A_LoginLog.ToList().Count;
                    var login = new A_LoginLog();
                    login.ID = (count + 1);
                    login.UserID = user.Id;
                    login.UserName = user.UserName;
                    login.LoginDate = DateTime.Now;
                    context.A_LoginLog.Add(login);
                    context.SaveChanges();
                }

            }
            catch
            {
                //throw;
                NHCC_NHCC_TMSEntities context = new NHCC_NHCC_TMSEntities();
                var user = context.AspNetUsers.FirstOrDefault(o => o.UserName == email || o.Email == email);

                int count = context.A_LoginLog.ToList().Count;
                var login = new A_LoginLog();
                login.ID = (count + 1);
                login.UserID = user.Id;
                login.UserName = user.UserName;
                login.LoginDate = DateTime.Now;
                context.A_LoginLog.Add(login);
                context.SaveChanges();
            }
        }
        //Geo Coordinates Ends Here

        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult AllocateRole()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Department = user.Department_ID,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Department_ID = p.Department,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            ViewBag.UsersWithRoles = usersWithRoles;

            var users = context.Users.ToList();
            ViewBag.Users = users;
            //  ViewBag.userRoles = new SelectList(context.Roles.ToList(), "Name", "Name");
            ViewBag.Department = db.A_Dept.ToList();

            ViewBag.userRoles = context.Roles.ToList();
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> AllocateRole(string userid, string userrole, string Email)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userid);
            if (user != null)
            {
                await this.UserManager.RemoveFromRolesAsync(userid, userrole);
            }
            await this.UserManager.AddToRoleAsync(userid, userrole);
            //user.Department_ID = Department;

            context.SaveChanges();

            return View();
        }

        public ActionResult UsersWithRoles()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Department = user.Department_ID,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Department_ID = p.Department,
                                      Role = string.Join(",", p.RoleNames),


                                  });

            ViewBag.UsersWithRoles = usersWithRoles.ToList();
            ViewBag.userRoles = context.Roles.ToList();
            ViewBag.Department = db.A_Dept.ToList();
            return View(usersWithRoles);
            //return View();
        }



        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            context.Configuration.ProxyCreationEnabled = false;
            ViewBag.Roles = context.Roles.AsNoTracking().ToList();

            db.Configuration.ProxyCreationEnabled = false;
            ViewBag.Department = db.A_Dept.AsNoTracking().ToList();

            context.Configuration.ProxyCreationEnabled = false;

            ViewBag.Name = "Account Succesfully Created";

            //ViewBag.Roles = context.Roles.ToList();

            //ViewBag.Department = db.A_Dept.ToList();
            //return View();

            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
          //  ViewBag.Name = "Account Succesfully Created";

            if (ModelState.IsValid)
            {
                if (Request["rolesList"] != null && Request["rolesList"] != string.Empty)
                {
                    string myrole = Request["rolesList"].ToString();
                    //model.Name =  Request["MySkills"].ToString();
                    model.Name = myrole;// Request["usersList"].ToString();
                }
                if (Request["Dept"] != null && Request["Dept"] != string.Empty)
                {
                    string Dept = Request["Dept"].ToString();
                    model.Department_ID = System.Convert.ToInt32(Dept);
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Department_ID = model.Department_ID, PhoneNumber = model.PhoneNumber, NameOfUserAccountHolder = model.NameOfUserAccountHolder
                //LockoutEnabled = false
                };
               // var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, PhoneNumber = model.PhoneNumber, Name = model.Name, UserTypeId = System.Convert.ToInt32(model.UserTypeId), FacilityId = model.FacilityId, MD5Hash = hased };



                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (Request["rolesList"] != null && Request["rolesList"] != string.Empty)
                    {
                        string myrole = Request["rolesList"].ToString();
                        //model.Name =  Request["MySkills"].ToString();
                        model.Name = myrole;// Request["usersList"].ToString();
                    }
                    //Assign Role to user Here 
                    await this.UserManager.AddToRoleAsync(user.Id, model.Name);
                    //Ends Here


                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //return RedirectToAction("Register", "Account");
                  return RedirectToAction("Usermanagement", "Account");   //Redirects to a particular form  

                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public ActionResult Roles()
        {
            var roles = context.Roles.ToList();
            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = UserManager.ChangePassword(user.Id, model.oldPassword, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }


        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //Session.Abandon();
            //return RedirectToAction("Index", "Home");

            List<string> keys = new List<string>();

            // retrieve application Cache enumerator
            IDictionaryEnumerator enumerator = HttpContext.Cache.GetEnumerator();

            // copy all keys that currently exist in Cache
            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Key.ToString());
            }

            // delete every key from cache
            for (int i = 0; i < keys.Count; i++)
            {
                HttpContext.Cache.Remove(keys[i]);
            }

            //Stop Caching in IE
            ////Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Session.Abandon();
            //Session.Clear();
            //Session.RemoveAll();
            //System.Web.Security.FormsAuthentication.SignOut();
            ////Response.Redirect("frmLogin.aspx");


            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddHours(-1));
            Response.Cache.SetNoServerCaching();
            //Stop Caching in FireFox
            Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        public ActionResult RemoveRolefromUser()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            ViewBag.UsersWithRoles = usersWithRoles.ToList();
            ViewBag.userRoles = context.Roles.ToList();
            ViewBag.Department = db.A_Dept.ToList();
            return View(usersWithRoles);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RemoveRoleAddedToUser()
        {
            var userid = string.Empty;
            var userrole = string.Empty;

            if (Request["usersList"] != null && Request["usersList"] != string.Empty)
            {
                userid = Request["usersList"].ToString();
            }
            else
            {
                ModelState.AddModelError("RoleName", "select proper RoleName");
            }

            if (Request["rolesList"] != null && Request["rolesList"] != string.Empty)
            {
                userrole = Request["rolesList"].ToString();
            }
            else
            {
                ModelState.AddModelError("UserName", "select proper Username");
            }

            var remresult = this.UserManager.RemoveFromRoles(userid, userrole);
            if (remresult.Succeeded)
            {
                ViewBag.ResultMessage = "User Role is removed successfully !";
            }
            //else

            //{
            //    ViewBag.ResultMessage = "";
            //}

            return RedirectToAction("RemoveRolefromUser", "Account");
            //return View();
        }




        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        public ActionResult Usermanagement()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins; 

            db.Configuration.ProxyCreationEnabled = false;
            ViewBag.Roles = db.View_AspNetRoles.AsNoTracking().OrderBy(s => s.Name);

            ViewBag.Department = db.A_Dept.ToList();
            return View();
        }

        public ActionResult DataSourceUserManagement(DataManager dm)
        {
            IEnumerable data = db.View_UserManagement.OrderBy(a => a.Email).ToList();
            int count = db.View_UserManagement.OrderBy(a => a.Email).ToList().Count;

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
            if (dm.Skip > 0)
                data = operation.PerformSkip(data, dm.Skip);
            if (dm.Take > 0)
                data = operation.PerformTake(data, dm.Take);

            return Json(new { result = data, count = count }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateUserInformation(string key, List<View_UserManagement> changed, List<View_UserManagement> added, List<View_UserManagement> deleted)
        {
            Models.ApplicationDbContext contextX = new Models.ApplicationDbContext();
            ////Performing update operation
            if (changed != null && changed.Count() > 0)
            {
                foreach (var temp in changed)
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    //  var x = db.A_Facilities.FirstOrDefault(a => a.FacilityCode == temp.FacilityId);
                    var user = UserManager.FindById(temp.Id);
                    user.UserName = temp.UserName;
                    // user.UserTypeId = temp.UserTypeId;
                    user.Email = temp.Email;
                    user.Department_ID = temp.Department_ID;
                    //user.Name = temp.Name;
                    user.PhoneNumber = temp.PhoneNumber;
                    user.LockoutEndDateUtc = temp.LockoutEndDateUtc;
                    user.LockoutEnabled = temp.LockoutEnabled;
                    UserManager.Update(user);

                    db.Configuration.ProxyCreationEnabled = false;
                    var userStore = new UserStore<ApplicationUser>(contextX);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    //IdentityResult IdUserResult;
                    foreach (string r in userManager.GetRoles(temp.Id))
                    {
                        userManager.RemoveFromRole(temp.Id, r);
                    }
                    userManager.AddToRole(temp.Id, temp.Role);
                }
            }
            //return null;
            var data = 0;// new CouncilCountryModels().GetAll(1).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("GridEdit");
        }

        #region "Reset User Password ---- 06-Mar-2019

        public ActionResult ResetUsersPasswords()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(usersWithRoles);
        }


        public ActionResult ResetUserPassword(string userId, string UserName)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            ViewBag.Username = UserName.ToString();
            ViewBag.UserId = userId.Trim().ToString();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ResetUserPassword(ResetUserPasswordViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
            String userId = model.UserId;// User.Identity.GetUserId();//"<YourLogicAssignsRequestedUserId>";
            String newPassword = model.ConfirmPassword;// "test@123"; //"<PasswordAsTypedByUser>";
            String hashedNewPassword = UserManager.PasswordHasher.HashPassword(newPassword);
            ApplicationUser cUser = await store.FindByIdAsync(userId);
            await store.SetPasswordHashAsync(cUser, hashedNewPassword);
            await store.UpdateAsync(cUser);
            var person = db.AspNetUsers.FirstOrDefault(o => o.Id == userId);
            if (person != null)
            {
                db.Entry(person).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ResetUsersPasswords", "Account", new { area = "", });
            //return View(model);
        }


        #endregion
    }
}
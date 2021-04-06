using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class ApprovedPropertyPaymentController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        // GET: ApprovedPropertyPayment
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PayMethods = db.PayMethods.AsNoTracking().ToList();
            ViewBag.PayMethods = PayMethods;

            db.Configuration.ProxyCreationEnabled = false;
            var Edit_ManagePropertyPayments = db.Property_Payment.AsNoTracking().ToList();
            ViewBag.datasource = Edit_ManagePropertyPayments;

            db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var paymethodcodes = db.PayMethods.AsNoTracking().OrderBy(a => a.PayMethodDesc).ToList();
            ViewBag.PayMethodscodes = paymethodcodes;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;
                      

            return View();
        }

        public ActionResult ApprovedPropertyPaymentCEO()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.Projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var PayMethods = db.PayMethods.AsNoTracking().ToList();
            ViewBag.PayMethods = PayMethods;

            db.Configuration.ProxyCreationEnabled = false;
            var Edit_ManagePropertyPayments = db.Property_Payment.AsNoTracking().ToList();
            ViewBag.datasource = Edit_ManagePropertyPayments;

            db.Configuration.ProxyCreationEnabled = false;
            //var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().OrderBy(a => a.Status_Description).ToList();
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var paymethodcodes = db.PayMethods.AsNoTracking().OrderBy(a => a.PayMethodDesc).ToList();
            ViewBag.PayMethodscodes = paymethodcodes;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            return View();
        }

        // GET: ApprovedPropertyPayment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApprovedPropertyPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApprovedPropertyPayment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApprovedPropertyPayment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApprovedPropertyPayment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApprovedPropertyPayment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApprovedPropertyPayment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DataSourceApprovedPropertyPayments(DataManager dm)
        {

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.Property_Payment.AsNoTracking().Where(b => ((b.PropertyPaymentStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.Property_Payment.AsNoTracking().Where(b => ((b.PropertyPaymentStatusID == 2) && (b.FinalSubmission == true) && (b.UnlockTitle == false))).ToList().Count();



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


        public ActionResult DialogUpdate(Property_Payment value)
        {
            Property_Payment table = db.Property_Payment.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.OfferNo == value.OfferNo && o.Volume == value.Volume &&
            o.Folio == value.Folio && o.Payment_Ref_No == value.Payment_Ref_No);


            if (table != null)
            {
                UserManagement user = new UserManagement();
                value.Edited_By = user.getCurrentuser();
                value.Edited_Date = DateTime.Now;

                //value.PropertyPaymentStatusID = 1;
                //value.UnlockTitle = false;

                db.Entry(table).CurrentValues.SetValues(value);
                db.Entry(table).State = EntityState.Modified;

                try
                {
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

        public ActionResult DialogInsert(Property_Payment value)
        {
            //int new_id = ++db.Counties.AsNoTracking().OrderBy(a => a.County_ID).ToList().Last().County_ID;
            //value.County_ID = Convert.ToInt32(new_id);

            Property_Payment table = db.Property_Payment.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.OfferNo == value.OfferNo && o.Volume == value.Volume &&
            o.Folio == value.Folio && o.Payment_Ref_No == value.Payment_Ref_No);

            if (table == null)
            {
                UserManagement user = new UserManagement();
                value.Added_By = user.getCurrentuser();
                value.Added_Date = DateTime.Now;

                //value.PropertyPaymentStatusID = 1;
                //value.UnlockTitle = false;

                db.Property_Payment.Add(value);
                db.SaveChanges();
            }
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogDelete(int Project_Code)
        {

            Property_Payment result = db.Property_Payment.Where(o => o.Project_Code == Project_Code).FirstOrDefault();
            db.Property_Payment.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetParent_Title(int Location_id)
        {
            //var result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            var result = db.PropertyTitles.Where(o => o.Location_id == Location_id).Select(a => new { a.Location_id, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVolume(string Title_Reference)

        {           
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference).Select(a => new { a.Title_Reference, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFolio(string Title_Reference, string Volume)
        {
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference && o.Volume == Volume).Select(a => new { a.Title_Reference, a.Volume, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveApprovedPropertyPayment(int? Location_id, string Title_Reference, int? Project_Code, string Volume, int? Folio
         , int? OfferNo, string Payment_Ref_No, DateTime? Pay_Date, int? PayMethodCode, int? AmountPaid,
          string Amount_in_Words, string Payment_Details, string GrroundRent, string PropertyRates, int _type,
            bool? FinalSubmission, int? PropertyPaymentStatusID, string RejectionComment, string UnlockComment,
            string Added_By, DateTime? Added_Date,bool? UnlockTitle,decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

                if (Location_id == null || OfferNo == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                || string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                || Folio == null || string.IsNullOrEmpty(Payment_Ref_No) || Payment_Ref_No.Contains("null"))
                               
                {
                    result = "Fields marked with asterisk (*) are required!";
                }

                else
                {
                    var approvedpaycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedpaycheckprimkeycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim()));

                    if (approvedpaycheck == null && approvedpaycheckprimkeycheck == null)

                    {

                        Property_Payment approveproppayment = new Property_Payment() { Location_id = Convert.ToInt32(Location_id), OfferNo = Convert.ToInt32(OfferNo), Volume = Volume, Folio = Convert.ToInt32(Folio), Payment_Ref_No = Payment_Ref_No, Title_Reference = Title_Reference };

                        AuditLog_PropertyPayment approveproppaymentlog = new AuditLog_PropertyPayment() { original_Locationid = Convert.ToInt32(Location_id), original_OfferNo = Convert.ToInt32(OfferNo), original_Volume = Volume, original_Folio = Convert.ToInt32(Folio), original_Payment_Ref_No = Payment_Ref_No, original_Title_Reference = Title_Reference };

                        try
                        {
                            //Property_Payment approveproppayment = new Property_Payment();
                            UserManagement user = new UserManagement();
                            approveproppayment.Added_By = user.getCurrentuser();
                            approveproppayment.Added_Date = DateTime.Now;

                            approveproppayment.UnlockTitle = UnlockTitle;
                            approveproppayment.Location_id = Convert.ToInt32(Location_id);
                            approveproppayment.Project_Code = Convert.ToInt32(Project_Code);
                            approveproppayment.Title_Reference = Title_Reference;
                            approveproppayment.Volume = Volume;
                            approveproppayment.Folio = Convert.ToInt32(Folio);
                            approveproppayment.OfferNo = Convert.ToInt32(OfferNo);
                            approveproppayment.Payment_Ref_No = Payment_Ref_No;
                            approveproppayment.Pay_Date = Pay_Date;
                            approveproppayment.PayMethodCode = Convert.ToInt32(PayMethodCode);
                            approveproppayment.AmountPaid = AmountPaid;
                            approveproppayment.Amount_in_Words = Amount_in_Words;
                            approveproppayment.Payment_Details = Payment_Details;
                            approveproppayment.GrroundRent = GrroundRent;
                            approveproppayment.PropertyRates = PropertyRates;

                            approveproppayment.FinalSubmission = FinalSubmission;
                            approveproppayment.PropertyPaymentStatusID = PropertyPaymentStatusID;
                            approveproppayment.RejectionComment = RejectionComment;
                            approveproppayment.UnlockComment = UnlockComment;
                            approveproppayment.Latitude = Convert.ToDouble(Latitude);
                            approveproppayment.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Saving

                            approveproppaymentlog.original_Added_By = user.getCurrentuser();
                            approveproppaymentlog.original_Added_Date = DateTime.Now;

                            approveproppaymentlog.original_UnlockTitle = UnlockTitle;
                            approveproppaymentlog.original_Locationid = Convert.ToInt32(Location_id);
                            approveproppaymentlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            approveproppaymentlog.original_Title_Reference = Title_Reference;
                            approveproppaymentlog.original_Volume = Volume;
                            approveproppaymentlog.original_Folio = Convert.ToInt32(Folio);
                            approveproppaymentlog.original_OfferNo = Convert.ToInt32(OfferNo);
                            approveproppaymentlog.original_Payment_Ref_No = Payment_Ref_No;
                            approveproppaymentlog.original_Pay_Date = Pay_Date;
                            approveproppaymentlog.original_PayMethodCode = Convert.ToInt32(PayMethodCode);
                            approveproppaymentlog.original_AmountPaid = AmountPaid;
                            approveproppaymentlog.original_Amount_in_Words = Amount_in_Words;
                            approveproppaymentlog.original_Payment_Details = Payment_Details;
                            approveproppaymentlog.original_GrroundRent = GrroundRent;
                            approveproppaymentlog.original_PropertyRates = PropertyRates;

                            approveproppaymentlog.original_FinalSubmission = FinalSubmission;
                            approveproppaymentlog.original_PropertyPaymentStatusID = PropertyPaymentStatusID;
                            approveproppaymentlog.original_RejectionComment = RejectionComment;
                            approveproppaymentlog.original_UnlockComment = UnlockComment;
                            approveproppaymentlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approveproppaymentlog.Original_Longitude = Convert.ToDouble(Longitude);

                            db.Property_Payment.Add(approveproppayment);
                            db.AuditLog_PropertyPayment.Add(approveproppaymentlog);

                            
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }
                    else if (approvedpaycheck == null && approvedpaycheckprimkeycheck != null)
                      
                    {

                        result = "Title with the same Location,Offer Number, Volume,Folio and Payment Reference Number arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both freeholdtitlecheck and freeholdprimkeycheck are not null

                    {
                        result = "This title arleady exists in the database (Record not saved)";

                    }

                    }
            }

            else if (_type == 2)
            {

                if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null"))

                {
                    result = "Please enter a Parent Title (Title Reference)!";
                }

                else
                {

                var editapproveproppayment = db.Property_Payment.FirstOrDefault(e => e.Location_id == Location_id && e.OfferNo == e.OfferNo && e.Volume == e.Volume && e.Folio == Folio
                && e.Payment_Ref_No == Payment_Ref_No);

                    var editapproveproppaymentlog = db.AuditLog_PropertyPayment.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_OfferNo == OfferNo && e.original_Volume == Volume && e.original_Folio == Folio
                && e.original_Payment_Ref_No == Payment_Ref_No);

                    if (editapproveproppayment != null)
                {

                    try
                    {
                        UserManagement user = new UserManagement();
                            //editapproveproppayment.Edited_By = user.getCurrentuser();
                            //editapproveproppayment.Edited_Date = DateTime.Now;

                      editapproveproppayment.UnlockedBy = user.getCurrentuser();
                      editapproveproppayment.UnlockDate = DateTime.Now;

                       editapproveproppayment.UnlockTitle = UnlockTitle;

                        editapproveproppayment.Project_Code = Convert.ToInt32(Project_Code);

                        editapproveproppayment.Pay_Date = Pay_Date;
                        editapproveproppayment.PayMethodCode = Convert.ToInt32(PayMethodCode);
                        editapproveproppayment.AmountPaid = AmountPaid;
                        editapproveproppayment.Amount_in_Words = Amount_in_Words;
                        editapproveproppayment.Payment_Details = Payment_Details;
                        editapproveproppayment.GrroundRent = GrroundRent;
                        editapproveproppayment.PropertyRates = PropertyRates;

                        editapproveproppayment.FinalSubmission = FinalSubmission;
                        editapproveproppayment.PropertyPaymentStatusID = PropertyPaymentStatusID;
                        editapproveproppayment.RejectionComment = RejectionComment;
                        editapproveproppayment.UnlockComment = UnlockComment;
                        editapproveproppayment.Latitude = Convert.ToDouble(Latitude);
                        editapproveproppayment.Longitude = Convert.ToDouble(Longitude);

                        editapproveproppayment.Added_By = Added_By;
                        editapproveproppayment.Added_Date = Added_Date;

                            //Audit Log Saving

                            editapproveproppaymentlog.original_UnlockedBy = user.getCurrentuser();
                            editapproveproppaymentlog.original_UnlockDate = DateTime.Now;

                            editapproveproppaymentlog.new_UnlockTitle = UnlockTitle;

                            editapproveproppaymentlog.original_Locationid = Convert.ToInt32(Location_id);
                            editapproveproppaymentlog.original_OfferNo = Convert.ToInt32(OfferNo);
                            editapproveproppaymentlog.original_Payment_Ref_No = Payment_Ref_No;
                            editapproveproppaymentlog.original_Volume = Volume;
                            editapproveproppaymentlog.original_Folio = Convert.ToInt32(Folio);

                            editapproveproppaymentlog.new_Project_Code = Convert.ToInt32(Project_Code);

                            editapproveproppaymentlog.new_Pay_Date = Pay_Date;
                            editapproveproppaymentlog.new_PayMethodCode = Convert.ToInt32(PayMethodCode);
                            editapproveproppaymentlog.new_AmountPaid = AmountPaid;
                            editapproveproppaymentlog.new_Amount_in_Words = Amount_in_Words;
                            editapproveproppaymentlog.new_Payment_Details = Payment_Details;
                            editapproveproppaymentlog.new_GrroundRent = GrroundRent;
                            editapproveproppaymentlog.new_PropertyRates = PropertyRates;

                            editapproveproppaymentlog.new_FinalSubmission = FinalSubmission;
                            editapproveproppaymentlog.new_PropertyPaymentStatusID = PropertyPaymentStatusID;
                            editapproveproppaymentlog.new_RejectionComment = RejectionComment;
                            editapproveproppaymentlog.new_UnlockComment = UnlockComment;
                            editapproveproppaymentlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapproveproppaymentlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapproveproppaymentlog.new_Added_By = Added_By;
                            editapproveproppaymentlog.new_Added_Date = Added_Date;


                            db.Entry(editapproveproppayment).CurrentValues.SetValues(editapproveproppayment);
                            db.Entry(editapproveproppayment).State = EntityState.Modified;

                            db.Entry(editapproveproppaymentlog).CurrentValues.SetValues(editapproveproppaymentlog);
                            db.Entry(editapproveproppaymentlog).State = EntityState.Modified;

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();

                            //result = "Action on " + Title_Reference + "is applied successfully";

                       result = "Action on " + Title_Reference.Trim() + " is applied successfully";

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
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CEOSaveApprovedPropertyPayment(int? Location_id, string Title_Reference, int? Project_Code, string Volume, int? Folio
         , int? OfferNo, string Payment_Ref_No, DateTime? Pay_Date, int? PayMethodCode, int? AmountPaid,
          string Amount_in_Words, string Payment_Details, string GrroundRent, string PropertyRates, int _type,
            bool? FinalSubmission, int? PropertyPaymentStatusID, string RejectionComment, string UnlockComment,
            string Added_By, DateTime? Added_Date, bool? UnlockTitle, decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {
                if (Location_id == null || OfferNo == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                || string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                || Folio == null || string.IsNullOrEmpty(Payment_Ref_No) || Payment_Ref_No.Contains("null"))

                {
                    result = "Fields marked with asterisk (*) are required!";
                }

                else
                {
                    var approvedpaycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var approvedpaycheckprimkeycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim()));

                    if (approvedpaycheck == null && approvedpaycheckprimkeycheck == null)

                    {

                        Property_Payment approveproppayment = new Property_Payment() { Location_id = Convert.ToInt32(Location_id), OfferNo = Convert.ToInt32(OfferNo), Volume = Volume, Folio = Convert.ToInt32(Folio), Payment_Ref_No = Payment_Ref_No, Title_Reference = Title_Reference };


                        try
                        {
                            //Property_Payment approveproppayment = new Property_Payment();
                            UserManagement user = new UserManagement();
                            approveproppayment.Added_By = user.getCurrentuser();
                            approveproppayment.Added_Date = DateTime.Now;

                            approveproppayment.UnlockTitle = UnlockTitle;

                            approveproppayment.Location_id = Convert.ToInt32(Location_id);
                            approveproppayment.Project_Code = Convert.ToInt32(Project_Code);
                            approveproppayment.Title_Reference = Title_Reference;
                            approveproppayment.Volume = Volume;
                            approveproppayment.Folio = Convert.ToInt32(Folio);
                            approveproppayment.OfferNo = Convert.ToInt32(OfferNo);
                            approveproppayment.Payment_Ref_No = Payment_Ref_No;
                            approveproppayment.Pay_Date = Pay_Date;
                            approveproppayment.PayMethodCode = Convert.ToInt32(PayMethodCode);
                            approveproppayment.AmountPaid = AmountPaid;
                            approveproppayment.Amount_in_Words = Amount_in_Words;
                            approveproppayment.Payment_Details = Payment_Details;
                            approveproppayment.GrroundRent = GrroundRent;
                            approveproppayment.PropertyRates = PropertyRates;

                            approveproppayment.FinalSubmission = FinalSubmission;
                            approveproppayment.PropertyPaymentStatusID = PropertyPaymentStatusID;
                            approveproppayment.RejectionComment = RejectionComment;
                            approveproppayment.UnlockComment = UnlockComment;
                            approveproppayment.Latitude = Convert.ToDouble(Latitude);
                            approveproppayment.Longitude = Convert.ToDouble(Longitude);

                            db.Property_Payment.Add(approveproppayment);
                            db.SaveChanges();

                            result = "Record saved successfully ......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (approvedpaycheck == null && approvedpaycheckprimkeycheck != null)

                    {

                        result = "Title with the same Location,Offer Number, Volume,Folio and Payment Reference Number arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both freeholdtitlecheck and freeholdprimkeycheck are not null

                    {
                        result = "This title arleady exists in the database (Record not saved)";

                    }


                }
            }

            else if (_type == 2)
            {
                if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null"))

                {
                    result = "Please enter a Parent Title (Title Reference)!";
                }

                else
                {

                var editapproveproppayment = db.Property_Payment.FirstOrDefault(e => e.Location_id == Location_id && e.OfferNo == e.OfferNo && e.Volume == e.Volume && e.Folio == Folio
                && e.Payment_Ref_No == Payment_Ref_No);

                if (editapproveproppayment != null)
                {
                    try
                    {
                        UserManagement user = new UserManagement();
                        //editapproveproppayment.Edited_By = user.getCurrentuser();
                        // editapproveproppayment.Edited_Date = DateTime.Now;

                        editapproveproppayment.UnlockedBy = user.getCurrentuser();
                        editapproveproppayment.UnlockDate = DateTime.Now;

                        editapproveproppayment.UnlockTitle = UnlockTitle;
                        editapproveproppayment.Project_Code = Convert.ToInt32(Project_Code);

                        editapproveproppayment.Pay_Date = Pay_Date;
                        editapproveproppayment.PayMethodCode = Convert.ToInt32(PayMethodCode);
                        editapproveproppayment.AmountPaid = AmountPaid;
                        editapproveproppayment.Amount_in_Words = Amount_in_Words;
                        editapproveproppayment.Payment_Details = Payment_Details;
                        editapproveproppayment.GrroundRent = GrroundRent;
                        editapproveproppayment.PropertyRates = PropertyRates;

                        editapproveproppayment.FinalSubmission = FinalSubmission;
                        editapproveproppayment.PropertyPaymentStatusID = PropertyPaymentStatusID;
                        editapproveproppayment.RejectionComment = RejectionComment;
                        editapproveproppayment.UnlockComment = UnlockComment;
                        editapproveproppayment.Latitude = Convert.ToDouble(Latitude);
                        editapproveproppayment.Longitude = Convert.ToDouble(Longitude);

                        editapproveproppayment.Added_By = Added_By;
                        editapproveproppayment.Added_Date = Added_Date;

                        db.Entry(editapproveproppayment).CurrentValues.SetValues(editapproveproppayment);
                        db.Entry(editapproveproppayment).State = EntityState.Modified;

                        //db.Entry(editfreehold).State = EntityState.Modified;
                        db.SaveChanges();

                            //result = "Click Ok to close " + Title_Reference + "safely";

                         result = "Action on " + Title_Reference.Trim() + " is applied successfully";


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
               }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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


    }
}

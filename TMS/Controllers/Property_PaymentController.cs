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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class Property_PaymentController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        string Number;
        string deciml;
        string _number;
        string _deciml;
        string[] US = new string[5000];
        string[] SNu = new string[2000];
        string[] SNt = new string[1000];
        // GET: Property_Payment
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;
            
            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.Property_Payment.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lawyers = db.TitleMovements_Lawyers.AsNoTracking().OrderBy(a => a.Lawyers_Desc).ToList();
            ViewBag.lawyers = Lawyers;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;

            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var folios = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            ViewBag.propertytitlesfolios = folios;

            db.Configuration.ProxyCreationEnabled = false;
            var paymethodcodes = db.PayMethods.AsNoTracking().OrderBy(a => a.PayMethodDesc).ToList();
            ViewBag.PayMethodscodes = paymethodcodes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            return View();
           
        }

        public ActionResult DataSourceProperty_Payment(DataManager dm)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Property_Payment.AsNoTracking().ToList();
            int count = 0;
            db.Configuration.ProxyCreationEnabled = false;

            db.Configuration.ProxyCreationEnabled = false;
            data = db.Property_Payment.AsNoTracking().ToList();
            count = db.Property_Payment.AsNoTracking().ToList().Count();

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
               
        public ActionResult DataSourcePropertyPaymentStatus(DataManager dm)
        {
            //Returns all the fields in the table based on the PropertyPaymentStatusID
            var user = User.Identity.Name;
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable data = db.Property_Payment.AsNoTracking().Where(b => ((b.PropertyPaymentStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.Added_By == user))).OrderByDescending(a => a.Added_Date).ToList();
            int count = db.Property_Payment.AsNoTracking().Where(b => ((b.PropertyPaymentStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false) && (b.Added_By == user))).ToList().Count();
                     
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
            o.Project_Code == value.Project_Code && o.Volume == value.Volume &&
            o.Folio == value.Folio && o.OfferNo == value.OfferNo && o.Payment_Ref_No == value.Payment_Ref_No);

            if (table != null)
            {
                UserManagement user = new UserManagement();
                value.Edited_By = user.getCurrentuser();
                value.Edited_Date = DateTime.Now;

                value.PropertyPaymentStatusID = 1;
                value.FinalSubmission = false;
                value.UnlockTitle = false;

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
            else
            {
                this.DialogInsert(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DialogInsert(Property_Payment value)
        {
            Property_Payment table = db.Property_Payment.FirstOrDefault(o =>
            o.Project_Code == value.Project_Code && o.Volume == value.Volume &&
            o.Folio == value.Folio && o.OfferNo == value.OfferNo && o.Payment_Ref_No == value.Payment_Ref_No);

            if (table == null)
            {
                try
                {
                    UserManagement user = new UserManagement();
                    value.Added_By = user.getCurrentuser();
                    value.Added_Date = DateTime.Now;

                    value.PropertyPaymentStatusID = 1;
                    value.FinalSubmission = false;
                    value.UnlockTitle = false;

                    db.Property_Payment.Add(value);
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
            else
            {
                this.DialogUpdate(value);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DialogDelete(int Project_Code, int Folio, string Volume, int OfferNo, string Payment_Ref_No)
        {

            Property_Payment result = db.Property_Payment.Where(o => o.Project_Code == Project_Code &&
            o.Folio == Folio && o.Volume == Volume && o.OfferNo == OfferNo && o.Payment_Ref_No == Payment_Ref_No).FirstOrDefault();
            db.Property_Payment.Remove(result);
            db.SaveChanges();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var _logins = db.A_LoginLog.AsNoTracking().ToList();
            var logins = _logins.Where(o => Convert.ToDateTime(o.LoginDate).Date == DateTime.Now.Date).ToList().Count;
            ViewBag.LogCount = logins;
            
            db.Configuration.ProxyCreationEnabled = false;
            var DataSource = db.Property_Payment.AsNoTracking().ToList();
            ViewBag.datasource = DataSource;

            db.Configuration.ProxyCreationEnabled = false;
            var DestinationTypes = db.DestinationTypes.AsNoTracking().OrderBy(a => a.DestinyDesc).ToList();
            ViewBag.destinationTypes = DestinationTypes;

            db.Configuration.ProxyCreationEnabled = false;
            var MovementPurposes = db.TitleMovement_Purpose.AsNoTracking().OrderBy(a => a.Purpose_Description).ToList();
            ViewBag.movementPurposes = MovementPurposes;

            db.Configuration.ProxyCreationEnabled = false;
            var Lawyers = db.TitleMovements_Lawyers.AsNoTracking().OrderBy(a => a.Lawyers_Desc).ToList();
            ViewBag.lawyers = Lawyers;

            db.Configuration.ProxyCreationEnabled = false;
            var Projects = db.Projects.AsNoTracking().ToList();
            ViewBag.projects = Projects;

            db.Configuration.ProxyCreationEnabled = false;
            var partitles = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            ViewBag.parenttitles = partitles;

            db.Configuration.ProxyCreationEnabled = false;
            var volumes = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();
            ViewBag.propertytitlesvolumes = volumes;

            db.Configuration.ProxyCreationEnabled = false;
            var folios = db.PropertyTitles.AsNoTracking().Select(a => new { a.Project_Code, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            ViewBag.propertytitlesfolios = folios;

            db.Configuration.ProxyCreationEnabled = false;
            var paymethodcodes = db.PayMethods.AsNoTracking().OrderBy(a => a.PayMethodDesc).ToList();
            ViewBag.PayMethodscodes = paymethodcodes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitleMovementStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitleMovementStatus = PropertyTitleMovementStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            return View(db.Property_Payment.ToList());

        }

        public ActionResult GetParent_Title(int Location_id)
        {
            //var result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            var result = db.PropertyTitles.Where(o => o.Location_id == Location_id).Select(a => new { a.Location_id, a.Title_Reference }).Distinct().OrderBy(a => a.Title_Reference).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult GetVolume(int Project_Code)
        public ActionResult GetVolume(string Title_Reference)

        {
            //var result = db.PropertyTitles.Where(o => o.Project_Code == Project_Code).Select(a => new { a.Project_Code, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();

            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference).Select(a => new { a.Title_Reference, a.Volume }).Distinct().OrderBy(a => a.Volume).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFolio(string Title_Reference,string Volume)
        {
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference && o.Volume == Volume).Select(a => new { a.Title_Reference,a.Volume, a.Folio,a.Latitude,a.Longitude }).Distinct().OrderBy(a => a.Folio).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDocument(string Title_Reference, string Volume,int? Folio)
        {
            var result = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.TitleReferenceNo, a.Volume, a.Folio,a.UploadDate }).OrderByDescending(a => a.UploadDate).Take(1);  
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLatitude(string Title_Reference, string Volume, int? Folio)
        {
            var result = db.PropertyTitles.Where(o => o.Title_Reference == Title_Reference && o.Volume == Volume).Select(a => new { a.Title_Reference, a.Volume, a.Folio }).Distinct().OrderBy(a => a.Folio).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SavePropertyPayment(int? Location_id, string Title_Reference,int? Project_Code, string Volume, int? Folio
           , int? OfferNo, string Payment_Ref_No, DateTime? Pay_Date, int? PayMethodCode, int? AmountPaid,
            string Amount_in_Words,string Payment_Details,string GrroundRent, string PropertyRates, int _type,decimal? Latitude,decimal? Longitude)

        {
            string result = string.Empty;

            if (_type == 1)
            {

                //if (Location_id == null || OfferNo == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                //|| Folio == null || string.IsNullOrEmpty(Payment_Ref_No) || Payment_Ref_No.Contains("null") || PayMethodCode == null)

                //{
                //    result = "Fields marked with asterisk (*) are required!";
                //}

                //else
                //{
                    var paycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim() && e.Title_Reference.Trim() == Title_Reference.Trim()));
                    var paycheckprimkeycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim()));

                    if (paycheck == null && paycheckprimkeycheck == null)
                        
                        {

                        Property_Payment proppayment = new Property_Payment() { Location_id = Convert.ToInt32(Location_id), OfferNo = Convert.ToInt32(OfferNo), Volume = Volume, Folio = Convert.ToInt32(Folio), Payment_Ref_No = Payment_Ref_No, Title_Reference = Title_Reference };

                        //Audit_Log Table Check
                        AuditLog_PropertyPayment proppaymentlog = new AuditLog_PropertyPayment() { original_Locationid = Convert.ToInt32(Location_id), original_OfferNo = Convert.ToInt32(OfferNo), original_Volume = Volume, original_Folio = Convert.ToInt32(Folio), original_Payment_Ref_No = Payment_Ref_No, original_Title_Reference = Title_Reference };

                        try
                        {
                          //  Property_Payment proppayment = new Property_Payment();
                            UserManagement user = new UserManagement();
                            proppayment.Added_By = user.getCurrentuser();
                            proppayment.Added_Date = DateTime.Now;
                            proppayment.PropertyPaymentStatusID = 1;
                            proppayment.FinalSubmission = false;
                            proppayment.UnlockTitle = false;

                            proppayment.Location_id = Convert.ToInt32(Location_id);
                            proppayment.Title_Reference = Title_Reference;
                            proppayment.Project_Code = Convert.ToInt32(Project_Code);
                            proppayment.Volume = Volume;
                            proppayment.Folio = Convert.ToInt32(Folio);
                            proppayment.OfferNo = Convert.ToInt32(OfferNo);
                            proppayment.Payment_Ref_No = Payment_Ref_No;
                            proppayment.Pay_Date = Pay_Date;
                            proppayment.PayMethodCode = Convert.ToInt32(PayMethodCode);
                            proppayment.AmountPaid = AmountPaid;
                            proppayment.Amount_in_Words = Amount_in_Words;
                            proppayment.Payment_Details = Payment_Details;
                            proppayment.GrroundRent = GrroundRent;
                            proppayment.PropertyRates = PropertyRates;
                            proppayment.Longitude = Convert.ToDouble(Longitude);
                            proppayment.Latitude = Convert.ToDouble(Latitude);
                        
                            //Audit Log Table Value Savings are Here

                            proppaymentlog.original_Added_By = user.getCurrentuser();
                            proppaymentlog.original_Added_Date = DateTime.Now;
                            proppaymentlog.original_PropertyPaymentStatusID = 1;
                            proppaymentlog.original_FinalSubmission = false;
                            proppaymentlog.original_UnlockTitle = false;


                            proppaymentlog.original_Locationid = Convert.ToInt32(Location_id);
                            proppaymentlog.original_Title_Reference = Title_Reference;
                            proppaymentlog.original_Project_Code = Convert.ToInt32(Project_Code);
                            proppaymentlog.original_Volume = Volume;
                            proppaymentlog.original_Folio = Convert.ToInt32(Folio);
                            proppaymentlog.original_OfferNo = Convert.ToInt32(OfferNo);
                            proppaymentlog.original_Payment_Ref_No = Payment_Ref_No;
                            proppaymentlog.original_Pay_Date = Pay_Date;
                            proppaymentlog.original_PayMethodCode = Convert.ToInt32(PayMethodCode);
                            proppaymentlog.original_AmountPaid = AmountPaid;
                            proppaymentlog.original_Amount_in_Words = Amount_in_Words;
                            proppaymentlog.original_Payment_Details = Payment_Details;
                            proppaymentlog.original_GrroundRent = GrroundRent;
                            proppaymentlog.original_PropertyRates = PropertyRates;
                            proppaymentlog.Original_Latitude = Convert.ToDouble(Longitude);
                            proppaymentlog.Original_Longitude = Convert.ToDouble(Latitude);

                            db.Property_Payment.Add(proppayment);
                            db.AuditLog_PropertyPayment.Add(proppaymentlog);
                            db.SaveChanges();

                            result = "A new title payment has been successfully added......";

                        }
                        catch (DbEntityValidationException /*ex*/)
                        {
                            //result = ex.Message.ToString();

                            result = "This title does not exist. Please check your field entries";
                        }
                    }

                    else if (paycheck == null && paycheckprimkeycheck != null)
                        
                    {
                        //result = "This title arleady exists in the database (Record not saved)";
                        result = "Title with the same Location,Offer Number,Volume,Folio and Payment Reference Number arleady exists in the database (Record not saved)";
                    }
                   
                    else //Check for if both paycheck and paycheckprimkeycheck are not null

                    {                       
                        result = "A payment to this title (" + Title_Reference.Trim()+ ") has arleady been recorded in the database (Record not saved)";
                    }
                  
                //}
            }


            else if (_type == 2)
            {

                var editproppayment = db.Property_Payment.FirstOrDefault(e => e.Location_id == Location_id && e.OfferNo == OfferNo && e.Volume == Volume && e.Folio == Folio
                && e.Payment_Ref_No == Payment_Ref_No);

                var editproppaymentlog = db.AuditLog_PropertyPayment.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_OfferNo == OfferNo && e.original_Volume == Volume && e.original_Folio == Folio
               && e.original_Payment_Ref_No == Payment_Ref_No);

                if (editproppayment != null)
                {

                    try
                    {

                        UserManagement user = new UserManagement();
                        editproppayment.Edited_By = user.getCurrentuser();
                        editproppayment.Edited_Date = DateTime.Now;
                        editproppayment.PropertyPaymentStatusID = 1;
                        editproppayment.FinalSubmission = false;
                        editproppayment.UnlockTitle = false;

                        editproppayment.Title_Reference = Title_Reference;
                        editproppayment.Project_Code = Convert.ToInt32(Project_Code);
                        editproppayment.Pay_Date = Pay_Date;
                        editproppayment.PayMethodCode = Convert.ToInt32(PayMethodCode);
                        editproppayment.AmountPaid = AmountPaid;
                        editproppayment.Amount_in_Words = Amount_in_Words;
                        editproppayment.Payment_Details = Payment_Details;
                        editproppayment.GrroundRent = GrroundRent;
                        editproppayment.PropertyRates = PropertyRates;

                        //Audit_Log Table Saving
                        editproppaymentlog.original_Edited_By = user.getCurrentuser();
                        editproppaymentlog.original_Edited_Date = DateTime.Now;
                        editproppaymentlog.new_PropertyPaymentStatusID = 1;
                        editproppaymentlog.new_FinalSubmission = false;
                        editproppaymentlog.new_UnlockTitle = false;

                        //Primary Keys Edit
                        editproppaymentlog.new_Locationid = Convert.ToInt32(Location_id);
                        editproppaymentlog.new_OfferNo = Convert.ToInt32(OfferNo);
                        editproppaymentlog.new_Volume = Volume;
                        editproppaymentlog.new_Folio = Convert.ToInt32(Folio);
                        editproppaymentlog.new_Payment_Ref_No = Payment_Ref_No;
                        
                        //Primary Keys Edit End

                        editproppaymentlog.new_Title_Reference = Title_Reference;
                        editproppaymentlog.new_Project_Code = Convert.ToInt32(Project_Code);
                        editproppaymentlog.new_Pay_Date = Pay_Date;
                        editproppaymentlog.new_PayMethodCode = Convert.ToInt32(PayMethodCode);
                        editproppaymentlog.new_AmountPaid = AmountPaid;
                        editproppaymentlog.new_Amount_in_Words = Amount_in_Words;
                        editproppaymentlog.new_Payment_Details = Payment_Details;
                        editproppaymentlog.new_GrroundRent = GrroundRent;
                        editproppaymentlog.new_PropertyRates = PropertyRates;
                        editproppaymentlog.New_Latitude = Convert.ToDouble(Longitude);
                        editproppaymentlog.New_Longitude = Convert.ToDouble(Latitude);

                        db.Entry(editproppayment).CurrentValues.SetValues(editproppayment);
                        db.Entry(editproppayment).State = EntityState.Modified;

                        db.Entry(editproppaymentlog).CurrentValues.SetValues(editproppaymentlog);
                        db.Entry(editproppaymentlog).State = EntityState.Modified;
                        

                        //db.Entry(editfreehold).State = EntityState.Modified;
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
                //  }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region "Convert Number to Words"
        public ActionResult NumberToText(string AmountPaid)
        {
            string output = string.Empty;
            SNu[0] = "";
            SNu[1] = "One";
            SNu[2] = "Two";
            SNu[3] = "Three";
            SNu[4] = "Four";
            SNu[5] = "Five";
            SNu[6] = "Six";
            SNu[7] = "Seven";
            SNu[8] = "Eight";
            SNu[9] = "Nine";
            SNu[10] = "Ten";
            SNu[11] = "Eleven";
            SNu[12] = "Twelve";
            SNu[13] = "Thirteen";
            SNu[14] = "Fourteen";
            SNu[15] = "Fifteen";
            SNu[16] = "Sixteen";
            SNu[17] = "Seventeen";
            SNu[18] = "Eighteen";
            SNu[19] = "Nineteen";
            SNt[2] = "Twenty";
            SNt[3] = "Thirty";
            SNt[4] = "Forty";
            SNt[5] = "Fifty";
            SNt[6] = "Sixty";
            SNt[7] = "Seventy";
            SNt[8] = "Eighty";
            SNt[9] = "Ninety";
            US[1] = "";
            US[2] = "Thousand";
            US[3] = "Million";
            US[4] = "Billion";
            US[5] = "Trillion";
            US[6] = "Quadrillion";
            US[7] = "Quintillion";
            US[8] = "Sextillion";
            US[9] = "Septillion";
            US[10] = "Octillion";
            string currency = "Shs. ";
            //string _currency = " Cents Only";
            string _currency = "No amount entered";

            int intPos = -1;
                int i = AmountPaid.Trim().Length;

                intPos = AmountPaid.IndexOf(".");
                

                if (intPos == i - 1)
                {
                    AmountPaid = AmountPaid.Trim() + "00";
                }

                if (intPos == -1)
                {
                    AmountPaid = AmountPaid.Trim() + ".00";
                }
                string[] no = AmountPaid.Split('.');
                if ((no[0] != null) && (no[1] != "00"))
                {
                    Number = no[0];
                    deciml = no[1];
                    _number = (NameOfNumber(Number));
                    _deciml = (NameOfNumber(deciml));

                    output = currency + _number.Trim() + " and " +
                        _deciml.Trim() + _currency;
                }
                if ((no[0] != null) && (no[1] == "00"))
                {
                    Number = no[0];
                    _number = (NameOfNumber(Number));
                    output = currency + _number + "Only";
                }
                if ((Convert.ToDouble(no[0]) == 0) && (no[1] != null))
                {
                    deciml = no[1];
                    _deciml = (NameOfNumber(deciml));
                    output = _deciml + _currency;
                }
            return Json(output, JsonRequestBehavior.AllowGet);
        }

        public string NameOfNumber(string Number)
        {
            string GroupName = "";
            string OutPut = "";

            if ((Number.Length % 3) != 0)
            {
                Number = Number.PadLeft((Number.Length + (3 - (Number.Length % 3))), '0');
            }
            string[] Array = new string[Number.Length / 3];
            Int16 Element = -1;
            Int32 DisplayCount = -1;
            bool LimitGroupsShowAll = false;
            int LimitGroups = 0;
            bool GroupToWords = true;
            for (Int16 Count = 0; Count <= Number.Length - 3; Count += 3)
            {
                Element += 1;
                Array[Element] = Number.Substring(Count, 3);

            }
            if (LimitGroups == 0)
            {
                LimitGroupsShowAll = true;
            }
            for (Int16 Count = 0; (Count <= ((Number.Length / 3) - 1)); Count++)
            {
                DisplayCount++;
                if (((DisplayCount < LimitGroups) || LimitGroupsShowAll))
                {
                    if (Array[Count] == "000") continue;
                    {
                        GroupName = US[((Number.Length / 3) - 1) - Count + 1];
                    }


                    if ((GroupToWords == true))
                    {
                        OutPut += Group(Array[Count]).TrimEnd(' ') + " " +

                            GroupName + " ";

                    }
                    else
                    {
                        OutPut += Array[Count].TrimStart('0') + " " + GroupName;

                    }
                }

            }
            Array = null;
            return OutPut;
        }


        private string Group(string Argument)
        {
            string Hyphen = "";
            string OutPut = "";
            Int16 d1 = Convert.ToInt16(Argument.Substring(0, 1));
            Int16 d2 = Convert.ToInt16(Argument.Substring(1, 1));
            Int16 d3 = Convert.ToInt16(Argument.Substring(2, 1));
            if ((d1 >= 1))
            {
                OutPut += SNu[d1] + " hundred ";
            }
            if ((double.Parse(Argument.Substring(1, 2)) < 20))
            {
                OutPut += SNu[Convert.ToInt16(Argument.Substring(1, 2))];
            }
            if ((double.Parse(Argument.Substring(1, 2)) >= 20))
            {
                if (Convert.ToInt16(Argument.Substring(2, 1)) == 0)
                {
                    Hyphen += " ";
                }
                else
                {
                    Hyphen += " ";
                }
                OutPut += SNt[d2] + Hyphen + SNu[d3];
            }
            return OutPut;
        }
        #endregion

        public ActionResult GetProjectCode1(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        {
            int? data = 0;
            db.Configuration.ProxyCreationEnabled = false;
            var result = db.PropertyTitles.FirstOrDefault(o => o.Location_id == Location_id);
            if (result.Project_Code != null)
            {
                data = result.Project_Code;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectCode(/*int Project_Code,*/ int Location_id, string Title_Reference, string Volume, int Folio)
        {
            
            //var result = db.PropertyTitles.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.Location_id, a.Title_Reference, a.Volume, a.Folio, a.Project_Code, a.Project_Desc }).Distinct().OrderBy
            //    (/*a => a.Project_Code*/a => a.Project_Code).ToList();  //For Ordering by Project Code

            var result = db.ViewPropertyTitlesTables.Where(o => o.Location_id == Location_id && o.Title_Reference == Title_Reference && o.Volume == Volume && o.Folio == Folio).Select(a => new { a.Location_id, a.Title_Reference, a.Volume, a.Folio, a.Project_Code, a.ProjectDesc }).Distinct().OrderBy
               (/*a => a.Project_Code*/a => a.ProjectDesc).ToList();  //For Ordering by Project Description
                return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DataSourceScans(DataManager dm, string Title_Reference, string Volume, int? Folio)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //var _data = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).ToList();   
            var _data = db.View_A_DocumentUpload.Where(o => o.TitleReferenceNo == Title_Reference && o.Volume == Volume && o.Folio == Folio).OrderByDescending(e => e.UploadDate).Take(1);
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

    }
}

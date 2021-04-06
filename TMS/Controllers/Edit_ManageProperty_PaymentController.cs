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
    public class Edit_ManageProperty_PaymentController : Controller
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        string Number;
        string deciml;
        string _number;
        string _deciml;
        string[] US = new string[5000];
        string[] SNu = new string[2000];
        string[] SNt = new string[1000];

        // GET: Edit_ManageProperty_Payment
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

            //var paymethodcodes = db.PayMethods.Select(a => new { a.PayMethodCode, a.PayMethodDesc }).Distinct().OrderBy(a => a.PayMethodDesc).ToList();
            //ViewBag.PayMethodscodes = paymethodcodes;

            db.Configuration.ProxyCreationEnabled = false;
            var paymethodcodes = db.PayMethods.AsNoTracking().OrderBy(a => a.PayMethodDesc).ToList();
            ViewBag.PayMethodscodes = paymethodcodes;

            db.Configuration.ProxyCreationEnabled = false;
            var PropertyTitlePaymentStatus = db.PropertyTitle_Payment_Status.AsNoTracking().ToList();
            ViewBag.PropertyTitlePaymentStatus = PropertyTitlePaymentStatus;

            db.Configuration.ProxyCreationEnabled = false;
            var locations = db.Locations.AsNoTracking().OrderBy(a => a.Location_Desc).ToList();
            ViewBag.Locations = locations;

            return View();
        }

        // GET: Edit_ManageProperty_Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Payment property_Payment = db.Property_Payment.Find(id);
            if (property_Payment == null)
            {
                return HttpNotFound();
            }
            return View(property_Payment);
        }

        // GET: Edit_ManageProperty_Payment/Create
        public ActionResult Create()
        {
            ViewBag.PayMethodCode = new SelectList(db.PayMethods, "PayMethodCode", "PayMethodDesc");
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc");
            ViewBag.Project_Code = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference");
            return View();
        }

        // POST: Edit_ManageProperty_Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_Code,OfferNo,Volume,Folio,Payment_Ref_No,Title_Reference,Pay_Date,PayMethodCode,AmountPaid,Payment_Details,NewDataAudit,EditDataAudit,Added_By,Added_Date,Edited_By,Edited_Date,GrroundRent,PropertyRates")] Property_Payment property_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Property_Payment.Add(property_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PayMethodCode = new SelectList(db.PayMethods, "PayMethodCode", "PayMethodDesc", property_Payment.PayMethodCode);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", property_Payment.Project_Code);
            ViewBag.Project_Code = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference", property_Payment.Project_Code);
            return View(property_Payment);
        }

        // GET: Edit_ManageProperty_Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Payment property_Payment = db.Property_Payment.Find(id);
            if (property_Payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PayMethodCode = new SelectList(db.PayMethods, "PayMethodCode", "PayMethodDesc", property_Payment.PayMethodCode);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", property_Payment.Project_Code);
            ViewBag.Project_Code = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference", property_Payment.Project_Code);
            return View(property_Payment);
        }

        // POST: Edit_ManageProperty_Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_Code,OfferNo,Volume,Folio,Payment_Ref_No,Title_Reference,Pay_Date,PayMethodCode,AmountPaid,Payment_Details,NewDataAudit,EditDataAudit,Added_By,Added_Date,Edited_By,Edited_Date,GrroundRent,PropertyRates")] Property_Payment property_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PayMethodCode = new SelectList(db.PayMethods, "PayMethodCode", "PayMethodDesc", property_Payment.PayMethodCode);
            ViewBag.Project_Code = new SelectList(db.Projects, "Project_id", "Project_Desc", property_Payment.Project_Code);
            ViewBag.Project_Code = new SelectList(db.PropertyTitles, "Project_Code", "Title_Reference", property_Payment.Project_Code);
            return View(property_Payment);
        }

        // GET: Edit_ManageProperty_Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Payment property_Payment = db.Property_Payment.Find(id);
            if (property_Payment == null)
            {
                return HttpNotFound();
            }
            return View(property_Payment);
        }

        // POST: Edit_ManageProperty_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property_Payment property_Payment = db.Property_Payment.Find(id);
            db.Property_Payment.Remove(property_Payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DataSourcePropertyPaymentStatus(DataManager dm)
        {

            db.Configuration.ProxyCreationEnabled = false;
            //IEnumerable data = db.PropertyTitles.Where(b => ((b.TitleMovementStatusID == 1))).OrderByDescending(a => a.Added_Date).ToList();
            IEnumerable data = db.Property_Payment.AsNoTracking().Where(b => ((b.PropertyPaymentStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false))).OrderByDescending(a => a.Added_Date).ToList();

            int count = db.Property_Payment.AsNoTracking().Where(b => ((b.PropertyPaymentStatusID == 1) && (b.FinalSubmission == false) && (b.UnlockTitle == false))).ToList().Count();


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

                value.UnlockTitle = false;

                //value.PropertyPaymentStatusID = 1;
                //value.FinalSubmission = false;

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

                value.UnlockTitle = false;

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

        public JsonResult GetTitleMovementStatus()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.PropertyTitle_Payment_Status.AsNoTracking().Where(a => a.Status_ID == 2).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveApprovePropertyPayment(int? Location_id, string Title_Reference, int? Project_Code, string Volume,
            int? Folio, int? OfferNo, string Payment_Ref_No, DateTime? Pay_Date, int? PayMethodCode, int? AmountPaid,
          string Amount_in_Words, string Payment_Details, string GrroundRent, string PropertyRates, int _type,
            bool? FinalSubmission, int? PropertyPaymentStatusID, string RejectionComment, string UnlockComment,
            string Added_By, DateTime? Added_Date,decimal? Latitude, decimal? Longitude)

        {
            string result = string.Empty;
            if (_type == 1)
            {

                //if (Location_id == null || OfferNo == null || string.IsNullOrEmpty(Volume) || Volume.Contains("null")
                //|| string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null")
                //|| Folio == null || string.IsNullOrEmpty(Payment_Ref_No) || Payment_Ref_No.Contains("null"))

                //{
                //    result = "Fields marked with asterisk (*) are required!";
                //}

                //else
                //{
                    var approveproppaymenttitlecheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() &&
                    e.OfferNo == OfferNo && e.Title_Reference.Trim() == Title_Reference.Trim()) && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim());
                    var approveproppaymentprimkeycheck = db.Property_Payment.FirstOrDefault(e => (e.Location_id == Location_id && e.OfferNo == OfferNo && e.Folio == Folio && e.Volume.Trim() == Volume.Trim() && e.Payment_Ref_No.Trim() == Payment_Ref_No.Trim()));

                    if (approveproppaymenttitlecheck == null && approveproppaymentprimkeycheck == null)
                    {

                        Property_Payment approveproppayment = new Property_Payment()
                        {
                            Location_id = Convert.ToInt32(Location_id),
                            OfferNo = Convert.ToInt32(OfferNo),
                            Volume = Volume,
                            Folio = Convert.ToInt32(Folio),
                            Payment_Ref_No = Payment_Ref_No,
                            Title_Reference = Title_Reference

                        };

                        AuditLog_PropertyPayment approveproppaymentlog = new AuditLog_PropertyPayment()
                        {
                            original_Locationid = Convert.ToInt32(Location_id),
                            original_OfferNo = Convert.ToInt32(OfferNo),
                            original_Volume = Volume,
                            original_Folio = Convert.ToInt32(Folio),
                            original_Payment_Ref_No = Payment_Ref_No,
                            original_Title_Reference = Title_Reference

                        };

                        try
                        {
                            //Property_Payment approveproppayment = new Property_Payment();
                            UserManagement user = new UserManagement();
                            approveproppayment.Added_By = user.getCurrentuser();
                            approveproppayment.Added_Date = DateTime.Now;
                            approveproppayment.PropertyPaymentStatusID = 1;
                            approveproppayment.FinalSubmission = false;
                            approveproppayment.UnlockTitle = false;

                            approveproppayment.Location_id = Convert.ToInt32(Location_id);
                            approveproppayment.Title_Reference = Title_Reference;
                            approveproppayment.Project_Code = Convert.ToInt32(Project_Code);

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
                            approveproppayment.UnlockComment = UnlockComment;
                            approveproppayment.Latitude = Convert.ToDouble(Latitude);
                            approveproppayment.Longitude = Convert.ToDouble(Longitude);

                            //Audit Log Property Payment

                            approveproppaymentlog.original_Added_By = user.getCurrentuser();
                            approveproppaymentlog.original_Added_Date = DateTime.Now;
                            approveproppaymentlog.original_PropertyPaymentStatusID = 1;
                            approveproppaymentlog.original_FinalSubmission = false;
                            approveproppaymentlog.original_UnlockTitle = false;

                            approveproppaymentlog.original_Locationid = Convert.ToInt32(Location_id);
                            approveproppaymentlog.original_Title_Reference = Title_Reference;
                            approveproppaymentlog.original_Project_Code = Convert.ToInt32(Project_Code);

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
                            approveproppaymentlog.original_UnlockComment = UnlockComment;
                            approveproppaymentlog.Original_Latitude = Convert.ToDouble(Latitude);
                            approveproppaymentlog.Original_Longitude = Convert.ToDouble(Longitude);


                            db.Property_Payment.Add(approveproppayment);
                            db.AuditLog_PropertyPayment.Add(approveproppaymentlog);
                            
                            db.SaveChanges();

                            result = "A new title payment has been successfully added......";

                        }
                        catch (DbEntityValidationException ex)
                        {
                            result = ex.Message.ToString();
                        }
                    }

                    else if (approveproppaymenttitlecheck == null && approveproppaymentprimkeycheck != null)

                    {

                        result = "Title with the same Location,Offer Number,Volume,Folio and Payment Reference Number arleady exists in the database (Record not saved)";
                    }

                    else //Check for if both freeholdtitlecheck and freeholdprimkeycheck are not null

                    {
                        result = "This title arleady exists in the database (Record not saved)";

                    }
                //}
            }

            else if (_type == 2)
            {

                //if (string.IsNullOrEmpty(Title_Reference) || Title_Reference.Contains("null"))

                //{
                //    result = "Please enter a Parent Title (Title Reference)!";
                //}

                //else
                //{
                    var editapproveproppayment = db.Property_Payment.FirstOrDefault(e => e.Location_id == Location_id && e.OfferNo == OfferNo && e.Volume == Volume && e.Folio == Folio
                    && e.Payment_Ref_No == Payment_Ref_No);

                    var editapproveproppaymentlog = db.AuditLog_PropertyPayment.FirstOrDefault(e => e.original_Locationid == Location_id && e.original_OfferNo == OfferNo && e.original_Volume == Volume && e.original_Folio == Folio
                    && e.original_Payment_Ref_No == Payment_Ref_No);

                    if (editapproveproppayment != null)
                    {
                        try
                        {
                            UserManagement user = new UserManagement();
                            editapproveproppayment.Edited_By = user.getCurrentuser();
                            editapproveproppayment.Edited_Date = DateTime.Now;

                            editapproveproppayment.UnlockTitle = false;

                            //editapproveproppayment.PropertyPaymentStatusID = 1;
                            //editapproveproppayment.FinalSubmission = false;

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

                            editapproveproppaymentlog.original_Edited_By = user.getCurrentuser();
                            editapproveproppaymentlog.original_Edited_Date = DateTime.Now;

                            editapproveproppaymentlog.new_UnlockTitle = false;

                            editapproveproppaymentlog.new_Locationid = Convert.ToInt32(Location_id);
                            editapproveproppaymentlog.new_OfferNo = Convert.ToInt32(OfferNo);
                            editapproveproppaymentlog.new_Payment_Ref_No = Payment_Ref_No;
                            editapproveproppaymentlog.new_Volume = Volume;
                            editapproveproppaymentlog.new_Folio = Convert.ToInt32(Folio);


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
                            editapproveproppaymentlog.New_Latitude = Convert.ToDouble(Latitude);
                            editapproveproppaymentlog.New_Longitude = Convert.ToDouble(Longitude);

                            editapproveproppaymentlog.original_RejectionComment = RejectionComment;
                            editapproveproppaymentlog.original_UnlockComment = UnlockComment;

                            editapproveproppaymentlog.new_Added_By = Added_By;
                            editapproveproppaymentlog.new_Added_Date = Added_Date;

                            db.Entry(editapproveproppayment).CurrentValues.SetValues(editapproveproppayment);
                            db.Entry(editapproveproppayment).State = EntityState.Modified;

                            db.Entry(editapproveproppaymentlog).CurrentValues.SetValues(editapproveproppaymentlog);
                            db.Entry(editapproveproppaymentlog).State = EntityState.Modified;
                                                        

                            //db.Entry(editfreehold).State = EntityState.Modified;
                            db.SaveChanges();
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
                    //  }
                //}
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


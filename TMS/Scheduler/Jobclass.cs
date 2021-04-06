using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using TMS.Models;

namespace TMS.Scheduler
{
    public class Jobclass : IJob
    {
        NHCC_NHCC_TMSEntities dbcontext = new NHCC_NHCC_TMSEntities();
        public void Execute(IJobExecutionContext context)
        {
            UserManagement user = new UserManagement();
            var clients = dbcontext.View_LeasePeriodNotification.ToList();

            try
            {
               using (var message = new MailMessage("nhccdonotreply@gmail.com", "ssekamj@gmail.com" /*"akayingo@nhcc.co.ug"*//*item.Email*/))
               // using (var message = new MailMessage("tms_nhcc@nhcc.co.ug","tms_grp@nhcc.co.ug"))
                {                   
                    string m = "Dear all, <br/> Please be notified that the following Leases are due to expire: <br/> <br/> <table class='table table-bordered'><tr><td> | </td><td><b> Title Reference</b> </td><td> | </td><td><b> Volume </b></td><td> | </td><td><b>Folio</b></td><td> | </td><td><b> Location</b> </td><td> | </td><td><b> Project</b> </td><td> | </td><td><b>Expiry Date</b></td><td> | </td></tr>";
                    foreach (var item in clients)
                    {
                        m += "<tr><td> | </td><td> " + item.Title_Reference + " </td><td> | </td><td> " + item.Volume + "</td><td> | </td><td>" + item.Folio + "</td><td> | </td><td> " + item.Location_Desc + " </td><td> | </td><td> " + item.Project_Desc + " </td><td> | </td><td>" + item.Lease_End_Date.Value.ToLongDateString() + "</td><td> | </td></tr>";
                    }
                    m += "</table> <br/> Kind Regards, <br/> National Housing and Construction Company <br/> " + DateTime.Now+"<br/><p style='color:red;'></p>"; 
                    message.Subject = "Lease Expiry Notification";
                    message.Body = m;
                    message.IsBodyHtml = true;
                    message.CC.Add("ssekamj@gmail.com");
                    using (SmtpClient client = new SmtpClient
                    {
                        //EnableSsl = true,
                        EnableSsl = false,
                        //Host = "smtp.gmail.com",
                        //Host = "smtp.office365.com",//Office emails
                        Host = "nhccexch.nhcc.co.ug",//NHCC emails
                        Port = 587,
                        //Credentials = new NetworkCredential("nhccdonotreply@gmail.com", "**Root@85")
                        Credentials = new NetworkCredential("tms_nhcc@nhcc.co.ug","Kampala123")
                    })
                    {
                        client.Send(message);
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
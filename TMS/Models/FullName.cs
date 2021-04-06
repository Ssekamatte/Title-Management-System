using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TMS.Models
{
    public class FullName
    {
        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();
        public string GetFullName(string username) {
            string result = string.Empty;
            var user = db.AspNetUsers.FirstOrDefault(o => o.UserName == username);
            if(user != null)
            {
                result = user.NameOfUserAccountHolder;
            }
            return result;
        }
    }
}
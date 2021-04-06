using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using TMS.Models;
using System.Data.Entity.Infrastructure;


namespace TMS.Models
{
    public class ReportsModels
    {
        private int mId;
        private DateTime? mStartTime;
        private DateTime? mEndTime;

        private string mProjectCode;
        private string mPropertyType;
        private string mLeaseType;
        private string mLocation;

        public int Id { get { return mId; } set { mId = value; } }
        public string ProjectCode { get { return mProjectCode; } set { mProjectCode = value; } }
        public string PropertyType { get { return mPropertyType; } set { mPropertyType = value; } }
        public string LeaseType { get { return mLeaseType; } set { mLeaseType = value; } }
        public string Location { get { return Location; } set { Location = value; } }

        public DateTime? StartTime { get { return mStartTime; } set { mStartTime = value; } }
        public DateTime? EndTime { get { return mEndTime; } set { mEndTime = value; } }


        private NHCC_NHCC_TMSEntities db = new NHCC_NHCC_TMSEntities();

        public ObjectResult getTitles()
        {
            using (var context = new NHCC_NHCC_TMSEntities())
            {
                ((IObjectContextAdapter)this.db).ObjectContext.CommandTimeout = 3000;
                var titles = context.spReport_AllPropertyTitlesGetAll(null, null, null, null, null, null, null, null, null);
                return (titles);
                //foreach (Title tt in courses)
                //    Console.WriteLine(cs.titles);
            }
        }


        public ObjectResult<spReport_AllPropertyTitlesGetAll_Result> GetAllProperty()
        {
            try
            {
                ((IObjectContextAdapter)this.db).ObjectContext.CommandTimeout = 3000;
                return db.spReport_AllPropertyTitlesGetAll(mPropertyType, null, null, null, mProjectCode, null, mLeaseType, null, null);
            }
            catch (Exception x)
            {
                throw (x);
            }
        }

        //public ObjectResult<spReport_AllPropertyTitlesGetAll> getAllExport(string TypeDesc, string Title_Reference, string Plot_No, string Project_Desc, string Plan_No, string Block_No, string LandDesc, Boolean? OfferPaidUP, Boolean? approved_activity)
        //{
        //    try
        //    {
        //        return db.spReport_AllPropertyTitlesGetAll(null, null, null, null, null, null, null, null, null);
        //    }
        //    catch (Exception x)
        //    {
        //        throw (x);
        //    }
        //}
    }
}
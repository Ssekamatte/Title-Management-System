//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMS.Models
{
    using System;
    
    public partial class spPropertyApplicantsGetAll_Result
    {
        public string Client_ID { get; set; }
        public string ClientName { get; set; }
        public Nullable<int> Nationality { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Office_Tel { get; set; }
        public string Home_Tel { get; set; }
        public string Mobile_Tel { get; set; }
        public byte[] PassportPhoto { get; set; }
        public string ID_Number { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }
        public Nullable<bool> IsRecordValid { get; set; }
        public Nullable<int> ID_Type { get; set; }
    }
}

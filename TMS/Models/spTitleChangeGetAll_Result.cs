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
    
    public partial class spTitleChangeGetAll_Result
    {
        public int Project_Code { get; set; }
        public int ChangeNo { get; set; }
        public string Volume { get; set; }
        public int Folio { get; set; }
        public string Title_Reference { get; set; }
        public Nullable<byte> TypeCode { get; set; }
        public string Unit_No { get; set; }
        public string Plan_No { get; set; }
        public string Block_No { get; set; }
        public string Flat_N0 { get; set; }
        public Nullable<System.DateTime> Lease_Start_Date { get; set; }
        public Nullable<System.DateTime> Lease_End_Date { get; set; }
        public Nullable<decimal> Ground_Rent { get; set; }
        public Nullable<decimal> Rates { get; set; }
        public string NewDataAudit { get; set; }
        public string EditDataAudit { get; set; }
    }
}

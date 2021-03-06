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
    using System.Collections.Generic;
    
    public partial class PropertyApplicationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropertyApplicationDetail()
        {
            this.PropertyApplications = new HashSet<PropertyApplication>();
        }
    
        public string ReferenceNumber { get; set; }
        public Nullable<int> Project_code { get; set; }
        public string PlotNo { get; set; }
        public string BlockNo { get; set; }
        public string House_Flat_No { get; set; }
        public string UnitNo { get; set; }
        public string Volume { get; set; }
        public Nullable<int> Folio { get; set; }
        public Nullable<int> NumberOfRooms { get; set; }
        public string Title_Reference { get; set; }
        public Nullable<bool> ApplicationAccepted { get; set; }
        public string ApplicationRemarks { get; set; }
        public Nullable<System.DateTime> ApplicationDate { get; set; }
        public Nullable<System.DateTime> DateApplicationRecieved { get; set; }
        public Nullable<bool> OfferAccepted { get; set; }
        public Nullable<System.DateTime> OfferDate { get; set; }
        public Nullable<int> HouseOfferPrice { get; set; }
        public Nullable<int> AmountPaidOnOfferAcceptance { get; set; }
        public Nullable<System.DateTime> OfferAcceptanceOrRejectionDate { get; set; }
        public Nullable<System.DateTime> OfferExpiryDate { get; set; }
        public Nullable<bool> OfferWithdrawn { get; set; }
        public string ReasonForWithdrawal { get; set; }
        public Nullable<System.DateTime> DateOfOfferWithdrawal { get; set; }
        public Nullable<int> PaymentTerms { get; set; }
        public Nullable<bool> TitleTransferred { get; set; }
        public Nullable<System.DateTime> DateOfTitleTransfer { get; set; }
        public Nullable<bool> CommitmentFeePaid { get; set; }
        public Nullable<int> AmountOfCommitmentFeePaid { get; set; }
        public Nullable<int> SalesAndMarketingManager { get; set; }
        public Nullable<int> ChiefCommercialOfficer { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }
        public Nullable<bool> IsRecordValid { get; set; }
        public string OfferAcceptanceOrRejectionReason { get; set; }
    
        public virtual A_ChiefCommunicationsOfficer A_ChiefCommunicationsOfficer { get; set; }
        public virtual A_MarketingManager A_MarketingManager { get; set; }
        public virtual A_NumberOfRooms A_NumberOfRooms { get; set; }
        public virtual A_PaymemtTerms A_PaymemtTerms { get; set; }
        public virtual User_NHCC User_NHCC { get; set; }
        public virtual User_NHCC User_NHCC1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplication> PropertyApplications { get; set; }
    }
}

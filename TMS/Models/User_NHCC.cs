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
    
    public partial class User_NHCC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_NHCC()
        {
            this.PropertyApplicants = new HashSet<PropertyApplicant>();
            this.PropertyApplicants1 = new HashSet<PropertyApplicant>();
            this.PropertyApplicationDetails = new HashSet<PropertyApplicationDetail>();
            this.PropertyApplicationDetails1 = new HashSet<PropertyApplicationDetail>();
            this.PropertyApplications = new HashSet<PropertyApplication>();
            this.PropertyApplications1 = new HashSet<PropertyApplication>();
            this.User_Menu_Option = new HashSet<User_Menu_Option>();
            this.NHCCUserRoles = new HashSet<NHCCUserRole>();
        }
    
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> AccountStatus_ID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplicant> PropertyApplicants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplicant> PropertyApplicants1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplicationDetail> PropertyApplicationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplicationDetail> PropertyApplicationDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplication> PropertyApplications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyApplication> PropertyApplications1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Menu_Option> User_Menu_Option { get; set; }
        public virtual Users_AccountStatus Users_AccountStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHCCUserRole> NHCCUserRoles { get; set; }
    }
}

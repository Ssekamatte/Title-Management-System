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
    
    public partial class TitleMovement_Purpose
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TitleMovement_Purpose()
        {
            this.PropertyTitleMovts = new HashSet<PropertyTitleMovt>();
        }
    
        public int Purpose_ID { get; set; }
        public string Purpose_Description { get; set; }
        public string Added_By { get; set; }
        public Nullable<System.DateTime> Added_Date { get; set; }
        public string Edited_By { get; set; }
        public Nullable<System.DateTime> Edited_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyTitleMovt> PropertyTitleMovts { get; set; }
    }
}

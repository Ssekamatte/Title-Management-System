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
    
    public partial class aspnet_Sessions
    {
        public string SessionId { get; set; }
        public string ApplicationName { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Expires { get; set; }
        public System.DateTime LockDate { get; set; }
        public int LockId { get; set; }
        public int Timeout { get; set; }
        public bool Locked { get; set; }
        public byte[] SessionItems { get; set; }
        public int Flags { get; set; }
    }
}

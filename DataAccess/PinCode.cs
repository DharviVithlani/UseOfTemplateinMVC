//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PinCode
    {
        public int PincodeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Pincode1 { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsConfirm { get; set; }
    
        public virtual User User { get; set; }
    }
}

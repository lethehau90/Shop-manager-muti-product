//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Shop_SettingIphone.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill_customers
    {
        public Bill_customers()
        {
            this.Billdetails = new HashSet<Billdetail>();
        }
    
        public int billid { get; set; }
        public Nullable<int> userid { get; set; }
        public string totalmoney { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<System.DateTime> xdate { get; set; }
        public string request { get; set; }
        public string typepay { get; set; }
        public Nullable<int> state { get; set; }
        public string lang { get; set; }
        public Nullable<int> show { get; set; }
    
        public virtual Custumer Custumer { get; set; }
        public virtual ICollection<Billdetail> Billdetails { get; set; }
    }
}

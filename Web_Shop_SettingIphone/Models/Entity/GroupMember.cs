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
    
    public partial class GroupMember
    {
        public GroupMember()
        {
            this.Members = new HashSet<Member>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Active { get; set; }
        public string NameEn { get; set; }
    
        public virtual ICollection<Member> Members { get; set; }
    }
}
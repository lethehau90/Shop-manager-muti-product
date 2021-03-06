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
    
    public partial class Member
    {
        public Member()
        {
            this.Documents = new HashSet<Document>();
            this.Libraries = new HashSet<Library>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> GroupMemberId { get; set; }
        public Nullable<int> Active { get; set; }
        public string NameEn { get; set; }
        public string Isplace { get; set; }
        public string IsplaceEn { get; set; }
        public string Note { get; set; }
        public string NoteEn { get; set; }
    
        public virtual ICollection<Document> Documents { get; set; }
        public virtual GroupMember GroupMember { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
    }
}

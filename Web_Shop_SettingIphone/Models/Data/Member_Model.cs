using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Member_Model //Hội viên
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int GroupMemberId { get; set; }//Id Nhóm thành viên
        public int Active { get; set; }
        public string NameEn { get; set; }
        public string Isplace { get; set; } //địa điểm
        public string IsplaceEn { get; set; }
        [AllowHtml]
        public string Note { get; set; } //chú thích
        [AllowHtml]
        public string NoteEn { get; set; }
    }
}
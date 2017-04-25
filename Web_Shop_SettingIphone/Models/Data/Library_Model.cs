using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Library_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
        public string File { get; set; }
        public string Info { get; set; }
        public int Priority { get; set; } //Sự ưu tiên
        public int Active { get; set; }
        public int GroupLibraryId { get; set; } //Thư viện nhóm
        public int MemberId { get; set; }  //thanh vien nhom
        public string Lang { get; set; }
        public string LibraryCatTag { get; set; } //danh mục thư viện
        public string NameEn { get; set; }
        public string infoEn { get; set; }
        public string Content { get; set; }
        public string ContetnEn { get; set; }
    }
}
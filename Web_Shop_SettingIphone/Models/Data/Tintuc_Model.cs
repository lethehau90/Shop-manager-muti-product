using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Tintuc_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public Nullable<DateTime> Ngaydang { get; set; }
        [AllowHtml]
        public string Tomtat { get; set; }
        
        [AllowHtml]
        public string Noidung { get; set; }
        public string Tacgia { get; set; }
        public Nullable<int> Luotxem { get; set; }
        public string Hinhanh { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public bool Active { get; set; }
        public int Ord { get; set; }
        public int Type { get; set; } //kiểu loại tin tức, hoặc hỗ trợ
        public Nullable<DateTime> Ngayxemganday { get; set; }
        public string lienkiettinh { get; set; }
        public string NameEn { get; set; }
        
        [AllowHtml]
        public string ContentEn { get; set; }
        
        [AllowHtml]
        public string DetailEn { get; set; }
        public string Nguon { get; set; }
    }
}
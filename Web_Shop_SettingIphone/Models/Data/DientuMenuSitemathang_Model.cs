using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuMenuSitemathang_Model
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Tag { get; set; }
        public string Level { get; set; }
        public string Logogroup { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
        [AllowHtml]
        public string Mota { get; set; }
        public string Url { get; set; }
        public Nullable<int> idThuoctinh { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> Index { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Title { get; set; }
    }
}
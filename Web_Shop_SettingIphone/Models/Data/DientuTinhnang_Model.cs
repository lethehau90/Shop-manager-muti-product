using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuTinhnang_Model
    {
        public int Idthuoctinh { get; set; }
        public string Thuoctinh { get; set; }
        public Nullable<int> Idtinhang { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public Nullable<int> Idthuoctinhselect { get; set; }
    }
}
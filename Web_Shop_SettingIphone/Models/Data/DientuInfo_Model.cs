using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuInfo_Model
    {
        public int Id { get; set; }
        public string Thuonghieu { get; set; }
        public string Dongmay { get; set; }
        public string Soseri { get; set; }
        public string Hovaten { get; set; }
        public string Sodienthoai { get; set; }
        public string Noidungsuachua { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public Nullable<decimal> Giaban { get; set; }
        public Nullable<int> Index { get; set; }
        public Nullable<System.DateTime> Ngaygoi { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Thuonghieu_Model
    {
        public int IDthuonghieu { get; set; }
        public string Tenthuonghieu { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public int Vitri { get; set; }
        public string Lienkettinh { get; set; }

        [AllowHtml]
        public string mota { get; set; }
        
        public string Lang { get; set; }
        public string Tenthuonghieu_En { get; set; }

        [AllowHtml]
        public string mota_En { get; set; }
    }
}
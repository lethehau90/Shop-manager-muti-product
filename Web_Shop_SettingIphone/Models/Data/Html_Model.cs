using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Html_Model // ma trinh bien html web
    {
        public int id { get; set; }
        public int type { get; set; } //nhom thuoc loai
        public int Active { get; set; } //kich hoat
        public string Lang { get; set; }
        public string Ten { get; set; }

        [AllowHtml]
        public string Html_content { get; set; }
        public string TenEn { get; set; }

        [AllowHtml]
        public string Html_contentEn { get; set; }
        public string images { get; set; }
        public int Ord { get; set; }
    }
}
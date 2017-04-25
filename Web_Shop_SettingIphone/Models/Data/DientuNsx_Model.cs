using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuNsx_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Nuocsanxuat_Model
    {
        public int IDNuocsanxuat { get; set; }
        public string TenNuocsanxuat { get; set; }
        public string Logo { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Vitri { get; set; }
        public string TenNuocsanxuat_En { get; set; }
    }
}
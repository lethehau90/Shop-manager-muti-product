using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Mausac_Model
    {
        public int IDmau { get; set; }
        public string Tenmau { get; set; }
        public string Hinhanh { get; set; }
        public string Lang { get; set; }
        public string TenmauEn { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Ord { get; set; }
    
    }
}
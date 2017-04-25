using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Khoanggia_Model
    {
        public int ID { get; set; }
        public string Khoangdau { get; set; }
        public string Khoangcuoi { get; set; }
        public int Vitri { get; set; }
        public bool Active { get; set; }
    }
}
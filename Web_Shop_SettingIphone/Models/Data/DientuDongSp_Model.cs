using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuDongSp_Model
    {
        public int Id { get; set; }
        public Nullable<int> Idnsx { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
    }
}
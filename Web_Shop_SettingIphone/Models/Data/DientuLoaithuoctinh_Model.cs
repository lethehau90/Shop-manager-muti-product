using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuLoaithuoctinh_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Content { get; set; }
    }
}
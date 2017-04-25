using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Even_Date_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string content { get; set; }
        public string contentEn { get; set; }
        public Nullable<System.DateTime> Date_event_start { get; set; }
        public Nullable<System.DateTime> Date_event_end { get; set; }
        public Nullable<int> Price_event { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
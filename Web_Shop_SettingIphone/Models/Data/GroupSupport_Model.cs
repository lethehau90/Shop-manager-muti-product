using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class GroupSupport_Model //nhom support
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ord { get; set; }
        public int Active { get; set; }
        public string Lang { get; set; }
        public string NameEn { get; set; }
    }
}
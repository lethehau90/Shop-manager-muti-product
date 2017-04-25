using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Language_Model
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public bool Default { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
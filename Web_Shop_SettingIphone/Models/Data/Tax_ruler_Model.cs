using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Tax_ruler_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; } //khu vực
        public Nullable<int> Tax_pri { get; set; } //giá trị thuế

        [AllowHtml]
        public string Description { get; set; }
        public string File_tax { get; set; } //file thuế
        public Nullable<int> Ord { get; set; }
        public string NameEn { get; set; }

        [AllowHtml]
        public string DescriptionEn { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Company_Model //công ty
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public int ProvinceId { get; set; } //Tỉnh
        public string NameEn { get; set; }
        public string AddressEn { get; set; }
    }
}
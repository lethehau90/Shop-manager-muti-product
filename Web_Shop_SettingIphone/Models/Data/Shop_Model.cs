using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Shop_Model //cửa hàng
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }//Id Công ty
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
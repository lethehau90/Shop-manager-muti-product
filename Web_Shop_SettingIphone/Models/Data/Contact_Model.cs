using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Contact_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Detail { get; set; }
        public System.DateTime Date { get; set; }
        public int Active { get; set; }
        public string Lang { get; set; }
        public string NameEn { get; set; }
        public string CompanyEn { get; set; }
        public string AddressEn { get; set; }
        public string DetailEn { get; set; }
    }
}
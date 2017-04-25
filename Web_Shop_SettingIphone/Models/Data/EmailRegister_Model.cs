using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class EmailRegister_Model
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public System.DateTime Createdate { get; set; }
        public int Status { get; set; }
    }
}
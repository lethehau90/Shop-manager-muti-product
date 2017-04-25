using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class User_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        public Nullable<int> Admin { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<int> Active { get; set; }
        public string Role { get; set; }
    }
}
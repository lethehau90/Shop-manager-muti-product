using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Advertise_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Link { get; set; }
        public string Target { get; set; }
        
        [AllowHtml]
        public string Content { get; set; }
        public short Position { get; set; } //vị trí quảng cáo trong trang
        public int PageId { get; set; } //Loại Quảng cáo
        public Nullable<int> Click { get; set; }
        public Nullable<int> Ord { get; set; }
        public bool Active { get; set; }
        public string Lang { get; set; }
        public string NameEn { get; set; }
        
        [AllowHtml]
        public string ContentEn { get; set; }
        public Nullable<DateTime> Ngaytao { get; set; }
        public Nullable<DateTime> Ngayhethan { get; set; }
        public Nullable<int> LuotClick { get; set; } 

    }
}
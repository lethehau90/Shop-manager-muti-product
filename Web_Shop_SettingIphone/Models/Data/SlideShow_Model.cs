using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class SlideShow_Model
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
        public short Position { get; set; }//vị trí
        public int Click { get; set; }
        public int Ord { get; set; }
        public bool Active { get; set; }
        public string Lang { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public int Index { get; set; } //chi muc
        public int Priority { get; set; } //Sự ưu tiên
        public string Tag { get; set; }
        public string NameEn { get; set; }
        [AllowHtml]
        public string ContentEn { get; set; }
        [AllowHtml]
        public string DetailEn { get; set; }
    }
}
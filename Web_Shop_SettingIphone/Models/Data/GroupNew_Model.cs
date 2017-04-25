using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class GroupNew_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Level { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public int Ord { get; set; }
        public int Priority { get; set; } //su uu tien trang chủ có hay không
        public int Index { get; set; } //Muc luc (chưa sử dụng)
        public int Active { get; set; }
        public string Lang { get; set; }
        public string Logogroup { get; set; }
        public string NameEn { get; set; }
        public string TitleEn { get; set; }
        public string ImagesLogo { get; set; } //chưa sử dụng
        [AllowHtml]
        public string content { get; set; }
        [AllowHtml]
        public string contentEn { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class GroupNewsNewsDetail_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public Nullable<int> Priority { get; set; }//su uu tien //kiểu loại bình thường hay nổi bật
        public Nullable<int> Index { get; set; } //muc luc 
        public Nullable<int> Active { get; set; } //kich hoat
        public Nullable<int> ord { get; set; }
        public string Nguon { get; set; }
        public string Lang { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string GroupNewsCatTag { get; set; } //nhom tag id
        public string Cateprolevel1 { get; set; } // danh muc lien ket cap 1 (goc)
        public string Cateprolevel2 { get; set; } // danh muc lien ket cap 2 (Cha)
        public string Cateprolevel3 { get; set; } // danh muc lien ket cap 3 (cha-con)
        public string NameEn { get; set; }
        public string ContentEn { get; set; }
        public string DetailEn { get; set; }
        public Nullable<DateTime> DateView { get; set; }
        public Nullable<int> Luotxem { get; set; }
  
    }
}
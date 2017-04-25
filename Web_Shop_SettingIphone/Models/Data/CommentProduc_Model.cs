using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class CommentProduc_Model
    {
        public int Id { get; set; }
        public int ProId { get; set; } //Id san pham
        public string Name { get; set; }
        public string Email { get; set; }
        public int Point { get; set; } //Điểm, danh dau
        
        [AllowHtml]
        public string Content { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public int Active { get; set; }  //kich hoat
        public string Level { get; set; }  //kich hoat
    }
}
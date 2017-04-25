using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Config_Model
    {
        public int Id { get; set; }
        public string Mail_Smtp { get; set; }
        public short Mail_Port { get; set; }
        public string Mail_Info { get; set; }
        public string Mail_Noreply { get; set; } //trả lời
        public string Mail_Password { get; set; }
         [AllowHtml]
        public string PlaceHead { get; set; }

        [AllowHtml]
        public string PlaceBody { get; set; } //chinh sach van chuyen
        public string GoogleId { get; set; }
        public string Contact { get; set; }
         [AllowHtml]
        public string DeliveryTerms { get; set; }//Điều khoản giao hàng
         [AllowHtml]
        public string PaymentTerms { get; set; }//Điều khoản thanh toán
        public double FreeShipping { get; set; }//Miễn phí vận chuyển
          [AllowHtml]
        public string Copyright { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Lang { get; set; }
          [AllowHtml]
        public string Helpsize { get; set; }
        public int Location { get; set; } //Vị trí Seo
         [AllowHtml]
        public string ToolScrip { get; set; }
        public string Icon { get; set; }
        public Nullable<int> pageging1 { get; set; }
        public Nullable<int> pageging2 { get; set; }
        public Nullable<int> pageging3 { get; set; }
        public Nullable<int> pageging4 { get; set; }
        public Nullable<int> pageging5 { get; set; }
    }
}
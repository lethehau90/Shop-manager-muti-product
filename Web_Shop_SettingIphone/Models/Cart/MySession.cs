using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Cart
{
    public class MySession
    {
        public static string IDsanpham
        {
            get { return "0"; }
        }
        public static string TongSL
        {
            get { return "1"; }
        }
        public static string Email
        {
            get { return "2"; }
        }

        public static double? TongTien { get; set; }

        public static List<Products> GioHang { get; set; }

    }
}
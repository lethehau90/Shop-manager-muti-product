using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Donhang_Model
    {
        public int IDhd { get; set; }
        public int IDuser { get; set; } //id user
        public string SDT { get; set; }
        public string Hoten { get; set; }
        public string Mail { get; set; }
        public string Diachi { get; set; }
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xungho { get; set; }
        public string Hinhthucthanhtoan { get; set; }
        public string Goidichvu { get; set; }
        public double Tongtienhang { get; set; }
        public double Thanhtoan { get; set; }
        public System.DateTime ngaydathang { get; set; }
        public string KH { get; set; }
        public string Duyet { get; set; }
        public string Khuyenmai { get; set; }
        public string Hinhthucgiaohang { get; set; }

        [AllowHtml]
        public string GhiChuKhac { get; set; }
        public int Tiengiamgia { get; set; }
    }
}
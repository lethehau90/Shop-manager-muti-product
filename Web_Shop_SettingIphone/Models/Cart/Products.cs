using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Cart
{
    public class Products
    {
        public int? Id { get; set; }
        public int? IDsanpham { get; set; }
        public string TenSanPham { get; set; }
        public string IdTag { get; set; }
        public int? SoLuong { get; set; }
        public double? Giacu { get; set; }
        public double? Giaban { get; set; }
        public string Size { get; set; }
        public string Mausac { get; set; }
        public string Dungluong { get; set; }
        public string IdDungluong { get; set; }
        public string Hinhanh { get; set; }
        public string danhmucsanpham { get; set; }
        public string chitietsanpham { get; set; }
        public double Giamthem { get; set; }
        public int phantramkm { get; set; }
        public string Baohanh { get; set; }
        public string tinhtrang { get; set; }
        public double? TongTien { get; set; }
    }
}
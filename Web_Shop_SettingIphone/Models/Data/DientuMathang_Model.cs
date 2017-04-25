using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuMathang_Model
    {
        public int Id { get; set; }
        public string Seri { get; set; }
        public string Tenhang { get; set; }
        public string Img { get; set; }
        public string ThumImg { get; set; }
        public string Thum_img_img { get; set; }
        public Nullable<int> Idnsx { get; set; }
        public Nullable<double> Giaban { get; set; }
        public Nullable<double> Giamua { get; set; }
        public Nullable<int> Soluongmua { get; set; }
        public Nullable<int> Soluong { get; set; }
        public string Tinhtrang { get; set; }
        public string Donvi { get; set; }
        [AllowHtml]
        public string Baohanh { get; set; }
        public Nullable<System.DateTime> Ngaynhap { get; set; }
        public Nullable<int> Danhgia { get; set; }
        public Nullable<int> Luotxem { get; set; }
        public Nullable<double> Vat { get; set; }
        public string Lienhe { get; set; }
        public string Forder { get; set; }
        [AllowHtml]
        public string Baiviet { get; set; }
        [AllowHtml]
        public string Thongso { get; set; }
        [AllowHtml]
        public string Mota { get; set; }
        public Nullable<double> Giagiam { get; set; }
        public Nullable<double> Phantramkm { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string Khuvuc { get; set; }
        [AllowHtml]
        public string thuoctinh { get; set; }
        [AllowHtml]
        public string khuyenmai { get; set; }
        [AllowHtml]
        public string khuyenmai_html { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<int> Active { get; set; }
        public Nullable<int> Idmenu { get; set; }
        public Nullable<int> Priority { get; set; } //nổi bật,bình thường
        public Nullable<int> Index { get; set; }
        public Nullable<int> Idthuoctinh { get; set; }
        public string Diemdanhgia { get; set; }
        public Nullable<System.DateTime> Ngayxemganday { get; set; }
        public string Tag { get; set; }
        public string GroupNewsCatTag { get; set; }
        public string Cateprolevel1 { get; set; }
        public string Cateprolevel2 { get; set; }
        public string Cateprolevel3 { get; set; }
    }
}
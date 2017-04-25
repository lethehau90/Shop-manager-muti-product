using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class GroupNewMenuSanPhamDetail_Model  //san pham chi tiet theo nhom san pham
    {
        public Nullable<int> Id { get; set; }

        public string Name { get; set; }
        public string NameEn { get; set; }

        public string Tag { get; set; }
        public string IDthuonghieu { get; set; }
        public string NguonSanPham { get; set; }
        public string Mausac { get; set; }
        public string Kichthuoc { get; set; }
        public string SanphamCungloai { get; set; }
        public string Donvi { get; set; }//cai, chiec
        public string Luotdanhgia { get; set; }
        public string Video { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }

        public Nullable<int> Priority { get; set; } //su uu tien
        public Nullable<int> Index { get; set; }
        public Nullable<int> Order { get; set; }  //muc luc
        public Nullable<int> Active { get; set; } //kich hoat

        public string GroupNewsCatTag { get; set; } //nhom tag id
        public string Cateprolevel1 { get; set; } // danh muc lien ket cap 1 (goc)
        public string Cateprolevel2 { get; set; } // danh muc lien ket cap 2 (Cha)
        public string Cateprolevel3 { get; set; } // danh muc lien ket cap 3 (cha-con)

        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        [AllowHtml]
        public string ContentEn { get; set; }

        [AllowHtml]
        public string Detail { get; set; }
        [AllowHtml]
        public string DetailEn { get; set; }

        [AllowHtml]
        public string Khuyenmai { get; set; }
        [AllowHtml]
        public string KhuyenmaiEn { get; set; }

        [AllowHtml]
        public string Baohanh { get; set; }
        [AllowHtml]
        public string BaohanhEn { get; set; }

        [AllowHtml]
        public string DacDiemNoiBat { get; set; }
        [AllowHtml]
        public string DacDiemNoiBatEn { get; set; }


        [AllowHtml]
        public string Thongdiep { get; set; }
        [AllowHtml]
        public string ThongdiepEn { get; set; }


        public string Seri { get; set; }//code seri
        public Nullable<int> Luotxem { get; set; }
        public Nullable<int> Soluongmua { get; set; }
        public Nullable<DateTime> DateCreate { get; set; }
        public Nullable<DateTime> DateView { get; set; }
        
       
        //Giá trị
        public Nullable<int> Stock { get; set; }
        public Nullable<int> Number_Stock { get; set; }
        public bool Vat { get; set; } //thue take

        public Nullable<double> Gianhaphang { get; set; }
        public Nullable<double> Giaban { get; set; }
        public Nullable<int> Phantramkhuyenmai { get; set; }
        public Nullable<double> Giabankhuyenmai { get; set; }

        public Nullable<DateTime> DateStart_Event { get; set; }
        public Nullable<DateTime> DateEnd_Event { get; set; }
        public Nullable<double> Giaban_Event { get; set; }
         [AllowHtml]
        public string Content_Event { get; set; }
         [AllowHtml]
        public string Content_EventEn { get; set; }
    }
}
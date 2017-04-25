using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Command;
using PagedList;
using Web_Shop_SettingIphone.Models.Cart;

namespace Web_Shop_SettingIphone.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        int Resurt;

        public ActionResult Topinfo()
        {
            var data = connect_entity.Htmls.Where(x => x.type == 5 && x.Active == 1).Take(1).ToList();
            return PartialView(data);
        }

        public ActionResult Index()
        {
            try
            {
                int num = MySession.GioHang.Count;
                if (num > 0)
                {
                    return View();
                }
                else
                {
                    return Redirect("/");
                }
            }
            catch
            {
                return Redirect("/");
            }
        }
        public ActionResult mycart()
        {
            try
            {
                int num = MySession.GioHang.Count;
                if (num > 0)
                {
                    return View();
                }
                else
                {
                    return Redirect("/");
                }
            }
            catch
            {
                return Redirect("/");
            }
        }

        #region[Cart]
        //hàm tính lấy giá trị % giảm trong csdl
        public int khuyenmai_sl(int soluong)
        {
            var dbkhuyenmai = connect_entity.quantity_purchased.FirstOrDefault(x => x.Sl_mua == soluong);
            int khuyenmai;
            if (dbkhuyenmai == null)
            {
                khuyenmai = 15;
            }
            else
            {
                khuyenmai = Convert.ToInt32(dbkhuyenmai.Phan_tram_tang);
            }

            return khuyenmai;
        }

        [HttpPost]
        public JsonResult CreatCart(string IDsanpham, string IdDungluong,string IdTag, string TenSanPham, string SoLuong, string Giacu, string Giaban, string Size, string Mausac, string Dungluong,
                                      string Hinhanh, string danhmucsanpham, string chitietsanpham, string Giamthem, string phantramkm, string Baohanh, string tinhtrang)
        {
            MySession.TongTien = 0;
            int id = int.Parse(IDsanpham);
            //Lưu các mã sản phẩm
            string ma = Session[MySession.IDsanpham] + IDsanpham.ToString();
            Session[MySession.IDsanpham] = ma;

            //Số lượng sản phẩm có trong giỏ hàng
            int sl =1 ;//Convert.ToInt32(SoLuong);  /*+ Convert.ToInt32(Session[MySession.TongSL]);*/
            string ms = Mausac;
            string si = "";
            double gc = Convert.ToDouble(Giacu.Replace(",", ""));
            double gb = Convert.ToDouble(Giaban.Replace(",",""));
            int ptkm = phantramkm == "" ? 0 : Convert.ToInt32(phantramkm);
            int bh = Baohanh == "" ? 0 : Convert.ToInt32(Baohanh);
            string tt = tinhtrang;
        
            Session[MySession.TongSL] = sl.ToString();

            // hàm tính trả về các giá trị giảm thêm nếu sl<=1 thì ko giảm ngược lại gọi hàm khuyenmai_sl(sl) để lấy giá trị giảm trong quản trị
           
            var query = (from p in connect_entity.DientuChitiethinhs
                         where p.IdProduct == IDsanpham && p.Idmau == ms && p.IdTag == IdTag && p.Iddungluong == IdDungluong
                         select new Products
                         {
                             IDsanpham = id,
                             IdTag = IdTag,
                             TenSanPham = TenSanPham,
                             SoLuong = sl,
                             Giacu = gc,
                             Giaban = gb,
                             Size = si,
                             Mausac = ms,
                             Dungluong= Dungluong,
                             IdDungluong=IdDungluong,
                             Hinhanh = Hinhanh,
                             danhmucsanpham = "",// p.Cateprolevel3,
                             chitietsanpham = "",//p.Tag,
                             Giamthem = 0,
                             phantramkm = ptkm,
                             Baohanh = Baohanh,
                             tinhtrang = tt,
                             TongTien = gb * sl 
                             ///gán hiển thị % giảm thêm theo cập nhật csdl, khai báo trong model phần tử giamthem
                         }).ToList();

            try
            {
                if(query.Count == 0)
                {
                    Resurt = 0; //trạng thái thành công 
                    return Json(Resurt, JsonRequestBehavior.AllowGet);
                }
                bool flag = false;
                for (int i = 0; i < MySession.GioHang.Count; i++)
                {
                    if (MySession.GioHang[i].IDsanpham == query[0].IDsanpham && MySession.GioHang[i].Mausac == query[0].Mausac && MySession.GioHang[i].Dungluong == query[0].Dungluong)
                    {
                        //double phantramkhuyenmaii;
                        //if (sl <= 1)
                        //{
                        //    phantramkhuyenmaii = 100;
                        //}
                        //else
                        //{
                        //    phantramkhuyenmaii = 100 - khuyenmai_sl(soluong);
                        //}

                        MySession.GioHang[i].SoLuong = sl;//MySession.GioHang[i].SoLuong +

                        MySession.GioHang[i].Giamthem = 0;
                        MySession.GioHang[i].TongTien = MySession.GioHang[i].Giaban * MySession.GioHang[i].SoLuong;// *phantramkhuyenmaii / 100; // * phantramkhuyenmaii / 100;//*phantramkhuyenmai1/100
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    foreach (var s in query)
                    {
                        MySession.GioHang.Add(s);
                    }
                }



                for (int k = 0; k < MySession.GioHang.Count; k++)
                {

                    MySession.TongTien += Convert.ToDouble(MySession.GioHang[k].TongTien.ToString());
                }

                MySession.TongTien = MySession.TongTien;

                //  MySession.TongTien = MySession.TongTien + Convert.ToDouble(query[0].TongTien.ToString());
            }
            catch
            {
                MySession.GioHang = query;
                MySession.TongTien = Convert.ToDouble(query[0].TongTien.ToString());
                Resurt = 1; //trạng thái thành công 
                return Json(Resurt, JsonRequestBehavior.AllowGet);
            }

            Resurt = 1; //trạng thái thành công 
            return Json(Resurt, JsonRequestBehavior.AllowGet);

        }
        #endregion

        public ActionResult CartIcon()
        {
            int tongsoluong = 0;
            if (MySession.GioHang == null)
            {
                tongsoluong = 0;
            }
            else
            {
                for (int i = 0; i < MySession.GioHang.Count; i++)
                {
                    tongsoluong = tongsoluong + Convert.ToInt32(MySession.GioHang[i].SoLuong);

                }
            }
            Session["tsltsl"] = tongsoluong;
            return PartialView();
        }
        //Xóa sản phẩm trong giỏ
        public ActionResult DeleteCart(int id)
        {
            Session[MySession.TongSL] = "0";
            List<Products> lst = new List<Products>();
            int i = 0;
            MySession.TongTien = 0;

            foreach (var s in MySession.GioHang)
            {
                if (MySession.GioHang[i].IDsanpham != id)
                {
                    //double phantramkhuyenmai;
                    //if (MySession.GioHang[i].SoLuong <= 1)
                    //{
                    //    phantramkhuyenmai = 100;
                    //}
                    //else
                    //{
                    //    phantramkhuyenmai = 100 - khuyenmai_sl(Convert.ToInt32(MySession.GioHang[i].SoLuong));
                    //}
                    lst.Add(s);
                    MySession.TongTien = MySession.TongTien + (MySession.GioHang[i].Giaban * MySession.GioHang[i].SoLuong);//* (phantramkhuyenmai / 100)
                    Session[MySession.TongSL] = (Convert.ToInt32(Session[MySession.TongSL]) + MySession.GioHang[i].SoLuong).ToString();
                }
                i++;
            }
            MySession.GioHang = lst;
            if (MySession.GioHang.Count == 0)
            {
                return Redirect("/");
            }
            else
            {
                return Redirect("/gio-hang");
            }
        }

       

        //Cập nhật số lượng sản phẩm trong giỏ
        [HttpPost]
        public JsonResult UpdateCart(string soluonggiohang, string masanphamgiohang)
        {
            try
            {
                if (long.Parse(soluonggiohang) > 32767)
                {
                    Resurt = 1; //trạng thái thành công 
                    return Json(Resurt, JsonRequestBehavior.AllowGet);
                }
                int sl = int.Parse(soluonggiohang);

                int masp = int.Parse(masanphamgiohang);
                Session[MySession.TongSL] = "0";
                MySession.TongTien = 0;
                // hàm tính trả về các giá trị giảm thêm nếu sl<=1 thì ko giảm ngược lại gọi hàm khuyenmai_sl(sl) để lấy giá trị giảm trong quản trị
                
                for (int i = 0; i < MySession.GioHang.Count; i++)
                {
                    if (MySession.GioHang[i].IDsanpham == masp)
                    {
                        if (sl < 1)
                        {
                            MySession.GioHang[i].SoLuong = 1;
                            /// hiển thị cập nhật lại % giảm thêm theo cập nhật csdl
                            MySession.GioHang[i].Giamthem = 0;
                            Session[MySession.TongSL] = ((Convert.ToInt32(Session[MySession.TongSL]) + 1)).ToString();
                            MySession.GioHang[i].TongTien = MySession.GioHang[i].Giaban;
                        }
                        else
                        {
                            MySession.GioHang[i].SoLuong = sl;
                            /// hiển thị cập nhật lại % giảm thêm theo cập nhật csdl
                            MySession.GioHang[i].Giamthem = 0;
                            Session[MySession.TongSL] = ((Convert.ToInt32(Session[MySession.TongSL]) + sl)).ToString();
                            MySession.GioHang[i].TongTien = MySession.GioHang[i].Giaban * sl ;
                        }
                    }
                    else
                    {
                        Session[MySession.TongSL] = ((Convert.ToInt32(Session[MySession.TongSL]) + MySession.GioHang[i].SoLuong)).ToString();

                    }
                    MySession.TongTien = MySession.TongTien + MySession.GioHang[i].TongTien;

                }
            }
            catch (Exception)
            {

                Resurt = 1; //trạng thái thành công 
                return Json(Resurt, JsonRequestBehavior.AllowGet);
            }


            Resurt = 1; //trạng thái thành công 
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }



    }
}

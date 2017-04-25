using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Command;

namespace Web_Shop_SettingIphone.Controllers
{
    public class ScreenProductController : Controller
    {
        //
        // GET: /ScreenProduct/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();


        //public ActionResult Mausac(string tag)
        //{
        //    var data = from a in connect_entity.DientuChitiethinhs
        //               join b in connect_entity.Mausacs
        //               on a.Idmau equals b.IDmau.ToString()
        //               where a.IdProduct == _resurtIdproduct(tag)
        //               select new
        //                   {
        //                       Tenmau = b.Tenmau,
        //                       IDmau = b.IDmau,
        //                       Hinhanh = b.Hinhanh
        //                   };

        //    return PartialView(data);
        //}

        // start Show mau sac 

        public ActionResult Mausac(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.Getmau(IdProduct).ToList();
            return PartialView(data);
        }
        public ActionResult Dungluong()
        {
            var data = connect_entity.DientuDungluongs.OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }

        //hinh anh sap xep thu 1
        public string _resurtImagesmain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return data.Images;
            }
            else
            {
                return "/images/no-image.jpg";
            }
        }
        public string _resurtIdmaumain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return data.Idmau;
            }
            else
            {
                return "0";
            }
        }
        public string _resurtIdDungluongmain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return data.Iddungluong;
            }
            else
            {
                return "0";
            }
        }
        public string _resurtIdTagmain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return data.IdTag;
            }
            else
            {
                return "0";
            }
        }
        public string _resurtIdDungluong(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return data.Iddungluong;
            }
            else
            {
                return "0";
            }
        }
        //gia ban
        public double _resurtPricebanmain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return Convert.ToDouble(data.Giaban);
            }
            else
            {
                return 0;
            }
        }

        //gia cu
        public double _resurtPricecumain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return Convert.ToDouble(data.Giacu);
            }
            else
            {
                return 0;
            }
        }
        //phan tram khuyen mai
        public int _resurtphantramkmcumain(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return Convert.ToInt32(data.Phantramkm);
            }
            else
            {
                return 0;
            }
        }
        //còn hàng-hết hàng
        public string _resurtconhannghethang(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                if (data.Tinhtrang == 0)
                {
                    return "hết hàng";
                }
                else
                    return "còn hàng";
            }
            else
            {
                return "hết hàng";
            }
        }

        //số lượng trong kho
        public int _resurtsoluongtrongkho(string tag)
        {
            string IdProduct = _resurtIdproduct(tag);
            var data = connect_entity.DientuChitiethinhs.OrderBy(x => x.Ord).FirstOrDefault(x => x.IdProduct == IdProduct);
            if (data != null)
            {
                return Convert.ToInt32(data.Soluong);
            }
            else
            {
                return 0;
            }
        }

        public string _resurtIdproduct(string tag)
        {
            var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Tag == tag);
            return data.Id.ToString();
        }
       

        public string _resurtTenmau(int Idmau)
        {
            var data = connect_entity.Mausacs.FirstOrDefault(x => x.IDmau == Idmau);
            return data.Tenmau;
        }
        public string _resurtTenDungluong(int IdDungluong)
        {
            var data = connect_entity.DientuDungluongs.FirstOrDefault(x => x.Id == IdDungluong);
            return data.Name;
        }
        public string _resurtImagesmau(int Idmau)
        {
            var data = connect_entity.Mausacs.FirstOrDefault(x => x.IDmau == Idmau);
            return data.Hinhanh;
        }


        // end Show mau sac 

        //start cấu hình sản phẩm

        public ActionResult Thuoctinh(string tag)
        {
            int IdProduct = Convert.ToInt32(_resurtIdproduct(tag));
            var data = connect_entity.DientuThuoctinhs.Where(x => x.Idproduct == IdProduct).OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }

    }
}

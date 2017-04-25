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
    public class ModuleController : Controller
    {
        //
        // GET: /Module/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Html_Service Connect = new Html_Service();
        public ActionResult logo()
        {
            var data = connect_entity.Advertises.Where(x => x.PageId == 1 && x.Active==true).Take(1).ToList();
            return PartialView(data);
        }
        public ActionResult nav()
        {
            var data = connect_entity.DientuMenuSitemathangs.Where(x => x.Level == null && x.Active == true).ToList();
            string strPath = HttpContext.Request.Url.AbsolutePath;
            string[] s = strPath.Split('/');
            if (s[1] == "tin-tuc" || s[1] == "dich-vu" || s[1] == "san-pham" || s[1] == "ho-tro")
            {
                ViewBag.menu = s[1].ToString();
            }
            else
            {
                ViewBag.menu = "";
            }
            return PartialView(data);
        }
        public ActionResult Menudichvu()
        {
            var data = connect_entity.GroupNews.Where(x => x.Active == 1).OrderBy(x => x.Ord).ToList();
            string strPath = HttpContext.Request.Url.AbsolutePath;
            string[] s = strPath.Split('/');
            if (s[1] == "tin-tuc" || s[1] == "dich-vu" || s[1] == "san-pham" || s[1] == "ho-tro")
            {
                ViewBag.menu = s[1].ToString();
            }
            else
            {
                ViewBag.menu = "";
            }
            return  PartialView(data);
        }
        public ActionResult slider()
        {
            var data = connect_entity.SlideShows.Where(x => x.Active==true).OrderBy(x=>x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult SliderText()
        {
            var data = connect_entity.Htmls.Where(x => x.Active == 1 && x.type==1).Take(1).ToList();
            return PartialView(data);
        }
        //Images quy trình sửa chữa
        public ActionResult Setting_Maintained()
        {
            var data = connect_entity.Advertises.Where(x => x.PageId == 5 && x.Active == true).Take(1).ToList();
            return PartialView(data);
        }
        //bảng đăng ký thông tin bảo trì sửa chữa
        public ActionResult TableRegisterInfo()
        {
            return PartialView();
        }
        //bảng định giá thông tin sản phẩm
        public ActionResult TablePriceInfo()
        {
            return PartialView();
        }
        //dẫn link bảng quảng cáo dịch vụ POSTER
        public ActionResult LinkAdvertiseService()
        {
            var data = connect_entity.Advertises.Where(x => x.PageId == 2 && x.Active == true).Take(1).ToList();
            return PartialView(data);
        }
        //danh mục sản phẩm active trang chủ
        public ActionResult CategoryProductActiveHome()
        {
            var data = connect_entity.DientuMenuSitemathangs.Where(x => x.Active == true && x.Priority == 1).OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult ProductCategoryProductActiveHome(int IdCategory)
        {
            var data = connect_entity.DientuMathangs.Where(x => x.Active == 1 && x.Priority == 2 && x.Idmenu == IdCategory).OrderBy(x => x.Ord).Take(6).ToList();
            return PartialView(data);
        }
        public ActionResult Map() //bản đồ
        {
            var data = connect_entity.Configs.Take(1).ToList();
            return PartialView(data);
        }
        public ActionResult Footer()
        {
            return PartialView();
        }

        //danh mục dịch vụ activce trang chủ
        public ActionResult CategorydichvuActiveHome()
        {
            var data = connect_entity.GroupNews.Where(x => x.Active == 1 && x.Priority == 1).OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult dichvuCategorydichvuActiveHome(string IdCategory)
        {
            var data = connect_entity.GroupNewsNewsDetails.Where(x => x.Active == 1 && x.Priority == 2 && x.GroupNewsCatTag == IdCategory).OrderBy(x => x.ord).Take(6).ToList();
            return PartialView(data);
        }
        public ActionResult dichvuCategorydichvuActiveHome_()
        {
            var data = connect_entity.GroupNewsNewsDetails.Where(x => x.Active == 1 && x.Priority == 2).OrderBy(x => x.ord).Take(6).ToList();
            return PartialView(data);
        }
    }
}

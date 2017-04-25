using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Shop_SettingIphone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //dịch vụ
            routes.MapRoute(
                name: "search",
                url: "tim-kiem",
                defaults: new { controller = "Phone", action = "Search", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Success",
               url: "da-dat-hang",
               defaults: new { controller = "Thanhtoan", action = "Succsess", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "cart",
                url: "gio-hang",
                defaults: new { controller = "cart", action = "mycart", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PhoneIndex",
                url: "dich-vu/{Category_tag}",
                defaults: new { controller = "Phone", action = "PhoneIndex", Category_tag = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PhonedetailIndex",
                url: "dich-vu/{Category_tag}/{tag}",
                defaults: new { controller = "Phone", action = "PhonedetailIndex", Category_tag = UrlParameter.Optional, tag = UrlParameter.Optional }
            );
            //tin tức
            routes.MapRoute(
                name: "PhonenewsIndex",
                url: "tin-tuc",
                defaults: new { controller = "Phone", action = "PhonenewsIndex", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PhonenewsdetailIndex",
                url: "tin-tuc/{tag}",
                defaults: new { controller = "Phone", action = "PhonenewsdetailIndex", tag = UrlParameter.Optional }
            );
            //hỗ trợ
            routes.MapRoute(
                name: "PhonesupportIndex",
                url: "ho-tro",
                defaults: new { controller = "Phone", action = "PhonesupportIndex", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PhonesupportdetailIndex",
                url: "ho-tro/{tag}",
                defaults: new { controller = "Phone", action = "PhonesupportdetailIndex", tag = UrlParameter.Optional }
            );
            //sản phẩm
            routes.MapRoute(
               name: "PhoneProducteIndex",
               url: "san-pham/{Category_tag}",
               defaults: new { controller = "Phone", action = "PhoneProducteIndex", Category_tag = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "PhoneProducteIndexdetail",
               url: "san-pham/{Category_tag}/{tag}",
               defaults: new { controller = "Phone", action = "PhoneProducteIndexdetail", Category_tag = UrlParameter.Optional, tag = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
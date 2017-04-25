using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;
using System.Globalization;

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.Library
{
    public class MenuLeverproductMutiController : Controller
    {
        //
        // GET: /Quanlywebsite/MenuLeverproductMuti/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        public ActionResult MenuLeverMuti_lever1()
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == null).ToList();
            return PartialView(data);
        }

        public ActionResult TK_MenuLeverMuti_lever1()
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == null).ToList();
            return PartialView(data);
        }

        public ActionResult MenuLeverMuti_lever2(string id, string select)
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == id).ToList();
            ViewBag.select = select;
            return PartialView(data);
        }

        public ActionResult MenuLeverMuti_lever3(string id, string select)
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == id).ToList();
            ViewBag.select = select;
            return PartialView(data);
        }

    }
}

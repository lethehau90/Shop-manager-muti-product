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
    public class MenuGroupproductMutiController : Controller
    {
        //
        // GET: /Quanlywebsite/MenuGroupproductMuti/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        public ActionResult Muti_Group_Menu_1()
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == null).ToList();
            return PartialView(data);
        }
        public ActionResult Muti_Group_Menu_2(string Id)
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == Id).ToList();
            return PartialView(data);
        }
        public ActionResult Muti_Group_Menu_3(string Id)
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == Id).ToList();
            return PartialView(data);
        }

    }
}

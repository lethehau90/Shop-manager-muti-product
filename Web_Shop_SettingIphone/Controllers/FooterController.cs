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
    public class FooterController : Controller
    {
        //
        // GET: /Footer/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Html_Service Connect = new Html_Service();
        public ActionResult F_LogoInfo() //thông tin và logo
        {
            var data = connect_entity.Advertises.Where(x => x.PageId == 3 && x.Active == true).Take(1).ToList();
            return PartialView(data);
        }
        public ActionResult F_Top3Service() //3 tin dịch vụ
        {
            var data = connect_entity.GroupNewsNewsDetails.
               Where(x => x.Active == 1  && x.Priority == 2).OrderBy(x => x.ord).Take(3).ToList();
            return PartialView(data);
        }
        public ActionResult F_Top3Product() //3 tin sản phẩm
        {
            var data = connect_entity.DientuMenuSitemathangs.Where(x =>  x.Active == true).Take(3).ToList();
            return PartialView(data);
        }
        public ActionResult F_Top7Contact() //7 tin hỗ trợ
        {
            var data = connect_entity.Tintucs.
               Where(x => x.Active == true  && x.Type == 2)
               .OrderBy(x => x.Ord).Take(7).ToList();
            return PartialView(data);
        }
        public ActionResult F_CopyRight() //bản quyền
        {
            var data = connect_entity.Configs.Take(1).ToList();
            return PartialView(data);
        }
        public ActionResult F_LogoSocialNetwork() //logo mạng xã hội
        {
            var data = connect_entity.Advertises.Where(x => x.PageId == 6 && x.Active == true).OrderBy(x=>x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult F_LogoWebFooter() //logo web cho footer
        {
            var data = connect_entity.Advertises.Where(x => x.PageId == 4 && x.Active == true).Take(1).ToList();
            return PartialView(data);
        }

    }
}

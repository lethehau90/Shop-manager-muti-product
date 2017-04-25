using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;
using Web_Shop_SettingIphone.Models.Command;

namespace Web_Shop_SettingIphone.Controllers
{
    public class AjaxproductController : Controller
    {
        //
        // GET: /Ajaxproduct/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuChitiethinh_Service Connect = new DientuChitiethinh_Service();
        int Resurt;
        public JsonResult AjaxDientuchitiethinh(string Idmau, string Iddungluong, string IdProduct)
        {
            try
            {
                var data = connect_entity.Get_DientuCauhinh().FirstOrDefault(x => x.Idmau == Idmau && x.Iddungluong == Iddungluong && x.IdProduct == IdProduct);
                if(data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
               
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult AjaxDientuchitiethinhProcedure(int Id)
        //{
        //    try
        //    {
        //        var data = connect_entity.AjaxreadProduct().FirstOrDefault(x => x. == Id);
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("", JsonRequestBehavior.AllowGet);
        //    }
        //}

    }
}

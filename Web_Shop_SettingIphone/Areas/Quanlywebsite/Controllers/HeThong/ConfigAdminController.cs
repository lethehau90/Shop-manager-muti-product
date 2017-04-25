using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;
using System.Web.Configuration;
using System.Configuration;

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.HeThong
{
    public class ConfigAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/ConfigAdmin/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Config_Service Connect = new Config_Service();
        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read()
        {
            return View();
        }


        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.Configs.FirstOrDefault(x => x.Id == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]  //Personnel phan quyen
        public JsonResult Update(string Id, string Mail_Smtp, string Mail_Port, string Mail_Info,
            string Mail_Noreply, string Mail_Password, string PlaceHead,
             string PlaceBody, string GoogleId, string Contact, string DeliveryTerms, string PaymentTerms,
             string FreeShipping, string Copyright, string Title, string Description, string Keyword,
             string Lang, string Helpsize, string Location, string ToolScrip, string Icon,
            string pageging1, string pageging2, string pageging3, string pageging4, string pageging5)
        {
            Config_Model data = new Config_Model();//gọi model data
            data.Id = Convert.ToInt16(Id);
            data.Mail_Smtp = Mail_Smtp;
            data.Mail_Smtp = Mail_Smtp;
            data.Mail_Port = Convert.ToInt16(Mail_Port);
            data.Mail_Info = Mail_Info;
            data.Mail_Noreply = Mail_Noreply;
            data.Mail_Password = Mail_Password;
            data.PlaceHead = Server.HtmlDecode(PlaceHead);
            data.PlaceBody = Server.HtmlDecode(PlaceBody);
            data.GoogleId = GoogleId;
            data.Contact = Contact;
            data.DeliveryTerms = Server.HtmlDecode(DeliveryTerms);
            data.PaymentTerms = Server.HtmlDecode(PaymentTerms);
            data.FreeShipping = Convert.ToDouble(FreeShipping);
            data.Copyright = Server.HtmlDecode(Copyright);
            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;
            data.Lang = Lang;
            data.Helpsize = Server.HtmlDecode(Helpsize);
            data.Location = Convert.ToInt16(Location);
            data.ToolScrip = Server.HtmlDecode(ToolScrip);
            data.Icon = Icon;
            data.pageging1 = Convert.ToInt32(pageging1);
            data.pageging2 = Convert.ToInt32(pageging2);
            data.pageging3 = Convert.ToInt32(pageging3);
            data.pageging4 = Convert.ToInt32(pageging4);
            data.pageging5 = Convert.ToInt32(pageging5);

            Connect.Update(data); //gọi service lưu

            //Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Request.ApplicationPath);
            //config.AppSettings.Settings.Remove("pagenews");
            //config.AppSettings.Settings.Add("pagenews", pagenews); //tin tức

            //config.AppSettings.Settings.Remove("pageproduct");
            //config.AppSettings.Settings.Add("pageproduct", pageproduct); //sản phẩm 

            //config.AppSettings.Settings.Remove("pageservice");
            //config.AppSettings.Settings.Add("pageservice", pageservice); //dịch vụ

            //config.AppSettings.Settings.Remove("pagesupport");
            //config.AppSettings.Settings.Add("pagesupport", pagesupport); //hỗ trợ
            //config.Save();


            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

    }
}

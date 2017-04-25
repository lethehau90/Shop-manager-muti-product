using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;
//vi tri // 1: Trang chủ 2: Về Chúng tôi 3: giới thiệu
namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DanhMuc
{
    public class NewInformationAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/HomeNewInformationAdmin/
       
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        information_Service Connect = new information_Service();
        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Readus()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read_info()
        {
            return View();
        }


        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.information.FirstOrDefault(x => x.Index == Id);
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
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Update(string Id, string Name, string Image, string Target,
            string Content, string Detail, string Position,
             string Click, string Ord, string Active, string Lang, string Title,
             string Description, string Keyword, string Image1, string Image2, string Image3,
             string Image4, string Image5, string Index, string Priority, string Tag, string NameEn, string ContentEn, string DetailEn)
        {
            information_Model data = new information_Model();//gọi model data
            data.Id = Convert.ToInt16(Id);
            data.Name = Name;
            data.Image = Image;
            data.Target = Target;
            data.Content = Content;
            data.Detail = Detail;
            data.Position = Convert.ToInt16(Position);
            data.Click = Convert.ToInt32(Click);
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToBoolean(Active);
            data.Lang = Lang;
            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;
            data.Image1 = Image1;
            data.Image2 = Image2;
            data.Image3 = Image3;
            data.Image4 = Image4;
            data.Image5 = Image5;
            data.Index = Convert.ToInt32(Index);
            data.Priority = Convert.ToInt32(Priority);
            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim());
            data.NameEn = NameEn;
            data.ContentEn = ContentEn;
            data.DetailEn = DetailEn;

            Connect.Update(data); //gọi service lưu
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Insert(string Name, string Image, string Target,
            string Content, string Detail, string Position,
             string Click, string Ord, string Active, string Lang, string Title,
             string Description, string Keyword, string Image1, string Image2, string Image3,
             string Image4, string Image5, string Index, string Priority, string Tag, string NameEn, string ContentEn, string DetailEn)
        {
            information_Model data = new information_Model();//gọi model data
            data.Name = Name;
            data.Image = Image;
            data.Target = Target;
            data.Content = Content;
            data.Detail = Detail;
            data.Position = Convert.ToInt16(Position);
            data.Click = Convert.ToInt32(Click);
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToBoolean(Active);
            data.Lang = Lang;
            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;
            data.Image1 = Image1;
            data.Image2 = Image2;
            data.Image3 = Image3;
            data.Image4 = Image4;
            data.Image5 = Image5;
            data.Index = Convert.ToInt32(Index);
            data.Priority = Convert.ToInt32(Priority);
            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim());
            data.NameEn = NameEn;
            data.ContentEn = ContentEn;
            data.DetailEn = DetailEn;

            Connect.Create(data); //gọi service lưu
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }


    }
}

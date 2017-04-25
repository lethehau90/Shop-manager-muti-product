using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DanhMuc
{
    public class CodeHtmlAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/CodeHtmlAdmin/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Html_Service Connect = new Html_Service();
        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = Connect.GetAll().OrderByDescending(x => x.Ten).ToList();
            return View(data);
        }
        /// <summary>
        /// //////////////////Change Active
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Active(int Id)
        {
            int result = ChangeActive(Id);
            return Json(new
            {
                Active = result
            });
        }
       
        // ChangeActive
       
        public int ChangeActive(int Id)
        {
            var data = connect_entity.Htmls.Find(Id);
            if (data.Active == 0)
                data.Active = 1;
            else if (data.Active == 1)
            {
                data.Active = 0;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.Htmls.FirstOrDefault(x => x.id == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Deleteone(int Id)
        {
            Connect.Deleteone(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult DeleteAll(int[] Id)
        {
            Connect.DeleteAll(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }
      
        //thục hiện action Insert

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Insert(string type, string Active, string Lang, string Ten, string Html_content, string TenEn,
                                   string Html_contentEn, string images, string Ord )
        {
            try
            {
                Html_Model model = new Html_Model();//gọi model data
                model.type = Convert.ToInt16(type);
                model.Active = Convert.ToInt16(Active);
                model.Lang = Lang;
                model.Ten = Ten;
                model.Ord = Convert.ToInt32(Ord);
                model.Html_content = Server.HtmlDecode(Html_content);
                model.TenEn = TenEn;
                model.Html_contentEn = Server.HtmlDecode(Html_contentEn);
                model.images = images;
                if (connect_entity.Htmls.FirstOrDefault
                   (x => x.Ten == model.Ten ) == null)// kiểm tra không được trùng tên
                {
                    Connect.Create(model); //gọi service lưu
                    Resurt = 1;
                }
                else
                {
                    Resurt = 0;
                }
                return Json(Resurt, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        //thục hiện action Update
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Update(string id, string type, string Active, string Lang, string Ten, string Html_content, string TenEn,
                                   string Html_contentEn, string images, string Ord)
        {
            try
            {
                Html_Model model = new Html_Model();//gọi model data
                model.id = Convert.ToInt16(id);
                model.type = Convert.ToInt16(type);
                model.Active = Convert.ToInt16(Active);
                model.Lang = Lang;
                model.Ten = Ten;
                model.Ord = Convert.ToInt32(Ord);
                model.Html_content = Server.HtmlDecode(Html_content);
                model.TenEn = TenEn;
                model.Html_contentEn = Server.HtmlDecode(Html_contentEn);
                model.images = images;

                if (connect_entity.Htmls.FirstOrDefault
                   (x => x.Ten == model.Ten && x.id != model.id ) == null)// kiểm tra không được trùng tên
                {
                    Connect.Update(model); //gọi service lưu
                    Resurt = 1;
                }
                else
                {
                    Resurt = 0;
                }

                return Json(Resurt, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }


    }
}

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

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DanhMuc
{
    public class ImagesAdvertiseAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/ImagesAdvertiseAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Advertise_Service Connect = new Advertise_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Advertises.OrderByDescending(x => x.PageId).ToList();
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
            var data = connect_entity.Advertises.Find(Id);
            if (data.Active == false)
                data.Active = true;
            else if (data.Active == true)
            {
                data.Active = false;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.Advertises.FirstOrDefault(x => x.Id == Id);
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
        public ActionResult Insert(string Name, string Image, string Width, string Height, string Link, string Target,
                                   string Content, string Position, string PageId, string Click, string Ord, string Active,
                                   string Lang, string NameEn, string ContentEn, string Ngaytao, string Ngayhethan, string LuotClick)
        {
            Advertise_Model model = new Advertise_Model();//gọi model data
            model.Name = Name;
            model.Image = Image;
            model.Width = Convert.ToInt32(Width);
            model.Height = Convert.ToInt32(Height);
            model.Link = Link;
            model.Target = Target;
            model.Content = Content;
            model.Position = Convert.ToInt16(Position);
            model.PageId = Convert.ToInt32(PageId);
            model.Click = Convert.ToInt32(Click);
            model.Ord = Convert.ToInt32(Ord);
            model.Active = Convert.ToBoolean(Active);
            model.Lang = Lang;
            model.NameEn = NameEn;
            model.ContentEn = ContentEn;

            DateTime DateNgaytao = DateTime.ParseExact(Ngaytao, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            model.Ngaytao = DateNgaytao;
            if (Ngayhethan != "")
            {
                DateTime DateNgayhethan = DateTime.ParseExact(Ngayhethan, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Ngayhethan = DateNgayhethan;
            }
            else
                model.Ngayhethan = null;

            model.LuotClick = Convert.ToInt32(LuotClick);

            if (connect_entity.Advertises.FirstOrDefault
               (x => x.Name == Name) == null)// kiểm tra không được trùng tên
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

        //thục hiện action Update
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Update(string Id, string Name, string Image, string Width, string Height, string Link, string Target,
                                   string Content, string Position, string PageId, string Click, string Ord, string Active,
                                   string Lang, string NameEn, string ContentEn, string Ngaytao, string Ngayhethan, string LuotClick)
        {
            Advertise_Model model = new Advertise_Model();//gọi model data
            model.Id = Convert.ToInt32(Id);
            model.Name = Name;
            model.Image = Image;
            model.Width = Convert.ToInt32(Width);
            model.Height = Convert.ToInt32(Height);
            model.Link = Link;
            model.Target = Target;
            model.Content = Content;
            model.Position = Convert.ToInt16(Position);
            model.PageId = Convert.ToInt32(PageId);
            model.Click = Convert.ToInt32(Click);
            model.Ord = Convert.ToInt32(Ord);
            model.Active = Convert.ToBoolean(Active);
            model.Lang = Lang;
            model.NameEn = NameEn;
            model.ContentEn = ContentEn;

            DateTime DateNgaytao = DateTime.ParseExact(Ngaytao, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            model.Ngaytao = DateNgaytao;
            if (Ngayhethan != "")
            {
                DateTime DateNgayhethan = DateTime.ParseExact(Ngayhethan, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Ngayhethan = DateNgayhethan;
            }
            else
                model.Ngayhethan = null;

            model.LuotClick = Convert.ToInt32(LuotClick);

            if (connect_entity.Advertises.FirstOrDefault
               (x => x.Name == model.Name && x.Id != model.Id) == null)// kiểm tra không được trùng tên
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

    }
}

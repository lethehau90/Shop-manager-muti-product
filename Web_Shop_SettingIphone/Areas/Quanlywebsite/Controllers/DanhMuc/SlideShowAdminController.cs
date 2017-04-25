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
    public class SlideShowAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/SlideShowAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        SlideShow_Service Connect = new SlideShow_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.SlideShows.OrderByDescending(x => x.Name).ToList();
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
            var data = connect_entity.SlideShows.Find(Id);
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
                var data = connect_entity.SlideShows.FirstOrDefault(x => x.Id == Id);
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
                                   string Content, string Position, string Click, string Ord, string Active, string Image3, string Image4,
                                   string Lang, string Detail, string Title, string Description, string Keyword, string Image1, string Image2,
                                 string Image5, string Index, string Priority, string Tag, string NameEn, string ContentEn, string DetailEn)
        {
            SlideShow_Model data = new SlideShow_Model();//gọi model data
            data.Name = Name;
            data.Image = Image;
            data.Width = Convert.ToInt32(Width);
            data.Height = Convert.ToInt32(Height);
            data.Link = Link;
            data.Target = Target;
            data.Content = Content;
            data.Position = Convert.ToInt16(Position);
            data.Click = Convert.ToInt32(Click);
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToBoolean(Active);
            data.Lang = Lang;
            data.Detail = Detail;
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
            data.Tag = Tag;
            data.NameEn = NameEn;
            data.ContentEn = ContentEn;
            data.DetailEn = DetailEn;

            if (connect_entity.SlideShows.FirstOrDefault
                 (x => x.Name == data.Name) == null)// kiểm tra không được trùng tên
            {
                Connect.Create(data); //gọi service lưu
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
                                   string Content, string Position, string Click, string Ord, string Active, string Image3, string Image4,
                                   string Lang, string Detail, string Title, string Description, string Keyword, string Image1, string Image2,
                                 string Image5, string Index, string Priority, string Tag, string NameEn, string ContentEn, string DetailEn)
        {
            SlideShow_Model data = new SlideShow_Model();//gọi model data
            data.Id = Convert.ToInt32(Id);
            data.Name = Name;
            data.Image = Image;
            data.Width = Convert.ToInt32(Width);
            data.Height = Convert.ToInt32(Height);
            data.Link = Link;
            data.Target = Target;
            data.Content = Content;
            data.Position = Convert.ToInt16(Position);
            data.Click = Convert.ToInt32(Click);
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToBoolean(Active);
            data.Lang = Lang;
            data.Detail = Detail;
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
            data.Tag = Tag;
            data.NameEn = NameEn;
            data.ContentEn = ContentEn;
            data.DetailEn = DetailEn;

            if (connect_entity.SlideShows.FirstOrDefault
             (x => x.Name == data.Name && x.Id != data.Id) == null)// kiểm tra không được trùng tên
            {
                Connect.Update(data); //gọi service lưu
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

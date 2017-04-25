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
    public class TinTucAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/TinTucAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Tintuc_Service Connect = new Tintuc_Service();
        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read(string filter)
        {
            var data = connect_entity.Tintucs.OrderByDescending(x => x.Type).ToList();
            
            switch (filter)
            {
                case "highlight": //nổi bật
                    data = data.Where(x => x.Type == 2).ToList();
                    break;
                case "normal": //bình thường
                    data = data.Where(x => x.Type == 1).ToList();
                    break;
                default: //mặt định lấy tất cả
                    data = data.ToList();
                    break;
            }

            ViewBag.Count = data.Count;
            return View(data);
        }

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.Tintucs.FirstOrDefault(x => x.Id == Id);
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
        public JsonResult Insert(string Id, string Name, string Tag, string Ngaydang, string Tomtat, string Noidung,
            string Tacgia, string Luotxem, string Hinhanh,
             string Title, string Description, string Keyword, string Active, string Ord,
             string Type, string Ngayxemganday, string lienkiettinh, string NameEn, string ContentEn,
           string DetailEn, string Nguon)
        {
            Tintuc_Model data = new Tintuc_Model();//gọi model data
            data.Name = Name;
            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim()); ;//Tag;
            data.Ngaydang = null; //xủ lý bên service
            data.Tomtat = Tomtat;
            data.Noidung = Noidung;
            data.Tacgia = Tacgia;
            data.Luotxem = Convert.ToInt32(Luotxem);
            data.Hinhanh = Hinhanh;
            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);
            data.Type = Convert.ToInt32(Type);
            data.Ngayxemganday = null; //xủ lý bên service
            data.lienkiettinh = lienkiettinh;
            data.NameEn = NameEn;
            data.ContentEn = ContentEn;
            data.DetailEn = DetailEn;
            data.Nguon = Nguon;
            if (connect_entity.Tintucs.FirstOrDefault
                   (x => x.Name == data.Name && x.Type == data.Type) == null)// kiểm tra không được trùng tên
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



        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Update(string Id, string Name, string Tag, string Ngaydang, string Tomtat, string Noidung,
            string Tacgia, string Luotxem, string Hinhanh,
             string Title, string Description, string Keyword, string Active, string Ord,
             string Type, string Ngayxemganday, string lienkiettinh, string NameEn, string ContentEn,
           string DetailEn, string Nguon)
                {
                    Tintuc_Model data = new Tintuc_Model();//gọi model data
                    data.Id = Convert.ToInt32(Id);
                    data.Name = Name;
                    data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim()); ;//Tag;
                    data.Ngaydang = null;//xủ lý bên service
                    data.Tomtat = Tomtat;
                    data.Noidung = Noidung;
                    data.Tacgia = Tacgia;
                    data.Luotxem = null; //xủ lý bên service
                    data.Hinhanh = Hinhanh;
                    data.Title = Title;
                    data.Description = Description;
                    data.Keyword = Keyword;
                    data.Active = Convert.ToBoolean(Active);
                    data.Ord = Convert.ToInt32(Ord);
                    data.Type = Convert.ToInt32(Type);
                    data.Ngayxemganday = null; //xủ lý bên service
                    data.lienkiettinh = lienkiettinh;
                    data.NameEn = NameEn;
                    data.ContentEn = ContentEn;
                    data.DetailEn = DetailEn;
                    data.Nguon = Nguon;
                    if (connect_entity.Tintucs.FirstOrDefault
                    (x => x.Name == data.Name && x.Type == data.Type && x.Id != data.Id) == null)// kiểm tra không được trùng tên
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
            var data = connect_entity.Tintucs.Find(Id);
            if (data.Active == false)
                data.Active = true;
            else if (data.Active == true)
            {
                data.Active = false;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }
       
    }
}

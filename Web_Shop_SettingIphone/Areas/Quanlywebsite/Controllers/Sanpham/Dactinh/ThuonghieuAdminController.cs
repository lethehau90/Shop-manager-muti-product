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

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.Sanpham.Dactinh
{
    public class ThuonghieuAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/Thuonghieu/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Thuonghieu_Service Connect = new Thuonghieu_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Thuonghieux.OrderByDescending(x => x.Tenthuonghieu).ToList();
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
            var data = connect_entity.Thuonghieux.Find(Id);
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
                var data = connect_entity.Thuonghieux.FirstOrDefault(x => x.IDthuonghieu == Id);
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
        public ActionResult Insert(string Tenthuonghieu, string Logo, string Url, string Active, string Vitri, string Lienkettinh,
                                   string mota, string Lang, string Tenthuonghieu_En, string mota_En)
        {
            Thuonghieu_Model data = new Thuonghieu_Model();//gọi model data
            data.Tenthuonghieu = Tenthuonghieu;
            data.Logo = Logo;
            data.Url = Url;
            data.Active = Convert.ToBoolean(Active);
            data.Vitri = Convert.ToInt32(Vitri);
            data.Lienkettinh = Lienkettinh;
            data.mota = mota;
            data.Lang = Lang;
            data.Tenthuonghieu_En = Tenthuonghieu_En;
            data.mota_En = mota_En;

            if (connect_entity.Thuonghieux.FirstOrDefault
               (x => x.Tenthuonghieu == Tenthuonghieu) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string IDthuonghieu, string Tenthuonghieu, string Logo, string Url, string Active, string Vitri, string Lienkettinh,
                                   string mota, string Lang, string Tenthuonghieu_En, string mota_En)
        {
            Thuonghieu_Model data = new Thuonghieu_Model();//gọi model data
            data.IDthuonghieu = Convert.ToInt32(IDthuonghieu);
            data.Tenthuonghieu = Tenthuonghieu;
            data.Logo = Logo;
            data.Url = Url;
            data.Active = Convert.ToBoolean(Active);
            data.Vitri = Convert.ToInt32(Vitri);
            data.Lienkettinh = UrlRewrite.GenShortName(data.Tenthuonghieu.Replace(":", "").Trim());
            data.mota = mota;
            data.Lang = Lang;
            data.Tenthuonghieu_En = Tenthuonghieu_En;
            data.mota_En = mota_En;

            if (connect_entity.Thuonghieux.FirstOrDefault
               (x => x.Tenthuonghieu == data.Tenthuonghieu && x.IDthuonghieu != data.IDthuonghieu) == null)// kiểm tra không được trùng tên
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

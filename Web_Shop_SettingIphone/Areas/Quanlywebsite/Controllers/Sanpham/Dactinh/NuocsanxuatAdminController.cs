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
    public class NuocsanxuatAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/NuocsanxuatAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Nuocsanxuat_Service Connect = new Nuocsanxuat_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Nuocsanxuats.OrderByDescending(x => x.TenNuocsanxuat).ToList();
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
            var data = connect_entity.Nuocsanxuats.Find(Id);
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
                var data = connect_entity.Nuocsanxuats.FirstOrDefault(x => x.IDNuocsanxuat == Id);
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
        public ActionResult Insert(string TenNuocsanxuat, string Logo, string Active, string Vitri, string TenNuocsanxuat_En)
        {
            Nuocsanxuat_Model data = new Nuocsanxuat_Model();//gọi model data
            data.TenNuocsanxuat = TenNuocsanxuat;
            data.Logo = Logo;
            data.Active = Convert.ToBoolean(Active);
            data.Vitri = Convert.ToInt32(Vitri);
            data.TenNuocsanxuat_En = TenNuocsanxuat_En;

            if (connect_entity.Nuocsanxuats.FirstOrDefault
               (x => x.TenNuocsanxuat == TenNuocsanxuat) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string IDNuocsanxuat, string TenNuocsanxuat, string Logo, string Active, string Vitri, string TenNuocsanxuat_En)
        {
            Nuocsanxuat_Model data = new Nuocsanxuat_Model();//gọi model data
            data.IDNuocsanxuat = Convert.ToInt32(IDNuocsanxuat);
            data.TenNuocsanxuat = TenNuocsanxuat;
            data.Logo = Logo;
            data.Active = Convert.ToBoolean(Active);
            data.Vitri = Convert.ToInt32(Vitri);
            data.TenNuocsanxuat_En = TenNuocsanxuat_En;

            if (connect_entity.Nuocsanxuats.FirstOrDefault
               (x => x.TenNuocsanxuat == data.TenNuocsanxuat && x.IDNuocsanxuat != data.IDNuocsanxuat) == null)// kiểm tra không được trùng tên
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

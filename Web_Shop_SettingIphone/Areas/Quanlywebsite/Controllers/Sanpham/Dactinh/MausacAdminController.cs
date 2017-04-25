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
    public class MausacAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/Mausac/

        //
        // GET: /Quanlywebsite/ImagesAdvertiseAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Mausac_Service Connect = new Mausac_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Mausacs.OrderByDescending(x => x.IDmau).ToList();
            return View(data);
        }
        /// <summary>
        /// //////////////////Change Active
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
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
            var data = connect_entity.Mausacs.Find(Id);
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
                var data = connect_entity.Mausacs.FirstOrDefault(x => x.IDmau == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult Deleteone(int Id)
        {
            Connect.Deleteone(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult DeleteAll(int[] Id)
        {
            Connect.DeleteAll(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        //thục hiện action Insert

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Insert(string Tenmau, string Hinhanh, string Lang, string TenmauEn, string Active, string Ord)
        {
            Mausac_Model data = new Mausac_Model();//gọi model data
            data.Tenmau =Tenmau;
            data.Hinhanh =Hinhanh;
            data.Lang =Lang;
            data.TenmauEn =TenmauEn;
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);

            if (connect_entity.Mausacs.FirstOrDefault
               (x => x.Tenmau == Tenmau) == null)// kiểm tra không được trùng tên
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
        [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Update(string IDmau, string Tenmau, string Hinhanh, string Lang, string TenmauEn, string Active, string Ord)
        {
            Mausac_Model data = new Mausac_Model();//gọi model data
            data.IDmau = Convert.ToInt32(IDmau);
            data.Tenmau = Tenmau;
            data.Hinhanh = Hinhanh;
            data.Lang = Lang;
            data.TenmauEn = TenmauEn;
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);

            if (connect_entity.Mausacs.FirstOrDefault
               (x => x.Tenmau == data.Tenmau && x.IDmau != data.IDmau) == null)// kiểm tra không được trùng tên
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

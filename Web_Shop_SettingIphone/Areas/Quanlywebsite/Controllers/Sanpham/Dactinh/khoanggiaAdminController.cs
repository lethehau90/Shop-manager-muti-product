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

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.Sanpham.Thongtin
{
    public class khoanggiaAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/khoanggiaAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Khoanggia_Service Connect = new Khoanggia_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Khoanggias.OrderByDescending(x => x.ID).ToList();
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
            var data = connect_entity.Khoanggias.Find(Id);
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
                var data = connect_entity.Khoanggias.FirstOrDefault(x => x.ID == Id);
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
        public ActionResult Insert(string Khoangdau, string Khoangcuoi, string Active, string Ord)
        {
            Khoanggia_Model data = new Khoanggia_Model();//gọi model data
            data.Khoangdau = Khoangdau;
            data.Khoangcuoi = Khoangcuoi;
            data.Active = Convert.ToBoolean(Active);
            data.Vitri = Convert.ToInt32(Ord);

            if (connect_entity.Khoanggias.FirstOrDefault
               (x => x.Khoangdau == Khoangdau && x.Khoangcuoi == Khoangcuoi) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string ID,string Khoangdau, string Khoangcuoi, string Active, string Ord)
        {
            Khoanggia_Model data = new Khoanggia_Model();//gọi model data
            data.ID = Convert.ToInt32(ID);
            data.Khoangdau = Khoangdau;
            data.Khoangcuoi = Khoangcuoi;
            data.Active = Convert.ToBoolean(Active);
            data.Vitri = Convert.ToInt32(Ord);

            if (connect_entity.Khoanggias.FirstOrDefault
               (x => x.Khoangdau == Khoangdau && x.Khoangcuoi == Khoangcuoi && x.ID != data.ID) == null)// kiểm tra không được trùng tên
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

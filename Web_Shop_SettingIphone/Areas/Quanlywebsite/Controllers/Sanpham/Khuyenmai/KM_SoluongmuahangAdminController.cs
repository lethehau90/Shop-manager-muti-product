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

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.Sanpham.Khuyenmai
{
    public class KM_SoluongmuahangAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/KM_SoluongmuahangAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        quantity_purchased_Service Connect = new quantity_purchased_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.quantity_purchased.OrderByDescending(x => x.Id_quantity).OrderBy(x=>x.Sl_mua).ToList();
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
            var data = connect_entity.quantity_purchased.Find(Id);
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
                var data = connect_entity.quantity_purchased.FirstOrDefault(x => x.Id_quantity == Id);
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
        public ActionResult Insert(int Sl_mua, string Phan_tram_tang, string Active)
        {
            quantity_purchased_Model data = new quantity_purchased_Model();//gọi model data
            data.Sl_mua = Convert.ToInt32(Sl_mua);
            data.Phan_tram_tang = Convert.ToInt32(Phan_tram_tang);
            data.Active = Convert.ToBoolean(Active);

            if (connect_entity.quantity_purchased.FirstOrDefault
               (x => x.Sl_mua == Sl_mua) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string Id_quantity, int Sl_mua, string Phan_tram_tang, string Active)
        {
            quantity_purchased_Model data = new quantity_purchased_Model();//gọi model data
            data.Id_quantity = Convert.ToInt32(Id_quantity);
            data.Sl_mua = Sl_mua;
            data.Phan_tram_tang = Convert.ToInt32(Phan_tram_tang);
            data.Active = Convert.ToBoolean(Active);

            if (connect_entity.quantity_purchased.FirstOrDefault
               (x => x.Sl_mua == data.Sl_mua && x.Id_quantity != data.Id_quantity) == null)// kiểm tra không được trùng tên
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

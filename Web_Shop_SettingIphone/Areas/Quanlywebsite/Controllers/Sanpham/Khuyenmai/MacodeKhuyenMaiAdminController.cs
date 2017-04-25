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
    public class MacodeKhuyenMaiAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/MacodeKhuyenMaiAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        MacodeKhuyenMai_Service Connect = new MacodeKhuyenMai_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.MacodeKhuyenMais.OrderByDescending(x => x.ID).ToList();
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
            var data = connect_entity.MacodeKhuyenMais.Find(Id);
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
                var data = connect_entity.MacodeKhuyenMais.FirstOrDefault(x => x.ID == Id);
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
        public ActionResult Insert(string Macode, string Valueprice, string Active)
        {
            MacodeKhuyenMai_Model data = new MacodeKhuyenMai_Model();//gọi model data
            data.Macode = Macode;
            data.Valueprice = Convert.ToInt32(Valueprice);
            data.Active = Convert.ToBoolean(Active);

            if (connect_entity.MacodeKhuyenMais.FirstOrDefault
               (x => x.Macode == Macode) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string ID,string Macode, string Valueprice, string Active)
        {
            MacodeKhuyenMai_Model data = new MacodeKhuyenMai_Model();//gọi model data
            data.ID = Convert.ToInt32(ID);
            data.Macode = Macode;
            data.Valueprice = Convert.ToInt32(Valueprice);
            data.Active = Convert.ToBoolean(Active);

            if (connect_entity.MacodeKhuyenMais.FirstOrDefault
               (x => x.Macode == data.Macode && x.ID != data.ID) == null)// kiểm tra không được trùng tên
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

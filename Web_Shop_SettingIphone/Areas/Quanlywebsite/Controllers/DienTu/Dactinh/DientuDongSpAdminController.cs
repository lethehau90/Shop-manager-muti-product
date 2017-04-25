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


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DienTu.Dactinh
{
    public class DientuDongSpAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/DientuDongSpAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuDongSp_Service Connect = new DientuDongSp_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.DientuDongSps.OrderBy(x => x.Idnsx).ToList();
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
            var data = connect_entity.DientuDongSps.Find(Id);
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
                var data = connect_entity.DientuDongSps.FirstOrDefault(x => x.Id == Id);
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
        public ActionResult Insert(string Idnsx, string Name, string Active, string Ord)
        {
            DientuDongSp_Model data = new DientuDongSp_Model();//gọi model data
            data.Idnsx = Convert.ToInt32(Idnsx);
            data.Name = Name;
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);
           

            if (connect_entity.DientuDongSps.FirstOrDefault
               (x => x.Name == Name) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string Id, string Idnsx, string Name, string Active, string Ord)
        {
            DientuDongSp_Model data = new DientuDongSp_Model();//gọi model data
            data.Id = Convert.ToInt32(Id);
            data.Idnsx = Convert.ToInt32(Idnsx);
            data.Name = Name;
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);

            if (connect_entity.DientuDongSps.FirstOrDefault
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

        public ActionResult MenuLeverMutiThuonghieuDT()
        {
            var data = connect_entity.DientuNsxes.Where(x => x.Active == true).OrderBy(x=>x.Ord).ToList();
            return PartialView(data);
        }
        public String Resurt_namethuonghieudt(int Idnsx)
        {
            var data = connect_entity.DientuNsxes.FirstOrDefault(x => x.Id == Idnsx);
            return data.Name;
        }
    }
}

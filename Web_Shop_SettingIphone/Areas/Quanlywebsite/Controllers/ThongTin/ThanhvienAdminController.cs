using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Command;
using System.Web.Security;

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.ThongTin
{
    public class ThanhvienAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/MemberAdmin/


        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Thanhvien_Service Connect = new Thanhvien_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read_active()
        {
            var data = connect_entity.Thanhviens.Where(x => x.Actice == true).OrderByDescending(x => x.id).ToList();
            return View(data);
        }
        public ActionResult Read_noactive()
        {
            var data = connect_entity.Thanhviens.Where(x => x.Actice == false).OrderByDescending(x => x.id).ToList();
            return View(data);
        }

        public int _count_contace_active()
        {
            var data = connect_entity.Thanhviens.Where(x => x.Actice == true).OrderByDescending(x => x.id).ToList();
            return data.Count;
        }
        public int _count_contace_noactive()
        {
            var data = connect_entity.Thanhviens.Where(x => x.Actice == false).OrderByDescending(x => x.id).ToList();
            return data.Count;
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
            var data = connect_entity.Thanhviens.Find(Id);
            if (data.Actice == false)
                data.Actice = true;
            else if (data.Actice == true)
            {
                data.Actice = false;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Actice);
        }

        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.Thanhviens.FirstOrDefault(x => x.id == Id);
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
       // [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Insert(string Taikhoan, string Matkhau, string Hoten, string Ngaysinh, string Gioitinh, string Diachi,
                                   string SDT, string Email, string Actice, string thutu)
        {
            Thanhvien_Model model = new Thanhvien_Model();//gọi model data
            model.Taikhoan = Taikhoan;
            if (Matkhau == "")
            {
                model.Matkhau = "";
            }
            else
            {
                model.Matkhau = StringClass.Encrypt(Matkhau);
            }
            model.Hoten = Hoten;
            model.Ngaysinh = Convert.ToDateTime(Ngaysinh);

            if (Ngaysinh != "")
            {
                DateTime DateNgaysinh = DateTime.ParseExact(Ngaysinh, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Ngaysinh = DateNgaysinh;
            }
            else
                model.Ngaysinh = null;

            model.Gioitinh = Gioitinh;
            model.Diachi = Diachi;
            model.SDT = SDT;
            model.Email = Email;
            model.Actice = Convert.ToBoolean(Actice);
            model.thutu = Convert.ToInt32(thutu);

            if (connect_entity.Thanhviens.FirstOrDefault
                  (x => x.Email == model.Email && x.Taikhoan == model.Taikhoan) == null)// kiểm tra không được trùng tên
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
        [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Update(string Id, string Taikhoan, string Matkhau, string Hoten, string Ngaysinh, string Gioitinh, string Diachi,
                                   string SDT, string Email, string Actice, string thutu)
        {
            Thanhvien_Model model = new Thanhvien_Model();//gọi model data
            model.id = Convert.ToInt32(Id);
            model.Taikhoan = Taikhoan;
            if(Matkhau =="")
            {
                model.Matkhau = _resurt_Pass(Convert.ToInt32(Id));
            }
            else
            {
                model.Matkhau = StringClass.Encrypt(Matkhau);
            }
            model.Hoten = Hoten;
            model.Ngaysinh = Convert.ToDateTime(Ngaysinh);
           
            if (Ngaysinh != "")
            {
                DateTime DateNgaysinh = DateTime.ParseExact(Ngaysinh, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Ngaysinh = DateNgaysinh;
            }
            else
                model.Ngaysinh = null;

            model.Gioitinh = Gioitinh;
            model.Diachi = Diachi;
            model.SDT = SDT;
            model.Email = Email;
            model.Actice = Convert.ToBoolean(Actice);
            model.thutu = Convert.ToInt32(thutu);
            if (connect_entity.Thanhviens.FirstOrDefault
                   (x => x.Email == model.Email && x.Taikhoan == model.Taikhoan && x.id != model.id) == null)// kiểm tra không được trùng tên
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

        public string _resurt_Pass(int Id)
        {
            var data = connect_entity.Thanhviens.FirstOrDefault(x => x.id == Id);
            return data.Matkhau;
        }


    }
}

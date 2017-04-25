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
    public class Tax_rulerAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/Tax_rulerAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Tax_ruler_Service Connect = new Tax_ruler_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Tax_ruler.OrderByDescending(x => x.Id).ToList();
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
            var data = connect_entity.Tax_ruler.Find(Id);
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
                var data = connect_entity.Tax_ruler.FirstOrDefault(x => x.Id == Id);
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
        public ActionResult Insert(string Name, string Province, string Tax_pri, string Description, string File_tax, string Ord, string NameEn, string DescriptionEn, string Active)
        {
            Tax_ruler_Model data = new Tax_ruler_Model();//gọi model data
            data.Name = Name;
            data.Province = Province;
            data.Description = Description;
            data.File_tax = File_tax;
            data.NameEn = NameEn;
            data.DescriptionEn = DescriptionEn;
            data.Active = Convert.ToBoolean(Active);
            data.Tax_pri = Convert.ToInt32(Tax_pri);
            data.Ord = Convert.ToInt32(Ord);

            if (connect_entity.Tax_ruler.FirstOrDefault
               (x => x.Province == Province && x.Name == Name) == null)// kiểm tra không được trùng tên trùng khu vực
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
        public ActionResult Update(string Id, string Name, string Province, string Tax_pri, string Description, string File_tax, string Ord, string NameEn, string DescriptionEn, string Active)
        {
            Tax_ruler_Model data = new Tax_ruler_Model();//gọi model data
            data.Id = Convert.ToInt32(Id);
            data.Name = Name;
            data.Province = Province;
            data.Description = Description;
            data.File_tax = File_tax;
            data.NameEn = NameEn;
            data.DescriptionEn = DescriptionEn;
            data.Active = Convert.ToBoolean(Active);
            data.Tax_pri = Convert.ToInt32(Tax_pri);
            data.Ord = Convert.ToInt32(Ord);

            if (connect_entity.Tax_ruler.FirstOrDefault
               (x => x.Province == data.Province && x.Name == Name && x.Id != data.Id) == null)// kiểm tra không được trùng tên trùng khu vực
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

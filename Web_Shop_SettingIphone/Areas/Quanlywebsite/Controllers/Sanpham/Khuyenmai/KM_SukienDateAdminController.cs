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
    public class KM_SukienDateAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/Even_DateAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Even_Date_Service Connect = new Even_Date_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.Even_Date.OrderByDescending(x => x.Name).ToList();
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
            var data = connect_entity.Even_Date.Find(Id);
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
                var data = connect_entity.Even_Date.FirstOrDefault(x => x.Id == Id);
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
        public ActionResult Insert(string Name, string NameEn, string content, string contentEn, string Date_event_start, string Date_event_end,
                                   string Price_event, string Ord, string Active)
        {
            Even_Date_Model model = new Even_Date_Model();//gọi model data
            model.Name = Name;
            model.NameEn = NameEn;
            model.content = content;
            model.contentEn = contentEn;
            model.Price_event = Convert.ToInt32(Price_event);
            model.Ord = Convert.ToInt32(Ord);
            model.Active = Convert.ToBoolean(Active);

           
            //event date start
            if (Date_event_start != "")
            {
                DateTime Date_event_start_string = DateTime.ParseExact(Date_event_start, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Date_event_start = Date_event_start_string;
            }
            else
                model.Date_event_start = null;

            //evevnt date end
            if (Date_event_end != "")
            {
                DateTime Date_event_end_string = DateTime.ParseExact(Date_event_end, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Date_event_end = Date_event_end_string;
            }
            else
                model.Date_event_end = null;


            if (connect_entity.Even_Date.FirstOrDefault
               (x => x.Name == Name) == null)// kiểm tra không được trùng tên
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
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Update(string Id, string Name, string NameEn, string content, string contentEn, string Date_event_start, string Date_event_end,
                                   string Price_event, string Ord, string Active)
        {
            Even_Date_Model model = new Even_Date_Model();//gọi model data
            model.Id = Convert.ToInt32(Id);
            model.Name = Name;
            model.NameEn = NameEn;
            model.content = content;
            model.contentEn = contentEn;
            model.Price_event = Convert.ToInt32(Price_event);
            model.Ord = Convert.ToInt32(Ord);
            model.Active = Convert.ToBoolean(Active);


            //event date start
            if (Date_event_start != "")
            {
                DateTime Date_event_start_string = DateTime.ParseExact(Date_event_start, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Date_event_start = Date_event_start_string;
            }
            else
                model.Date_event_start = null;

            //evevnt date end
            if (Date_event_end != "")
            {
                DateTime Date_event_end_string = DateTime.ParseExact(Date_event_end, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                model.Date_event_end = Date_event_end_string;
            }
            else
                model.Date_event_end = null;

            if (connect_entity.Even_Date.FirstOrDefault
               (x => x.Name == model.Name && x.Id != model.Id) == null)// kiểm tra không được trùng tên
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

    }
}

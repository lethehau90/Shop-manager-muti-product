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

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.UserMember
{
    public class ContactAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/ContactAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Contact_Service Connect = new Contact_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read_active()
        {
            var data = connect_entity.Contacts.Where(x=>x.Active==1).OrderByDescending(x => x.Date).ToList();
            return View(data);
        }
        public ActionResult Read_noactive()
        {
            var data = connect_entity.Contacts.Where(x => x.Active == 0).OrderByDescending(x => x.Date).ToList();
            return View(data);
        }

        public int _count_contace_active()
        {
            var data = connect_entity.Contacts.Where(x => x.Active == 1).OrderByDescending(x => x.Date).ToList();
            return data.Count;
        }
        public int _count_contace_noactive()
        {
            var data = connect_entity.Contacts.Where(x => x.Active == 0).OrderByDescending(x => x.Date).ToList();
            return data.Count;
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
            var data = connect_entity.Contacts.Find(Id);
            if (data.Active == 0)
                data.Active = 1;
            else if (data.Active == 1)
            {
                data.Active = 0;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.Contacts.FirstOrDefault(x => x.Id == Id);
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
        public ActionResult Insert(string Name, string Company, string Address, string Tel, string Mail, string Detail,
                                   string Date, string Active, string Lang, string NameEn, string CompanyEn, string AddressEn,string DetailEn)
        {
            Contact_Model model = new Contact_Model();//gọi model data
            model.Name = Name;
            model.Company = Company;

            model.Address = Address;
            model.Tel = Tel;
            model.Mail = Mail;
            model.Detail = Detail;
            model.Date = DateTime.Now;
            model.Active = Convert.ToInt32(Active);
          
            model.Lang = Lang;
            model.NameEn = NameEn;

            model.CompanyEn = CompanyEn;
            model.AddressEn = AddressEn;
            model.DetailEn = DetailEn;

        
                Connect.Create(model); //gọi service lưu
                Resurt = 1;
          
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        //thục hiện action Update
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Update(string Id, string Name, string Company, string Address, string Tel, string Mail, string Detail,
                                   string Date, string Active, string Lang, string NameEn, string CompanyEn, string AddressEn, string DetailEn)
        {
            Contact_Model model = new Contact_Model();//gọi model data
            model.Id = Convert.ToInt32(Id);
            model.Name = Name;
            model.Company = Company;

            model.Address = Address;
            model.Tel = Tel;
            model.Mail = Mail;
            model.Detail = Detail;
            model.Date = DateTime.Now;
            model.Active = Convert.ToInt32(Active);

            model.Lang = Lang;
            model.NameEn = NameEn;

            model.CompanyEn = CompanyEn;
            model.AddressEn = AddressEn;
            model.DetailEn = DetailEn;

        
                Connect.Update(model); //gọi service lưu
                Resurt = 1;
         

            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }


    }
}

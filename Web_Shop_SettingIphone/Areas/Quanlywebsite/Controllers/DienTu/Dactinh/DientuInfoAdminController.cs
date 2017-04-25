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
using System.IO;


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DienTu.Dactinh
{
    public class DientuInfoAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/DientuInfoAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuInfo_Service Connect = new DientuInfo_Service();
        int Resurt;
        /// <summary>
        /// Type cho Mail Sửa chữa
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read_active_type1()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == true && x.Index==1).OrderByDescending(x => x.Ngaygoi).ToList();
            return View(data);
        }
        public ActionResult Read_noactive_type1()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == false && x.Index == 1).OrderByDescending(x => x.Ngaygoi).ToList();
            return View(data);
        }

        public int _count_contace_active_type1()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == true && x.Index == 1).OrderByDescending(x => x.Ngaygoi).ToList();
            return data.Count;
        }
        public int _count_contace_noactive_type1()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == false && x.Index == 1).OrderByDescending(x => x.Ngaygoi).ToList();
            return data.Count;
        }

        ///////

        /// <summary>
        /// /Mail type 2 cho định giá
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read_active_type2()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == true && x.Index == 2).OrderByDescending(x => x.Ngaygoi).ToList();
            return View(data);
        }
        public ActionResult Read_noactive_type2()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == false && x.Index == 2).OrderByDescending(x => x.Ngaygoi).ToList();
            return View(data);
        }

        public int _count_contace_active_type2()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == true && x.Index == 2).OrderByDescending(x => x.Ngaygoi).ToList();
            return data.Count;
        }
        public int _count_contace_noactive_type2()
        {
            var data = connect_entity.DientuInfoes.Where(x => x.Active == false && x.Index == 2).OrderByDescending(x => x.Ngaygoi).ToList();
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
            var data = connect_entity.DientuInfoes.Find(Id);
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
                var data = connect_entity.DientuInfoes.FirstOrDefault(x => x.Id == Id);
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
        //[Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Insert(string Thuonghieu, string Dongmay, string Soseri, string Hovaten, string Sodienthoai, string Noidungsuachua,
                                   string Images1, string Images2, string Giaban, string Index, string Ngaygoi, string Active)
        {
            DientuInfo_Model model = new DientuInfo_Model();//gọi model data
            model.Thuonghieu = Thuonghieu;
            model.Dongmay = Dongmay;
            model.Soseri = Soseri;
            model.Hovaten = Hovaten;
            model.Sodienthoai = Sodienthoai;
            model.Noidungsuachua = Noidungsuachua;
            model.Images1 = Images1;
            model.Images2 = Images2;
            model.Giaban = Convert.ToDecimal(Giaban);
            model.Index = Convert.ToInt32(Index);
            model.Ngaygoi = DateTime.Now;
            model.Active = Convert.ToBoolean(Active);

            Connect.Create(model); //gọi service lưu
            Resurt = 1;

            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        //thục hiện action Update
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Update(string Id,string Thuonghieu, string Dongmay, string Soseri, string Hovaten, string Sodienthoai, string Noidungsuachua,
                                   string Images1, string Images2, string Giaban, string Index, string Ngaygoi, string Active)
        {
            DientuInfo_Model model = new DientuInfo_Model();//gọi model data
            model.Id = Convert.ToInt32(Id);
            model.Thuonghieu = Thuonghieu;
            model.Dongmay = Dongmay;
            model.Soseri = Soseri;
            model.Hovaten = Hovaten;
            model.Sodienthoai = Sodienthoai;
            model.Noidungsuachua = Noidungsuachua;
            model.Images1 = Images1;
            model.Images2 = Images2;
            model.Giaban = Convert.ToDecimal(Giaban);
            model.Index = Convert.ToInt32(Index);
            model.Ngaygoi = Resurt_Date_Create(Convert.ToInt32(Id));
            model.Active = Convert.ToBoolean(Active);

            Connect.Update(model); //gọi service lưu
            Resurt = 1;


            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }
        public DateTime Resurt_Date_Create(int id) //id is key of DientuMathangs
        {
            var data = connect_entity.DientuInfoes.FirstOrDefault(x => x.Id == id);
            return Convert.ToDateTime(data.Ngaygoi);
        }
    }
}

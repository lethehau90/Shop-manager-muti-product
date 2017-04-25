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


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DienTu.Thuoctinh
{
    public class DientuChitiethinhAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/DientuChitiethinhAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuChitiethinh_Service Connect = new DientuChitiethinh_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.DientuChitiethinhs.OrderByDescending(x => x.Id).ToList();
            return View(data);
        }
        /// <summary>
        /// //////////////////Change Active
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult Active(string IdTag)
        {
            int result = ChangeActive(IdTag);
            return Json(new
            {
                Active = result
            });
        }

        // ChangeActive

        public int ChangeActive(string IdTag)
        {
            var data = connect_entity.DientuChitiethinhs.FirstOrDefault(x => x.IdTag == IdTag);
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
                var data = connect_entity.DientuChitiethinhs.FirstOrDefault(x => x.Id == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Get_Read_Idtag(string IdTag)
        {
            try
            {
                var data = connect_entity.DientuChitiethinhs.FirstOrDefault(x => x.IdTag == IdTag);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Get_ReadCH(string Idproduct)
        {
            try
            {
                var data = connect_entity.Get_DientuCauhinh().Where(x => x.IdProduct == Idproduct).ToList();
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
        public JsonResult Deleteone(string IdTag)
        {
            Connect.Deleteone(IdTag);
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
        public ActionResult Insert(string IdProduct, string Images, string ThumImg, string Idmau,string Iddungluong, string IdSize, string Giaban
                                   , string Giacu, string Soluong, string Phantramkm, string Tinhtrang, string Active, string Ord,
                                   string Images1, string Images2, string Images3, string Images4)
        {
            DientuChitiethinh_Model data = new DientuChitiethinh_Model();//gọi model data
            data.IdProduct = IdProduct;
            data.Images = Images;
            data.ThumImg = ThumImg;
            data.Idmau = Idmau;
            data.IdSize = IdSize;
            data.Giaban = Convert.ToDouble(Giaban);
            data.Giacu = Convert.ToDouble(Giacu);
            data.Soluong = Convert.ToInt32(Soluong);
            data.Phantramkm = Convert.ToInt32(Phantramkm);
            data.Tinhtrang = Convert.ToInt32(Tinhtrang);
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToBoolean(Active);
            data.IdTag = _resurtMaxIdData();
            data.Iddungluong = Iddungluong;

            data.Images1 = Images1;
            data.Images2 = Images2;
            data.Images3 = Images3;
            data.Images4 = Images4;

            Connect.Create(data); //gọi service lưu
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        public string _resurtMaxIdData()
        {
            var data = connect_entity.DientuChitiethinhs.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            if (data == null)
                return "MTT" + 0;
            return "MTT" + data.Id;
        }
        public string _resurtMaxIdDataCurent(int Id)
        {
            var data = connect_entity.DientuChitiethinhs.Where(x => x.Id == Id).OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            return data.IdTag;
        }

        //thục hiện action Update
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Update(string Id, string IdTag, string IdProduct, string Images, string ThumImg, string Idmau, string Iddungluong, string IdSize, string Giaban
                                   , string Giacu, string Soluong, string Phantramkm, string Tinhtrang, string Active, string Ord,
                                    string Images1, string Images2, string Images3, string Images4)
        {
            DientuChitiethinh_Model data = new DientuChitiethinh_Model();//gọi model data
            data.Id = _resurtId(IdTag);
            data.IdProduct = IdProduct;
            data.Images = Images;
            data.ThumImg = ThumImg;
            data.Idmau = Idmau;
            data.IdSize = IdSize;
            data.Giaban = Convert.ToDouble(Giaban);
            data.Giacu = Convert.ToDouble(Giacu);
            data.Soluong = Convert.ToInt32(Soluong);
            data.Phantramkm = Convert.ToInt32(Phantramkm);
            data.Tinhtrang = Convert.ToInt32(Tinhtrang);
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToBoolean(Active);
            data.IdTag = IdTag;
            data.Iddungluong = Iddungluong;

            data.Images1 = Images1;
            data.Images2 = Images2;
            data.Images3 = Images3;
            data.Images4 = Images4;

            Connect.Update(data); //gọi service lưu
            Resurt = 1;

            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        public int _resurtId(string IdTag)
        {
            var data = connect_entity.DientuChitiethinhs.FirstOrDefault(x => x.IdTag == IdTag);
            return data.Id;
        }


    }
}

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
using System.Data;


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DienTu.Thuoctinh
{
    public class DientuThuoctinhAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/DientuThuoctinh_Admin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuThuoctinh_Service Connect = new DientuThuoctinh_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public JsonResult Read(int Idproduct)
        {
            try
            {
                var data = connect_entity.DientuThuoctinhs.Where(x => x.Idproduct == Idproduct).OrderBy(x => x.Ord).ToList();
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "Admin,Personnel")]
        public JsonResult Get_Read_Idtag(string IdTag)
        {
            try
            {
                var data = connect_entity.DientuThuoctinhs.FirstOrDefault(x => x.IdTag == IdTag);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "Admin,Personnel")]
        public JsonResult ReadTT(int Idproduct)
        {
            try
            {
                var data = connect_entity.Get_DientuThuoctinh().Where(x => x.Idproduct == Idproduct).OrderBy(x => x.Ord).ToList();
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// //////////////////Change Active
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Active(string  IdTag)
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
            var data = connect_entity.DientuThuoctinhs.FirstOrDefault(x => x.IdTag == IdTag);
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
                var data = connect_entity.DientuThuoctinhs.FirstOrDefault(x => x.Id == Id);
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
        public JsonResult Deleteone(string IdTag)
        {
            Connect.Deleteone(IdTag);
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
        public ActionResult Insert(string Text, string Value, string Idproduct, string Idthuoctinh, string Idcapthuoctinh, string Active, string Ord, string Content, string TagProduct)
        {
            DientuThuoctinh_Model data = new DientuThuoctinh_Model();//gọi model data
            data.Text = Text;
            data.Value = Value;
            data.IdTag = _resurtMaxIdData();
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);
            data.Idproduct = Convert.ToInt32(Idproduct);
            data.Idthuoctinh = Convert.ToInt32(Idthuoctinh);
            data.Idcapthuoctinh = Convert.ToInt32(Idcapthuoctinh);
            data.Content = Content;
            data.TagProduct = TagProduct;

            if (connect_entity.DientuThuoctinhs.FirstOrDefault
               (x => x.Text == Text && x.Idproduct == data.Idproduct) == null)// kiểm tra không được trùng tên
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

        public string _resurtMaxIdData()
        {
            var data = connect_entity.DientuThuoctinhs.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            if (data == null)
                return "MTT"+0;
            return "MTT"+data.Id;
        }
        public string _resurtMaxIdDataCurent(int Id)
        {
            var data = connect_entity.DientuThuoctinhs.Where(x=>x.Id==Id).OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            return data.IdTag;
        }

        //thục hiện action Update
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Update(string Id,string IdTag ,string Text, string Value, string Idcapthuoctinh, string Idproduct, string Idthuoctinh, string Active, string Ord, string Content, string TagProduct)
        {
            DientuThuoctinh_Model data = new DientuThuoctinh_Model();//gọi model data
            data.Id = _resurtId(IdTag);
            data.Text = Text;
            data.Value = Value;
            data.IdTag = IdTag;
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);
            data.Idproduct = Convert.ToInt32(Idproduct);
            data.Idthuoctinh = Convert.ToInt32(Idthuoctinh);
            data.Idcapthuoctinh = Convert.ToInt32(Idcapthuoctinh);
            data.Content = Content;
            data.TagProduct = TagProduct;

            if (connect_entity.DientuThuoctinhs.FirstOrDefault
               (x => x.Text == data.Text && x.Idproduct == data.Idproduct && x.Id != data.Id) == null)// kiểm tra không được trùng tên
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

        public int _resurtId(string IdTag)
        {
            var data = connect_entity.DientuThuoctinhs.FirstOrDefault(x => x.IdTag == IdTag);
            return data.Id;
        }

    }
}

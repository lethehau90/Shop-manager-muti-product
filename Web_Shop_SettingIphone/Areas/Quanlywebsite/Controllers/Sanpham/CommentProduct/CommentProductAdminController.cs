using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;
using System.Globalization;

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.Sanpham.CommentPro
{
    public class CommentProductAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/ImagesAdvertiseAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        CommentProduc_Service Connect = new CommentProduc_Service();
        int Resurt;
        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = connect_entity.CommentProducs.Where(x => x.Level == null)
                .OrderByDescending(x => x.Date).ToList();
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
            var data = connect_entity.CommentProducs.Find(Id);
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
                var data = connect_entity.CommentProducs.FirstOrDefault(x => x.Id == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Read_Rep(string IdProduct, string Id)
        {
            try
            {
                int IdPr = Convert.ToInt32(IdProduct);
                var data = connect_entity.CommentProducs.Where(x => x.Level == Id && x.ProId == IdPr)
               .OrderByDescending(x => x.Date).ToList();
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult Deleteone(int Id)
        {
            string IdLever = Id.ToString();
            var data = connect_entity.CommentProducs.Where(x => x.Level == IdLever).ToList();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    connect_entity.CommentProducs.Remove(item);
                    connect_entity.SaveChanges();
                }
            }
            Connect.Deleteone(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult DeleteAll(int[] Id)
        {
           // string[] IdLever = Id.Select(x=>x.ToString()).ToArray();
            //chuyển đổi mảng số nguyên sang mảng chuổi
            foreach (var i in Id)
            {
                string IdLever = i.ToString();
                var data = connect_entity.CommentProducs.Where(x => x.Level == IdLever).ToList();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        connect_entity.CommentProducs.Remove(item);
                        connect_entity.SaveChanges();
                    }
                }
            }
            Connect.DeleteAll(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        public void DeleteIDLeverAll()
        {

        }


        //thục hiện action Insert

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public ActionResult Insert(string ProId, string Name, string Email, string Point,
                                    string Content, string Date, string Active, string Level)
        {
            CommentProduc_Model model = new CommentProduc_Model();//gọi model data
            model.ProId = Convert.ToInt32(ProId);
            model.Name = Name;
            model.Email = Email;
            model.Point = Convert.ToInt32(Point);
            model.Active = Convert.ToInt32(Active);
            model.Content = Content;
            model.Date = DateTime.Now;
            model.Level = Level;
            if (connect_entity.CommentProducs.FirstOrDefault
               (x => x.Content == Content) == null)// kiểm tra không được trùng tên
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
        public ActionResult Update(string Id, string ProId, string Name, string Email, string Point,
                                    string Content, string Date, string Active, string Level)
        {
            CommentProduc_Model model = new CommentProduc_Model();//gọi model data
            model.Id = Convert.ToInt32(Id);
            model.ProId = Convert.ToInt32(ProId);
            model.Name = Name;
            model.Email = Email;
            model.Point = Convert.ToInt32(Point);
            model.Active = Convert.ToInt32(Active);
            model.Content = Content;
            model.Date = DateTime.Now;
            model.Level = Level;
            Connect.Update(model); //gọi service lưu
            Resurt = 1;

            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        //count number comment product
        public string _ResurtCountCommentProduct(int Idproduct, string Id)
        {
            var data = connect_entity.CommentProducs.Where(x => x.ProId == Idproduct && x.Level == Id).ToList();
            string count = data.Count.ToString();
            return (count);
        }


        public string _ResurtStringProduct(int Idproduct)
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == Idproduct);
            if (data == null)
            {
                return "";
            }
            else
                return data.Name;
        }


    }
}

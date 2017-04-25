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
using System.Globalization;


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DienTu.Dactinh
{
    public class DientuTinhnangAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/DientuTinhnangAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuTinhnang_Service Connect = new DientuTinhnang_Service();
        readonly List<SelectListItem> Selectlist_lever = new List<SelectListItem>();

        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read()
        {
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idtinhang == 0).ToList();
            ViewBag.Selectlist_lever = Selectlist_lever;
            return View(data);
        }
        public ActionResult Read_Lever2(int Id)
        {
            var data = connect_entity.DientuTinhnangs.Where(x => x.Idtinhang==Id).OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }

        public ActionResult Read_Lever3(int Id)
        {
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idtinhang==Id).ToList();
            return PartialView(data);
        }

        #region Select_option
        public DientuTinhnangAdminController()
        {
            var data = connect_entity.DientuTinhnangs.Where(x => x.Idtinhang == 0).ToList();
            foreach (var item in data)
            {
                Selectlist_lever.Add(new SelectListItem
                                {
                                    Text = item.Thuoctinh,
                                    Value = item.Idthuoctinh.ToString(CultureInfo.InvariantCulture)
                                });
            }
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Loadmenu_Lever()
        {
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idtinhang.Equals(0)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Loadmenu_Lever_muti(int Id)
        {
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idtinhang==Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Loadmenu_Lever2_muti_(string Id)
        {
            int lever = Convert.ToInt32(Lever2up_lever(Convert.ToInt32(Id)));
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idtinhang == lever).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Loadmenu_Lever2_muti_Id(int Id)
        {
            string lever = Lever2up_lever(Convert.ToInt32(Id));
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idthuoctinh == Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Loadmenu_Lever1_muti_(string Id)
        {
            int lever = Convert.ToInt32(Lever1up(Convert.ToInt32(Id)));
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).Where(x => x.Idthuoctinh == lever).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public string Lever2up_lever(int Id)
        {
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).First(x => x.Idthuoctinh == Id);
            return data.Idtinhang.ToString();
        }

        public int Lever1up(int Id)
        {
            int idlever1 = Convert.ToInt32(Lever2up_lever(Id));
            var data = connect_entity.DientuTinhnangs.OrderBy(x => x.Ord).First(x => x.Idthuoctinh == idlever1);
            return data.Idthuoctinh;
        }

        #endregion

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Insert(string Thuoctinh, string Idtinhang, string Active, string Ord,
                                 string Title, string Content, string Level2)
        {
            DientuTinhnang_Model data = new DientuTinhnang_Model();//gọi model data
            if(Idtinhang=="")
            {
                Idtinhang = "0";
            }
          
            data.Thuoctinh = Thuoctinh;
            data.Thuoctinh = Thuoctinh;
            data.Title = UrlRewrite.GenShortName(data.Thuoctinh.Replace(":", "").Trim());
            ///data.Idtinhang = Convert.ToInt32(Idtinhang);
            if (Level2 == "" || Level2 == null)
            {
                //data.Idtinhang = Convert.ToInt32(Idtinhang);
                data.Idtinhang = Convert.ToInt32(Idtinhang == "" ? "0" : Idtinhang);
                //Id select ajax product
                if (data.Idtinhang == 0)
                {
                    data.Idthuoctinhselect = 0;
                }
                else
                    data.Idthuoctinhselect = GetIdmax(Convert.ToInt32(data.Idtinhang));
            }
            else
            {
                //data.Idtinhang = Convert.ToInt32(Level2);
                data.Idtinhang = Convert.ToInt32(Level2 == "" ? "0" : Level2);
                //Id select ajax product
                if (data.Idtinhang == 0)
                {
                    data.Idthuoctinhselect = 0;
                }
                else
                    data.Idthuoctinhselect = GetIdmax(Convert.ToInt32(data.Idtinhang));
            }  
            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);
            data.Title = Title;
            data.Content = Content;

            Connect.Create(data); //gọi service lưu
            Resurt = 1;

            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Update(string Id, string Thuoctinh, string Idtinhang, string Active, string Ord,
                                 string Title, string Content)
        {
            DientuTinhnang_Model data = new DientuTinhnang_Model();//gọi model data
            if (Idtinhang == "")
            {
                Idtinhang = "0";
            }
            data.Idthuoctinh = Convert.ToInt32(Id);
            data.Thuoctinh = Thuoctinh;
            data.Thuoctinh = Thuoctinh;
            data.Title = UrlRewrite.GenShortName(data.Thuoctinh.Replace(":", "").Trim());
            data.Idtinhang = Convert.ToInt32(Idtinhang == "0" ? "0" : Idtinhang);
            //Id select ajax product
            if (data.Idtinhang == 0)
            {
                data.Idthuoctinhselect = 0;
            }
            else
                data.Idthuoctinhselect = GetIdmax(Convert.ToInt32(data.Idtinhang));

            data.Active = Convert.ToBoolean(Active);
            data.Ord = Convert.ToInt32(Ord);
            data.Title = Title;
            data.Content = Content;

            Connect.Update(data); //gọi service lưu
            Resurt = 1;

            return Json(Resurt, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel

        #region Set active anh Priority
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
            var data = connect_entity.DientuTinhnangs.Find(Id);
            if (data.Active == false)
                data.Active = true;
            else if (data.Active == true)
            {
                data.Active = false;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

        #endregion

        #region Count
        public int Count_category(int Id) //đếm danh mục trả về kiểu số nguyên
        {
            //string idd = Convert.ToString(Id);
            var data = connect_entity.DientuTinhnangs.Where(x => x.Idtinhang == Id).ToList();
            int dem = data.Count;
            return dem;
        }

        public ActionResult __count_category(int Id) //đếm danh mục
        {
            var data = connect_entity.DientuTinhnangs.Where(x => x.Idtinhang == Id).ToList();

            string dem = data.Count.ToString();

            return Content(dem);
        }     
        #endregion  

        public int GetIdmax(int Id)
        {
            var data_con = connect_entity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh == Id);
            int Id_tag = 0;
            if (data_con.Idtinhang == 0)
            {

                Id_tag = data_con.Idthuoctinh;
            }
            else
            {
                int chuyenlever_idhientai = Convert.ToInt32(data_con.Idtinhang);

                if (chuyenlever_idhientai != 0)
                {
                    var data_cha = connect_entity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh == chuyenlever_idhientai);

                    if (data_cha.Idtinhang == 0)
                    {
                        Id_tag = data_cha.Idthuoctinh;
                    }
                    else
                    {
                        int chuyenlever_idchahientai = Convert.ToInt32(data_cha.Idtinhang);
                        var data_cha_cha = connect_entity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh == chuyenlever_idchahientai);
                        Id_tag = data_cha_cha.Idthuoctinh;
                    }

                }
            }

            return Id_tag;
        }
    }
}

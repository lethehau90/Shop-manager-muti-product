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

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.Sanpham.Product
{
    public class CategotyproductAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/CategotyproductAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        GroupMenuSanPham_Service Connect = new GroupMenuSanPham_Service();
        readonly List<SelectListItem> Selectlist_lever = new List<SelectListItem>();

        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read()
        {
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Level == null).ToList();
            ViewBag.Selectlist_lever = Selectlist_lever;
            return View(data);
        }
        public ActionResult Read_Lever2(string Id)
        {
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Level.Equals(Id)).ToList();
            return PartialView(data);
        }

        public ActionResult Read_Lever3(string Id)
        {
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Level.Equals(Id)).ToList();
            return PartialView(data);
        }

        #region Select_option
        public CategotyproductAdminController()
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == null).ToList();
            foreach (var item in data)
            {
                Selectlist_lever.Add(new SelectListItem
                                {
                                    Text = item.Name,
                                    Value = item.Id.ToString(CultureInfo.InvariantCulture)
                                });
            }
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Loadmenu_Lever()
        {
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Level.Equals(null)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Loadmenu_Lever_muti(string Id)
        {
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Level.Equals(Id)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Loadmenu_Lever2_muti_(string Id)
        {
            string lever = Lever2up_lever(Convert.ToInt32(Id));
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Level == lever).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Loadmenu_Lever2_muti_Id(int Id)
        {
            string lever = Lever2up_lever(Convert.ToInt32(Id));
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Id == Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Loadmenu_Lever1_muti_(string Id)
        {
            int lever = Convert.ToInt32(Lever1up(Convert.ToInt32(Id)));
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).Where(x => x.Id == lever).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
       

        public string Lever2up_lever(int Id)
        {
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).First(x => x.Id==Id);
            return data.Level;
        }

        public int Lever1up(int Id)
        {
            int idlever1 = Convert.ToInt32(Lever2up_lever(Id));
            var data = connect_entity.GroupMenuSanPhams.OrderBy(x => x.Ord).First(x => x.Id == idlever1);
            return data.Id;
        }

        #endregion

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == Id);
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
        public JsonResult Insert( string Name, string Tag, string Level, string Title, 
                                 string Description, string Keyword, string Ord, string Priority, string Index,
                                 string Active, string Lang, string Logogroup, string NameEn, string TitleEn,
                                 string ImagesLogo, string content, string contentEn, string Level2)
        {
            GroupMenuSanPham_Model data = new GroupMenuSanPham_Model();//gọi model data

            data.Name = Name;
            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim());

            if (Level2 == "" || Level2 == null)
            {
                data.Level = Level == "" ? null : Level;
            }
            else
            {
                data.Level = Level2 == "" ? null : Level2;
            }  
        
            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;
            data.Ord = Convert.ToInt32(Ord);
            data.Priority = Convert.ToInt32(Priority);
            data.Index = Convert.ToInt32(Index);
            data.Active = Convert.ToInt32(Active);
            data.Lang = Lang;
            data.Logogroup = Logogroup;
            data.ImagesLogo = ImagesLogo;
            data.content = content;
            data.NameEn = NameEn;
            data.TitleEn = TitleEn;
            data.contentEn = contentEn;

            if (connect_entity.GroupMenuSanPhams.FirstOrDefault
                   (x => x.Name == data.Name) == null)// kiểm tra không được trùng tên
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

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Update(string Id, string Name, string Tag, string Level, string Title,
                                 string Description, string Keyword, string Ord, string Priority, string Index,
                                 string Active, string Lang, string Logogroup, string NameEn, string TitleEn,
                                 string ImagesLogo, string content, string contentEn)
        {
            GroupMenuSanPham_Model data = new GroupMenuSanPham_Model();//gọi model data
            data.Id = Convert.ToInt32(Id);
            data.Name = Name;
            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim());
            data.Level = Level == "" ? null : Level;
            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;
            data.Ord = Convert.ToInt32(Ord);
            data.Priority = Convert.ToInt32(Priority);
            data.Index = Convert.ToInt32(Index);
            data.Active = Convert.ToInt32(Active);
            data.Lang = Lang;
            data.Logogroup = Logogroup;
            data.ImagesLogo = ImagesLogo;
            data.content = content;
            data.NameEn = NameEn;
            data.TitleEn = TitleEn;
            data.contentEn = contentEn;
            if (connect_entity.GroupMenuSanPhams.FirstOrDefault
            (x => x.Name == data.Name && x.Id != data.Id) == null)// kiểm tra không được trùng tên
            {
                string tag_Pre=resurt_tag(data.Id); // lấy giá trị tag trước

                Connect.Update(data); //gọi service lưu

                //update to news detail other group save
                Resurt_Cateprolevel1(tag_Pre, data.Tag);
                Resurt_Cateprolevel2(tag_Pre, data.Tag);
                Resurt_Cateprolevel3(tag_Pre, data.Tag);
                Resurt = 1;
            }
            else
            {
                Resurt = 0;
            }

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
            var data = connect_entity.GroupMenuSanPhams.Find(Id);
            if (data.Active == 0)
                data.Active = 1;
            else if (data.Active == 1)
            {
                data.Active = 0;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

        //Quyền trang chủ hay không
        public JsonResult Priority(int Id)
        {
            int result = ChangePriority(Id);
            return Json(new
            {
                Priority = result
            });
        }

        // ChangeActive

        public int ChangePriority(int Id)
        {
            var data = connect_entity.GroupMenuSanPhams.Find(Id);
            if (data.Priority == 0)
                data.Priority = 1;
            else if (data.Priority == 1)
            {
                data.Priority = 0;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Priority);
        } 
        #endregion

        #region Count

        public ActionResult __count_category(string Id) //đếm danh mục
        {
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level.Equals(Id)).ToList();

            string dem = data.Count.ToString();

            return Content(dem);
        }

        public ActionResult __count_lever3(string tag)
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel3.Equals(tag)).ToList();
            string dem = data.Count.ToString();
            return Content(dem);
        }

        public ActionResult __count_lever2(string tag)
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel2.Equals(tag) || x.Cateprolevel3.Equals(tag)).ToList();
            string dem = data.Count.ToString();
            return Content(dem);
        }

        public ActionResult __count_lever1(string tag) 
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel1.Equals(tag)).ToList();
            string dem = data.Count.ToString();
            return Content(dem);
        }


        public int Count_category(int Id) //đếm danh mục trả về kiểu số nguyên
        {
            string idd = Convert.ToString(Id);
            var data = connect_entity.GroupMenuSanPhams.Where(x => x.Level == idd).ToList();
            int dem = data.Count;
            return dem;
        }

        public int Count_news_lever3(string tag) //đếm  tin cấp độ 3
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel3.Equals(tag)).ToList();
            int demtin = data.Count;
            return demtin;
        }

        public int Count_news_lever2(string tag) //đếm  tin cấp độ 2
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel2.Equals(tag) || x.Cateprolevel3.Equals(tag)).ToList();
            int demtin = data.Count;
            return demtin;
        }

        public int Count_news_lever1(string tag) //đếm  tin cấp độ 1
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel1.Equals(tag)).ToList();
            int demtin = data.Count;
            return demtin;
        }
        #endregion

        /// <summary>
        /// Bind take value lever Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Resurt_Cateprolevel1(string tag, string tag_edit) //id is tag the lever group
        {
            var Data_parent_level1 = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel1 == tag).ToList(); //bind cấp cao nhất

            if (Data_parent_level1.Count > 0)
            {
                for (int i = 0; i < Data_parent_level1.Count; i++)
                {
                    Data_parent_level1[i].Cateprolevel1 = tag_edit;
                    connect_entity.SaveChanges();
                }
            }
        }
        public void Resurt_Cateprolevel2(string tag ,string tag_edit) //id is tag the lever group
        {
            var Data_parent_level2 = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel2 == tag).ToList(); //bind cấp cao nhất
            if (Data_parent_level2.Count > 0)
            {
                for (int i = 0; i < Data_parent_level2.Count; i++)
                {
                    Data_parent_level2[i].Cateprolevel2 = tag_edit;
                    connect_entity.SaveChanges();
                }
            }
        }
        public void Resurt_Cateprolevel3(string tag, string tag_edit)  //id is tag the lever group
        {
            var Data_parent_level3 = connect_entity.GroupNewMenuSanPhamDetails.Where(x => x.Cateprolevel3 == tag).ToList(); //bind cấp cao nhất
            if (Data_parent_level3.Count > 0)
            {
                for (int i = 0; i < Data_parent_level3.Count; i++)
                {
                    Data_parent_level3[i].Cateprolevel3 = tag_edit;
                    connect_entity.SaveChanges();
                }
            }
        }

        public string resurt_tag(int id) //resurt get values tag group news
        {
            var Data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == id);
            return Data.Tag;
        }

    }
}

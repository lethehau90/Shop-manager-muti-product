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


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.DienTu.Product
{
    public class DientuMathangAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/DientuMathangAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        DientuMathang_Service Connect = new DientuMathang_Service();
        DientuChitiethinh_Service ConnectCH = new DientuChitiethinh_Service();
        DientuThuoctinh_Service ConnectTT = new DientuThuoctinh_Service();

        readonly List<SelectListItem> Selectlist_lever = new List<SelectListItem>();
        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read(string filter, string tag)
        {
            var data = connect_entity.DientuMathangs.OrderByDescending(x => x.Id).ToList();
            string Group = "";
            if (filter != "")
            {
                switch (filter)
                {
                    case "highlight": //nổi bật
                        data = data.Where(x => x.Priority == 2).ToList();
                        break;
                    case "normal": //bình thường
                        data = data.Where(x => x.Priority == 1).ToList();
                        break;
                }
            }
            if (tag != null)
            {
                Group += "Thuộc Thể Loại: " + Resurt_name(tag);
                data = data.Where(x => x.Cateprolevel3 == tag).ToList();
                if (data.Count == 0)
                {
                    data = data.Where(x => x.Cateprolevel2 == tag).ToList();
                }
                if (data.Count == 0)
                {
                    data = data.Where(x => x.Cateprolevel1 == tag).ToList();
                }
            }
            ViewBag.Selectlist_lever = Selectlist_lever;
            ViewBag.Group = Group;
            ViewBag.Count = data.Count;
            return View(data);
        }

        //perform function search form the newsdetail
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        [HttpPost]
        public ActionResult Read(FormCollection collection)
        {
            String name = collection["txtname_tk"];
            String SelectCategory_tk = "";
            if (collection["SelectCategory_tk"] != "")
            {
                SelectCategory_tk = Resurt_Cateprolevel3(Convert.ToInt32(collection["SelectCategory_tk"])); //Thể loại
            }
            string SelectPriority_tk = collection["SelectPriority_tk"]; int Priority_tk = Convert.ToInt32(SelectPriority_tk);  //kiểu loại 
            string Selectactive_tk = collection["Selectactive_tk"]; int active_tk = Convert.ToInt32(Selectactive_tk);//Kích hoạt
            var data = connect_entity.DientuMathangs.OrderByDescending(x => x.Id).ToList();
            string search = "";
            if (name != "")
            {
                data = data.Where(x => x.Tenhang.Contains(name)).ToList();
                search += "từ khóa:" + name;
            }
            if (SelectCategory_tk != "")
            {
                data = data.Where(x => x.Cateprolevel3 == SelectCategory_tk).ToList();
                search += " ,thể loại: " + _Resurt_name_groupnew(Convert.ToInt32(collection["SelectCategory_tk"]));
            }
            if (Priority_tk != 0)
            {
                data = data.Where(x => x.Priority == Priority_tk).ToList();
                search += " ,kiểu loại: ";
                search += Priority_tk == 1 ? "bình thường" : "nổi bật";
            }
            if (active_tk != 0)
            {
                data = data.Where(x => x.Active == active_tk).ToList();
                search += " ,kích hoạt: ";
                search += active_tk == 1 ? "Có" : "Không"; ;
            }
            ViewBag.Selectlist_lever = Selectlist_lever;
            ViewBag.Count = data.Count;
            if (search != "")
                ViewBag.search = "Bạn đang tìm kiếm với " + search;
            else
            {
                ViewBag.search = "Không có từ khóa nào được tìm.";
            }
            return View(data);
        }
        #region Select_option
        public DientuMathangAdminController()
        {
            var data = connect_entity.DientuMenuSitemathangs.Where(x => x.Level == null).ToList();
            foreach (var item in data)
            {
                Selectlist_lever.Add(new SelectListItem
                                {
                                    Text = item.MenuName,
                                    Value = item.Id.ToString(CultureInfo.InvariantCulture)
                                });
            }
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Loadmenu_Lever()
        {
            var data = connect_entity.DientuMenuSitemathangs.OrderBy(x => x.Ord).Where(x => x.Level.Equals(null)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Loadmenu_Lever_muti(string Id)
        {
            var data = connect_entity.DientuMenuSitemathangs.OrderBy(x => x.Ord).Where(x => x.Level.Equals(Id)).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Id == Id);
                Resurt = 1; //trạng thái thành công 
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read_Tag(string Tag)
        {
            try
            {
                var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Tag == Tag);
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
        public JsonResult Insert(string Seri, string Tenhang, string Img, string ThumImg, string Thum_img_img, string Idnsx,
                                 string Giaban, string Giamua, string Soluong, string Tinhtrang, string Donvi, string Baohanh,
                                 string Ngaynhap, string Danhgia, string Luotxem, string Vat, string Lienhe, string Forder,
                                 string Baiviet, string Thongso, string Mota, string Giagiam, string Phantramkm, string Title,
                                 string Keyword, string Description, string Khuvuc, string thuoctinh, string khuyenmai, string khuyenmai_html,
                                 string Ord, string Active, string Idmenu, string Priority, string Index, string Idthuoctinh,
                                 string Diemdanhgia, string Ngayxemganday, string Tag, string GroupNewsCatTag,
                                 string Cateprolevel1, string Cateprolevel2, string Cateprolevel3)
        {
            DientuMathang_Model data = new DientuMathang_Model();//gọi model data

            data.Seri = Seri;
            data.Tenhang = Tenhang;
            data.Img = Img;
            data.ThumImg = ThumImg;
            data.Thum_img_img = Thum_img_img;
            data.Idnsx = Convert.ToInt32(Idnsx);
            data.Giaban = Convert.ToDouble(Giaban);
            data.Giamua = Convert.ToDouble(Giamua);
            data.Soluong = Convert.ToInt32(Soluong);
            data.Tinhtrang = Tinhtrang;
            data.Donvi = Donvi;
            data.Baohanh = Baohanh;
            data.Ngaynhap = DateTime.Now;
           
            data.Danhgia = Convert.ToInt32(Danhgia);
            data.Luotxem = Convert.ToInt32(Luotxem);
            data.Vat = Convert.ToInt32(Vat);
            data.Lienhe = Lienhe;
            data.Forder = Forder;
            data.Baiviet = Baiviet;
            data.Thongso = Thongso;
            data.Mota = Mota;
            data.Giagiam = Convert.ToDouble(Giagiam);
            data.Phantramkm = Convert.ToDouble(Phantramkm);
            data.Title = Title;
            data.Keyword = Keyword;
            data.Description = Description;
            data.Khuvuc = Khuvuc;
            data.thuoctinh = thuoctinh;
            data.khuyenmai = khuyenmai;
            data.khuyenmai_html = khuyenmai_html;
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToInt32(Active);
            data.Idmenu = Convert.ToInt32(Idmenu);
            data.Priority = Convert.ToInt32(Priority);
            data.Index = Convert.ToInt32(Index);
            data.Idthuoctinh = Convert.ToInt32(Idthuoctinh);
            data.Diemdanhgia = Diemdanhgia;
            //data.Ngayxemganday = Ngayxemganday;

            data.Tag = UrlRewrite.GenShortName(data.Tenhang.Replace(":", "").Trim());
            data.GroupNewsCatTag = GroupNewsCatTag;
            // Lever for catelog 1 and catelog 2 and catelog 3
            data.Cateprolevel1 = Resurt_Cateprolevel1(Convert.ToInt32(GroupNewsCatTag));
            data.Cateprolevel2 = Resurt_Cateprolevel2(Convert.ToInt32(GroupNewsCatTag));
            data.Cateprolevel3 = Resurt_Cateprolevel3(Convert.ToInt32(GroupNewsCatTag));

            
            if (connect_entity.DientuMathangs.FirstOrDefault
                   (x => x.Tenhang == data.Tenhang) == null)// kiểm tra không được trùng tên
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
        public JsonResult Update(string Id, string Seri, string Tenhang, string Img, string ThumImg, string Thum_img_img, string Idnsx,
                                 string Giaban, string Giamua, string Soluong, string Tinhtrang, string Donvi, string Baohanh,
                                 string Ngaynhap, string Danhgia, string Luotxem, string Vat, string Lienhe, string Forder,
                                 string Baiviet, string Thongso, string Mota, string Giagiam, string Phantramkm, string Title,
                                 string Keyword, string Description, string Khuvuc, string thuoctinh, string khuyenmai, string khuyenmai_html,
                                 string Ord, string Active, string Idmenu, string Priority, string Index, string Idthuoctinh,
                                 string Diemdanhgia, string Ngayxemganday, string Tag, string GroupNewsCatTag,
                                 string Cateprolevel1, string Cateprolevel2, string Cateprolevel3)
        {
            DientuMathang_Model data = new DientuMathang_Model();//gọi model data
            data.Id = Convert.ToInt32(Id);
            data.Seri = Seri;
            data.Tenhang = Tenhang;
            data.Img = Img;
            data.ThumImg = ThumImg;
            data.Thum_img_img = Thum_img_img;
            data.Idnsx = Convert.ToInt32(Idnsx);
            data.Giaban = Convert.ToDouble(Giaban);
            data.Giamua = Convert.ToDouble(Giamua);
            data.Soluong = Convert.ToInt32(Soluong);
            data.Tinhtrang = Tinhtrang;
            data.Donvi = Donvi;
            data.Baohanh = Baohanh;
            //data.Ngaynhap = DateTime.Now;

            data.Danhgia = Convert.ToInt32(Danhgia);
            data.Luotxem = Convert.ToInt32(Luotxem);
            data.Vat = Convert.ToInt32(Vat);
            data.Lienhe = Lienhe;
            data.Forder = Forder;
            data.Baiviet = Baiviet;
            data.Thongso = Thongso;
            data.Mota = Mota;
            data.Giagiam = Convert.ToDouble(Giagiam);
            data.Phantramkm = Convert.ToDouble(Phantramkm);
            data.Title = Title;
            data.Keyword = Keyword;
            data.Description = Description;
            data.Khuvuc = Khuvuc;
            data.thuoctinh = thuoctinh;
            data.khuyenmai = khuyenmai;
            data.khuyenmai_html = khuyenmai_html;
            data.Ord = Convert.ToInt32(Ord);
            data.Active = Convert.ToInt32(Active);
            data.Idmenu = Convert.ToInt32(Idmenu);
            data.Priority = Convert.ToInt32(Priority);
            data.Index = Convert.ToInt32(Index);
            data.Idthuoctinh = Convert.ToInt32(Idthuoctinh);
            data.Diemdanhgia = Diemdanhgia;
            //data.Ngayxemganday = Ngayxemganday;

            data.Tag = UrlRewrite.GenShortName(data.Tenhang.Replace(":", "").Trim());
            data.GroupNewsCatTag = GroupNewsCatTag;
            // Lever for catelog 1 and catelog 2 and catelog 3
            data.Cateprolevel1 = Resurt_Cateprolevel1(Convert.ToInt32(GroupNewsCatTag));
            data.Cateprolevel2 = Resurt_Cateprolevel2(Convert.ToInt32(GroupNewsCatTag));
            data.Cateprolevel3 = Resurt_Cateprolevel3(Convert.ToInt32(GroupNewsCatTag));

            if (connect_entity.DientuMathangs.FirstOrDefault
            (x => x.Tenhang == data.Tenhang && x.Id != data.Id) == null)// kiểm tra không được trùng tên
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

        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult Deleteone(int Id)
        {
            Connect.Deleteone(Id);
            ConnectCH.DeleteoneProduct(Id); //delete CH
            ConnectTT.DeleteoneProduct(Id); //delete TT
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Personnel")]  //Personnel
        public JsonResult DeleteAll(int[] Id)
        {
            Connect.DeleteAll(Id);
            ConnectCH.DeletemutiProduct(Id); //delete CH
            ConnectTT.DeletemutiProduct(Id); //delete TT
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }
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
            var data = connect_entity.DientuMathangs.Find(Id);
            if (data.Active == 0)
                data.Active = 1;
            else if (data.Active == 1)
            {
                data.Active = 0;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

        /// <summary>
        /// Bind take value lever Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Resurt_Cateprolevel1(int id) //id is tag the lever group
        {
            var Data_parent = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == id); //bind cấp cao nhất
            string Name_tag = null; //mặc định là null
            if (Data_parent.Level == null) //nhóm tin không có cấp độ
            {
                Name_tag = Data_parent.Tag; //lấy giá trị tag làm id cho tin
            }
            else //ngược lại có cấp độ
            {
                int Convert_LeverId_curent = Convert.ToInt32(Data_parent.Level); //chuyển đổi lại số nguyên : lerver kiểu string convert id là nguyên

                if (Data_parent.Level != null) //giá trị Level khác null
                {
                    var Data_child = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == Convert_LeverId_curent); //bind cấp con

                    if (Data_child.Level == null) //nhóm tin không có cấp độ
                    {
                        Name_tag = Data_child.Tag; //lấy giá trị tag làm id cho tin
                    }
                    else
                    {
                        int Convert_LeverId_child_curent = Convert.ToInt32(Data_child.Level);//chuyển đổi lại số nguyên
                        var Data_child_cha = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == Convert_LeverId_child_curent); //chuyển lên cấp cao hơn
                        Name_tag = Data_child_cha.Tag; //lấy giá trị tag làm id cho tin
                    }

                }
            }

            return Name_tag;
        }
        public string Resurt_Cateprolevel2(int id) //id is tag the lever group
        {
            string Name_tag = null; //mặc định là null
            var Data = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == id);
            int Id_curent = Convert.ToInt32(Data.Level);
            if (Data.Level == null) //nếu là null
            {
                Name_tag = Data.Tag; //lấy tag chính nó
            }
            else //ngược lại
            {
                var Data_curent = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == Id_curent); //chuyển lên cấp cao hơn
                Name_tag = Data_curent.Tag; // lấy giá trị tag
            }
            return Name_tag;
        }
        public string Resurt_Cateprolevel3(int id)  //id is tag the lever group
        {
            string Name_tag = null; //mặc định là null
            var Data = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == id);
            Name_tag = Data.Tag;
            return Name_tag;
        }

        //take value view when update of customers
        public int Resurt_View(int id) //id is key of DientuMathangs
        {
            var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Id == id);
            return Convert.ToInt32(data.Luotxem);
        }
        public int Resurt_Soluongmua(int id) //id is key of DientuMathangs
        {
            var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Id == id);
            return Convert.ToInt32(data.Soluongmua);
        }
        public DateTime Resurt_Date_Create(int id) //id is key of DientuMathangs
        {
            var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Id == id);
            return Convert.ToDateTime(data.Ngaynhap);
        }

        public DateTime Resurt_Date_view(int id) //id is key of DientuMathangs
        {
            var data = connect_entity.DientuMathangs.FirstOrDefault(x => x.Id == id);
            return Convert.ToDateTime(data.Ngayxemganday);
        }
        public ActionResult Resurt_name_groupnew(string catelog) //Resurt action view html on screen
        {
            string Name = "";
            try
            {
                var data = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Tag.Equals(catelog));
                Name = data.MenuName;
                return Content(Name); //function call take content html
            }
            catch
            {
                return Content(Name); //function call take content html
            }
        }
        public String _Resurt_name_groupnew(int Id) //Resurt only string the connect in other function. 
        {
            string Name = "";
            try
            {
                var data = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id.Equals(Id));
                Name = data.MenuName;
                return (Name);
            }
            catch
            {
                return (Name);
            }
        }
        public string Resurt_name(string tag) //resurt get string values Name group news
        {
            var Data = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Tag == tag);
            return Data.MenuName;
        }

        public ActionResult MenuDientuHsx()
        {
            var data = connect_entity.DientuNsxes.OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
        //code have in TT
        public ActionResult MenuDientuLoaithuoctinh()
        {
            var data = connect_entity.DientuLoaithuoctinhs.OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult MenuDientuCapLoaithuoctinh()
        {
            var data = connect_entity.DientuCapLoaithuoctinhs.OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult MenuDientuMausac()
        {
            var data = connect_entity.Mausacs.OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
        public ActionResult MenuDientuDungluong()
        {
            var data = connect_entity.DientuDungluongs.OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }
    }
}

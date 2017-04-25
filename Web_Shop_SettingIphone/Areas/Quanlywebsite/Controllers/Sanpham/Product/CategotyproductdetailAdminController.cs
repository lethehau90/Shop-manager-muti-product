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
    public class CategotyproductdetailAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/CategotyproductdetailAdmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        GroupNewMenuSanPhamDetail_Service Connect = new GroupNewMenuSanPhamDetail_Service();
        readonly List<SelectListItem> Selectlist_lever = new List<SelectListItem>();
        int Resurt;

        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public ActionResult Read(string filter, string tag)
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.OrderByDescending(x => x.Id).ToList();
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
            var data = connect_entity.GroupNewMenuSanPhamDetails.OrderByDescending(x => x.Id).ToList();
            string search = "";
            if (name != "")
            {
                data = data.Where(x => x.Name.Contains(name)).ToList();
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
        public CategotyproductdetailAdminController()
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
        #endregion
        [Authorize(Roles = "Admin,Personnel")]  //Personnel phan quyen
        public JsonResult Get_Read(int Id)
        {
            try
            {
                var data = connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == Id);
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
        public JsonResult Insert(string Name, string NameEn, string Tag, string IDthuonghieu, string NguonSanPham, string Mausac,
                                 string Kichthuoc, string SanphamCungloai, string Donvi, string Luotdanhgia, string Video, string Title,
                                 string Description, string Keyword, string Priority, string Index, string Order, string Active,
                                 string GroupNewsCatTag, string Cateprolevel1, string Cateprolevel2, string Cateprolevel3, string Image, string Image1,
                                 string Image2, string Image3, string Image4, string Image5, string Content, string ContentEn, string Detail,
                                 string DetailEn, string Khuyenmai, string KhuyenmaiEn, string Baohanh, string BaohanhEn, string DacDiemNoiBat,
                                 string DacDiemNoiBatEn, string Thongdiep, string ThongdiepEn, string Seri, string Luotxem, string Soluongmua,
                                 string DateCreate, string DateView, string Stock, string Number_Stock, string Vat, string Gianhaphang,
                                 string Giaban, string Phantramkhuyenmai, string Giabankhuyenmai, string DateStart_Event, string DateEnd_Event, string Giaban_Event,
                                 string Content_Event, string Content_EventEn)
        {
            GroupNewMenuSanPhamDetail_Model data = new GroupNewMenuSanPhamDetail_Model();//gọi model data

            data.Name = Name;
            data.NameEn = NameEn;

            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim());
            data.IDthuonghieu = IDthuonghieu;
            data.NguonSanPham = NguonSanPham;
            data.Mausac = Mausac;
            data.Kichthuoc = Kichthuoc;
            data.SanphamCungloai = SanphamCungloai;
            data.Donvi = Donvi;
            data.Luotdanhgia = Luotdanhgia;
            data.Video = Video;

            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;

            data.Priority = Convert.ToInt32(Priority);
            data.Index = Convert.ToInt32(Index);
            data.Order = Convert.ToInt32(Order);
            data.Active = Convert.ToInt32(Active);

            data.GroupNewsCatTag = GroupNewsCatTag;
            // Lever for catelog 1 and catelog 2 and catelog 3
            Cateprolevel1 = Resurt_Cateprolevel1(Convert.ToInt32(GroupNewsCatTag));
            Cateprolevel2 = Resurt_Cateprolevel2(Convert.ToInt32(GroupNewsCatTag));
            Cateprolevel3 = Resurt_Cateprolevel3(Convert.ToInt32(GroupNewsCatTag));
            //

            data.Cateprolevel1 = Cateprolevel1;
            data.Cateprolevel2 = Cateprolevel2;
            data.Cateprolevel3 = Cateprolevel3;

            data.Image = Image;
            data.Image1 = Image1;
            data.Image2 = Image2;
            data.Image3 = Image3;
            data.Image4 = Image4;
            data.Image5 = Image5;

            data.Content = Content;
            data.ContentEn = ContentEn;

            data.Detail = Detail;
            data.DetailEn = DetailEn;

            data.Khuyenmai = Khuyenmai;
            data.KhuyenmaiEn = KhuyenmaiEn;

            data.Baohanh = Baohanh;
            data.BaohanhEn = BaohanhEn;

            data.DacDiemNoiBat = DacDiemNoiBat;
            data.DacDiemNoiBatEn = DacDiemNoiBatEn;

            data.Thongdiep = Thongdiep;
            data.ThongdiepEn = ThongdiepEn;

            data.Seri = Seri;
            data.Luotxem = Convert.ToInt32(Luotxem);
            data.Soluongmua = 0; //Convert.ToInt32(Soluongmua);
            data.DateCreate = DateTime.Now; //Convert.ToDateTime(DateCreate);
            data.DateView = null;// Convert.ToDateTime(DateView);

            //giá trị
            data.Stock = Convert.ToInt32(Stock);
            data.Number_Stock = Convert.ToInt32(Number_Stock);
            data.Vat = Convert.ToBoolean(Vat);

            data.Gianhaphang = Convert.ToDouble(Gianhaphang.Replace(",", ""));
            data.Giaban = Convert.ToDouble(Giaban.Replace(",", ""));
            data.Phantramkhuyenmai = Convert.ToInt32(Phantramkhuyenmai);
            data.Giabankhuyenmai = Convert.ToDouble(Giabankhuyenmai.Replace(",", ""));
            if ((DateEnd_Event != null && DateStart_Event != null) || (DateEnd_Event != "" && DateStart_Event != ""))
            {
                try
                {
                    DateTime DateStart_Event_ = DateTime.ParseExact(DateStart_Event, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime DateEnd_Event_ = DateTime.ParseExact(DateEnd_Event, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    data.DateStart_Event = DateStart_Event_;
                    data.DateEnd_Event = DateEnd_Event_;
                }
                catch
                {
                    Resurt = 3;
                }
            }
            else
            {
                data.DateStart_Event = null;
                data.DateEnd_Event = null;
            }

            //giá bán event

            if (Giaban_Event == "" || DateEnd_Event == "" && DateStart_Event == "")
            {
                data.Giaban_Event = 0;
            }
            else
            {
                data.Giaban_Event = Convert.ToDouble(Giaban_Event.Replace(",", ""));
            }

            data.Content_Event = Content_Event;
            data.Content_EventEn = Content_EventEn;
            if (connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault
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
        public JsonResult Update(string Id, string Name, string NameEn, string Tag, string IDthuonghieu, string NguonSanPham, string Mausac,
                                 string Kichthuoc, string SanphamCungloai, string Donvi, string Luotdanhgia, string Video, string Title,
                                 string Description, string Keyword, string Priority, string Index, string Order, string Active,
                                 string GroupNewsCatTag, string Cateprolevel1, string Cateprolevel2, string Cateprolevel3, string Image, string Image1,
                                 string Image2, string Image3, string Image4, string Image5, string Content, string ContentEn, string Detail,
                                 string DetailEn, string Khuyenmai, string KhuyenmaiEn, string Baohanh, string BaohanhEn, string DacDiemNoiBat,
                                 string DacDiemNoiBatEn, string Thongdiep, string ThongdiepEn, string Seri, string Luotxem, string Soluongmua,
                                 string DateCreate, string DateView, string Stock, string Number_Stock, string Vat, string Gianhaphang,
                                 string Giaban, string Phantramkhuyenmai, string Giabankhuyenmai, string DateStart_Event, string DateEnd_Event, string Giaban_Event,
                                 string Content_Event, string Content_EventEn)
        {
            GroupNewMenuSanPhamDetail_Model data = new GroupNewMenuSanPhamDetail_Model();//gọi model data
            data.Id = Convert.ToInt32(Id);
            data.Name = Name;
            data.NameEn = NameEn;

            data.Tag = UrlRewrite.GenShortName(data.Name.Replace(":", "").Trim());
            data.IDthuonghieu = IDthuonghieu;
            data.NguonSanPham = NguonSanPham;
            data.Mausac = Mausac;
            data.Kichthuoc = Kichthuoc;
            data.SanphamCungloai = SanphamCungloai;
            data.Donvi = Donvi;
            data.Luotdanhgia = Luotdanhgia;
            data.Video = Video;

            data.Title = Title;
            data.Description = Description;
            data.Keyword = Keyword;

            data.Priority = Convert.ToInt32(Priority);
            data.Index = Convert.ToInt32(Index);
            data.Order = Convert.ToInt32(Order);
            data.Active = Convert.ToInt32(Active);

            data.GroupNewsCatTag = GroupNewsCatTag;
            // Lever for catelog 1 and catelog 2 and catelog 3
            Cateprolevel1 = Resurt_Cateprolevel1(Convert.ToInt32(GroupNewsCatTag));
            Cateprolevel2 = Resurt_Cateprolevel2(Convert.ToInt32(GroupNewsCatTag));
            Cateprolevel3 = Resurt_Cateprolevel3(Convert.ToInt32(GroupNewsCatTag));
            //

            data.Cateprolevel1 = Cateprolevel1;
            data.Cateprolevel2 = Cateprolevel2;
            data.Cateprolevel3 = Cateprolevel3;

            data.Image = Image;
            data.Image1 = Image1;
            data.Image2 = Image2;
            data.Image3 = Image3;
            data.Image4 = Image4;
            data.Image5 = Image5;

            data.Content = Content;
            data.ContentEn = ContentEn;

            data.Detail = Detail;
            data.DetailEn = DetailEn;

            data.Khuyenmai = Khuyenmai;
            data.KhuyenmaiEn = KhuyenmaiEn;

            data.Baohanh = Baohanh;
            data.BaohanhEn = BaohanhEn;

            data.DacDiemNoiBat = DacDiemNoiBat;
            data.DacDiemNoiBatEn = DacDiemNoiBatEn;

            data.Thongdiep = Thongdiep;
            data.ThongdiepEn = ThongdiepEn;

            data.Seri = Seri;
            data.Luotxem = Resurt_View(Convert.ToInt32(Id));
            data.Soluongmua = Resurt_Soluongmua(Convert.ToInt32(Id));
            data.DateCreate = Resurt_Date_Create(Convert.ToInt32(Id));
            data.DateView = Resurt_Date_view(Convert.ToInt32(Id));

            //giá trị
            data.Stock = Convert.ToInt32(Stock);
            data.Number_Stock = Convert.ToInt32(Number_Stock);
            data.Vat = Convert.ToBoolean(Vat);

            data.Gianhaphang = Convert.ToDouble(Gianhaphang.Replace(",", ""));
            data.Giaban = Convert.ToDouble(Giaban.Replace(",", ""));
            data.Phantramkhuyenmai = Convert.ToInt32(Phantramkhuyenmai);
            data.Giabankhuyenmai = Convert.ToDouble(Giabankhuyenmai.Replace(",", ""));

            if ((DateEnd_Event != null && DateStart_Event != null) || (DateEnd_Event != "" && DateStart_Event != ""))
            {
                try
                {
                    DateTime DateStart_Event_ = DateTime.ParseExact(DateStart_Event, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime DateEnd_Event_ = DateTime.ParseExact(DateEnd_Event, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    data.DateStart_Event = DateStart_Event_;
                    data.DateEnd_Event = DateEnd_Event_;
                }
                catch
                {
                    Resurt = 3;
                }
            }
            else
            {
                data.DateStart_Event = null;
                data.DateEnd_Event = null;
            }

            if (Giaban_Event == "" || DateEnd_Event == "" && DateStart_Event == "")
            {
                data.Giaban_Event = 0;
            }
            else
            {
                data.Giaban_Event = Convert.ToDouble(Giaban_Event.Replace(",", ""));
            }

            data.Content_Event = Content_Event;
            data.Content_EventEn = Content_EventEn;

            if (connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault
            (x => x.Name == data.Name && x.Id != data.Id) == null)// kiểm tra không được trùng tên
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
            string Idproduct = Id.ToString();
            var DataDeltete = connect_entity.CommentProducs.Where(x => x.Level == Idproduct).ToList();
            if (DataDeltete.Count > 0)
            {
                foreach (var item in DataDeltete)
                {
                    connect_entity.CommentProducs.Remove(item);
                    connect_entity.SaveChanges();
                }
            }
            Connect.Deleteone(Id);

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
            var data = connect_entity.GroupNewMenuSanPhamDetails.Find(Id);
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
            var Data_parent = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == id); //bind cấp cao nhất
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
                    var Data_child = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == Convert_LeverId_curent); //bind cấp con

                    if (Data_child.Level == null) //nhóm tin không có cấp độ
                    {
                        Name_tag = Data_child.Tag; //lấy giá trị tag làm id cho tin
                    }
                    else
                    {
                        int Convert_LeverId_child_curent = Convert.ToInt32(Data_child.Level);//chuyển đổi lại số nguyên
                        var Data_child_cha = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == Convert_LeverId_child_curent); //chuyển lên cấp cao hơn
                        Name_tag = Data_child_cha.Tag; //lấy giá trị tag làm id cho tin
                    }

                }
            }

            return Name_tag;
        }
        public string Resurt_Cateprolevel2(int id) //id is tag the lever group
        {
            string Name_tag = null; //mặc định là null
            var Data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == id);
            int Id_curent = Convert.ToInt32(Data.Level);
            if (Data.Level == null) //nếu là null
            {
                Name_tag = Data.Tag; //lấy tag chính nó
            }
            else //ngược lại
            {
                var Data_curent = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == Id_curent); //chuyển lên cấp cao hơn
                Name_tag = Data_curent.Tag; // lấy giá trị tag
            }
            return Name_tag;
        }
        public string Resurt_Cateprolevel3(int id)  //id is tag the lever group
        {
            string Name_tag = null; //mặc định là null
            var Data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == id);
            Name_tag = Data.Tag;
            return Name_tag;
        }

        //take value view when update of customers
        public int Resurt_View(int id) //id is key of GroupNewMenuSanPhamDetails
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == id);
            return Convert.ToInt32(data.Luotxem);
        }
        public int Resurt_Soluongmua(int id) //id is key of GroupNewMenuSanPhamDetails
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == id);
            return Convert.ToInt32(data.Soluongmua);
        }
        public DateTime Resurt_Date_Create(int id) //id is key of GroupNewMenuSanPhamDetails
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == id);
            return Convert.ToDateTime(data.DateCreate);
        }

        public DateTime Resurt_Date_view(int id) //id is key of GroupNewMenuSanPhamDetails
        {
            var data = connect_entity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == id);
            return Convert.ToDateTime(data.DateView);
        }
        public ActionResult Resurt_name_groupnew(string catelog) //Resurt action view html on screen
        {
            string Name = "";
            try
            {
                var data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Tag.Equals(catelog));
                Name = data.Name;
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
                var data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Id.Equals(Id));
                Name = data.Name;
                return (Name);
            }
            catch
            {
                return (Name);
            }
        }
        public string Resurt_name(string tag) //resurt get string values Name group news
        {
            var Data = connect_entity.GroupMenuSanPhams.FirstOrDefault(x => x.Tag == tag);
            return Data.Name;
        }

    }
}

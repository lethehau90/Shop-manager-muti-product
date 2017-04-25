using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Command;


namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.ThongKe
{
    public class DonhangadminController : Controller
    {
        //
        // GET: /Quanlywebsite/Donhangadmin/

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        GroupNew_Service Connect = new GroupNew_Service();
        public ActionResult Index()
        {
            return View();
        }

        #region List Đơn hàng

        public ActionResult List_donhang(string name)
        {
            Session["loi"] = "";
            if (string.IsNullOrEmpty(name))
            {
                var data = connect_entity.Donhangs.ToList();
                ViewBag.count = data.Count;
                return View(connect_entity.Donhangs.OrderByDescending(x => x.IDhd).ToList());
            }
            else
            {
                var data = connect_entity.Donhangs.Where(x => x.Hoten.Contains(name)).ToList();
                ViewBag.count = data.Count;
                return View(
                    connect_entity.Donhangs.Where(x => x.Hoten.Contains(name)).OrderByDescending(x => x.IDhd).ToList());
            }
        }


        public ActionResult List_donhang_DaDuyet(string name)
        {
            Session["loi"] = "";
            if (string.IsNullOrEmpty(name))
            {
                var data = connect_entity.Donhangs.ToList();
                ViewBag.count = data.Count;
                return
                    View(
                        connect_entity.Donhangs.Where(x => x.Duyet == "1").OrderByDescending(x => x.IDhd).ToList());
            }
            else
            {
                var data = connect_entity.Donhangs.Where(x => x.Hoten.Contains(name) & x.Duyet == "1").ToList();
                ViewBag.count = data.Count;
                return View(
                    connect_entity.Donhangs.Where(x => x.Hoten.Contains(name)).OrderByDescending(x => x.IDhd).ToList());
            }
        }


        public ActionResult List_donhang_ChuaDuyet(string name)
        {
            Session["loi"] = "";
            if (string.IsNullOrEmpty(name))
            {
                var data = connect_entity.Donhangs.ToList();
                ViewBag.count = data.Count;
                return
                    View(
                        connect_entity.Donhangs.Where(x => x.Duyet == "0").OrderByDescending(x => x.IDhd).ToList());
            }
            else
            {
                var data = connect_entity.Donhangs.Where(x => x.Hoten.Contains(name) & x.Duyet == "0").ToList();
                ViewBag.count = data.Count;
                return View(
                    connect_entity.Donhangs.Where(x => x.Hoten.Contains(name)).OrderByDescending(x => x.IDhd).ToList());
            }
        }

        public ActionResult List_donhang_Top5(string name)
        {
            Session["loi"] = "";
            var data = connect_entity.Donhangs.ToList();
            ViewBag.count = data.Count;
            return
                View(connect_entity.Donhangs.OrderByDescending(x => x.IDhd).Take(5).ToList());
        }

        public ActionResult List_donhang_Top10(string name)
        {
            Session["loi"] = "";
            var data = connect_entity.Donhangs.ToList();
            ViewBag.count = data.Count;
            return
                View(connect_entity.Donhangs.OrderByDescending(x => x.IDhd).Take(10).ToList());
        }

        public ActionResult List_donhang_Top50(string name)
        {
            Session["loi"] = "";
            var data = connect_entity.Donhangs.ToList();
            ViewBag.count = data.Count;
            return
                View(connect_entity.Donhangs.OrderByDescending(x => x.IDhd).Take(50).ToList());
        }

        public ActionResult List_donhang_Top100(string name)
        {
            Session["loi"] = "";
            var data = connect_entity.Donhangs.ToList();
            ViewBag.count = data.Count;
            return
                View(connect_entity.Donhangs.OrderByDescending(x => x.IDhd).Take(100).ToList());
        }

        #endregion

        public ActionResult Edit_donhang(int id)
        {

            var data_d = connect_entity.Donhangs.FirstOrDefault(x => x.IDhd.Equals(id));

            Donhang_Model model = new Donhang_Model();

            if(data_d != null)
            {
                model.IDhd = id;
                model.Hoten = data_d.Hoten;
                model.SDT = data_d.SDT;
                model.Mail = data_d.Mail;
                model.Diachi = data_d.Diachi;
                model.Tinh = data_d.Tinh;
                model.Huyen = data_d.Huyen;
                model.Xungho = data_d.Xungho;
                model.Hinhthucgiaohang = data_d.Hinhthucgiaohang;
                model.Tongtienhang = Convert.ToInt32(data_d.Tongtienhang);
                model.Duyet = data_d.Duyet;
                model.ngaydathang = Convert.ToDateTime(data_d.ngaydathang);
                model.GhiChuKhac = data_d.GhiChuKhac;
                model.Tiengiamgia = Convert.ToInt32(data_d.Tiengiamgia);
                ViewBag.id = id;
                string strURLOld = HttpContext.Request.UrlReferrer.ToString();
                ViewBag.link = strURLOld;
                Session["tongtien"] = model.Tongtienhang;
                Session["IDhd"] = model.IDhd;
            }

           
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit_donhang(Donhang_Model model)
        {
            if (ModelState.IsValid)
            {
                var data = connect_entity.Donhangs.FirstOrDefault(x => x.IDhd.Equals(model.IDhd));

                if (data != null)
                {
                    data.IDhd = model.IDhd;
                    data.Hoten = model.Hoten;
                    data.SDT = model.SDT;
                    data.Mail = model.Mail;
                    data.Diachi = model.Diachi;
                    data.Tinh = model.Tinh;
                    data.Huyen = model.Huyen;
                    data.Xungho = model.Xungho;
                    data.Hinhthucgiaohang = model.Hinhthucgiaohang;
                    // data.Tongtienhang = model.Tongtienhang;
                    data.Duyet = model.Duyet;
                    // data.ngaydathang = model.ngaydathang;
                    data.GhiChuKhac = model.GhiChuKhac;
                    data.Tiengiamgia = model.Tiengiamgia;
                    connect_entity.SaveChanges();
                    ModelState.AddModelError("", "Bạn Cập nhật Thành Công, Bấm Back Danh Sách để quay trở về");
                    ViewBag.id = model.IDhd;

                    string strURLOld = HttpContext.Request.UrlReferrer.ToString();
                    string strUrlHienTai = HttpContext.Request.Url.AbsoluteUri;
                    return Redirect(strURLOld);

                }
            }
            return View(model);

        }

        public ActionResult giohang_id(int id)
        {
            var data_C = connect_entity.CTdonhangs.Where(x => x.IDhd == id).ToList();
            return PartialView(data_C);
        }

        #region Xoaone

        public ActionResult Xoaone(int id)
        {


            var data = connect_entity.Donhangs.FirstOrDefault(x => x.IDhd.Equals(id));

            if (data != null)
            {


                connect_entity.CTdonhangs.Where(x => x.IDhd == (id)).ToList().ForEach(m => connect_entity.CTdonhangs.Remove(m));

                connect_entity.Donhangs.Remove(data);
                //   var dulieu = connect_entity.CTdonhangs.FirstOrDefault(x => x.IDhd == id);




                connect_entity.SaveChanges();

                ViewBag.loi = "Xóa Thành Công";

                Session["loi"] = ViewBag.loi;

            }

            return RedirectToAction("List_donhang", "Donhangadmin");
        }

        #endregion

        #region XoaAll

        public ActionResult XoaAll(int[] id)
        {
            if (id != null)
            {
                foreach (var i in id)
                {
                    var data = connect_entity.Donhangs.FirstOrDefault(x => x.IDhd.Equals(i));


                    if (data != null)
                    {
                        connect_entity.CTdonhangs.Where(x => x.IDhd == (i)).ToList().ForEach(m => connect_entity.CTdonhangs.Remove(m));

                        connect_entity.Donhangs.Remove(data);

                        connect_entity.SaveChanges();
                    }
                }

                ViewBag.loi = "Xóa Thành Công";

                Session["loi"] = ViewBag.loi;

            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = connect_entity.Donhangs.FirstOrDefault(x => x.IDhd.Equals(id));
            if (data != null)
            {


                connect_entity.CTdonhangs.Where(x => x.IDhd == (id)).ToList().ForEach(m => connect_entity.CTdonhangs.Remove(m));

                connect_entity.Donhangs.Remove(data);
                //   var dulieu = connect_entity.CTdonhangs.FirstOrDefault(x => x.IDhd == id);




                connect_entity.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int IDhd)
        {

            string result = Changeduyet(IDhd);
            return Json(new
            {


                Duyet = result
            });

        }

        public string Changeduyet(int id)
        {
            var donhang = connect_entity.Donhangs.Find(id);
            if (donhang.Duyet == "0")
                donhang.Duyet = "1";
            else
            {
                donhang.Duyet = "0";
            }
            connect_entity.SaveChanges();
            return donhang.Duyet;
        }

        ///code xuất ra êxce
        /// 
        /// 

        public void Excel()
        {
            var model = connect_entity.Asp_Excell_GetByAll();
            Export export = new Export();
            export.ToExcel(Response, model);
        }

        public void Excel_Daduyet()
        {
            var model = connect_entity.Asp_Excell_GetBy_duyet();
            Export export = new Export();
            export.ToExcel(Response, model);
        }

        public void Excel_Chuaduyet()
        {
            var model = connect_entity.Asp_Excell_GetBy_Chuaduyet();
            Export export = new Export();
            export.ToExcel(Response, model);
        }

        public void Excel_5Top()
        {
            var model = connect_entity.Asp_Excell_GetBy_5DHMoiNhat();
            Export export = new Export();
            export.ToExcel(Response, model);
        }

        public void Excel_10Top()
        {
            var model = connect_entity.Asp_Excell_GetBy_10DHMoiNhat();
            Export export = new Export();
            export.ToExcel(Response, model);
        }

        public void Excel_50Top()
        {
            var model = connect_entity.Asp_Excell_GetBy_50DHMoiNhat();
            Export export = new Export();
            export.ToExcel(Response, model);

        }

        public void Excel_100Top()
        {
            var model = connect_entity.Asp_Excell_GetBy_100DHMoiNhat();
            Export export = new Export();
            export.ToExcel(Response, model);

        }

        public void Excel_ToDay()
        {
            var model = connect_entity.Asp_Excell_GetBy_Today();
            Export export = new Export();
            export.ToExcel(Response, model);

        }


    }
}

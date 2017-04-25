using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Command;
using System.IO;

namespace Web_Shop_SettingIphone.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        public JsonResult Get_ThuonghieuNsx()
        {
            try
            {
                var data = connect_entity.DientuNsxes.Where(x => x.Active == true).OrderBy(x => x.Ord).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_DongThuonghieuNsx(int Id)
        {
            try
            {
                var data = connect_entity.DientuDongSps.Where(x => x.Active == true && x.Idnsx == Id).OrderBy(x => x.Ord).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ContentResult UploadFiles()
        {
            var r = new List<UploadFilesResult>();
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                // lay dung luong va kieu file tu the input file
                int fsize = hpf.ContentLength;
                var ftype = hpf.ContentType;
                var fname = hpf.FileName;

                if (fsize >= 5000000)
                {
                    return Content("{\"data\":\"1\"}", "application/json");
                }

                if (ftype == "image/png" || ftype == "image/gif" || ftype == "image/jpeg" || ftype == "image/pjpeg" || ftype == "application/vnd.ms-excel" || ftype == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                {
                    if (hpf.ContentLength == 0)
                        continue;

                    string savedFileName = Path.Combine(Server.MapPath("~/Uploads/images/UploadInfo"), Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName);

                    r.Add(new UploadFilesResult()
                    {
                        Name = hpf.FileName,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType
                    });
                    return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");

                }
                else
                {
                    return Content("{\"data\":\"2\"}", "application/json");
                }
            }
            return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
        }
       
        //cấu hình
        public ActionResult Setting_Config()
        {
            try
            {
                var data = connect_entity.Configs.Take(1).ToList();
                return PartialView(data);
            }
            catch (Exception)
            {

                return Redirect("/");
            }

        }

        public ActionResult Setting_Config_catelog()
        {
            try
            {
                var data = connect_entity.Configs.Take(1).ToList();
                return PartialView(data);
            }
            catch (Exception)
            {

                return Redirect("/");
            }
        }

        public ActionResult _Icon_web()
        {
            var data = connect_entity.Configs.Take(1).ToList();
            return PartialView(data);
        }

        public ActionResult _Tool_Scrip()
        {
            var data = connect_entity.Configs.Take(1).ToList();
            return PartialView(data);
        }
    }
}

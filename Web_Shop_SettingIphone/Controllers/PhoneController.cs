using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Command;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace Web_Shop_SettingIphone.Controllers
{
    public class PhoneController : Controller
    {
        //
        // GET: /Phone/
        public int PagegingProduct()
        {
            var data = connect_entity.Configs.FirstOrDefault();
            return Convert.ToInt32(data.pageging1);
        }
        public int Pagegingnews()
        {
            var data = connect_entity.Configs.FirstOrDefault();
            return Convert.ToInt32(data.pageging2);
        }
        public int Pagegingservice()
        {
            var data = connect_entity.Configs.FirstOrDefault();
            return Convert.ToInt32(data.pageging3);
        }
        public int Pagegingsupport()
        {
            var data = connect_entity.Configs.FirstOrDefault();
            return Convert.ToInt32(data.pageging4);
        }
        public int Pagegingsearch()
        {
            var data = connect_entity.Configs.FirstOrDefault();
            return Convert.ToInt32(data.pageging5);
        }


        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        //public ActionResult PhoneIndex(string Category_tag, int? trang) //dich vu
        //{


        //    //Seo

        //    if(Category_tag !=  null )
        //    {
        //        ViewBag.title = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag).Name;
        //        ViewBag.Description = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag).Description;
        //        ViewBag.Keyword = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag).Keyword;
        //        var data = connect_entity.GroupNewsNewsDetails.
        //        Where(x => x.Active == 1 && x.Cateprolevel3 == Category_tag).OrderBy(x => x.ord).ToPagedList(trang ?? 1, Pagegingservice());
        //        if (data.Count > 0)
        //        {
        //            ViewBag.categorydv = _resurtTendichvu(Category_tag);
        //            ViewBag.categorydvcontent = _resurtContentdichvu(Category_tag);
        //        }
        //        return View(data);
        //    }
        //    else
        //    {
        //        ViewBag.title = "Dịch vụ";
        //        ViewBag.categorydv = "Dịch vụ";
        //        var data = connect_entity.GroupNewsNewsDetails.
        //        Where(x => x.Active == 1 ).OrderBy(x => x.ord).ToPagedList(trang ?? 1, Pagegingservice());
        //        return View(data);
        //    }
        //}

        public ActionResult PhoneIndex(string Category_tag, int page = 1, int pageSize = 2) //dich vu
        {
            int totalRecord = 0;

            //Seo

            var data = connect_entity.GroupNewsNewsDetails.ToList();
            totalRecord = connect_entity.GroupNewsNewsDetails.ToList().Count();
            if (Category_tag != null)
            {
                ViewBag.title = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag).Name;
                ViewBag.Description = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag).Description;
                ViewBag.Keyword = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag).Keyword;
                data = data.Where(x => x.Active == 1 && x.Cateprolevel3 == Category_tag).OrderBy(x => x.ord).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                if (data.Count > 0)
                {
                    ViewBag.categorydv = _resurtTendichvu(Category_tag);
                    ViewBag.categorydvcontent = _resurtContentdichvu(Category_tag);
                }
                // return View(data);
            }
            else
            {
                ViewBag.title = "Dịch vụ";
                ViewBag.categorydv = "Dịch vụ";
                data = data.Where(x => x.Active == 1).OrderBy(x => x.ord).Skip((page - 1) * pageSize).Take(pageSize).ToList().ToList();
                //return View(data);
            }

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(data);
        }

        public string _resurtTendichvu(string Category_tag)
        {
            string s = "";
            var data = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag);
            if (data != null)
            {
                s = data.Name;
                return s;
            }
            else
                return s;
        }
        public string _resurtContentdichvu(string Category_tag)
        {
            string s = "";
            var data = connect_entity.GroupNews.FirstOrDefault(x => x.Tag == Category_tag);
            if (data != null)
            {
                s = data.content;
                return s;
            }
            else
                return s;
        }

        public ActionResult PhonedetailIndex(string Category_tag, string tag) //chi tiet dich vu
        {
            var data = connect_entity.GroupNewsNewsDetails.
                Where(x => x.Active == 1 && x.Cateprolevel3 == Category_tag && x.Tag == tag)
                .OrderBy(x => x.ord).ToList();
            ViewBag.title = data[0].Name;
            ViewBag.Description = data[0].Description;
            if (ViewBag.Description == "")
            {
                ViewBag.Description = data[0].Name;
            }
            ViewBag.Keyword = data[0].Keyword;
            if (ViewBag.Keyword == "")
            {
                ViewBag.Keyword = data[0].Name;
            }
            return View(data);
        }

        public ActionResult SamePhonedetailTTIndex(string tag) //cùng loại tin tức 
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Type == 1 && x.Tag != tag)
                .OrderBy(x => x.Ord).Take(6).ToList();
            return PartialView(data);
        }
        public ActionResult SamePhonedetailHTIndex(string tag) //cùng loại  hỗ trợ
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Type == 2 && x.Tag != tag)
                .OrderBy(x => x.Ord).Take(6).ToList();
            return PartialView(data);
        }
        public ActionResult HotSamePhonedetailIndex(string tag) //cùng loại Hot
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Tag != tag)
                .OrderBy(x => x.Ord).Take(10).ToList();
            return PartialView(data);
        }
        /// <summary>
        /// //////////////////////
        /// </summary>
        /// <param name="Category_tag"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ActionResult SamePhonedetailDVIndex(string Category_tag, string tag) //cùng loại dich vu
        {
            var data = connect_entity.GroupNewsNewsDetails.
                Where(x => x.Active == 1 && x.Cateprolevel3 == Category_tag && x.Tag != tag)
                .OrderBy(x => x.ord).Take(6).ToList();
            return PartialView(data);
        }
        public ActionResult HotSamePhoneDVdetailIndex(string Category_tag, string tag) //cùng loại Hot Dich vu
        {
            var data = connect_entity.GroupNewsNewsDetails.
                Where(x => x.Active == 1 && x.Tag != tag)
                .OrderBy(x => x.ord).Take(10).ToList();
            return PartialView(data);
        }


        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <returns></returns>
        public ActionResult PhonenewsIndex(int? trang) //tin tuc type 1
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Type == 1).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, Pagegingnews());
            var dataview = connect_entity.Htmls.FirstOrDefault(x => x.type == 2 && x.Active == 1);
            if (dataview != null)
            {
                ViewBag.categorytt = dataview.Ten;
                ViewBag.categoryttcontent = dataview.Html_content;
            }

            return View(data);
        }
        public ActionResult PhonenewsdetailIndex(string tag) //chi tiet tin tuc
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Type == 1 && x.Tag == tag)
                .OrderBy(x => x.Ord).ToList();
            ViewBag.title = data[0].Name;
            ViewBag.Description = data[0].Description;
            if (ViewBag.Description == "")
            {
                ViewBag.Description = data[0].Name;
            }
            ViewBag.Keyword = data[0].Keyword;
            if (ViewBag.Keyword == "")
            {
                ViewBag.Keyword = data[0].Name;
            }
            return View(data);
        }
        public ActionResult PhonesupportIndex(int? trang) //ho-tro type 2
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Type == 2).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, Pagegingsupport());
            var dataview = connect_entity.Htmls.FirstOrDefault(x => x.type == 4 && x.Active == 1);
            if (dataview != null)
            {
                ViewBag.categoryht = dataview.Ten;
                ViewBag.categoryhtcontent = dataview.Html_content;
            }
            return View(data);
        }
        public ActionResult PhonesupportdetailIndex(string tag) //chi tiet ho-tro
        {
            var data = connect_entity.Tintucs.
                Where(x => x.Active == true && x.Type == 2 && x.Tag == tag)
                .OrderBy(x => x.Ord).ToList();
            ViewBag.title = data[0].Name;
            ViewBag.Description = data[0].Description;
            if (ViewBag.Description == "")
            {
                ViewBag.Description = data[0].Name;
            }
            ViewBag.Keyword = data[0].Keyword;
            if (ViewBag.Keyword == "")
            {
                ViewBag.Keyword = data[0].Name;
            }
            return View(data);
        }

        public ActionResult PhoneProducteIndex(string Category_tag, int? trang) //sản phẩm
        {

            //var data = connect_entity.DientuMathangs.Where(x => x.Active == 1 && x.Cateprolevel3 == Category_tag).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, PagegingProduct());
            var dataview = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Tag == Category_tag);
            if (dataview != null)
            {
                ViewBag.categoryproduct = dataview.MenuName;
                ViewBag.categoryproductmota = dataview.Mota;
            }
            //Seo

            if (Category_tag != null)
            {
                ViewBag.title = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Tag == Category_tag).MenuName;
                ViewBag.Description = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Tag == Category_tag).Description;
                ViewBag.Keyword = connect_entity.DientuMenuSitemathangs.FirstOrDefault(x => x.Tag == Category_tag).Keyword;
            }
            else
            {
                ViewBag.title = "Điện thoại";
                ViewBag.categoryproduct = "Điện thoại";
            }

            if (Category_tag != null)
            {
                var data = connect_entity.DientuMathangs.Where(x => x.Active == 1 && x.Cateprolevel3 == Category_tag).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, PagegingProduct());
                return View(data);
            }
            else
            {
                var data = connect_entity.DientuMathangs.Where(x => x.Active == 1).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, PagegingProduct());
                return View(data);
            }

        }

        public ActionResult PhoneProducteIndexdetail(string Category_tag, string tag) //chi tiết sản phẩm
        {
            var data = connect_entity.DientuMathangs.Where(x => x.Active == 1 && x.Tag == tag).OrderBy(x => x.Ord).ToList();
            ViewBag.title = data[0].Tenhang;
            ViewBag.Description = data[0].Description;
            if (ViewBag.Description == "")
            {
                ViewBag.Description = data[0].Tenhang;
            }
            ViewBag.Keyword = data[0].Keyword;
            if (ViewBag.Keyword == "")
            {
                ViewBag.Keyword = data[0].Tenhang;
            }
            return View(data);
        }

        public ActionResult SameKindPhoneProducte(string Category_tag, string tag)
        {
            var data = connect_entity.DientuMathangs
                .Where(x => x.Active == 1 && x.Priority == 3 && x.Cateprolevel3 == Category_tag && x.Tag != tag)
                .Take(4).OrderBy(x => x.Ord).ToList();
            return PartialView(data);
        }

        public ActionResult Search(string currentFilter, string key, int? trang)
        {
            ViewBag.CurrentFilter = key;
            ViewBag.title = key;
            ViewBag.Description = key;
            ViewBag.Keyword = key;
            if (!string.IsNullOrEmpty(key))
            {
                var data = connect_entity.DientuMathangs.Where(x => x.Active == 1 & x.Tenhang.Contains(key)).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, Pagegingsearch());
                ViewBag.timkiem = key;
                ViewBag.count = data.Count;
                return View(data);
            }
            else
            {
                var data = connect_entity.DientuMathangs.Where(x => x.Active == 1).OrderBy(x => x.Ord).ToPagedList(trang ?? 1, Pagegingsearch());
                ViewBag.timkiem = key;
                ViewBag.count = data.Count;
                return View(data);
            }

        }

    }
}

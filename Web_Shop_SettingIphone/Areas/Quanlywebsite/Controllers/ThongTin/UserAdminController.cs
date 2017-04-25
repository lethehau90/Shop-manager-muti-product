using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Entity;
using System.Web.Security;
namespace Web_Shop_SettingIphone.Areas.Quanlywebsite.Controllers.UserMember
{
    public class UserAdminController : Controller
    {
        //
        // GET: /Quanlywebsite/UserAdmin/
        //start HttpCookie 
          //  HttpCookie Username = new HttpCookie("Username");
          //  HttpCookie Password = new HttpCookie("Password");
         
            //end HttpCookie 
        //public UserAdminController()
        //{
        //    User_Model model = new User_Model();
        //    model.Username = Request.Cookies["Username"].Value;
        //    model.Password = Request.Cookies["Password"].Value;
        //    if (Connect.Login(model) == true)
        //    {
        //        Session["Username"] = model.Username;
        //        Session.Timeout = 96000;
        //        Redirect("/Quanlywebsite/");
        //    }
        //    else
        //    {
        //        Session["Username"] = null;
        //        Redirect("/Quanlywebsite/");
        //    }


        //}

        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        User_Service Connect = new User_Service();
        int Resurt;
        #region LoginAdmin

        [AllowAnonymous]
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult GetLogin(string userName, string pw, string checkbox)
        {
            DateTime date = DateTime.Now;
            //Username.Value = userName;
            //Username.Expires = date.AddDays(3);
            //Password.Value = pw;
            //Password.Expires = date.AddDays(4);

            var result = new object();
            User_Model model = new User_Model();
            model.Username = userName;
            model.Password = pw;

            if (Connect.Login(model) == true)
            {
                //if (checkbox == "1")
                //{
                //    Username.Expires = date.AddDays(7);
                //    Password.Expires = date.AddDays(8);
                //    Response.Cookies.Add(Username);
                //    Response.Cookies.Add(Password);
                //}
                // lay gia tri cookies  Request.Cookies["Username"].Value;
                Session["Username_Web_config"] = userName;
               
                FormsAuthentication.SetAuthCookie(userName, false);


                //lay quyen của username
                String Role = Connect.GetAll().Where(x => x.Username == userName).Take(1).FirstOrDefault().Role;
                Session["Roles"] = Role;
                Session.Timeout = 96000;

                result = "/Quanlywebsite";
                Connect.Dispose();
            }
            else
            {
                result = "-1";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Logout()
        {
            //if (Request.Cookies["Username"] != null)
            //{
            //    HttpCookie myCookie = new HttpCookie("Username");
            //    myCookie.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCookie);
            //}
            //if (Request.Cookies["Password"] != null)
            //{
            //    HttpCookie myCookie = new HttpCookie("Password");
            //    myCookie.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCookie);
            //}

            FormsAuthentication.SignOut();//gan quyen = null
            Session["Username_Web_config"] = null;
            Session.Clear();
            
            return RedirectToAction("LoginAdmin", "UserAdmin");
        } 
        #endregion

        [Authorize(Roles = "Admin,Personnel")]
        public ActionResult Read()
        {
            var data = Connect .GetAll().OrderByDescending(x=>x.Ord).ToList();
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
        /// <summary>
        /// ChangeActive
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int ChangeActive(int Id)
        {
            var data = connect_entity.Users.Find(Id);
            if (data.Active == 0)
                data.Active = 1;
            else if (data.Active == 1)
            {
                data.Active = 0;
            }
            connect_entity.SaveChanges();
            return Convert.ToInt32(data.Active);
        }

       [Authorize(Roles = "Admin,Personnel")]
        public JsonResult Get_Read(int Id)
        {
            var data = connect_entity.Users.FirstOrDefault(x => x.Id == Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public JsonResult Deleteone(int Id)
        {
            Connect.Deleteone(Id);
            Resurt = 1;
            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }

        //////////////////////End Change Ord/

        //thục hiện action Insert

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Insert(string Name, string Username, string Password, string Ord, string Active, string Role)
        {
            User_Model model = new User_Model();//gọi model data
            model.Name = Name;
            model.Username = Username;
            model.Password = Password;
            model.Level = "";
            model.Admin = 1;
            model.Ord = Convert.ToInt32(Ord);
            model.Active = Convert.ToInt32(Active);
            model.Role= Role;
            if (connect_entity.Users.FirstOrDefault
               (x => x.Username == model.Username || x.Name == model.Name) == null)// kiểm tra không được trùng tên
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

        [HttpPost]
        [Authorize(Roles = "Admin")]  //Personnel
        public ActionResult Update(string Id, string Name, string Username, string Password, string Ord, string Active, string Role)
        {
            User_Model model = new User_Model();//gọi model data
            model.Id = Convert.ToInt32(Id);
            model.Name = Name;
            model.Username = Username;
            model.Password = Password;
            model.Level = "";
            model.Admin = 1;
            model.Ord = Convert.ToInt32(Ord);
            model.Active = Convert.ToInt32(Active);
            model.Role = Role;

            if (connect_entity.Users.FirstOrDefault
               (x => x.Username == model.Username && x.Id != model.Id || x.Name == model.Name && x.Id != model.Id) == null)// kiểm tra không được trùng tên
            {
                Connect.Update(model); //gọi service lưu
                Resurt = 1; 
            }
            else
            {
                Resurt = 0;
            }

            return Json(Resurt, JsonRequestBehavior.AllowGet);
        }


    }
}

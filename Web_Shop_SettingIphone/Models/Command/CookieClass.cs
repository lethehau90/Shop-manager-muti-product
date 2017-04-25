using System;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Command
{
    public class CookieClass
    {

        /// <summary>
        /// Get cookie name from cookie
        /// </summary>
        /// <param name="CookieName"></param>
        /// <returns></returns>
        public string GetCookie(string CookieName)
        {
            return HttpContext.Current.Request.Cookies[CookieName].Value;
        }
        /// <summary>
        /// Set string to cookie
        /// </summary>
        /// <param name="CookieName"></param>
        /// <param name="CookieValue"></param>
        public void SetCookie(string CookieName, string CookieValue)
        {
            HttpCookie aCookie = new  HttpCookie(CookieName);
            aCookie.Domain = "http://localhost:5575/";
            aCookie.Value = CookieValue;
            aCookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(aCookie);

        }
    }
}

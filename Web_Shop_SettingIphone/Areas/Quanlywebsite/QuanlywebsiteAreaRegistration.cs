using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Areas.Quanlywebsite
{
    public class QuanlywebsiteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Quanlywebsite";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
           

            context.MapRoute(
                "Quanlywebsite_default",
                "Quanlywebsite/{controller}/{action}/{id}",
                new { Controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

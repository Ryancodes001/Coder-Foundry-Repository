using System.Web.Mvc;

namespace Coder_Foundry_Portfolio.Areas.index2
{
    public class index2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "index2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "index2_default",
                "index2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
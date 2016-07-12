using System.Web;
using System.Web.Mvc;

namespace Coder_Foundry_Portfolio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

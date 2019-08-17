using System.Web;
using System.Web.Mvc;

namespace Impacta.AspNet.Mvc.ADO_01
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}

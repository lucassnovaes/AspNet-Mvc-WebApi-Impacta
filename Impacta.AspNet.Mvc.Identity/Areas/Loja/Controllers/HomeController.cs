using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.AspNet.Mvc.Identity.Areas.Loja.Controllers
{
    public class HomeController : Controller
    {
        // GET: Loja/Home
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult QuemSomos()
		{
			return View();
		}

		public ActionResult Contato()
		{
			return View();
		}
	}
}
using Impacta.AspNet.Mvc.DAL;
using Impacta.AspNet.Mvc.EF;
using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.AspNet.Mvc.ADO_01.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public object Contexto { get; private set; }

		public ActionResult Index()
		{
			try
			{
				return View();
			}
			catch (Exception ex) 
			{
				throw;
			}
		}

	}
}
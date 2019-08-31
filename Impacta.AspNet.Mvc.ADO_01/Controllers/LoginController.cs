using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Impacta.AspNet.Mvc.ADO_01.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Autenticacao()
        {
			Usuario usuario = null;
            return View(usuario);
        }
		public ActionResult AutenticacaoLogin(Usuario usuario)
		{
			FormsAuthentication.SetAuthCookie(usuario.Username,false);
			return RedirectToAction("Index", "Home");
			
		}
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Autenticacao");
		}

	}
}
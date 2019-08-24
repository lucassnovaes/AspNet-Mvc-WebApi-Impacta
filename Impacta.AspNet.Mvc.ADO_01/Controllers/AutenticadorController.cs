using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.AspNet.Mvc.ADO_01.Controllers
{
	public class AutenticadorController : Controller
	{
		public ActionResult Formulario()
		{
			return View();
		}


		public ActionResult Entrar(Usuario usuario)
		{
			if(!string.IsNullOrEmpty(usuario.Username) && !string.IsNullOrEmpty(usuario.Password))
			{
				if(usuario.Username.Equals("lucas.santana") && usuario.Password.Equals("lucas123"))
				{
					Session["Usuario"] = usuario;
					return RedirectToAction("Index", "RealBooks");
				}
				else
				{
					ViewBag.Message = "Usuário ou senha inválidos!";
					return View("Formulario");
				}
			}
			else
			{
				ViewBag.Message = "Usuário e senha obrigatórios!";
				return View("Formulario");
			}
		}
		public ActionResult Sair()
		{
			Session.Abandon();
			return RedirectToAction("Formulario", "Autenticador");
		}
	}
}
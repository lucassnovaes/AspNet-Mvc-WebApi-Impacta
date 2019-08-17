using Impacta.AspNet.Mvc.Business;
using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.AspNet.Mvc.ADO_01.Controllers
{
    public class RealBooksController : Controller
    {
        // GET: RealBooks
        public ActionResult Index()
        {
			EditoraBusiness editora = new EditoraBusiness();
			var lista = editora.listarEditoras();
            return View(lista);
        }

		[HttpGet]
		public ActionResult RegistraEditora()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RegistraEditora(Editora editora)
		{
			EditoraBusiness editoraEF = new EditoraBusiness();
			if (editoraEF.RegistraEditora(editora))
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			EditoraBusiness editoraEF = new EditoraBusiness();
			var editora = editoraEF.listarEditorasPorId(id).FirstOrDefault();
			return View(editora);
		}


		[HttpPost]
		public ActionResult Edit(int id, Editora editora)
		{
			EditoraBusiness editoraEF = new EditoraBusiness();
			if (editoraEF.AlterarEditora(id,editora))
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			EditoraBusiness editoraEF = new EditoraBusiness();
			if (editoraEF.RemoverEditora(id))
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}

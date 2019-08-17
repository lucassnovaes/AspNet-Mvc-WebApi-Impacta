using Impacta.AspNet.Mvc.ADO_01.Models;
using Impacta.AspNet.Mvc.DAL;
using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.AspNet.Mvc.ADO_01.Controllers
{
	public class TarefaController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult NovaTarefa(TarefaViewModel tarefaView)
		{

			if (ModelState.IsValid)
			{
				Data objData = new Data();
				TarefaMOD tarefaMOD = new TarefaMOD()
				{
					Nome = tarefaView.Nome,
					Prioridade = tarefaView.Prioridade,
					Concluido = tarefaView.Concluido,
					Observacao = tarefaView.Observacao
				};
				var resultado = objData.CriarTarefa(tarefaMOD);
				return RedirectToAction("ListarNovasTarefas");
			}
			else
			{
				ViewBag.Alerta = "Verifique os dados do formulario";
			}
			return View();
		}

		public ActionResult NovaTarefa()
		{
			return View();
		}

		public ActionResult ListarNovasTarefas()
		{
			List<TarefaMOD> tarefas = null;
			try
			{
				Data data = new Data();
				tarefas = data.ListarTarefas();

			}
			catch (Exception ex)
			{
				ViewBag.Alerta = "Verifique: " + ex.Message;
			}
			return View(tarefas);
		}


		[HttpGet]
		public ActionResult Edit(int id)
		{
			Data data = new Data();
			var tarefa = data.ConsultarTarefa(id);
			if (tarefa == null)
			{
				ViewBag.Alerta = "Não foi encontrado o registro";
				return View("ListarNovasTarefas");
			}
			return View(tarefa);
		}
		[HttpPost]
		public ActionResult Edit(int id, TarefaMOD tarefa)
		{
			Data data = new Data();
			tarefa.Id = id;
			if (data.AtualizarTarefa(tarefa))
			{
				ViewBag.Sucesso = "Tarefa atualizada!";
				return RedirectToAction("ListarNovasTarefas");
			}
			else
			{
				ViewBag.Alerta = "Não foi possivel atualizar!";
				return View("ListarNovasTarefas");
			}

		}

		public ActionResult Delete(int id)
		{
			Data data = new Data();
			if (data.ExcluirRegistro(id))
			{
				ViewBag.Sucesso = "Tarefa atualizada!";
				return RedirectToAction("ListarNovasTarefas");
			}
			else
			{
				ViewBag.Alerta = "Não foi possivel atualizar!";
				return View("ListarNovasTarefas");
			}
		}

	}
}

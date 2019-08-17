using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Impacta.AspNet.Mvc.ADO_01.Models
{
	public class TarefaViewModel
	{
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nome da tarefa")]
		public string Nome { get; set; }
		[Required]
		[Display(Name = "Prioridade definida")]
		public int Prioridade { get; set; }
		[Required]
		[Display(Name = "Tarefa concluida?")]
		public bool  Concluido { get; set; }
		[StringLength(200,ErrorMessage = "Maximo de 200 caracteres")]
		public string Observacao { get; set; }
	}
}
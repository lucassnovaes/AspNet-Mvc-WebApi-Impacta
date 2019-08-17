using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.AspNet.Mvc.MOD
{
	public class TarefaMOD
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Prioridade { get; set; }
		public bool Concluido { get; set; }
		public string Observacao { get; set; }
	}
}

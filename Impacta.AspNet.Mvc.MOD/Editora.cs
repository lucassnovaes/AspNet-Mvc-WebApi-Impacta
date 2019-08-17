using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.AspNet.Mvc.MOD
{
	public class Editora
	{
		[Display(Name ="CÓDIGO DA EDITORA")]
		public int EditoraId { get; set; }

		[Display(Name ="RAZÃO SOCIAL")]
		[Required(ErrorMessage ="Razão social deve ser informada")]
		public string Nome { get; set; }

		[EmailAddress]
		[Required(ErrorMessage ="E-mail de contato não está sendo informado")]
		public string Email { get; set; }

		[Required]
		public string Cnpj { get; set; }

		[Phone]
		public string Telefone { get; set; }

		public Endereco Endereco { get; set; }
		public string NumeroCelular { get; set; }
	}
}

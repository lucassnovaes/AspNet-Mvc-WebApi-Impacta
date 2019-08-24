using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.AspNet.Mvc.MOD
{
	public class Usuario
	{
		[Required(ErrorMessage = "Nome do usuário é obrigatório")]
		[Display(Name ="Usuário")]
		[StringLength(10, MinimumLength =5, ErrorMessage ="Usuário deve conter entre 5 e 8 caracteres")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Senha é obrigatória")]
		[Display(Name = "Senha")]
		public string Password { get; set; }
	}
}

﻿namespace Impacta.AspNet.Mvc.MOD
{
	public class Endereco
	{
		public int Id { get; set; }
		public string Logradouro { get; set; }
		public int Numero { get; set; }
		public string Complemento { get; set; }
		public string Cep { get; set; }
		public string Municipio { get; set; }
		public string Uf { get; set; }
	}
}
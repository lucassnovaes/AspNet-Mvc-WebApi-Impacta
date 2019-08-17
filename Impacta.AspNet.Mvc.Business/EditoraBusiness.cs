using Impacta.AspNet.Mvc.EF;
using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;

namespace Impacta.AspNet.Mvc.Business
{
	public class EditoraBusiness
	{
		public List<Editora> listarEditoras()
		{
			try
			{
				EditoraEF editora = new EditoraEF();
				return editora.listarEditoras();
			}
			catch (Exception ex)
			{

				throw new Exception("Falha ao buscar editoras. \nErro:" + ex.Message);
			}
		}
		public List<Editora> listarEditorasPorId(int id)
		{
			try
			{
				EditoraEF editora = new EditoraEF();
				return editora.listarEditorasPorId(id);
			}
			catch (Exception ex)
			{

				throw new Exception("Falha ao buscar editoras. \nErro:" + ex.Message);
			}
		}


		public bool RegistraEditora(Editora editora)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(editora.Nome))
					throw new Exception("Nome precisa ser preenchido");
				if (string.IsNullOrWhiteSpace(editora.Email))
					throw new Exception("Email precisa ser preenchido");
				EditoraEF editoraEF = new EditoraEF();
				return editoraEF.RegistraEditora(editora);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public bool AlterarEditora(int id, Editora editora)
		{
			EditoraEF editoraEF = new EditoraEF();
			return editoraEF.AlterarEditora(id, editora);
		}

		public bool RemoverEditora(int id)
		{
			EditoraEF editoraEF = new EditoraEF();
			return editoraEF.RemoverEditora(id);
		}
	}
}

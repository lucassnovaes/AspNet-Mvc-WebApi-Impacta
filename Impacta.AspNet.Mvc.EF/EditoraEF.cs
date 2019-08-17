using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Impacta.AspNet.Mvc.EF
{
	public class EditoraEF
	{
		public List<Editora> listarEditoras()
		{
			try
			{
				using (var db = new RealBooksContexto())
				{
					return db.Editoras.ToList();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Editora> listarEditorasPorId(int id)
		{
			try
			{
				using (var db = new RealBooksContexto())
				{
					return db.Editoras.Where(p => p.EditoraId == id).ToList();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool RegistraEditora(Editora editora)
		{
			try
			{
				using (var db = new RealBooksContexto())
				{
					db.Editoras.Add(editora);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex; 
			}
			return true;
		}

		public bool AlterarEditora(int id, Editora editora)
		{
			try
			{
				using (var db = new RealBooksContexto())
				{
					using (var transaction = db.Database.BeginTransaction())
					{
						try
						{
							var resultEditora = db.Editoras.Where(e => e.EditoraId == id).FirstOrDefault();
							resultEditora.Nome = editora.Nome;
							resultEditora.Email = editora.Email;
							resultEditora.Cnpj = editora.Cnpj;
							resultEditora.Telefone = editora.Telefone;
							resultEditora.NumeroCelular = editora.NumeroCelular;
							db.SaveChanges();
							transaction.Commit();
						}
						catch (Exception e)
						{
							transaction.Rollback();
							throw e;
						}
					}
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return true;
		}

		public bool RemoverEditora(int id)
		{
			try
			{
				using (var db = new RealBooksContexto())
				{
					var editora = db.Editoras.Where(i => i.EditoraId == id).FirstOrDefault();
					db.Editoras.Remove(editora);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return true;
		}
	}
}

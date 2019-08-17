using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Impacta.AspNet.Mvc.DAL
{
	public class Data
	{
		SqlConnection SqlConn;
		SqlCommand cmd;
		bool resultado;

		string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TAREFAS;
						Integrated Security=True;Connect Timeout=30;Encrypt=False;
						TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public Data()
		{
			
		}

		private bool CriarConexao()
		{
			bool criadoConexao = false;
			if (SqlConn == null)
			{

				SqlConn = new SqlConnection(cs);
				criadoConexao = true; 
			}
			return criadoConexao;
		}

		private void CriarComando(string querySql, TarefaMOD objModelTarefa)
		{
			cmd = new SqlCommand();

			cmd.CommandText = querySql;
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.Parameters.AddWithValue("@Nome", objModelTarefa.Nome);
			cmd.Parameters.AddWithValue("@Prioridade", objModelTarefa.Prioridade);
			cmd.Parameters.AddWithValue("@Concluido", objModelTarefa.Concluido);
			cmd.Parameters.AddWithValue("@Observacoes", objModelTarefa.Observacao);

			cmd.Connection = SqlConn; 
		}

		public bool CriarTarefa(TarefaMOD tarefa)
		{
			resultado = false;
			try
			{
				string query =
					@"INSERT INTO TAREFA (NOME, PRIORIDADE, CONCLUIDO,  OBSERVACOES)
						VALUES (@Nome, @Prioridade, @Concluido, @Observacoes)";
				if (CriarConexao())
				{
					CriarComando(query, tarefa);
					SqlConn.Open();
					var ret = cmd.ExecuteNonQuery();
					resultado = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if(SqlConn.State == System.Data.ConnectionState.Open)
				{
					SqlConn.Close();
				}
			}
			return resultado;
		}

		public List<TarefaMOD> ListarTarefas()
		{
			resultado = false;
			List<TarefaMOD> lista = new List<TarefaMOD>();
			try
			{
				if (CriarConexao())
				{
					string query = @"SELECT Id,Nome,Prioridade,Concluido,Observacoes FROM TAREFA ORDER BY Concluido,Prioridade";
					using (var conn = SqlConn)
					{
						conn.Open();
						using (var cmd = new SqlCommand(query, conn))
						{
							using (var dr = cmd.ExecuteReader())
							{
								while (dr.Read())
								{
									var tarefa = new TarefaMOD()
									{
										Id = Convert.ToInt32(dr["id"]),
										Nome = dr["Nome"].ToString(),
										Prioridade = Convert.ToInt32(dr["Prioridade"]),
										Concluido = Convert.ToBoolean(dr["Concluido"]),
										Observacao = dr["Observacoes"].ToString()
									};
									lista.Add(tarefa);

								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (SqlConn.State == System.Data.ConnectionState.Open)
					SqlConn.Close();
			}
			return lista;
		}

		public TarefaMOD ConsultarTarefa(int id)
		{
			TarefaMOD tarefa = new TarefaMOD();
			try
			{
				if (CriarConexao())
				{
					string sql = "SELECT * FROM TAREFA WHERE ID = @id";
					using (var conn = SqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@id", id);
							conn.Open();
							var reader = cmd.ExecuteReader();
							while (reader.Read())
							{
								tarefa = new TarefaMOD()
								{
									Id = Convert.ToInt32(reader["id"]),
									Prioridade = Convert.ToInt32(reader["Prioridade"]),
									Concluido = Convert.ToBoolean(reader["Concluido"]),
									Nome = reader["Nome"].ToString(),
									Observacao = reader["OBSERVACOES"].ToString(),
								};
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (SqlConn.State == System.Data.ConnectionState.Open)
					SqlConn.Close();
			}
			return tarefa;
		}

		public bool AtualizarTarefa(TarefaMOD tarefa)
		{
			bool retorno = false;
			try
			{
				if (CriarConexao())
				{
					string sql = "UPDATE TAREFA SET" +
						" NOME = @Nome," +
						" PRIORIDADE = @Prioridade," +
						" CONCLUIDO = @Concluido," +
						" OBSERVACOES = @Observacoes" +
						" WHERE ID = @Id";

					using (var conn = SqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
							cmd.Parameters.AddWithValue("@Prioridade", tarefa.Prioridade);
							cmd.Parameters.AddWithValue("@Concluido", tarefa.Concluido);
							cmd.Parameters.AddWithValue("@Observacoes", tarefa.Observacao);
							cmd.Parameters.AddWithValue("@Id", tarefa.Id);
							conn.Open();
							retorno = cmd.ExecuteNonQuery()> 0 ? true : false;
						}
					}
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				if (SqlConn.State == System.Data.ConnectionState.Open)
					SqlConn.Close();
			}
			return retorno;
		}

		public bool ExcluirRegistro(int id)
		{
			bool retorno = false;
			try
			{
				string sql = @"DELETE FROM TAREFA WHERE ID = @ID";
				if (CriarConexao())
				{
					using (var conn = SqlConn)
					{
						using (var cmd = new SqlCommand(sql, conn))
						{
							cmd.Parameters.AddWithValue("@ID",id);
							conn.Open();
							retorno = cmd.ExecuteNonQuery() > 0 ? true : false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return retorno;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Impacta.Client.Api
{
	class Program
	{
		static void Main(string[] args)
		{
			RunAsync().Wait();
		}
		static async Task RunAsync()
		{
			var formato = new MediaTypeWithQualityHeaderValue("application/json");
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:52839/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(formato);

				var resposta = await client.GetAsync("api/editora");
				var conteudo = await resposta.Content.ReadAsAsync<List<object>>();
				Console.WriteLine(conteudo[0]);

			}
			Console.ReadLine();
		}
	}
}


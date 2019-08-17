using Impacta.AspNet.Mvc.Business;
using Impacta.AspNet.Mvc.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Impacta.Tarefas.WebApi.Controllers
{
    public class EditoraController : ApiController
    {
		EditoraBusiness editora;

		public IEnumerable<Editora> Get()
        {
			editora = new EditoraBusiness();
			var result = editora.listarEditoras();
			return result;
        }


        public Editora Get(int id)
        {
			editora = new EditoraBusiness();
			var result = editora.listarEditorasPorId(id);
            return result.FirstOrDefault();
        }

        public void Post(Editora objEditora)
        {
			editora = new EditoraBusiness();
			editora.RegistraEditora(objEditora);

        }

        public void Put(int id, Editora objEditora)
        {
			editora = new EditoraBusiness();
			editora.AlterarEditora(id, objEditora);
		}

       
        public void Delete(int id)
        {
			editora = new EditoraBusiness();
			editora.RemoverEditora(id);
		}
    }
}

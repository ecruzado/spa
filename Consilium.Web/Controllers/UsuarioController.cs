using Consilium.Entity;
using Consilium.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consilium.Web.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/usuario
        public IEnumerable<Usuario> Get(int colegioId)
        {
            var lista = UsuarioLogica.Instancia.List(colegioId);
            if (lista != null)
                lista.Insert(0,new Usuario { UsuarioId = 0, Codigo = "--Seleccionar Usuario--" });
            return lista;
        }


        // POST api/usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT api/usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/usuario/5
        public void Delete(int id)
        {
        }
    }
}

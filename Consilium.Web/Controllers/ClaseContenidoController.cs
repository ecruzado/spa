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
    public class ClaseContenidoController : ApiController
    {
        // GET api/clasecontenido
        public IEnumerable<ClaseContenido> Get(int claseId)
        {
            var lista = ClaseLogica.Instancia.ListClaseContenidoByClase(claseId);
            return lista;
        }


        // POST api/clasecontenido
        public void Post([FromBody]string value)
        {
        }

        // PUT api/clasecontenido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasecontenido/5
        public void Delete(int id)
        {
        }
    }
}

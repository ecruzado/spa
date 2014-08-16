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
    public class ClaseValorController : ApiController
    {
        // GET api/clasevalor
        public IEnumerable<ClaseValor> Get(int claseId)
        {
            return ClaseLogica.Instancia.ListClaseValorByClase(claseId);
        }

        // POST api/clasevalor
        public void Post([FromBody]ClaseValor claseValor)
        {
            ClaseLogica.Instancia.CrearClaseValor(claseValor);
        }

        // PUT api/clasevalor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasevalor/5
        public void Delete(int id)
        {
            ClaseLogica.Instancia.DeleteClaseValor(new ClaseValor{ClaseValorId = id});
        }
    }
}

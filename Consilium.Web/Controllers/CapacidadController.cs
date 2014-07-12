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
    public class CapacidadController : ApiController
    {
        // GET api/capacidad
        public IEnumerable<DeArea> Get(int colegioId, int areaId)
        {
            var lista = DeAreaLogica.Instancia.ListByAreaAndColegio(new DeArea { ColegioId = colegioId, AreaId = areaId });
            return lista;
        }

        // GET api/capacidad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/capacidad
        public void Post([FromBody]string value)
        {
        }

        // PUT api/capacidad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/capacidad/5
        public void Delete(int id)
        {
        }
    }
}

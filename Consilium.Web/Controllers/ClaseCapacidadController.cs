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
    public class ClaseCapacidadController : ApiController
    {
        // GET api/clasecapacidad
        public IEnumerable<ClaseCapacidad> Get(int claseId)
        {
            var list = ClaseLogica.Instancia.ListClaseCapacidadByClase(claseId);
            return list;
        }

        // POST api/clasecapacidad
        public void Post([FromBody]ClaseCapacidad capacidad)
        {
            ClaseLogica.Instancia.CrearClaseCapacidad(capacidad);
        }

        // PUT api/clasecapacidad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasecapacidad/5
        public void Delete(int id)
        {
            ClaseLogica.Instancia.DeleteClaseCapacidad(new ClaseCapacidad { ClaseCapacidadId = id });
        }
    }
}

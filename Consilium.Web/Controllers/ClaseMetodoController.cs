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
    public class ClaseMetodoController : ApiController
    {
        // GET api/clasemetodo
        public IEnumerable<ClaseMetodo> Get(int claseId)
        {
            return ClaseLogica.Instancia.ListClaseMetodoByClase(claseId);
        }

        // POST api/clasemetodo
        public void Post([FromBody]ClaseMetodo claseMetodo)
        {
            ClaseLogica.Instancia.CrearClaseMetodo(claseMetodo);
        }

        // PUT api/clasemetodo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasemetodo/5
        public void Delete(int id)
        {
            ClaseLogica.Instancia.DeleteClaseMetodo(new ClaseMetodo{ClaseMetodoId = id});
        }
    }
}

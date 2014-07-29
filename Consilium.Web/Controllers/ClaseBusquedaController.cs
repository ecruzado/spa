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
    public class ClaseBusquedaController : ApiController
    {
        // GET api/clasebusqueda
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/clasebusqueda/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/clasebusqueda
        public List<Clase> Post([FromBody]Clase busqueda)
        {
            if(busqueda.Usuario.Equals("--Seleccionar Usuario--"))
                busqueda.Usuario = "";
            return ClaseLogica.Instancia.ListByFiltro(busqueda);
        }

        // PUT api/clasebusqueda/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasebusqueda/5
        public void Delete(int id)
        {
        }
    }
}

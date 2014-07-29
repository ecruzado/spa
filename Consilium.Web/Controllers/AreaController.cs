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
    public class AreaController : ApiController
    {
        // GET api/area
        public IEnumerable<Area> Get()
        {
            var lista = AreaLogica.Instancia.List();
            if (lista != null)
                lista.Insert(0, new Area { AreaId = 0, Descripcion = "Seleccionar Area" });
            return lista;
        }

        // GET api/area/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/area
        public void Post([FromBody]string value)
        {
        }

        // PUT api/area/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/area/5
        public void Delete(int id)
        {
        }
    }
}

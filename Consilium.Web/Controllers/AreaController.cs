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
        public IEnumerable<Area> Get(int colegioId)
        {
            var lista = AreaLogica.Instancia.List(colegioId);
            /*if (lista != null)
                lista.Insert(0, new Area { AreaId = 0, Descripcion = "--todos las areas--" });*/
            return lista;
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

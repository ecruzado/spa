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
    public class ListaColumnaController : ApiController
    {
        // GET api/listacolumna
        public IEnumerable<ItemNodo> Get(int columnaId, int colegioId, int areaId)
        {
            var busqueda = new ConfColumnaColegio{ColumnaId = columnaId, ColegioId = colegioId, AreaId = areaId};
            return ConfColumnaColegioLogica.Instancia.ListNodosByColumnaAndColegioAndArea(busqueda);
        }

        // GET api/listacolumna/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/listacolumna
        public void Post([FromBody]string value)
        {
        }

        // PUT api/listacolumna/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/listacolumna/5
        public void Delete(int id)
        {
        }
    }
}

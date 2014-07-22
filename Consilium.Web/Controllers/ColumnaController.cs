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
    public class ColumnaController : ApiController
    {
        // GET api/columna
        public IEnumerable<ConfColumnaColegio> Get(int colegioId,int columnaId,int areaId, int padreId)
        {
            var busqueda = new ConfColumnaColegio{ColegioId = 5,ColumnaId = 1,AreaId = areaId,ConfColumnaColegioPadreId = padreId};
            return ConfColumnaColegioLogica.Instancia.ListByColumnaAndColegio(busqueda);
        }

        // GET api/columna/5
        public ConfColumnaColegio Get(int id)
        {
            return ConfColumnaColegioLogica.Instancia.Get(id);
        }

        // POST api/columna
        public void Post([FromBody]ConfColumnaColegio value)
        {
            if(value.ConfColumnaColegioId == 0)
                ConfColumnaColegioLogica.Instancia.Crear(value);
            else
                ConfColumnaColegioLogica.Instancia.Actualizar(value);
        }

        // PUT api/columna/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/columna/5
        public void Delete(int id)
        {
        }
    }
}

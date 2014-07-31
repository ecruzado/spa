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
    public class ClaseColumnaController : ApiController
    {
        // GET api/clasecolumna
        public IEnumerable<ItemNodo> Get(int claseId, int columnaId)
        {
            return ClaseConfColumnaColegioLogica.Instancia.ListByClase(new ClaseColColumnaColegio {ClaseId = claseId,ColumnaId = columnaId });
        }

        // POST api/clasecolumna
        public void Post([FromBody]ClaseColColumnaColegio entidad)
        {
            ClaseConfColumnaColegioLogica.Instancia.Crear(entidad);
        }

        // PUT api/clasecolumna/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasecolumna/5
        public void Delete(int id)
        {
            ClaseConfColumnaColegioLogica.Instancia.Eliminar(new ClaseColColumnaColegio { ClaseColColumnaColegioId = id });
        }
    }
}

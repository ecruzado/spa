using Consilium.Entity;
using Consilium.Entity.Constantes;
using Consilium.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consilium.Web.Controllers
{
    public class ColumnaColegioController : ApiController
    {
        // GET api/columnacolegio
        public ColumnaColegio Get(int columnaId, int colegioId)
        {
            var busqueda = new ColumnaColegio{ColumnaId = columnaId, ColegioId = colegioId};
            var entidad = ColumnaColegioLogica.Instancia.Get(busqueda);
            if (entidad == null)
            {
                busqueda.ColegioId = Constantes.COLEGIO_DEFECTO;
                entidad = ColumnaColegioLogica.Instancia.Get(busqueda);
            }
            return entidad;
        }

        // POST api/columnacolegio
        public void Post([FromBody]ColumnaColegio columnaColegio)
        {
            ColumnaColegioLogica.Instancia.Actualizar(columnaColegio);
        }

        // PUT api/columnacolegio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/columnacolegio/5
        public void Delete(int id)
        {
        }
    }
}

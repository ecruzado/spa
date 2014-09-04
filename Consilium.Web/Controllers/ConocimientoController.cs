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
    public class ConocimientoController : ApiController
    {
        // GET api/conocimiento
        public IEnumerable<Contenido> Get(int colegioId, int areaId)
        {
            return ContenidoLogica.Instancia.ListConocimiento(colegioId, areaId);
        }

        // POST api/conocimiento
        public void Post([FromBody]Contenido value)
        {
            if (value.ConocimientoId == 0)
                ContenidoLogica.Instancia.CrearConocimiento(value);
            else
                ContenidoLogica.Instancia.ActualizarConocimiento(value);
        }

        // POST api/conocimiento
        public void Delete(int id)
        {
            ContenidoLogica.Instancia.DeleteConocimiento(id);
        }
    }
}

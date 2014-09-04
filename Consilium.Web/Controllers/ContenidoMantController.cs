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
    public class ContenidoMantController : ApiController
    {
        // GET api/contenidomant
        public List<Contenido> Get(int detalleId)
        {
            var busqueda = new Contenido();
            busqueda.DetalleId = detalleId;

            return ContenidoLogica.Instancia.ListContenido(busqueda);
        }

        // POST api/contenidomant
        public void Post([FromBody]Contenido value)
        {
            if (value.ContenidoId == 0)
                ContenidoLogica.Instancia.CrearContenido(value);
            else
                ContenidoLogica.Instancia.ActualizarContenido(value);
        }
    }
}

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
    public class DetalleController : ApiController
    {
        // GET api/detalle
        public List<Contenido> Get(int nivelId, int gradoId, int conocimientoId) 
        {
            var busqueda = new Contenido();
            busqueda.NivelId = nivelId;
            busqueda.GradoId = gradoId;
            busqueda.ConocimientoId = conocimientoId;

            return ContenidoLogica.Instancia.ListDetalle(busqueda);
        }

        // POST api/detalle
        public void Post([FromBody]Contenido value)
        {
            if (value.DetalleId == 0)
                ContenidoLogica.Instancia.CrearDetalle(value);
            else
                ContenidoLogica.Instancia.ActualizarDetalle(value);
        }
    }
}

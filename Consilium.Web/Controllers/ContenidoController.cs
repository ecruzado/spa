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
    public class ContenidoController : ApiController
    {
        // GET api/contenido
        public IEnumerable<Contenido> Get(int colegioId,int areaId, int nivelId, int gradoId)
        {
            var busqueda = new Contenido
            {
                ColegioId = colegioId,
                Area = areaId,
                NivelId = nivelId,
                GradoId = gradoId
            };
            return ContenidoLogica.Instancia.ListContenidoByColegioAndAreaAndNivelAndGrado(busqueda);
        }

        // GET api/contenido/5
        public string Get(int id)
        {
            return "value";
        }
    }
}

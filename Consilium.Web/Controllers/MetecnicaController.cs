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
    public class MetecnicaController : ApiController
    {
        public List<Metodologia> Get(int criterioId)
        {
            return MetodologiaLogica.Instancia.ListMetecnicaByCriterio(criterioId);
        }

        // POST api/columna
        public void Post([FromBody]Metodologia value)
        {
            if (value.MetecnicaId == 0)
                MetodologiaLogica.Instancia.CrearMetecnica(value);
            else
                MetodologiaLogica.Instancia.ActualizarMetecnica(value);
        }
    }
}

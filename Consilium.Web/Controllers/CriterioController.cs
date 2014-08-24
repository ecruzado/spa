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
    public class CriterioController : ApiController
    {
        public List<Metodologia> Get(int colegioId, int areaId) 
        {
            return MetodologiaLogica.Instancia.ListCriterioByColegioAndArea(colegioId, areaId);
        }

        // POST api/columna
        public void Post([FromBody]Metodologia value)
        {
            if (value.CriterioId == 0)
                MetodologiaLogica.Instancia.CrearCriterio(value);
            else
                MetodologiaLogica.Instancia.ActualizarCriterio(value);
        }
    }
}

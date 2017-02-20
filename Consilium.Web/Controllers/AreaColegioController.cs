using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Entity;
using Consilium.Logica;
using System.Web.Http;

namespace Consilium.Web.Controllers
{
    public class AreaColegioController : ApiController
    {

        // GET api/area/5
        public IEnumerable<Area> Get(int colegioId)
        {
            var lista = AreaLogica.Instancia.ListByColegio(colegioId);
            return lista;
        }

        // POST api/area
        public void Post([FromBody]Area area)
        {
            AreaLogica.Instancia.Actualizar(area);
        }

    }
}

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
    public class CapacidadController : ApiController
    {
        // GET api/capacidad
        public List<ItemNodo> Get(int colegioId, int areaId)
        {
            var lista = CapacidadLogica.Instancia.ListByColegioAndArea(colegioId, areaId);
            return lista;
        }


    }
}

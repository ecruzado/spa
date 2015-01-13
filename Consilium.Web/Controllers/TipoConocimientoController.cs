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
    public class TipoConocimientoController : ApiController
    {
        // GET api/tipoconocimiento
        public IEnumerable<ItemNodo> Get()
        {
            return ConocimientoLogica.Instancia.List();
        }

        // GET api/tipoconocimiento/5
        public string Get(int id)
        {
            return "value";
        }
    }
}

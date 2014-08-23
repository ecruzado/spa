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
    public class ValorController : ApiController
    {
        // GET api/nivel
        public IEnumerable<ItemNodo> Get(int colegioId)
        {
            var lista = ValorLogica.Instancia.ListByColegio(colegioId);
            return lista;
        }
    }
}

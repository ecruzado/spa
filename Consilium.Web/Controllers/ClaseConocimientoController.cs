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
    public class ClaseConocimientoController : ApiController
    {
        // GET api/claseconocimiento
        public IEnumerable<ItemNodo> Get(int claseId)
        {
            var list = ClaseLogica.Instancia.ListClaseConocimientoByClase(claseId);
            return list;
        }

        // POST api/claseconocimiento
        public void Post([FromBody]ItemNodo claseConocimiento)
        {
            ClaseLogica.Instancia.CrearClaseConocimiento(claseConocimiento);
        }

        // DELETE api/claseconocimiento/5
        public void Delete(int id)
        {
            ClaseLogica.Instancia.DeleteClaseConocimiento(new ItemNodo { NodoId = id });
        }
    }
}

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
    public class ClasePruebaController : ApiController
    {
        // GET api/claseprueba
        public IEnumerable<ItemNodo> Get(int claseId)
        {
            var list = ClaseLogica.Instancia.ListClasePruebaByClase(claseId);
            return list;
        }

        // POST api/claseprueba
        public void Post([FromBody]ItemNodo clasePrueba)
        {
            ClaseLogica.Instancia.CrearClasePrueba(clasePrueba);
        }

        // DELETE api/claseprueba/5
        public void Delete(int id)
        {
            ClaseLogica.Instancia.DeleteClasePrueba(new ItemNodo { NodoId = id });
        }
    }
}

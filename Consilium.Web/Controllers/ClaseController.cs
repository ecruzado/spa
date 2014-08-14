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
    public class ClaseController : ApiController
    {
        // GET api/clase
        public IEnumerable<Clase> Get()
        {
            return ClaseLogica.Instancia.List(5);
        }

        // GET api/clase/5
        public Clase Get(int claseId)
        {
            return ClaseLogica.Instancia.Get(claseId);
        }

        // POST api/clase
        public Clase Post([FromBody]Clase value)
        {
            if (value.ClaseId == 0)
            {
                value.FechaRegistro = DateTime.UtcNow;
                var resultado = ClaseLogica.Instancia.Crear(value);
                value.ClaseId = resultado;
                return value;
            }
            else 
            {
                 ClaseLogica.Instancia.Actualizar(value);
                 return value;
            }
        }

        // PUT api/clase/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clase/5
        public void Delete(int id)
        {
        }
    }
}

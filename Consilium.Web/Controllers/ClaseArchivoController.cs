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
    public class ClaseArchivoController : ApiController
    {
        // GET api/clasearchivo
        public IEnumerable<ClaseArchivo> Get(int claseId)
        {
            return ClaseLogica.Instancia.ListClaseArchivoByClase(claseId);
        }


        // POST api/clasearchivo
        public void Post([FromBody]ClaseArchivo claseArchivo)
        {
            if (claseArchivo.ClaseArchivoId == 0)
                ClaseLogica.Instancia.CrearClaseArchivo(claseArchivo);
            else
                ClaseLogica.Instancia.ActualizarClaseArchivo(claseArchivo);
        }

        // PUT api/clasearchivo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasearchivo/5
        public void Delete([FromUri]int[] ids = null)
        {
        }
    }
}

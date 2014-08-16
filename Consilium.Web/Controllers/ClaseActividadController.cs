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
    public class ClaseActividadController : ApiController
    {
        // GET api/claseactividad
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/claseactividad/5
        public ClaseActividad Get(int claseid)
        {
            return ClaseLogica.Instancia.GetClaseActividadByClase(claseid);
        }

        // POST api/claseactividad
        public void Post([FromBody]ClaseActividad claseActividad)
        {
            if(claseActividad != null)
            {
                if (claseActividad.ClaseActividadId == 0)
                    ClaseLogica.Instancia.ActualizarClaseActvidad(claseActividad);
                else
                    ClaseLogica.Instancia.ActualizarClaseActvidad(claseActividad);
            }
        }

        // PUT api/claseactividad/5
        public void Put(int id, [FromBody]ClaseActividad claseActividad)
        {
            ClaseLogica.Instancia.ActualizarClaseActvidad(claseActividad);
        }

        // DELETE api/claseactividad/5
        public void Delete(int id)
        {
        }
    }
}

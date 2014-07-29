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
    public class GradoController : ApiController
    {
        // GET api/grado
        public IEnumerable<Grado> Get(int nivelId)
        {
            var lista = GradoLogica.Instancia.ListByNivel(nivelId);
            if(lista != null)
                lista.Insert(0,new Grado{GradoId=0,GradoDesc="--Seleccionar Grado--"});
            return lista;
        }

        // POST api/grado
        public void Post([FromBody]string value)
        {
        }

        // PUT api/grado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/grado/5
        public void Delete(int id)
        {
        }
    }
}

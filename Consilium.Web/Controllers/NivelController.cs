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
    public class NivelController : ApiController
    {
        // GET api/nivel
        public IEnumerable<Nivel> Get()
        {
            var lista = NivelLogica.Instancia.List();
            if(lista != null)
                lista.Insert(0,new Nivel{NivelId=0,NivelDesc="--Seleccionar Nivel--"});
            return lista;
        }

        // GET api/nivel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/nivel
        public void Post([FromBody]string value)
        {
        }

        // PUT api/nivel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/nivel/5
        public void Delete(int id)
        {
        }
    }
}

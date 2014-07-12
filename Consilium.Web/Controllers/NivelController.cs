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
            return NivelLogica.Instancia.List();
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

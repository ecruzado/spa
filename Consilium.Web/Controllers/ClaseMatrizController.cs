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
    public class ClaseMatrizController : ApiController
    {
        // GET api/clasematriz
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/clasematriz/5
        public ClaseMatriz Get(int claseId)
        {
            return ClaseLogica.Instancia.GetClaseMatrizByClase(claseId);
        }

        // POST api/clasematriz
        public void Post([FromBody]string value)
        {
        }

        // PUT api/clasematriz/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/clasematriz/5
        public void Delete(int id)
        {
        }
    }
}

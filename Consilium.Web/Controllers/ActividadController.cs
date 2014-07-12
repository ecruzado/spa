using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consilium.Web.Controllers
{
    public class ActividadController : ApiController
    {
        // GET api/actividad
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/actividad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/actividad
        public void Post([FromBody]string value)
        {
        }

        // PUT api/actividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/actividad/5
        public void Delete(int id)
        {
        }
    }
}

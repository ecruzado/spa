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
    public class ActitudController : ApiController
    {
        public List<Valor> Get(int valorId)
        {
            return ValorLogica.Instancia.ListActitudByValor(valorId);
        }

        // POST api/columna
        public void Post([FromBody]Valor value)
        {
            if (value.ActitudId == 0)
                ValorLogica.Instancia.CrearActitud(value);
            else
                ValorLogica.Instancia.ActualizarActitud(value);
        }
    }
}

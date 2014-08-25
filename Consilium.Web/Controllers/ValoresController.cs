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
    public class ValoresController : ApiController
    {
        public List<Valor> Get(int colegioId)
        {
            return ValorLogica.Instancia.ListValorByColegio(colegioId);
        }

        // POST api/columna
        public void Post([FromBody]Valor value)
        {
            if (value.ValorId == 0)
                ValorLogica.Instancia.CrearValor(value);
            else
                ValorLogica.Instancia.ActualizarValor(value);
        }
    }
}

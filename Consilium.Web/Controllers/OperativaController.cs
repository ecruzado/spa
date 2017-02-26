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
    public class OperativaController : ApiController
    {
        public List<Capacidad> Get(int especificaId)
        {
            return CapacidadLogica.Instancia.ListOperativaByEspecifica(especificaId);
        }

        // POST api/columna
        public void Post([FromBody]Capacidad value)
        {
            if (value.OperativaId == 0)
                CapacidadLogica.Instancia.CrearOperativa(value);
            else
                CapacidadLogica.Instancia.ActualizarOperativa(value);
        }

        // DELETE api/claseconocimiento/5
        public void Delete(int id)
        {
            CapacidadLogica.Instancia.DeleteOperativa(id);
        }

        [HttpPost]
        public void Export([FromBody]CapacidadExportar capacidadExportar)
        {
            CapacidadLogica.Instancia.ExportarOperativa(capacidadExportar);
        }

        [HttpPost]
        public void Combinar([FromBody]CapacidadExportar capacidadExportar)
        {
            CapacidadLogica.Instancia.CombinarOperativa(capacidadExportar);
        }
    }
}

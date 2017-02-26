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
    public class EspecificaController : ApiController
    {
        public List<Capacidad> Get(int deAreaId)
        {
            return CapacidadLogica.Instancia.ListEspecificaByDeArea(deAreaId);
        }

        // POST api/columna
        public void Post([FromBody]Capacidad value)
        {
            if (value.EspecificaId == 0)
                CapacidadLogica.Instancia.CrearEspecifica(value);
            else
                CapacidadLogica.Instancia.ActualizarEspecifica(value);
        }

        // DELETE api/claseconocimiento/5
        public void Delete(int id)
        {
            CapacidadLogica.Instancia.DeleteEspecifica(id);
        }

        [HttpPost]
        public void Export([FromBody]CapacidadExportar capacidadExportar)
        {
            CapacidadLogica.Instancia.ExportarEspecifica(capacidadExportar);
        }

        [HttpPost]
        public void Combinar([FromBody]CapacidadExportar capacidadExportar)
        {
            CapacidadLogica.Instancia.CombinarEspecifica(capacidadExportar);
        }
    }
}

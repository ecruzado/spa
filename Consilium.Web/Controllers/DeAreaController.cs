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
    public class DeAreaController : ApiController
    {
        public List<Capacidad> Get(int colegioId, int areaId)
        {
            return CapacidadLogica.Instancia.ListDeAreaByColegioAndArea(colegioId, areaId);
        }

        // POST api/columna
        public void Post([FromBody]Capacidad value)
        {
            if (value.DeAreaId == 0)
                CapacidadLogica.Instancia.CrearDeArea(value);
            else
                CapacidadLogica.Instancia.ActualizarDeArea(value);
        }

        // DELETE api/claseconocimiento/5
        public void Delete(int id)
        {
            CapacidadLogica.Instancia.DeleteDeArea(id); 
        }
    }
}

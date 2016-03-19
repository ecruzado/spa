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
    public class ArribaAbajoController : ApiController
    {
        // GET api/arribaabajo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/arribaabajo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/arribaabajo
        public void Post([FromBody]ArribaAbajo arribaAbajo)
        {
            switch (arribaAbajo.Entidad)
            {
                case "Valor":
                    ValorLogica.Instancia.ActualizarValorOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Actitud":
                    ValorLogica.Instancia.ActualizarActitudOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "DeArea":
                    CapacidadLogica.Instancia.ActualizarDeAreaOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Especifica":
                    CapacidadLogica.Instancia.ActualizarEspecificaOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Operativa":
                    CapacidadLogica.Instancia.ActualizarOperativaOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Conocimiento":
                    ContenidoLogica.Instancia.ActualizarConocimientoOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Detalle":
                    ContenidoLogica.Instancia.ActualizarDetalleOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Contenido":
                    ContenidoLogica.Instancia.ActualizarContenidoOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Criterio":
                    MetodologiaLogica.Instancia.ActualizarCriterioOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                case "Metecnica":
                    MetodologiaLogica.Instancia.ActualizarMetecnicaOrden(arribaAbajo.Id1, arribaAbajo.Arriba);
                    break;
                default:
                    break;
            }
        }

        // PUT api/arribaabajo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/arribaabajo/5
        public void Delete(int id)
        {
        }
    }
}

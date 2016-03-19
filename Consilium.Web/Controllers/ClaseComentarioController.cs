using Consilium.Entity;
using Consilium.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Consilium.Web.Controllers
{
    public class ClaseComentarioController : ApiController
    {
        public IEnumerable<ClaseComentario> Get(int claseId)
        {
            var list = ClaseComentarioLogica.Instancia.GetByClase(claseId);
            return list;
        }

        public IEnumerable<ClaseComentario> Get(string usuario)
        {
            var list = ClaseComentarioLogica.Instancia.GetByUsuario(usuario);
            return list;
        }

        // POST api/claseconocimiento
        public void Post([FromBody]ClaseComentario claseComentario)
        {
            if (claseComentario.ClaseComentarioId == 0)
                ClaseComentarioLogica.Instancia.CrearClaseComentario(claseComentario);
            else
                ClaseComentarioLogica.Instancia.ActualizarClaseComentario(claseComentario);
        }


    }
}

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

    }
}

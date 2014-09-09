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
    public class CambioPasswordController : ApiController
    {
        // POST api/usuario
        public void Post([FromBody]Usuario usuario)
        {
            if (usuario != null && usuario.UsuarioId != 0 && !string.IsNullOrEmpty(usuario.Password))
            {
                UsuarioLogica.Instancia.UpdatePassword(usuario.UsuarioId, usuario.Password);
            }
            else
            {
                throw new MissingFieldException("contraseña");
            }
        }
    }
}

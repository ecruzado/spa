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
    public class UsuarioController : ApiController
    {
        // GET api/usuario
        public IEnumerable<Usuario> Get(string tipo,int colegioId)
        {
            var lista = UsuarioLogica.Instancia.List(colegioId);
            return lista;
        }

        // GET api/usuario
        public Usuario Get(int usuarioId)
        {
            var usuario = UsuarioLogica.Instancia.GetById(usuarioId);
            return usuario;
        }

        // POST api/usuario
        public void Post([FromBody]Usuario usuario)
        {
            if (usuario.UsuarioId == 0)
            {
                UsuarioLogica.Instancia.Insert(usuario);
            }
            else 
            {
                UsuarioLogica.Instancia.Update(usuario);
            }
        }

        // PUT api/usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/usuario/5
        public void Delete(int id)
        {
        }
    }
}

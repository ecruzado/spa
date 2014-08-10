using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System.Collections.Generic;
namespace Consilium.Logica
{
    public class UsuarioLogica : Singleton<UsuarioLogica>
	{
        private readonly UsuarioData usuarioData = new UsuarioData();
        
        public List<Usuario> List(int colegioId)
        {
            return usuarioData.List(colegioId);
        }

        public Usuario GetById(int usuarioId) 
        {
            return usuarioData.GetById(usuarioId);
        }

        public Usuario GetByUsuarioAndPassword(string nombreUsuario, string password) 
        {
            return usuarioData.GetByUsuarioAndPassword(nombreUsuario,password);
        }

        public int Insert(Usuario usuario) 
        {
            return usuarioData.Insert(usuario);
        }

        public int Update(Usuario usuario) 
        {
            return usuarioData.Update(usuario);
        }
	}
}

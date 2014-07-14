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
	}
}

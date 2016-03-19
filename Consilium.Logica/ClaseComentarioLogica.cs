using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ClaseComentarioLogica : Singleton<ClaseComentarioLogica>
    {
        private readonly ClaseComentarioData claseComentarioData = new ClaseComentarioData();

        public List<ClaseComentario> GetByClase(int claseId)
        {
            return claseComentarioData.GetByClase(claseId);
        }

        public List<ClaseComentario> GetByUsuario(string usuario)
        {
            return claseComentarioData.GetByUsuario(usuario);
        }

        public int CrearClaseComentario(ClaseComentario claseComentario)
        {
            return claseComentarioData.CrearClaseComentario(claseComentario);
        }

        public int ActualizarClaseComentario(ClaseComentario claseComentario)
        {
            return claseComentarioData.ActualizarClaseComentario(claseComentario);
        }
    }
}

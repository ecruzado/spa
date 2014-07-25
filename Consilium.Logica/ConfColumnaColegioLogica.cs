using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ConfColumnaColegioLogica : Singleton<ConfColumnaColegioLogica>
    {
        private readonly ConfColumnaColegioData confColumnaColegioData = new ConfColumnaColegioData();
        
        public int Crear(ConfColumnaColegio confColumnaColegio) 
        {
            return confColumnaColegioData.Crear(confColumnaColegio);
        }
        public int Actualizar(ConfColumnaColegio confColumnaColegio) 
        {
            return confColumnaColegioData.Actualizar(confColumnaColegio);
        }
        public ConfColumnaColegio Get(int id)
        {
            return confColumnaColegioData.Get(id);
        }
        public List<ConfColumnaColegio> ListByColumnaAndColegio(ConfColumnaColegio busqueda)
        {
            return confColumnaColegioData.ListByColumnaAndColegio(busqueda);
        }
        public List<ItemNodo> ListNodosByColumnaAndColegioAndArea(ConfColumnaColegio busqueda)
        {
            return confColumnaColegioData.ListNodosByColumnaAndColegioAndArea(busqueda);
        }
    }
}

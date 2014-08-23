using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class MetodologiaLogica : Singleton<MetodologiaLogica>
    {
        private MetodologiaData metodologiaData = new MetodologiaData();

        public List<ItemNodo> ListByColegio(int colegioId) 
        {
            return metodologiaData.ListByColegio(colegioId);
        }
    }
}

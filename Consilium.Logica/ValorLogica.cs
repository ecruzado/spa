using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ValorLogica : Singleton<ValorLogica>
    {
        private readonly ValorData valorData = new ValorData();

        public List<ItemNodo> ListByColegio(int colegioId)
        {
            return valorData.ListByColegio(colegioId);
        }
    }
}

using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class PruebaLogica : Singleton<PruebaLogica>
    {
        private readonly PruebaData pruebaData = new PruebaData();
        public List<ItemNodo> List()
        {
            return pruebaData.List();
        }

    }
}

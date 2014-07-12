using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class DeAreaLogica : Singleton<DeAreaLogica>
    {
        private readonly DeAreaData deAreaData = new DeAreaData();

        public List<DeArea> ListByAreaAndColegio(DeArea deAreaBusqueda)
        {
            return deAreaData.ListByAreaAndColegio(deAreaBusqueda);
        }
    }
}

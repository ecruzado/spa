using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ConocimientoLogica : Singleton<ConocimientoLogica>
    {
        private readonly ConocimientoData conocimientoData = new ConocimientoData();
        public List<ItemNodo> List()
        {
            return conocimientoData.List();
        }

    }
}

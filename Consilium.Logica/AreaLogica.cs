using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class AreaLogica : Singleton<AreaLogica>
    {
        private readonly AreaData areaData = new AreaData();
        public List<Area> List()
        {
            return areaData.List();
        }

    }
}

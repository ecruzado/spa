using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Metodologia
    {
        public int CriterioId { get; set; }
        public String Criterio { get; set; }
        public int MetecnicaId { get; set; }
        public string Metecnica { get; set; }
        public int ColegioId { get; set; }
        public int AreaId { get; set; }
    }
}

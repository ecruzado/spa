using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class TipoConocimiento
    {
        public int TipoConocimientoId { get; set; }
        public string TipoConocimientoDesc { get; set; }
        public int ConocimientoId { get; set; }
    }
}

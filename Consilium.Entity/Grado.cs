using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Grado
    {
        public int GradoId { get; set; }
        public string GradoDesc { get; set; }
        public int NivelId { get; set; }
        public int Orden { get; set; }
    }
}

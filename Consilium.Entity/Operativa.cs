using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Operativa
    {
        public int OperativaId { get; set; }
        public string Nombre { get; set; }
        public int EspecificaId { get; set; }
        public bool Seleccion { get; set; }
    }
}

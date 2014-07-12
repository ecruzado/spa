using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Especifica
    {
        public int EspecificaId { get; set; }
        public string Nombre { get; set; }
        public int DeAreaId { get; set; }
        public List<Operativa> Operativas { get; set; }
    }
}

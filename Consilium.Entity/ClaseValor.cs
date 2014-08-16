using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ClaseValor
    {
        public int ValorId { get; set; }
        public string Valor { get; set; }
        public int ActitudId { get; set; }
        public string Actitud { get; set; }
        public int ClaseValorId { get; set; }
        public int ClaseId { get; set; }
    }
}

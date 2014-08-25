using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Valor
    {
        public int ValorId { get; set; }
        public string ValorDsc { get; set; }
        public int ActitudId { get; set; }
        public string Actitud { get; set; }
        public int ColegioId { get; set; }
    }
}

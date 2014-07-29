using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ColumnaColegio
    {
        public int ColumnaId { get; set; }
        public int ColegioId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}

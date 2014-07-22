using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ConfColumnaColegio
    {
        public int ConfColumnaColegioId { get; set; }
        public int ColumnaId { get; set; }
        public int ColegioId { get; set; }
        public int AreaId { get; set; }
        public int NivelId { get; set; }
        public int GradoId { get; set; }
        public string Valor { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
        public int ConfColumnaColegioPadreId { get; set; }
        public string Area { get; set; }
        public string Nivel { get; set; }
        public string Grado { get; set; }

    }
}

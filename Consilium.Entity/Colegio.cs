using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Colegio
    {
        public int ColegioId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class ColegioExportar
    {
        public int ColegioIdOrigen { get; set; }
        public int ColegioIdDestino { get; set; }
        public bool Capacidad { get; set; }
        public bool Contenido { get; set; }
        public bool Valores { get; set; }
        public bool Metodologia { get; set; }
        public bool Columna1 { get; set; }
        public bool Columna2 { get; set; }
        public bool Columna3 { get; set; }
        public bool Columna4 { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ClaseContenido
    {
        public int ClaseContenidoId { get; set; }
        public int ContenidoId { get; set; }
        public string ContenidoDesc { get; set; }
        public int DetalleId { get; set; }
        public string Detalle { get; set; }
        public int ConocimientoId { get; set; }
        public string Conocimiento { get; set; }
        public int ClaseId { get; set; }
    }
}

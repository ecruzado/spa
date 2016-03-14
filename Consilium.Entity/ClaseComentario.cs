using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ClaseComentario
    {
        public int ClaseComentarioId { get; set; }
        public string Descripcion { get; set; }
        public int ClaseId { get; set; }
        public string Usuario { get; set; }
        public bool EsNotificado { get; set; }
        public bool Estado { get; set; }
    }
}

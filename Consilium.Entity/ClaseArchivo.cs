using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ClaseArchivo
    {
        public int ClaseArchivoId { get; set; }
        public int ClaseId { get; set; }
        public string Nombre { get; set; }
        public Guid Archivo { get; set; }
        public string Estado { get; set; }

    }
}

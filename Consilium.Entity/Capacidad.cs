using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Capacidad
    {
        public int DeAreaId { get; set; }
        public string DeArea { get; set; }
        public int EspecificaId { get; set; }
        public string Especifica { get; set; }
        public int OperativaId { get; set; }
        public string Operativa { get; set; }
        public int ColegioId { get; set; }
        public int AreaId { get; set; }
    }

    public class CapacidadExportar
    {
        public int DeAreaIdOrigen { get; set; }
        public int AreaIdDestino { get; set; }
    }
}

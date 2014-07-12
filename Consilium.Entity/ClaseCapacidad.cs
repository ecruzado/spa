using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ClaseCapacidad
    {
        public int ClaseCapacidadId { get; set; }
        public int ClaseId { get; set; }
        public int OperativaId { get; set; }
        public string Operativa { get; set; }
        public int EspecificaId { get; set; }
        public string Especifica { get; set; }
        public int DeAreaId { get; set; }
        public string DeArea { get; set; }
    }
}

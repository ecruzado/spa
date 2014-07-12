using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class DeArea
    {
        public int DeAreaId { get; set; }
        public string Nombre { get; set; }
        public int AreaId { get; set; }
        public int ColegioId { get; set; }
        public List<Especifica> Especificas { get; set; }
    }
}

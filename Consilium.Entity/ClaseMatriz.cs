using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class ClaseMatriz
    {
        public int ClaseMatrizId { get; set; }
        public bool Formativa { get; set; }
        public bool Sumativa { get; set; }
        public bool AutoEvaluativa { get; set; }
        public bool Coevaluativa { get; set; }
        public bool HeteroEvalucion { get; set; }
        public bool Censal { get; set; }
        public bool Muestral { get; set; }
        public string IndicadorLogro { get; set; }
        public string PruebaTexto { get; set; }
        public string ObservacionClase { get; set; }
        public int ClaseId { get; set; }


    }
}

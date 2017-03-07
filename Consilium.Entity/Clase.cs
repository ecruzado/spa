using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Formato { get; set; }
        public int ColegioId { get; set; }
        public int AreaId { get; set; }
        public int NivelId { get; set; }
        public int GradoId { get; set; }
        public string Usuario { get; set; }
        public string Area { get; set; }
        public string Nivel { get; set; }
        public string Grado { get; set; }
        public List<ClaseCapacidad> Capacidades { get; set; }

        public string FechaInicioFormato { get; set; }

        public string FechaFinFormato { get; set; }

        public string FechaRegistroFormato { get; set; }

        public string Colegio { get; set; }

        public int ClaseIdOrigen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Entity
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public int ColegioId { get; set; }
        public bool Estado { get; set; }
        public bool DisenoClase { get; set; }
        public bool HistorialClase { get; set; }
        public bool Reporte { get; set; }
        public bool Mantenimiento { get; set; }
        public bool Administrador { get; set; }

        public string Colegio { get; set; }
    }
}

using Consilium.DAO;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ReporteLogica : Singleton<ReporteLogica>
    {
        private ReporteData reporteData = new ReporteData();
        public DataTable ReporteCapacidad(int colegioId, int areaId, int nivelId, int gradoId) 
        {
            return reporteData.ReporteCapacidad(colegioId, areaId, nivelId, gradoId);
        }
        
        public DataTable ReporteContendio(int colegioId, int areaId, int nivelId, int gradoId)
        {
            return reporteData.ReporteContendio(colegioId, areaId, nivelId, gradoId);
        }
        
        public DataTable ReporteMetodos(int colegioId, int areaId, int nivelId, int gradoId)
        {
            return reporteData.ReporteMetodos(colegioId, areaId, nivelId, gradoId);
        }
        
        public DataTable ReporteValores(int colegioId, int areaId, int nivelId, int gradoId)
        {
            return reporteData.ReporteValores(colegioId, areaId, nivelId, gradoId);
        }
        
        public DataTable ReporteIndicadores(int colegioId, int areaId, int nivelId, int gradoId)
        {
            return reporteData.ReporteIndicadores(colegioId, areaId, nivelId, gradoId);
        }
        
        public DataTable ReporteTipoConocimiento(int colegioId, int areaId, int nivelId, int gradoId)
        {
            return reporteData.ReporteTipoConocimiento(colegioId, areaId, nivelId, gradoId);
        }

        public DataTable ReportePrueba(int colegioId, int areaId, int nivelId, int gradoId) 
        {
            return reporteData.ReportePrueba(colegioId, areaId, nivelId, gradoId);
        }

    }
}

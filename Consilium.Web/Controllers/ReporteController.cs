using Consilium.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consilium.Web.Controllers
{
    public class ReporteController : ApiController
    {
        public DataTable Get(string tipo, int colegioId, int areaId, int nivelId, int gradoId)
        {
            DataTable reporte = null;
            switch (tipo) 
            {
                case "CAPACIDAD":
                    reporte = ReporteLogica.Instancia.ReporteCapacidad(colegioId, areaId, nivelId, gradoId);
                    break;
                case "CONTENIDO":
                    reporte = ReporteLogica.Instancia.ReporteContendio(colegioId, areaId, nivelId, gradoId);
                    break;
                case "METODOLOGIAS":
                    reporte = ReporteLogica.Instancia.ReporteMetodos(colegioId, areaId, nivelId, gradoId);
                    break;
                case "VALORES":
                    reporte = ReporteLogica.Instancia.ReporteValores(colegioId, areaId, nivelId, gradoId);
                    break;
                case "INDICADORES":
                    reporte = ReporteLogica.Instancia.ReporteIndicadores(colegioId, areaId, nivelId, gradoId);
                    break;
                case "TIPO DE CONOCIMIENTO":
                    reporte = ReporteLogica.Instancia.ReporteTipoConocimiento(colegioId, areaId, nivelId, gradoId);
                    break;
                case "PRUEBA":
                    reporte = ReporteLogica.Instancia.ReportePrueba(colegioId, areaId, nivelId, gradoId);
                    break;
            }
            return reporte;
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using  Consilium.Entity;
using Consilium.DAO;
namespace Consilium.Logica
{
	public class ReportesLogica
	{

		public DataTable reporte_capacidad(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_capacidad(AreaEntity);
			return result;

		}

		public DataTable reporte_contenido(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_contenido(AreaEntity);
			return result;

		}

		public DataTable reporte_valores(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_valores(AreaEntity);
			return result;

		}

		public DataTable reporte_metodos(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_metodos(AreaEntity);
			return result;

		}

		public DataTable reporte_indicadores(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_indicadores(AreaEntity);
			return result;

		}

		public DataTable reporte_tipo_conocimiento(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_tipo_conocimiento(AreaEntity);
			return result;

		}

		public DataTable reporte_prueba(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ReportesDAO ReportesDAO = new ReportesDAO();
			result = ReportesDAO._reporte_prueba(AreaEntity);
			return result;

		}
	}
}

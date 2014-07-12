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

	public class MatrizEvaluacionLogica
	{

		public DataTable lst_tipo_conocimiento(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_tipo_conocimiento(AreaEntity);
			return result;

		}

		public DataTable lst_conocimiento()
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_conocimiento();
			return result;

		}

		public DataTable lst_clase_tipo_conocimiento(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_clase_tipo_conocimiento(AreaEntity);
			return result;

		}

		public DataTable lst_prueba()
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_prueba();
			return result;

		}

		public DataTable lst_item_registro_reactivo(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_item_registro_reactivo(AreaEntity);
			return result;

		}

		public DataTable lst_prueba_item_reg_act(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_prueba_item_reg_act(AreaEntity);
			return result;

		}

		public DataTable lst_actividad_clase(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_actividad_clase(AreaEntity);
			return result;

		}

		public DataTable lst_clase_matriz(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			result = MatrizEvaluacionDAO._lst_clase_matriz(AreaEntity);
			return result;

		}

		public int insertar_tipo_conocimiento(AreaEntity AreaEntity)
		{

			int retVal = 0;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			retVal = MatrizEvaluacionDAO._insert_tipo_conocimiento(AreaEntity);

			return retVal;

		}

		public int delete_clase_tipo_conocimiento(ArrayList delreg)
		{

			int retVal = 0;
			MatrizEvaluacionDAO MatrizEvaluacionDAO = new MatrizEvaluacionDAO();
			retVal = MatrizEvaluacionDAO._delete_clase_tipo_conocimiento(delreg);

			return retVal;

		}

	}
}

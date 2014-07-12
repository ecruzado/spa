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

	public class MetodoLogica
	{

		public DataTable lst_criterio(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MetodosDAO MetodosDAO = new MetodosDAO();
			result = MetodosDAO._lst_criterio(AreaEntity);
			return result;

		}

		public DataTable lst_metecnica(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MetodosDAO MetodosDAO = new MetodosDAO();
			result = MetodosDAO._lst_metecnica(AreaEntity);
			return result;

		}

		public DataTable lst_metodos(AreaEntity AreaEntity)
		{

			DataTable result = null;
			MetodosDAO MetodosDAO = new MetodosDAO();
			result = MetodosDAO._lst_metodos(AreaEntity);
			return result;

		}


		public int insertar_criterio(AreaEntity AreaEntity)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._insertar_criterio(AreaEntity);

			return retVal;

		}

		public int delete_criterio(ArrayList delreg)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._delete_criterio(delreg);

			return retVal;

		}

		public int update_criterio(AreaEntity AreaEntity)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._update_criterio(AreaEntity);

			return retVal;

		}


		public int insertar_metecnica(AreaEntity AreaEntity)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._insertar_metecnica(AreaEntity);

			return retVal;

		}

		public int delete_metecnica(ArrayList delreg)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._delete_metecnica(delreg);

			return retVal;

		}

		public int update_metecnica(AreaEntity AreaEntity)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._update_metecnica(AreaEntity);

			return retVal;

		}

		public int delete_clase_metodo(ArrayList delreg)
		{

			int retVal = 0;
			MetodosDAO MetodosDAO = new MetodosDAO();
			retVal = MetodosDAO._delete_clase_metodo(delreg);

			return retVal;

		}

	}
}

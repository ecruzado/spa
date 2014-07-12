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
	public class ValoresLogica
	{


		public DataTable lst_valores(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ValoresDAO ValoresDAO = new ValoresDAO();
			result = ValoresDAO._lst_valores(AreaEntity);
			return result;

		}

		public DataTable lst_actitud(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ValoresDAO ValoresDAO = new ValoresDAO();
			result = ValoresDAO._lst_actitud(AreaEntity);
			return result;

		}

		public DataTable lst_valores_all(AreaEntity AreaEntity)
		{

			DataTable result = null;
			ValoresDAO ValoresDAO = new ValoresDAO();
			result = ValoresDAO._lst_valores_all(AreaEntity);
			return result;

		}

		public int insertar_valores(AreaEntity AreaEntity)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._insertar_valores(AreaEntity);

			return retVal;

		}

		public int delete_valores(ArrayList delreg)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._delete_valores(delreg);

			return retVal;

		}

		public int update_valores(AreaEntity AreaEntity)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._update_valores(AreaEntity);

			return retVal;

		}






		public int insertar_actitud(AreaEntity AreaEntity)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._insertar_actitud(AreaEntity);

			return retVal;

		}

		public int delete_actitud(ArrayList delreg)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._delete_actitud(delreg);

			return retVal;

		}

		public int update_actitud(AreaEntity AreaEntity)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._update_actitud(AreaEntity);

			return retVal;

		}

		public int delete_clase_valor(ArrayList delreg)
		{

			int retVal = 0;
			ValoresDAO ValoresDAO = new ValoresDAO();
			retVal = ValoresDAO._delete_clase_valor(delreg);

			return retVal;

		}

	}
}

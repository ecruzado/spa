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
	public class ColegioLogica
	{

		public int insertar_colegio(AreaEntity AreaEntity)
		{

			int retVal = 0;
			ColegioDAO ColegioDAO = new ColegioDAO();
			retVal = ColegioDAO._insertar_colegio(AreaEntity);

			return retVal;

		}

		public DataTable listar_colegio()
		{

			DataTable retVal = null;
			ColegioDAO ColegioDAO = new ColegioDAO();
			retVal = ColegioDAO._listar_colegio();

			return retVal;

		}
		public int update_colegio(AreaEntity AreaEntity)
		{

			int retVal = 0;
			ColegioDAO ColegioDAO = new ColegioDAO();
			retVal = ColegioDAO._update_colegio(AreaEntity);

			return retVal;

		}


	}
}

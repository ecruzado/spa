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
	public class UsuarioLogica
	{
		public DataTable Logeo_Usuario(UsuarioEntity UsuarioEntity)
		{

			DataTable result = null;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			result = UsuarioDAO._logeo_usuario(UsuarioEntity);
			return result;

		}

		public DataTable Logeo_Usuario_Conectado(UsuarioEntity UsuarioEntity)
		{

			DataTable result = null;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			result = UsuarioDAO._logeo_usuario_conectado(UsuarioEntity);
			return result;

		}

		public int insertar_usuario(AreaEntity AreaEntity)
		{

			int retVal = 0;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			retVal = UsuarioDAO._insertar_usuario(AreaEntity);

			return retVal;

		}

		public DataTable listar_usuario(int colegio_id)
		{

			DataTable retVal = null;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			retVal = UsuarioDAO._listar_usuario(colegio_id);
			return retVal;

		}
		public DataTable listar_usuario_colegio(AreaEntity AreaEntity)
		{

			DataTable retVal = null;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			retVal = UsuarioDAO._listar_usuario_colegio(AreaEntity);
			return retVal;

		}
		public int update_usuario(AreaEntity AreaEntity)
		{

			int retVal = 0;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			retVal = UsuarioDAO._update_usuario(AreaEntity);

			return retVal;

		}

		public int update_usuario_pass(AreaEntity AreaEntity)
		{

			int retVal = 0;
			UsuarioDAO UsuarioDAO = new UsuarioDAO();
			retVal = UsuarioDAO._update_usuario_pass(AreaEntity);

			return retVal;

		}

	}
}

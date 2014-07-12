using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class UsuarioEntity : EspecificaEntity
	{


		private static UsuarioEntity datos_user;

		public UsuarioEntity()
		{
		}

		public static UsuarioEntity Instance()
		{

			if (datos_user == null) {
				datos_user = new UsuarioEntity();
			}

			return datos_user;

		}


		private int _usuario_id;
		public int usuario_id {
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}


		private string _usuario;
		public string usuario {
			get { return _usuario; }
			set { _usuario = value; }
		}


		private string _nombres;
		public string nombres {
			get { return _nombres; }
			set { _nombres = value; }
		}

		private string _apematerno;
		public string apematerno {
			get { return _apematerno; }
			set { _apematerno = value; }
		}


		private string _apepaterno;
		public string apepaterno {
			get { return _apepaterno; }
			set { _apepaterno = value; }
		}


		private string _pass;
		public string pass {
			get { return _pass; }
			set { _pass = value; }
		}


		private string _correo;
		public string correo {
			get { return _correo; }
			set { _correo = value; }
		}


		private bool _estado;
		public bool estado {
			get { return _estado; }
			set { _estado = value; }
		}


		private bool _adminlocal;
		public bool adminlocal {
			get { return _adminlocal; }
			set { _adminlocal = value; }
		}


		private bool _diseno;
		public bool diseno {
			get { return _diseno; }
			set { _diseno = value; }
		}


		private bool _historia;
		public bool historia {
			get { return _historia; }
			set { _historia = value; }
		}


		private bool _reporte;
		public bool reporte {
			get { return _reporte; }
			set { _reporte = value; }
		}


		private bool _mantenimiento;
		public bool mantenimiento {
			get { return _mantenimiento; }
			set { _mantenimiento = value; }
		}


		private bool _administrador;
		public bool administrador {
			get { return _administrador; }
			set { _administrador = value; }
		}


	}
}

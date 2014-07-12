using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{
	public class ColegioEntity
	{


		private int _colegio_id;
		public int colegio_id {
			get { return _colegio_id; }
			set { _colegio_id = value; }
		}


		private string _colegio_nombre;
		public string colegio_nombre {
			get { return _colegio_nombre; }
			set { _colegio_nombre = value; }
		}


		private string _colegio_dirección;
		public string colegio_dirección {
			get { return _colegio_dirección; }
			set { _colegio_dirección = value; }
		}


		private string _colegio_telefono;
		public string colegio_telefono {
			get { return _colegio_telefono; }
			set { _colegio_telefono = value; }
		}


		private string _colegio_contacto;
		public string colegio_contacto {
			get { return _colegio_contacto; }
			set { _colegio_contacto = value; }
		}

	}
}

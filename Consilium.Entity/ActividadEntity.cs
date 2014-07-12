using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class ActividadEntity : ColegioEntity
	{


		private int _actividad_id;
		public int actividad_id {
			get { return _actividad_id; }
			set { _actividad_id = value; }
		}


		private string _actividad;
		public string actividad {

			get { return _actividad; }
			set { _actividad = value; }
		}


		private string _actividad_hora;
		public string actividad_hora {

			get { return _actividad_hora; }
			set { _actividad_hora = value; }
		}


		private string _actividad1;
		public string actividad1 {

			get { return _actividad1; }
			set { _actividad1 = value; }
		}


		private string _actividad_hora1;
		public string actividad_hora1 {

			get { return _actividad_hora1; }
			set { _actividad_hora1 = value; }
		}


		private string _actividad2;
		public string actividad2 {

			get { return _actividad2; }
			set { _actividad2 = value; }
		}


		private string _actividad_hora2;
		public string actividad_hora2 {

			get { return _actividad_hora2; }
			set { _actividad_hora2 = value; }
		}

	}
}

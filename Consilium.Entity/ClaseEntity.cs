using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class ClaseEntity : NivelEntity
	{


		private int _clase_id;
		public int clase_id {
			get { return _clase_id; }
			set { _clase_id = value; }
		}


		private string _clase_titulo;
		public string clase_titulo {

			get { return _clase_titulo; }
			set { _clase_titulo = value; }
		}


		private System.DateTime _fecha_inicio;
		public System.DateTime fecha_inicio {
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}


		private System.DateTime _fecha_fin;
		public System.DateTime fecha_fin {
			get { return _fecha_fin; }
			set { _fecha_fin = value; }
		}

		private int _id_unico;
		public int id_unico {
			get { return _id_unico; }
			set { _id_unico = value; }
		}

		private string _formato;
		public string formato {
			get { return _formato; }
			set { _formato = value; }
		}

	}
}

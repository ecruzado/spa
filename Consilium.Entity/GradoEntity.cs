using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class GradoEntity : UsuarioEntity
	{


		private int _grado_id;
		public int grado_id {
			get { return _grado_id; }
			set { _grado_id = value; }
		}


		private string _grado;
		public string grado {
			get { return _grado; }
			set { _grado = value; }
		}

	}
}

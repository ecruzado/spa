using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class OrganizadorEntity : Organizador2Entity
	{


		private int _Organizador_id;
		public int Organizador_id {
			get { return _Organizador_id; }
			set { _Organizador_id = value; }
		}


		private string _Organizador;
		public string Organizador {

			get { return _Organizador; }
			set { _Organizador = value; }
		}

	}
}

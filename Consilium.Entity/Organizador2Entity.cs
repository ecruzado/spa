using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class Organizador2Entity : Organizador3Entity
	{


		private int _Organizador2_id;
		public int Organizador2_id {
			get { return _Organizador2_id; }
			set { _Organizador2_id = value; }
		}


		private string _Organizador2;
		public string Organizador2 {

			get { return _Organizador2; }
			set { _Organizador2 = value; }
		}

	}
}

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{
	public class MetecnicaEntity : MatrizEntity
	{

		private int _metecnica_id;
		public int metecnica_id {
			get { return _metecnica_id; }
			set { _metecnica_id = value; }
		}


		private string _metecnica;
		public string metecnica {

			get { return _metecnica; }
			set { _metecnica = value; }
		}
	}
}

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class ValoresEntity : ActitudEntity
	{

		private int _valores_id;
		public int valores_id {
			get { return _valores_id; }
			set { _valores_id = value; }
		}


		private string _valores;
		public string valores {

			get { return _valores; }
			set { _valores = value; }
		}

	}
}

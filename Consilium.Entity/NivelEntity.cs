using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class NivelEntity : GradoEntity
	{


		private int _nivel_id;
		public int nivel_id {
			get { return _nivel_id; }
			set { _nivel_id = value; }
		}


		private string _nivel;
		public string nivel {
			get { return _nivel; }
			set { _nivel = value; }
		}

	}
}

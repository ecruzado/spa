using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class EspecificaEntity : OperativaEntityvb
	{


		private int _especifica_id;
		public int especifica_id {
			get { return _especifica_id; }
			set { _especifica_id = value; }
		}


		private string _especifica;
		public string especifica {

			get { return _especifica; }
			set { _especifica = value; }
		}
	}
}

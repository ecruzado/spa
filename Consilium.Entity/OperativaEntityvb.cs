using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class OperativaEntityvb : OrganizadorEntity
	{


		private int _operativa_id;
		public int operativa_id {
			get { return _operativa_id; }
			set { _operativa_id = value; }
		}


		private string _operativa;
		public string operativa {

			get { return _operativa; }
			set { _operativa = value; }
		}

	}
}

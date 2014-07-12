using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class ActitudEntity : CriterioEntity
	{


		private int _actitud_id;
		public int actitud_id {
			get { return _actitud_id; }
			set { _actitud_id = value; }
		}


		private string _actitud;
		public string actitud {

			get { return _actitud; }
			set { _actitud = value; }
		}

	}
}

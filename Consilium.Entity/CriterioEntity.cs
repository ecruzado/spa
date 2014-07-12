using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{
	public class CriterioEntity : MetecnicaEntity
	{

		private int _criterio_id;
		public int criterio_id {
			get { return _criterio_id; }
			set { _criterio_id = value; }
		}


		private string _criterio;
		public string criterio {

			get { return _criterio; }
			set { _criterio = value; }
		}


	}
}

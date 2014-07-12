using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class DeareaEntity : ClaseEntity
	{


		private int _dearea_id;
		public int dearead_id {
			get { return _dearea_id; }
			set { _dearea_id = value; }
		}


		private string _dearea;
		public string dearea {

			get { return _dearea; }
			set { _dearea = value; }
		}

	}
}

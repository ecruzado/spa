using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class AreaEntity : DeareaEntity
	{


		private int _area_id;
		public int area_id {
			get { return _area_id; }
			set { _area_id = value; }
		}


		private int _area;
		public int area {

			get { return _area; }
			set { _area = value; }
		}

	}
}

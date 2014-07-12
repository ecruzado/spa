using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class Organizador3Entity : ValoresEntity
	{


		private int _Organizador3_id;
		public int Organizador3_id {
			get { return _Organizador3_id; }
			set { _Organizador3_id = value; }
		}


		private string _Organizador3;
		public string Organizador3 {

			get { return _Organizador3; }
			set { _Organizador3 = value; }
		}
	}
}

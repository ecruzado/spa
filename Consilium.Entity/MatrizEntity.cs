using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace Consilium.Entity
{

	public class MatrizEntity : ActividadEntity
	{

		private bool _formativa;
		public bool formativa {
			get { return _formativa; }
			set { _formativa = value; }
		}


		private bool _sumativa;
		public bool sumativa {

			get { return _sumativa; }
			set { _sumativa = value; }
		}


		private bool _autoevaluativa;
		public bool autoevaluativa {
			get { return _autoevaluativa; }
			set { _autoevaluativa = value; }
		}


		private bool _coevaluativa;
		public bool coevaluativa {
			get { return _coevaluativa; }

			set { _coevaluativa = value; }
		}


		private bool _muestral;
		public bool muestral {

			get { return _muestral; }
			set { _muestral = value; }
		}



		private bool _censal;
		public bool censal {

			get { return _censal; }
			set { _censal = value; }
		}



		private bool _heteroevaluacion;
		public bool heteroevaluacion {

			get { return _heteroevaluacion; }
			set { _heteroevaluacion = value; }
		}



		private string _indicador_logro;
		public string indicador_logro {

			get { return _indicador_logro; }

			set { _indicador_logro = value; }
		}


		private int _tipo_conocimiento_id;
		public int tipo_conocimiento_id {
			get { return _tipo_conocimiento_id; }
			set { _tipo_conocimiento_id = value; }
		}


		private string _conocimiento;
		public string conocimiento {
			get { return _conocimiento; }
			set { _conocimiento = value; }
		}


		private int _conocimiento_id;
		public int conocimiento_id {
			get { return _conocimiento_id; }
			set { _conocimiento_id = value; }
		}


		private string _tipo_conocimiento;
		public string tipo_conocimiento {
			get { return _tipo_conocimiento; }
			set { _tipo_conocimiento = value; }
		}


		private int _prueba_id;
		public int prueba_id {
			get { return _prueba_id; }
			set { _prueba_id = value; }
		}


		private string _prueba;
		public string prueba {
			get { return _prueba; }
			set { _prueba = value; }
		}


		private string _pruebatxt;
		public string pruebatxt {
			get { return _pruebatxt; }
			set { _pruebatxt = value; }
		}


		private int _item_registro_reactivo_id;
		public int item_registro_reactivo_id {
			get { return _item_registro_reactivo_id; }
			set { _item_registro_reactivo_id = value; }
		}


		private int _item_registro_reactivo;
		public int item_registro_reactivo {

			get { return _item_registro_reactivo; }
			set { _item_registro_reactivo = value; }
		}


		private string _obsclase;
		public string obsclase {
			get { return _obsclase; }
			set { _obsclase = value; }
		}

	}
}

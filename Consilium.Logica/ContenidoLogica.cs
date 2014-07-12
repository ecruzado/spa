using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using  Consilium.Entity;
using Consilium.DAO;
using Consilium.Entity.Generics;
namespace Consilium.Logica
{
    public class ContenidoLogica : Singleton<ContenidoLogica>
	{
        private ContenidoData contenidoData = new ContenidoData();

        public List<Contenido> ListContenidoByColegioAndAreaAndNivelAndGrado(Contenido busqueda) 
        {
            var lista = contenidoData.ListContenidoByColegioAndAreaAndNivelAndGrado(busqueda);
            return lista;
        }
	}
}

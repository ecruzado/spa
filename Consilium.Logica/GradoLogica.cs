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
    public class GradoLogica : Singleton<GradoLogica>
	{
        private readonly GradoData gradoData = new GradoData();

        public List<Grado> ListByNivel(int nivelId)
        {
            return gradoData.ListByNivel(nivelId);
        }

	}
}

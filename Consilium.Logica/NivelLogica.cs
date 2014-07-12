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
    public class NivelLogica : Singleton<NivelLogica>
	{
        private readonly NivelData nivelData = new NivelData();

        public List<Nivel> List()
        {
            return nivelData.List();
        }
    }
}

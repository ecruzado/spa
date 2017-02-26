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
    public class ColegioLogica : Singleton<ColegioLogica>
	{
        private ColegioData colegioData = new ColegioData();
        public List<Colegio> List()
        {
            return colegioData.List();
        }
        public Colegio Get(int colegioId)
        {
            return colegioData.Get(colegioId);
        }
        public int Insert(Colegio colegio)
        {
            return colegioData.Insert(colegio);
        }
        public int Update(Colegio colegio)
        {
            return colegioData.Update(colegio);
        }

        public int Exportar(ColegioExportar colegioExportar)
        {
            return colegioData.Exportar(colegioExportar);
        }

    }
}

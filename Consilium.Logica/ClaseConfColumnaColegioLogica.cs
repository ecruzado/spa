using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ClaseConfColumnaColegioLogica : Singleton<ClaseLogica>
    {
        private readonly ClaseConfColumnaColegioData claseConfColumnaColegioData = new ClaseConfColumnaColegioData();

       public int Crear(ClaseColColumnaColegio claseColColumnaColegio)
       {
           return claseConfColumnaColegioData.Crear(claseColColumnaColegio);
       }
    }
}

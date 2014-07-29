using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ColumnaColegioLogica : Singleton<ColumnaColegioLogica>
    {
        private readonly ColumnaColegioData columnaColegioData = new ColumnaColegioData();
        
        public int Crear(ColumnaColegio columnaColegio) 
        {
            return columnaColegioData.Crear(columnaColegio);
        }

        public int Actualizar(ColumnaColegio columnaColegio)
        {
            return columnaColegioData.Actualizar(columnaColegio);
        }

        public ColumnaColegio Get(ColumnaColegio columnaColegio) 
        {
            return columnaColegioData.Get(columnaColegio);
        }
    }
}

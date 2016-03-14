using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class ValorLogica : Singleton<ValorLogica>
    {
        private readonly ValorData valorData = new ValorData();

        public List<ItemNodo> ListByColegio(int colegioId)
        {
            return valorData.ListByColegio(colegioId);
        }

        #region valor

        public List<Valor> ListValorByColegio(int colegioId) 
        {
            return valorData.ListValorByColegio(colegioId);
        }

        public int CrearValor(Valor valor) 
        {
            return valorData.CrearValor(valor);
        }

        public int ActualizarValor(Valor valor) 
        {
            return valorData.ActualizarValor(valor);
        }

        public int DeleteValor(Valor valor) 
        {
            return valorData.DeleteValor(valor);
        }

        public int ActualizarValorOrden(int valorid, bool arriba)
        {
            return valorData.ActualizarValorOrden(valorid, arriba);
        }

        #endregion
        
        #region actiud
        
        public List<Valor> ListActitudByValor(int valorId) 
        {
            return valorData.ListActitudByValor(valorId);
        }

        public int CrearActitud(Valor actitud) 
        {
            return valorData.CrearActitud(actitud);
        }

        public int ActualizarActitud(Valor actitud) 
        {
            return valorData.ActualizarActitud(actitud);
        }

        public int DeleteActitud(Valor actitud) 
        {
            return valorData.DeleteActitud(actitud);
        }

        public int ActualizarActitudOrden(int actitudId, bool arriba) 
        {
            return valorData.ActualizarActitudOrden(actitudId, arriba);
        }

        #endregion

    }
}

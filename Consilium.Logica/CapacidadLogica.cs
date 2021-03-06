using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Consilium.Entity;
using Consilium.DAO;
using Consilium.Entity.Generics;

namespace Consilium.Logica
{
    public class CapacidadLogica : Singleton<CapacidadLogica>
	{
        private CapacidadData capacidadData = new CapacidadData();

        public List<ItemNodo> ListByColegioAndArea(int colegioId, int areaId)
        {
            return capacidadData.ListByColegioAndArea(colegioId, areaId);
        }

        #region deaarea
        public List<Capacidad> ListDeAreaByColegioAndArea(int colegioId, int areaId)
        {
            return capacidadData.ListDeAreaByColegioAndArea(colegioId, areaId);
        }
        public int CrearDeArea(Capacidad capacidad) 
        {
            return capacidadData.CrearDeArea(capacidad);
        }
        public int ActualizarDeArea(Capacidad capacidad) 
        {
            return capacidadData.ActualizarDeArea(capacidad);
        }
        public int DeleteDeArea(int deAreaId) 
        {
            return capacidadData.DeleteDeArea(deAreaId);
        }

        public int ActualizarDeAreaOrden(int deAreaId, bool arriba) 
        {
            return capacidadData.ActualizarDeAreaOrden(deAreaId, arriba);
        }

        public int ExportarDeArea(CapacidadExportar capacidadExportar)
        {
            return capacidadData.ExportarDeArea(capacidadExportar);
        }

        public int CombinarDeArea(CapacidadExportar capacidadCombinar)
        {
            return capacidadData.CombinarDeArea(capacidadCombinar);
        }

        #endregion

        #region especifica

        public List<Capacidad> ListEspecificaByDeArea(int deAreaId)
        {
            return capacidadData.ListEspecificaByDeArea(deAreaId);
        }
        public int CrearEspecifica(Capacidad capacidad) 
        {
            return capacidadData.CrearEspecifica(capacidad);
        }
        public int ActualizarEspecifica(Capacidad capacidad) 
        {
            return capacidadData.ActualizarEspecifica(capacidad);
        }
        public int DeleteEspecifica(int especificaId) 
        {
            return capacidadData.DeleteEspecifica(especificaId);
        }

        public int ActualizarEspecificaOrden(int especificaId, bool arriba) 
        {
            return capacidadData.ActualizarEspecificaOrden(especificaId, arriba);
        }

        public int ExportarEspecifica(CapacidadExportar capacidadExportar)
        {
            return capacidadData.ExportarEspecifica(capacidadExportar);
        }
        public int CombinarEspecifica(CapacidadExportar capacidadCombinar)
        {
            return capacidadData.CombinarEspecifica(capacidadCombinar);
        }
        #endregion

        #region operativa

        public List<Capacidad> ListOperativaByEspecifica(int especificaId) 
        {
            return capacidadData.ListOperativaByEspecifica(especificaId);
        }
        public int CrearOperativa(Capacidad capacidad) 
        {
            return capacidadData.CrearOperativa(capacidad);
        }
        public int ActualizarOperativa(Capacidad capacidad) 
        {
            return capacidadData.ActualizarOperativa(capacidad);
        }
        public int DeleteOperativa(int operativaId)
        {
            return capacidadData.DeleteOperativa(operativaId);
        }
        public int ActualizarOperativaOrden(int operativaId, bool arriba) 
        {
            return capacidadData.ActualizarOperativaOrden(operativaId, arriba);
        }

        public int ExportarOperativa(CapacidadExportar capacidadExportar)
        {
            return capacidadData.ExportarOperativa(capacidadExportar);
        }
        public int CombinarOperativa(CapacidadExportar capacidadCombinar)
        {
            return capacidadData.CombinarOperativa(capacidadCombinar);
        }
        #endregion
    }
}

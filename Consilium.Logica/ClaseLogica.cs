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
	public class ClaseLogica:Singleton<ClaseLogica>
	{
        private readonly ClaseData claseData = new ClaseData();

        public int Crear(Clase clase)
        {
            return claseData.Crear(clase);
        }

        public List<Clase> List(int colegioId)
        {
            var lista = claseData.List(colegioId);
            foreach (var entidad in lista)
            {
                entidad.FechaInicioFormato = entidad.FechaInicio.ToString("dd/MM/yyyy");
                entidad.FechaFinFormato = entidad.FechaFin.ToString("dd/MM/yyyy");
                entidad.FechaRegistroFormato = entidad.FechaRegistro.ToString("dd/MM/yyyy");
            }
            return lista;
        }
        
        public List<Clase> ListByFiltro(Clase busqueda)
        {
            return claseData.ListByFiltro(busqueda);
        }


        public Clase Get(int claseId)
        {
            Clase entidad = claseData.Get(claseId);
            entidad.FechaInicioFormato = entidad.FechaInicio.ToString("dd/MM/yyyy");
            entidad.FechaFinFormato = entidad.FechaFin.ToString("dd/MM/yyyy");
            return entidad;
        }


        public List<ClaseCapacidad> ListClaseCapacidadByClase(int claseId)
        {
            return claseData.ListClaseCapacidadByClase(claseId);
        }

        public int CrearClaseCapacidad(ClaseCapacidad claseCapacidad)
        {
            return claseData.CrearClaseCapacidad(claseCapacidad);
        }

        public int DeleteClaseCapacidad(ClaseCapacidad claseCapacidad)
        {
            return claseData.DeleteClaseCapacidad(claseCapacidad);
        }
        
        public List<ClaseContenido> ListClaseContenidoByClase(int claseId)
        {
            return claseData.ListClaseContenidoByClase(claseId);
        }

        public List<ClaseValor> ListClaseValorByClase(int claseId) 
        {
            return claseData.ListClaseValorByClase(claseId);
        }

        public List<ClaseMetodo> ListClaseMetodoByClase(int claseId) 
        {
            return claseData.ListClaseMetodoByClase(claseId);
        }

        #region Actividad
        public ClaseActividad GetClaseActividadByClase(int claseId) 
        {
            return claseData.GetClaseActividadByClase(claseId);
        }
        public int InsertClaseActividad(ClaseActividad claseActividad)
        {
            return claseData.InsertClaseActividad(claseActividad);
        }
        public int UpdateClaseActvidadSetActividad(ClaseActividad claseActividad)
        {
            return claseData.UpdateClaseActvidadSetActividad(claseActividad);
        }
        public int UpdateClaseActvidadSetHora(ClaseActividad claseActividad)
        {
            return claseData.UpdateClaseActvidadSetHora(claseActividad);
        }

        #endregion

        #region matriz Evaluacion
        public ClaseMatriz GetClaseMatrizByClase(int claseId) 
        {
            return claseData.GetClaseMatrizByClase(claseId);
        }


        #endregion 

        #region Conocimiento
        public List<ItemNodo> ListClaseConocimientoByClase(int claseId)
        {
            return claseData.ListClaseConocimientoByClase(claseId);
        }
        public int CrearClaseConocimiento(ItemNodo itemNodo)
        {
            return claseData.CrearClaseConocimiento(itemNodo);
        }
        public int DeleteClaseConocimiento(ItemNodo itemNodo)
        {
            return claseData.DeleteClaseConocimiento(itemNodo);
        } 
        #endregion

        #region Prueba
        public List<ItemNodo> ListClasePruebaByClase(int claseId)
        {
            return claseData.ListClasePruebaByClase(claseId);
        }
        public int CrearClasePrueba(ItemNodo itemNodo)
        {
            return claseData.CrearClasePrueba(itemNodo);
        }
        public int DeleteClasePrueba(ItemNodo itemNodo)
        {
            return claseData.DeleteClasePrueba(itemNodo);
        }

        #endregion

    }
}

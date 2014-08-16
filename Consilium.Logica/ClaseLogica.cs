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
            int resultado = 0;
            int resultadoClase = 0;
            resultadoClase = claseData.Crear(clase);
            if (resultadoClase > 0) 
            {
                //Crear clase matriz por defecto
                var claseMatriz = new ClaseMatriz {
                    ClaseId = resultadoClase, 
                    IndicadorLogro = String.Empty, 
                    PruebaTexto = String.Empty ,
                    ObservacionClase = String.Empty,
                };
                var claseActividad = new ClaseActividad {
                    ClaseId = resultadoClase, 
                    Actividades = String.Empty,
                    Horas = String.Empty
                };
                resultado = claseData.CrearClaseMatriz(claseMatriz);
                resultado = claseData.CrearClaseActividad(claseActividad);
            }
            return resultadoClase;
        }

        public int Actualizar(Clase clase)
        {
            return claseData.Actualizar(clase);
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

        public int CrearClaseContenido(ClaseContenido claseContenido) 
        {
            return claseData.CrearClaseContenido(claseContenido);
        }

        public int DeleteClaseContenido(ClaseContenido claseContenido) 
        {
            return claseData.DeleteClaseContenido(claseContenido);
        }
        

        public List<ClaseValor> ListClaseValorByClase(int claseId) 
        {
            return claseData.ListClaseValorByClase(claseId);
        }
        public int CrearClaseValor(ClaseValor claseValor) 
        {
            return claseData.CrearClaseValor(claseValor);
        }
        public int DeleteClaseValor(ClaseValor claseValor) 
        {
            return claseData.DeleteClaseValor(claseValor);
        }

        public List<ClaseMetodo> ListClaseMetodoByClase(int claseId) 
        {
            return claseData.ListClaseMetodoByClase(claseId);
        }
        public int CrearClaseMetodo(ClaseMetodo claseMetodo) 
        {
            return claseData.CrearClaseMetodo(claseMetodo);
        }
        public int DeleteClaseMetodo(ClaseMetodo claseMetodo) 
        {
            return claseData.DeleteClaseMetodo(claseMetodo);
        }

        #region Actividad
        public ClaseActividad GetClaseActividadByClase(int claseId) 
        {
            return claseData.GetClaseActividadByClase(claseId);
        }
        public int CrearClaseActividad(ClaseActividad claseActividad)
        {
            return claseData.CrearClaseActividad(claseActividad);
        }
        public int ActualizarClaseActvidad(ClaseActividad claseActividad)
        {
            return claseData.ActualizarClaseActvidad(claseActividad);
        }

        #endregion

        #region matriz Evaluacion
        public ClaseMatriz GetClaseMatrizByClase(int claseId) 
        {
            return claseData.GetClaseMatrizByClase(claseId);
        }
        public int CrearClaseMatriz(ClaseMatriz claseMatriz)
        {
            return claseData.CrearClaseMatriz(claseMatriz);
        }
        public int ActualizarClaseMatriz(ClaseMatriz claseMatriz)
        {
            return claseData.ActualizarClaseMatriz(claseMatriz);
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

        #region Archivo
        public List<ClaseArchivo> ListClaseArchivoByClase(int claseId)
        {
            return claseData.ListClaseArchivoByClase(claseId);
        }
        public ClaseArchivo GetClaseArchivoById(int claseArchivoId)
        {
            return claseData.GetClaseArchivoById(claseArchivoId);
        }
        public int CrearClaseArchivo(ClaseArchivo claseArchivo)
        {
            return claseData.CrearClaseArchivo(claseArchivo);
        }
        public int ActualizarClaseArchivo(ClaseArchivo claseArchivo)
        {
            return claseData.ActualizarClaseArchivo(claseArchivo);
        }

        #endregion
    }
}

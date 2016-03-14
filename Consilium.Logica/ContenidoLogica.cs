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
        
        #region conocimiento
        public List<Contenido> ListConocimiento(int colegioId, int areaId) 
        {
            return contenidoData.ListConocimiento(colegioId, areaId);
        }

        public int CrearConocimiento(Contenido conocimiento) 
        {
            return contenidoData.CrearConocimiento(conocimiento);
        }

        public int DeleteConocimiento(int conocimientoId) 
        {
            return contenidoData.DeleteConocimiento(conocimientoId);
        }

        public int ActualizarConocimiento(Contenido conocimiento) 
        {
            return contenidoData.ActualizarConocimiento(conocimiento);
        }

        public int ActualizarConocimientoOrden(int conocimientoId, bool arriba)
        {
            return contenidoData.ActualizarConocimientoOrden(conocimientoId, arriba);
        }
        #endregion 

        #region detalle

        public List<Contenido> ListDetalle(Contenido detalle) 
        {
            return contenidoData.ListDetalle(detalle);
        }

        public int CrearDetalle(Contenido detalle) 
        {
            return contenidoData.CrearDetalle(detalle);
        }

        public int DeleteDetalle(int detalleId) 
        {
            return contenidoData.DeleteDetalle(detalleId);
        }

        public int ActualizarDetalle(Contenido detalle) 
        {
            return contenidoData.ActualizarDetalle(detalle);
        }

        public int ActualizarDetalleOrden(int detalleId, bool arriba)
        {
            return contenidoData.ActualizarDetalleOrden(detalleId, arriba);
        }

        #endregion

        #region contenido

        public List<Contenido> ListContenido(Contenido contenido) 
        {
            return contenidoData.ListContenido(contenido);
        }

        public int CrearContenido(Contenido contenido) 
        {
            return contenidoData.CrearContenido(contenido);
        }

        public int DeleteContenido(int contenidoId) 
        {
            return contenidoData.DeleteContenido(contenidoId);
        }

        public int ActualizarContenido(Contenido contenido) 
        {
            return contenidoData.ActualizarContenido(contenido);
        }

        public int ActualizarContenidoOrden(int contenidoId, bool arriba)
        {
            return contenidoData.ActualizarContenidoOrden(contenidoId, arriba);
        }

        #endregion
    }
}

using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ClaseData : BaseData
    {
        /// <summary>
        /// Crear una clase, devuelve 0 si la clase esta registrada
        /// </summary>
        /// <param name="clase"></param>
        /// <returns></returns>
        public int Crear(Clase clase)
        {
            string spName = "sp_crear_clase";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@clase_titulo", clase.Titulo, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", clase.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area_id", clase.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@nivel_id", clase.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@grado_id", clase.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@fecha_inicio", clase.FechaInicio, ParameterDirection.Input, System.Data.DbType.Date));
                        command.Parameters.Add(ObjSqlParameter("@fecha_fin", clase.FechaFin, ParameterDirection.Input, System.Data.DbType.Date));
                        command.Parameters.Add(ObjSqlParameter("@fecha_reg", clase.FechaRegistro, ParameterDirection.Input, System.Data.DbType.Date));
                        command.Parameters.Add(ObjSqlParameter("@usuario", clase.Usuario, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@formato", clase.Formato, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.ExecuteNonQuery();
                        retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                    }
                    return retVal;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        
        public List<Clase> List(int colegioId)
        {

            string spName = "clase.sp_clase_lst";
            var lista = new List<Clase>();
            Clase claseMetodo = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseMetodo = new Clase();
                            claseMetodo.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            claseMetodo.Titulo = dr.GetString(dr.GetOrdinal("clase_titulo"));
                            claseMetodo.Area = dr.GetString(dr.GetOrdinal("area"));
                            claseMetodo.Nivel = dr.GetString(dr.GetOrdinal("nivel"));
                            claseMetodo.Grado = dr.GetString(dr.GetOrdinal("grado"));
                            claseMetodo.FechaInicio = dr.GetDateTime(dr.GetOrdinal("fecha_inicio"));
                            claseMetodo.FechaFin = dr.GetDateTime(dr.GetOrdinal("fecha_fin"));
                            claseMetodo.FechaRegistro = dr.GetDateTime(dr.GetOrdinal("fecha_reg"));
                            claseMetodo.Usuario = dr.GetString(dr.GetOrdinal("usuario"));
                            lista.Add(claseMetodo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }

        public List<Clase> ListByFiltro(Clase busqueda)
        {

            string spName = "clase.sp_clase_lstByFilto";
            var lista = new List<Clase>();
            Clase claseMetodo = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", busqueda.ColegioId, ParameterDirection.Input, DbType.Int32));
                        if(!string.IsNullOrEmpty(busqueda.Usuario))
                            command.Parameters.Add(ObjSqlParameter("@usuario", busqueda.Usuario, ParameterDirection.Input, DbType.String));
                        if (busqueda.AreaId != 0)
                            command.Parameters.Add(ObjSqlParameter("@area", busqueda.AreaId, ParameterDirection.Input, DbType.Int32));
                        if (busqueda.NivelId != 0)
                            command.Parameters.Add(ObjSqlParameter("@nivelId", busqueda.NivelId, ParameterDirection.Input, DbType.Int32));
                        if (busqueda.GradoId != 0)
                            command.Parameters.Add(ObjSqlParameter("@gradoId", busqueda.GradoId, ParameterDirection.Input, DbType.Int32));
                        if (!string.IsNullOrEmpty(busqueda.FechaInicioFormato))
                            command.Parameters.Add(ObjSqlParameter("@fechaInicio", busqueda.FechaInicioFormato, ParameterDirection.Input, DbType.String));
                        if (!string.IsNullOrEmpty(busqueda.FechaFinFormato))
                            command.Parameters.Add(ObjSqlParameter("@fechaFin", busqueda.FechaFinFormato, ParameterDirection.Input, DbType.String));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseMetodo = new Clase();
                            claseMetodo.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            claseMetodo.Titulo = dr.GetString(dr.GetOrdinal("clase_titulo"));
                            claseMetodo.Area = dr.GetString(dr.GetOrdinal("area"));
                            claseMetodo.Nivel = dr.GetString(dr.GetOrdinal("nivel"));
                            claseMetodo.Grado = dr.GetString(dr.GetOrdinal("grado"));
                            claseMetodo.FechaInicio = dr.GetDateTime(dr.GetOrdinal("fecha_inicio"));
                            claseMetodo.FechaFin = dr.GetDateTime(dr.GetOrdinal("fecha_fin"));
                            claseMetodo.FechaRegistro = dr.GetDateTime(dr.GetOrdinal("fecha_reg"));
                            claseMetodo.Usuario = dr.GetString(dr.GetOrdinal("usuario"));

                            //formato fechas
                            claseMetodo.FechaInicioFormato = claseMetodo.FechaInicio.ToString("dd/MM/yyyy");
                            claseMetodo.FechaFinFormato = claseMetodo.FechaFin.ToString("dd/MM/yyyy");
                            claseMetodo.FechaRegistroFormato = claseMetodo.FechaRegistro.AddHours(-5).ToString("dd/MM/yyyy hh:mm:ss tt");
                            lista.Add(claseMetodo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }


        public Clase Get(int claseId)
        {

            string spName = "clase.sp_clase_getById";
            Clase clase = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            clase = new Clase();
                            clase.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            clase.Titulo = dr.GetString(dr.GetOrdinal("clase_titulo"));
                            clase.Area = dr.GetString(dr.GetOrdinal("area"));
                            clase.Nivel = dr.GetString(dr.GetOrdinal("nivel"));
                            clase.Grado = dr.GetString(dr.GetOrdinal("grado"));
                            clase.FechaInicio = dr.GetDateTime(dr.GetOrdinal("fecha_inicio"));
                            clase.FechaFin = dr.GetDateTime(dr.GetOrdinal("fecha_fin"));
                            clase.FechaRegistro = dr.GetDateTime(dr.GetOrdinal("fecha_reg"));
                            clase.Usuario = dr.GetString(dr.GetOrdinal("usuario"));
                            clase.NivelId = dr.GetInt32(dr.GetOrdinal("nivel_id"));
                            clase.GradoId = dr.GetInt32(dr.GetOrdinal("grado_id"));
                            clase.AreaId = dr.GetInt32(dr.GetOrdinal("area_id"));
                            clase.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return clase;

        }

        #region Capacidad

        /// <summary>
        /// Obtener el listado de capacidades por clase
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<ClaseCapacidad> ListClaseCapacidadByClase(int claseId)
        {

            string spName = "clase.sp_clase_capacidad";
            var lista = new List<ClaseCapacidad>();
            ClaseCapacidad claseCapacidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseCapacidad = new ClaseCapacidad();
                            claseCapacidad.ClaseCapacidadId = dr.GetInt32(dr.GetOrdinal("clase_capacidad_id"));
                            claseCapacidad.DeAreaId = dr.GetInt32(dr.GetOrdinal("dearea_id"));
                            claseCapacidad.DeArea = dr.GetString(dr.GetOrdinal("dearea"));
                            claseCapacidad.EspecificaId = dr.GetInt32(dr.GetOrdinal("especifica_id"));
                            claseCapacidad.Especifica = dr.GetString(dr.GetOrdinal("especifica"));
                            claseCapacidad.OperativaId = dr.GetInt32(dr.GetOrdinal("operativa_id"));
                            claseCapacidad.Operativa = dr.GetString(dr.GetOrdinal("operativa"));
                            lista.Add(claseCapacidad);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }

        /// <summary>
        /// Crear una capacidad para una clase
        /// </summary>
        /// <param name="claseCapacidad"></param>
        /// <returns></returns>
        public int CrearClaseCapacidad(ClaseCapacidad claseCapacidad)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {
                string spName = "clase.sp_crear_clase_capacidad";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@operativa_id", claseCapacidad.OperativaId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@clase_id", claseCapacidad.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    command.ExecuteNonQuery();
                    retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                    return retVal;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

        }


        /// <summary>
        /// Elimina clase capacidad por identificador
        /// </summary>
        /// <param name="claseCapacidad"></param>
        /// <returns></returns>
        public int DeleteClaseCapacidad(ClaseCapacidad claseCapacidad)
        {

            string spName = "clase.sp_delete_clase_capacidad";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@clase_capacidad_id", claseCapacidad.ClaseCapacidadId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    retVal = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

            return retVal;

        }

        #endregion Capacidad

        #region Actividad
        
        public ClaseActividad GetClaseActividadByClase(int claseId)
        {
            string spName = "clase.sp_clase_actividad_getByClase";
            ClaseActividad claseActividad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            claseActividad = new ClaseActividad();
                            claseActividad.ClaseActividadId = dr.GetInt32(dr.GetOrdinal("actividades_id"));
                            claseActividad.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            claseActividad.Actividades = dr.GetString(dr.GetOrdinal("actividades"));
                            claseActividad.Horas = dr.GetString(dr.GetOrdinal("actividades_hora"));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return claseActividad;
        }
        
        public int InsertClaseActividad(ClaseActividad claseActividad)
        {
            string spName = "clase.sp_clase_actividad_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@actividades", claseActividad.Actividades, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@actividades_hora", claseActividad.Horas, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseActividad.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.ExecuteNonQuery();
                        retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                    }
                    return retVal;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int UpdateClaseActvidadSetActividad(ClaseActividad claseActividad)
        {
            string spName = "clase.sp_clase_actividad_update_actividades";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@actividades", claseActividad.Actividades, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@clase_id", claseActividad.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    retVal = command.ExecuteNonQuery();
                    return retVal;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        public int UpdateClaseActvidadSetHora(ClaseActividad claseActividad)
        {
            string spName = "clase.sp_clase_actividad_update_actividades_hora";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@actividades_hora", claseActividad.Horas, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@clase_id", claseActividad.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    retVal = command.ExecuteNonQuery();
                    return retVal;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }


        #endregion

        #region Matriz Evaluacion

        public ClaseMatriz GetClaseMatrizByClase(int claseId)
        {
            string spName = "clase.sp_clase_matriz_getByClase";
            ClaseMatriz claseMatriz = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            claseMatriz = new ClaseMatriz();
                            claseMatriz.ClaseMatrizId = dr.GetInt32(dr.GetOrdinal("clase_matriz_id"));
                            claseMatriz.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            claseMatriz.Formativa = dr.GetBoolean(dr.GetOrdinal("formativa"));
                            claseMatriz.Sumativa = dr.GetBoolean(dr.GetOrdinal("sumativa"));
                            claseMatriz.AutoEvaluativa = dr.GetBoolean(dr.GetOrdinal("autoevaluativa"));
                            claseMatriz.Coevaluativa = dr.GetBoolean(dr.GetOrdinal("coevaluativa"));
                            claseMatriz.HeteroEvalucion = dr.GetBoolean(dr.GetOrdinal("heteroevaluacion"));
                            claseMatriz.Censal = dr.GetBoolean(dr.GetOrdinal("censal"));
                            claseMatriz.Muestral = dr.GetBoolean(dr.GetOrdinal("muestral"));
                            claseMatriz.IndicadorLogro = dr.GetString(dr.GetOrdinal("indicador_logro"));
                            claseMatriz.PruebaTexto = dr.GetString(dr.GetOrdinal("pruebatxt"));
                            claseMatriz.ObservacionClase = dr.GetString(dr.GetOrdinal("obsclase"));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return claseMatriz;
        }
        
        

        #endregion

        /// <summary>
        /// Obtener el listado de contenidos por clase
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<ClaseContenido> ListClaseContenidoByClase(int claseId)
        {

            string spName = "clase.sp_clase_contenido_lstByClase";
            var lista = new List<ClaseContenido>();
            ClaseContenido claseContenido = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseContenido = new ClaseContenido();
                            claseContenido.ConocimientoId = dr.GetInt32(dr.GetOrdinal("organi_id"));
                            claseContenido.Conocimiento = dr.GetString(dr.GetOrdinal("organi"));
                            claseContenido.DetalleId = dr.GetInt32(dr.GetOrdinal("organi2_id"));
                            claseContenido.Detalle = dr.GetString(dr.GetOrdinal("organi2"));
                            claseContenido.ContenidoId = dr.GetInt32(dr.GetOrdinal("organi3_id"));
                            claseContenido.ContenidoDesc = dr.GetString(dr.GetOrdinal("organi3"));
                            claseContenido.ClaseContenidoId = dr.GetInt32(dr.GetOrdinal("clase_cono_id"));
                            lista.Add(claseContenido);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }

        /// <summary>
        /// Obtener el listado de valores por clase
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<ClaseValor> ListClaseValorByClase(int claseId)
        {

            string spName = "clase.sp_clase_valores_lstByClase";
            var lista = new List<ClaseValor>();
            ClaseValor claseValor = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseValor = new ClaseValor();
                            claseValor.ValorId = dr.GetInt32(dr.GetOrdinal("valores_id"));
                            claseValor.Valor = dr.GetString(dr.GetOrdinal("valores"));
                            claseValor.ActitudId = dr.GetInt32(dr.GetOrdinal("actitud_id"));
                            claseValor.Actitud = dr.GetString(dr.GetOrdinal("actitud"));
                            claseValor.ClaseValorId = dr.GetInt32(dr.GetOrdinal("clase_valores_id"));
                            lista.Add(claseValor);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }

        /// <summary>
        /// Obtener el listado de contenidos por clase
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<ClaseMetodo> ListClaseMetodoByClase(int claseId)
        {

            string spName = "clase.sp_clase_metodo_lstByClase";
            var lista = new List<ClaseMetodo>();
            ClaseMetodo claseMetodo = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseMetodo = new ClaseMetodo();
                            claseMetodo.CriterioId = dr.GetInt32(dr.GetOrdinal("criterio_id"));
                            claseMetodo.Criterio = dr.GetString(dr.GetOrdinal("criterio"));
                            claseMetodo.MetecnicaId = dr.GetInt32(dr.GetOrdinal("metecnica_id"));
                            claseMetodo.Metecnica = dr.GetString(dr.GetOrdinal("metecnica"));
                            claseMetodo.ClaseMetodoId = dr.GetInt32(dr.GetOrdinal("clase_metodo_id"));
                            lista.Add(claseMetodo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }


        #region Conocimiento
        /// <summary>
        /// Obtener el listado de conocimientos por clase
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<ItemNodo> ListClaseConocimientoByClase(int claseId)
        {

            string spName = "clase.clase_tipo_conocimiento_lst";
            var lista = new List<ItemNodo>();
            ItemNodo itemNodo = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            itemNodo = new ItemNodo();
                            itemNodo.Nodo1Id = dr.GetInt32(dr.GetOrdinal("n1_id"));
                            itemNodo.Nodo1Valor = dr.GetString(dr.GetOrdinal("n1_valor"));
                            itemNodo.Nodo2Id = dr.GetInt32(dr.GetOrdinal("n2_id"));
                            itemNodo.Nodo2Valor = dr.GetString(dr.GetOrdinal("n2_valor"));
                            itemNodo.NodoId = dr.GetInt32(dr.GetOrdinal("clase_tipo_cono_id"));
                            lista.Add(itemNodo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }

        /// <summary>
        /// Crear una conocimiento para una clase
        /// </summary>
        /// <param name="itemNodo"></param>
        /// <returns></returns>
        public int CrearClaseConocimiento(ItemNodo itemNodo)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {
                string spName = "clase.clase_tipo_conocimiento_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@tipo_conocimiento_id", itemNodo.Nodo2Id, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@clase_id", itemNodo.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    command.ExecuteNonQuery();
                    retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                    return retVal;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

        }


        /// <summary>
        /// Elimina clase capacidad por identificador
        /// </summary>
        /// <param name="itemNodo"></param>
        /// <returns></returns>
        public int DeleteClaseConocimiento(ItemNodo itemNodo)
        {

            string spName = "clase.clase_tipo_conocimiento_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@clase_tipo_cono_id", itemNodo.NodoId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    retVal = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

            return retVal;

        }        
        
        #endregion

        #region prueba
        /// <summary>
        /// Obtener el listado de conocimientos por clase
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<ItemNodo> ListClasePruebaByClase(int claseId)
        {

            string spName = "clase.clase_item_registro_reactivo_lst";
            var lista = new List<ItemNodo>();
            ItemNodo itemNodo = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            itemNodo = new ItemNodo();
                            itemNodo.Nodo1Id = dr.GetInt32(dr.GetOrdinal("n1_id"));
                            itemNodo.Nodo1Valor = dr.GetString(dr.GetOrdinal("n1_valor"));
                            itemNodo.Nodo2Id = dr.GetInt32(dr.GetOrdinal("n2_id"));
                            itemNodo.Nodo2Valor = dr.GetString(dr.GetOrdinal("n2_valor"));
                            itemNodo.NodoId = dr.GetInt32(dr.GetOrdinal("clase_item_reg_act_id"));
                            lista.Add(itemNodo);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }

        /// <summary>
        /// Crear una conocimiento para una clase
        /// </summary>
        /// <param name="itemNodo"></param>
        /// <returns></returns>
        public int CrearClasePrueba(ItemNodo itemNodo)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {
                string spName = "clase.clase_item_registro_reactivo_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@item_reg_act_id", itemNodo.Nodo2Id, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@clase_id", itemNodo.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    command.ExecuteNonQuery();
                    retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                    return retVal;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

        }


        /// <summary>
        /// Elimina clase capacidad por identificador
        /// </summary>
        /// <param name="itemNodo"></param>
        /// <returns></returns>
        public int DeleteClasePrueba(ItemNodo itemNodo)
        {

            string spName = "clase.clase_item_registro_reactivo_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@clase_item_reg_act_id", itemNodo.NodoId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    retVal = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }

            return retVal;

        }

        #endregion
    }
}

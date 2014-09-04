using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ContenidoData:BaseData
    {
        /// <summary>
        /// Obtener el listado de contenido
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<Contenido> ListContenidoByColegioAndAreaAndNivelAndGrado(Contenido busqueda)
        {

            string spName = "clase.sp_organizador3_lstByColegioAndAreaAndNivelAndGrado";
            var lista = new List<Contenido>();
            Contenido contenido = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", busqueda.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area", busqueda.Area, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@nivel_id", busqueda.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@grado_id", busqueda.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            contenido = new Contenido();
                            contenido.ConocimientoId = dr.GetInt32(dr.GetOrdinal("organi_id"));
                            contenido.Conocimiento = dr.GetString(dr.GetOrdinal("organi"));
                            contenido.DetalleId = dr.GetInt32(dr.GetOrdinal("organi2_id"));
                            contenido.Detalle = dr.GetString(dr.GetOrdinal("organi2"));
                            contenido.ContenidoId = dr.GetInt32(dr.GetOrdinal("organi3_id"));
                            contenido.ContenidoDesc = dr.GetString(dr.GetOrdinal("organi3"));
                            lista.Add(contenido);
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

        #region conocimiento

        public List<Contenido> ListConocimiento(int colegioId, int areaId)
        {
            string spName = "sp_organizador_lst";
            var lista = new List<Contenido>();
            Contenido contenido = null;

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@area", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    IDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        contenido = new Contenido();
                        contenido.ConocimientoId = dr.GetInt32(dr.GetOrdinal("organi_id"));
                        contenido.Conocimiento = dr.GetString(dr.GetOrdinal("organi"));
                        contenido.Area = dr.GetInt32(dr.GetOrdinal("area"));
                        lista.Add(contenido);
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
        public int CrearConocimiento(Contenido conocimiento)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                string spName = "sp_organizador_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi", conocimiento.Conocimiento, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@area", conocimiento.Area, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", conocimiento.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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
        public int DeleteConocimiento(int conocimientoId)
        {

            string spName = "sp_organizador_delete";
            int retVal = 0;


            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi_id", conocimientoId, ParameterDirection.Input, System.Data.DbType.Int32));
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
        public int ActualizarConocimiento(Contenido conocimiento)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                string spName = "sp_organizador_update";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi", conocimiento.Conocimiento, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@organi_id", conocimiento.ConocimientoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        #region detalle

        public List<Contenido> ListDetalle(Contenido detalle)
        {

            string spName = "sp_organizador2_lst";
            var lista = new List<Contenido>();
            Contenido contenido = null;

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.Parameters.Add(ObjSqlParameter("@organi_id", detalle.ConocimientoId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@nivel_id", detalle.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@grado_id", detalle.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));

                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    IDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        contenido = new Contenido();
                        contenido.DetalleId = dr.GetInt32(dr.GetOrdinal("organi2_id"));
                        contenido.Detalle = dr.GetString(dr.GetOrdinal("organi2"));
                        lista.Add(contenido);
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

        public int CrearDetalle(Contenido detalle)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                string spName = "sp_organizador2_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi2", detalle.Detalle, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@organi_id", detalle.ConocimientoId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@nivel_id", detalle.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@grado_id", detalle.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteDetalle(int detalleId)
        {
            string spName = "sp_organizador2_delete";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi2_id", detalleId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int ActualizarDetalle(Contenido detalle)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                string spName = "sp_organizador2_update";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi2_id", detalle.DetalleId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@organi2", detalle.Detalle, ParameterDirection.Input, System.Data.DbType.String));
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

        #region contenido

        public List<Contenido> ListContenido(Contenido contenido)
        {

            string spName = "sp_organizador3_lst";
            var lista = new List<Contenido>();
            Contenido entidad = null;

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.Parameters.Add(ObjSqlParameter("@organi2_id", contenido.DetalleId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    IDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        entidad = new Contenido();
                        entidad.ContenidoId = dr.GetInt32(dr.GetOrdinal("organi3_id"));
                        entidad.ContenidoDesc = dr.GetString(dr.GetOrdinal("organi3"));
                        lista.Add(entidad);
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

        public int CrearContenido(Contenido contenido)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                string spName = "sp_organizador3_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi3", contenido.ContenidoDesc, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@organi2_id", contenido.DetalleId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteContenido(int contenidoId)
        {

            string spName = "sp_organizador3_delete";
            int retVal = 0;


            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi3_id", contenidoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int ActualizarContenido(Contenido contenido)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                string spName = "sp_organizador3_update";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@organi3", contenido.ContenidoDesc, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@organi3_id", contenido.ContenidoId, ParameterDirection.Input, System.Data.DbType.Int32));
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
    }
}

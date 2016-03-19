using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ClaseComentarioData : BaseData
    {

        public List<ClaseComentario> GetByClase(int claseId)
        {

            string spName = "clase.sp_clase_comentario_getByClase";
            var lista = new List<ClaseComentario>();
            ClaseComentario claseMetodo = null;

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

                        while (dr.Read())
                        {
                            claseMetodo = new ClaseComentario();
                            claseMetodo.ClaseComentarioId = dr.GetInt32(dr.GetOrdinal("clase_comentario_id"));
                            claseMetodo.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            claseMetodo.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                            claseMetodo.Usuario = dr.GetString(dr.GetOrdinal("usuario"));
                            claseMetodo.EsNotificado = dr.GetBoolean(dr.GetOrdinal("es_notificado"));
                            claseMetodo.Estado = dr.GetBoolean(dr.GetOrdinal("estado"));
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

        public List<ClaseComentario> GetByUsuario(string usuario)
        {

            string spName = "clase.sp_clase_comentario_getByUsuario";
            var lista = new List<ClaseComentario>();
            ClaseComentario claseMetodo = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@usuario", usuario, ParameterDirection.Input, System.Data.DbType.String));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            claseMetodo = new ClaseComentario();
                            claseMetodo.ClaseComentarioId = dr.GetInt32(dr.GetOrdinal("clase_comentario_id"));
                            claseMetodo.ClaseId = dr.GetInt32(dr.GetOrdinal("clase_id"));
                            claseMetodo.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                            claseMetodo.Usuario = dr.GetString(dr.GetOrdinal("usuario"));
                            claseMetodo.EsNotificado = dr.GetBoolean(dr.GetOrdinal("es_notificado"));
                            claseMetodo.Estado = dr.GetBoolean(dr.GetOrdinal("estado"));
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

        public int CrearClaseComentario(ClaseComentario claseComentario)
        {
            string spName = "clase.sp_clase_comentario_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseComentario.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@descripcion", claseComentario.Descripcion, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@usuario", claseComentario.Usuario, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@es_notificado", claseComentario.EsNotificado, ParameterDirection.Input, System.Data.DbType.Boolean));
                        command.Parameters.Add(ObjSqlParameter("@estado", claseComentario.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
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

        public int ActualizarClaseComentario(ClaseComentario claseComentario)
        {
            string spName = "clase.sp_clase_comentario_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@clase_comentario_id", claseComentario.ClaseComentarioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@clase_id", claseComentario.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@descripcion", claseComentario.Descripcion, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@usuario", claseComentario.Usuario, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@es_notificado", claseComentario.EsNotificado, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@estado", claseComentario.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
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


    }
}

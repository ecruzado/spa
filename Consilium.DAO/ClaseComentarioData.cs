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


    }
}

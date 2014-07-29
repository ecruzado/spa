using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ColumnaColegioData:BaseData
    {
        public int Crear(ColumnaColegio columnaColegio)
        {
            string spName = "clase.col_colegio_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@columna_id", columnaColegio.ColumnaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", columnaColegio.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@nombre", columnaColegio.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@estado", columnaColegio.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        retVal = command.ExecuteNonQuery();
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

        public int Actualizar(ColumnaColegio columnaColegio)
        {
            string spName = "clase.col_colegio_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@columna_id", columnaColegio.ColumnaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", columnaColegio.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@nombre", columnaColegio.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@estado", columnaColegio.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        retVal = command.ExecuteNonQuery();
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

        public ColumnaColegio Get(ColumnaColegio columnaColegio)
        {

            string spName = "clase.col_colegio_lstByColuAndCole";
            ColumnaColegio entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@columna_id", columnaColegio.ColumnaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", columnaColegio.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            entidad = new ColumnaColegio();
                            entidad.ColumnaId = dr.GetInt32(dr.GetOrdinal("columna_id"));
                            entidad.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            entidad.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                            entidad.Estado = dr.GetBoolean(dr.GetOrdinal("estado"));
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
            return entidad;

        }
    }
}

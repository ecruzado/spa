using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ColegioData:BaseData
    {
        public List<Colegio> List()
        {
            var lista = new List<Colegio>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_colegio_lst";
                Colegio colegio;
                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    IDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        colegio = new Colegio();
                        colegio.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                        colegio.Nombre = dr.IsDBNull(dr.GetOrdinal("colegio_nombre")) ? "" : dr.GetString(dr.GetOrdinal("colegio_nombre"));
                        colegio.Direccion = dr.IsDBNull(dr.GetOrdinal("colegio_dirección")) ? "" : dr.GetString(dr.GetOrdinal("colegio_dirección"));
                        colegio.Telefono = dr.IsDBNull(dr.GetOrdinal("colegio_telefono")) ? "" : dr.GetString(dr.GetOrdinal("colegio_telefono"));
                        lista.Add(colegio);
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


        public int Insert(Colegio colegio)
        {

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_colegio_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@colegio_nombre", colegio.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_dirección", colegio.Direccion, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_telefono", colegio.Telefono, ParameterDirection.Input, System.Data.DbType.String));
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

        public int Update(Colegio colegio)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_colegio_update";
                int retVal = 0;


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@colegio_nombre", colegio.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_dirección", colegio.Direccion, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_telefono", colegio.Telefono, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", colegio.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

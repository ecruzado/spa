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

        public Colegio Get(int colegioId)
        {
            Colegio colegio = null;
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_colegio_getById";
                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.String));
                    conn.Open();
                    IDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        colegio = new Colegio();
                        colegio.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                        colegio.Nombre = dr.IsDBNull(dr.GetOrdinal("colegio_nombre")) ? "" : dr.GetString(dr.GetOrdinal("colegio_nombre"));
                        colegio.Direccion = dr.IsDBNull(dr.GetOrdinal("colegio_dirección")) ? "" : dr.GetString(dr.GetOrdinal("colegio_dirección"));
                        colegio.Telefono = dr.IsDBNull(dr.GetOrdinal("colegio_telefono")) ? "" : dr.GetString(dr.GetOrdinal("colegio_telefono"));
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
            return colegio;
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

        public int Exportar(ColegioExportar colegioExportar)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                string spName = "clase.sp_exportar_mantenimiento";
                int retVal = 0;
                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@colegio_id_origen", colegioExportar.ColegioIdOrigen, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id_destino", colegioExportar.ColegioIdDestino, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@capacidad", colegioExportar.Capacidad, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@contenido", colegioExportar.Contenido, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@valores", colegioExportar.Valores, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@metodologia", colegioExportar.Metodologia, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@columna1", colegioExportar.Columna1, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@columna2", colegioExportar.Columna2, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@columna3", colegioExportar.Columna3, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@columna4", colegioExportar.Columna4, ParameterDirection.Input, System.Data.DbType.Boolean));
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

using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ConfColumnaColegioData : BaseData
    {
        public int Crear(ConfColumnaColegio confColumnaColegio)
        {
            string spName = "clase.conf_col_colegio_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@columna_id", confColumnaColegio.ColumnaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", confColumnaColegio.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        if(confColumnaColegio.AreaId != 0)
                            command.Parameters.Add(ObjSqlParameter("@area_id", confColumnaColegio.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        if (confColumnaColegio.NivelId != 0)
                            command.Parameters.Add(ObjSqlParameter("@nivel_id", confColumnaColegio.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        if (confColumnaColegio.GradoId != 0)
                            command.Parameters.Add(ObjSqlParameter("@grado_id", confColumnaColegio.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@valor", confColumnaColegio.Valor, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@orden", confColumnaColegio.Orden, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@estado", confColumnaColegio.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                        if (confColumnaColegio.ConfColumnaColegioPadreId != 0)
                            command.Parameters.Add(ObjSqlParameter("@confcolcolegio_padre_id", confColumnaColegio.ConfColumnaColegioPadreId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int Actualizar(ConfColumnaColegio confColumnaColegio)
        {
            string spName = "clase.conf_col_colegio_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@confcolcolegio_id", confColumnaColegio.ConfColumnaColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@columna_id", confColumnaColegio.ColumnaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", confColumnaColegio.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        if (confColumnaColegio.AreaId != 0)
                            command.Parameters.Add(ObjSqlParameter("@area_id", confColumnaColegio.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        if (confColumnaColegio.NivelId != 0)
                            command.Parameters.Add(ObjSqlParameter("@nivel_id", confColumnaColegio.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        if (confColumnaColegio.GradoId != 0)
                            command.Parameters.Add(ObjSqlParameter("@grado_id", confColumnaColegio.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@valor", confColumnaColegio.Valor, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@orden", confColumnaColegio.Orden, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@estado", confColumnaColegio.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                        if (confColumnaColegio.ConfColumnaColegioPadreId != 0)
                            command.Parameters.Add(ObjSqlParameter("@confcolcolegio_padre_id", confColumnaColegio.ConfColumnaColegioPadreId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        retVal =  command.ExecuteNonQuery();
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

        public ConfColumnaColegio Get(int id)
        {

            string spName = "clase.conf_col_colegio_lstById";
            ConfColumnaColegio entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@confcolcolegio_id", id, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            entidad = new ConfColumnaColegio();
                            entidad.ConfColumnaColegioId = dr.GetInt32(dr.GetOrdinal("confcolcolegio_id"));
                            entidad.ColumnaId = dr.GetInt32(dr.GetOrdinal("columna_id"));
                            entidad.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            entidad.AreaId = dr.IsDBNull(dr.GetOrdinal("area_id"))? 0 : dr.GetInt32(dr.GetOrdinal("area_id"));
                            entidad.NivelId = dr.IsDBNull(dr.GetOrdinal("nivel_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("nivel_id"));
                            entidad.GradoId = dr.IsDBNull(dr.GetOrdinal("grado_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("grado_id"));
                            entidad.Valor = dr.GetString(dr.GetOrdinal("valor"));
                            entidad.Orden = dr.GetInt32(dr.GetOrdinal("orden"));
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

        public List<ConfColumnaColegio> ListByColumnaAndColegio(ConfColumnaColegio busqueda)
        {

            string spName = "clase.conf_col_colegio_lstByColumnaCole";
            var lista = new List<ConfColumnaColegio>();
            ConfColumnaColegio entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@columna_id", busqueda.ColumnaId, ParameterDirection.Input, DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", busqueda.ColegioId, ParameterDirection.Input, DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area_id ", busqueda.AreaId, ParameterDirection.Input, DbType.Int32));
                        if (busqueda.ConfColumnaColegioPadreId != 0)
                            command.Parameters.Add(ObjSqlParameter("@confcolcolegio_padre_id", busqueda.ConfColumnaColegioPadreId, ParameterDirection.Input, DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new ConfColumnaColegio();
                            entidad.ConfColumnaColegioId = dr.GetInt32(dr.GetOrdinal("confcolcolegio_id"));
                            entidad.ColumnaId = dr.GetInt32(dr.GetOrdinal("columna_id"));
                            entidad.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            entidad.AreaId = dr.IsDBNull(dr.GetOrdinal("area_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("area_id"));
                            entidad.NivelId = dr.IsDBNull(dr.GetOrdinal("nivel_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("nivel_id"));
                            entidad.GradoId = dr.IsDBNull(dr.GetOrdinal("grado_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("grado_id"));
                            entidad.Valor = dr.GetString(dr.GetOrdinal("valor"));
                            entidad.Orden = dr.GetInt32(dr.GetOrdinal("orden"));
                            entidad.Estado = dr.GetBoolean(dr.GetOrdinal("estado"));
                            lista.Add(entidad);
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

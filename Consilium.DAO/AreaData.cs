using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class AreaData:BaseData
    {
        public List<Area> List(int colegioId)
        {

            string spName = "clase.sp_area_lst";
            var lista = new List<Area>();
            Area area = null;

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
                            area = new Area();
                            area.AreaId = dr.GetInt32(dr.GetOrdinal("area_id"));
                            area.Descripcion = dr.GetString(dr.GetOrdinal("area"));
                            lista.Add(area);
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

        public List<Area> ListByColegio(int colegioId)
        {
            string spName = "clase.sp_area_lst_ByColegio";
            var lista = new List<Area>();
            Area area = null;

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
                            area = new Area();
                            area.AreaId = dr.GetInt32(dr.GetOrdinal("area_id"));
                            area.Descripcion = dr.GetString(dr.GetOrdinal("area"));
                            area.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            area.EsOpcional = dr.IsDBNull(dr.GetOrdinal("esOpcional")) ? false : dr.GetBoolean(dr.GetOrdinal("esOpcional"));
                            area.NombreAlternativo = dr.IsDBNull(dr.GetOrdinal("nombreAlternativo")) ? "" : dr.GetString(dr.GetOrdinal("nombreAlternativo"));

                            lista.Add(area);
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

        public int Actualizar(Area area)
        {
            string spName = "clase.sp_area_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@area_id", area.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", area.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@nombre", area.NombreAlternativo, ParameterDirection.Input, System.Data.DbType.String));
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


    }
}

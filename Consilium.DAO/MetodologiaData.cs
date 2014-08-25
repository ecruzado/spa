using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class MetodologiaData : BaseData
    {
        public List<ItemNodo> ListByColegioAndArea(int colegioId, int areaId)
        {

            string spName = "clase.sp_metodo_lst";
            var lista = new List<ItemNodo>();
            ItemNodo entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new ItemNodo();
                            entidad.Nodo1Id = dr.GetInt32(dr.GetOrdinal("n1_id"));
                            entidad.Nodo1Valor = dr.GetString(dr.GetOrdinal("n1_valor"));
                            entidad.Nodo2Id = dr.GetInt32(dr.GetOrdinal("n2_id"));
                            entidad.Nodo2Valor = dr.GetString(dr.GetOrdinal("n2_valor"));
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
        
        #region criterio

        public List<Metodologia> ListCriterioByColegioAndArea(int colegioId, int areaId)
        {

            string spName = "clase.sp_criterio_lst";
            var lista = new List<Metodologia>();
            Metodologia entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new Metodologia();
                            entidad.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            entidad.AreaId = dr.GetInt32(dr.GetOrdinal("area_id"));
                            entidad.CriterioId = dr.GetInt32(dr.GetOrdinal("criterio_id"));
                            entidad.Criterio = dr.GetString(dr.GetOrdinal("criterio"));
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
        
        public int CrearCriterio(Metodologia metodologia)
        {
            string spName = "clase.sp_criterio_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@criterio", metodologia.Criterio, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@area_id", metodologia.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", metodologia.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int ActualizarCriterio(Metodologia metodologia)
        {
            string spName = "clase.sp_criterio_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@criterio_id", metodologia.CriterioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@criterio", metodologia.Criterio, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@area_id", metodologia.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", metodologia.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteCriterio(Metodologia metodologia)
        {

            string spName = "clase.sp_criterio_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@criterio_id", metodologia.CriterioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        #region metecnica

        public List<Metodologia> ListMetecnicaByCriterio(int criterio)
        {

            string spName = "clase.sp_metecnica_lstByCriterio";
            var lista = new List<Metodologia>();
            Metodologia entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@criterio_id", criterio, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new Metodologia();
                            entidad.CriterioId = dr.GetInt32(dr.GetOrdinal("criterio_id"));
                            entidad.MetecnicaId = dr.GetInt32(dr.GetOrdinal("metecnica_id"));
                            entidad.Metecnica = dr.GetString(dr.GetOrdinal("metecnica"));
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

        public int CrearMetecnica(Metodologia metodologia)
        {
            string spName = "clase.sp_metecnica_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@metecnica", metodologia.Metecnica, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@criterio_id", metodologia.CriterioId, ParameterDirection.Input, System.Data.DbType.Int32));
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
        
        public int ActualizarMetecnica(Metodologia metodologia)
        {
            string spName = "clase.sp_metecnica_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@metecnica_id", metodologia.MetecnicaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@metecnica", metodologia.Metecnica, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@criterio_id", metodologia.CriterioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteMetecnica(Metodologia metodologia)
        {

            string spName = "clase.sp_metecnica_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@metecnica_id", metodologia.MetecnicaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

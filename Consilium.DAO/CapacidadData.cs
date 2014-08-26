using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class CapacidadData:BaseData
    {
        public List<ItemNodo> ListByColegioAndArea(int colegioId, int areaId)
        {

            string spName = "clase.sp_capacidad_lst";
            var lista = new List<ItemNodo>();
            ItemNodo entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
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
                            entidad.Nodo3Id = dr.GetInt32(dr.GetOrdinal("n3_id"));
                            entidad.Nodo3Valor = dr.GetString(dr.GetOrdinal("n3_valor"));
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

        #region deaarea

        public List<Capacidad> ListDeAreaByColegioAndArea(int colegioId, int areaId)
        {

            string spName = "clase.sp_dearea_lst";
            var lista = new List<Capacidad>();
            Capacidad entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@area", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new Capacidad();
                            entidad.DeAreaId = dr.GetInt32(dr.GetOrdinal("dearea_id"));
                            entidad.DeArea = dr.GetString(dr.GetOrdinal("dearea"));
                            entidad.AreaId = dr.GetInt32(dr.GetOrdinal("area"));
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

        public int CrearDeArea(Capacidad capacidad)
        {
            string spName = "clase.sp_dearea_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@dearea", capacidad.DeArea, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@area", capacidad.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", capacidad.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int ActualizarDeArea(Capacidad capacidad)
        {
            string spName = "clase.sp_dearea_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@dearea", capacidad.DeArea, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@dearea_id", capacidad.DeAreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area", capacidad.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", capacidad.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteDeArea(int deAreaId)
        {

            string spName = "clase.sp_dearea_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@dearea_id", deAreaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        #region especifica

        public List<Capacidad> ListEspecificaByDeArea(int deAreaId)
        {

            string spName = "clase.sp_especifica_lst";
            var lista = new List<Capacidad>();
            Capacidad entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@dearea_id", deAreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new Capacidad();
                            entidad.EspecificaId = dr.GetInt32(dr.GetOrdinal("especifica_id"));
                            entidad.Especifica = dr.GetString(dr.GetOrdinal("especifica"));
                            entidad.DeAreaId = dr.GetInt32(dr.GetOrdinal("dearea_id"));
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

        public int CrearEspecifica(Capacidad capacidad)
        {
            string spName = "clase.sp_especifica_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@especifica", capacidad.Especifica, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@dearea_id", capacidad.DeAreaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int ActualizarEspecifica(Capacidad capacidad)
        {
            string spName = "clase.sp_especifica_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@especifica", capacidad.Especifica, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@dearea_id", capacidad.DeAreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@especifica_id", capacidad.EspecificaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteEspecifica(int especificaId)
        {
            string spName = "clase.sp_especifica_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@especifica_id", especificaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        #region operativa

        public List<Capacidad> ListOperativaByEspecifica(int especificaId)
        {

            string spName = "clase.sp_operativa_lst";
            var lista = new List<Capacidad>();
            Capacidad entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@especifica_id", especificaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            entidad = new Capacidad();
                            entidad.OperativaId = dr.GetInt32(dr.GetOrdinal("operativa_id"));
                            entidad.Operativa = dr.GetString(dr.GetOrdinal("operativa"));
                            entidad.EspecificaId = dr.GetInt32(dr.GetOrdinal("especifica_id"));
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

        public int CrearOperativa(Capacidad capacidad)
        {
            string spName = "clase.sp_operativa_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@operativa", capacidad.Operativa, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@especifica_id", capacidad.EspecificaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int ActualizarOperativa(Capacidad capacidad)
        {
            string spName = "clase.sp_operativa_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@operativa", capacidad.Operativa, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@especifica_id", capacidad.EspecificaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@operativa_id", capacidad.OperativaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public int DeleteOperativa(int operativaId)
        {
            string spName = "clase.sp_operativa_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@operativa_id", operativaId, ParameterDirection.Input, System.Data.DbType.Int32));
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

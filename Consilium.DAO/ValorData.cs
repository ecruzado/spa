using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ValorData : BaseData
    {
       public List<ItemNodo> ListByColegio(int colegioId)
        {

            string spName = "clase.sp_valor_lst";
            var lista = new List<ItemNodo>();
            ItemNodo entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

       #region valor

       public List<Valor> ListValorByColegio(int colegioId)
       {

           string spName = "clase.sp_valores_lst";
           var lista = new List<Valor>();
           Valor entidad = null;

           using (SqlConnection conn = new SqlConnection(CadenaConexion))
           {
               try
               {
                   using (SqlCommand command = new SqlCommand(spName, conn))
                   {
                       command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                       command.CommandType = CommandType.StoredProcedure;
                       conn.Open();

                       IDataReader dr = command.ExecuteReader();

                       while (dr.Read())
                       {
                           entidad = new Valor();
                           entidad.ColegioId = dr.GetInt32(dr.GetOrdinal("colegio_id"));
                           entidad.ValorId = dr.GetInt32(dr.GetOrdinal("valores_id"));
                           entidad.ValorDsc = dr.GetString(dr.GetOrdinal("valores"));
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

       public int CrearValor(Valor valor)
       {
           string spName = "clase.sp_valores_insert";
           int retVal = 0;

           using (SqlConnection conn = new SqlConnection(CadenaConexion))
           {
               try
               {
                   using (SqlCommand command = new SqlCommand(spName, conn))
                   {
                       command.CommandType = CommandType.StoredProcedure;

                       command.Parameters.Add(ObjSqlParameter("@valores", valor.ValorDsc, ParameterDirection.Input, System.Data.DbType.String));
                       command.Parameters.Add(ObjSqlParameter("@colegio_id", valor.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

       public int ActualizarValor(Valor valor)
       {
           string spName = "clase.sp_valores_update";
           int retVal = 0;

           using (SqlConnection conn = new SqlConnection(CadenaConexion))
           {
               try
               {
                   using (SqlCommand command = new SqlCommand(spName, conn))
                   {
                       command.CommandType = CommandType.StoredProcedure;

                       command.Parameters.Add(ObjSqlParameter("@valores_id", valor.ValorId, ParameterDirection.Input, System.Data.DbType.Int32));
                       command.Parameters.Add(ObjSqlParameter("@valores", valor.ValorDsc, ParameterDirection.Input, System.Data.DbType.String));
                       command.Parameters.Add(ObjSqlParameter("@colegio_id", valor.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

       public int DeleteValor(Valor valor)
       {

           string spName = "clase.sp_valores_delete";
           int retVal = 0;
           using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
           {

               try
               {
                   SqlCommand command = new SqlCommand(spName, conn);
                   command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.Add(ObjSqlParameter("@valores_id", valor.ValorId, ParameterDirection.Input, System.Data.DbType.Int32));
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

       #region actitud

       public List<Valor> ListActitudByValor(int valorId)
       {

           string spName = "clase.sp_actitud_lstByValores";
           var lista = new List<Valor>();
           Valor entidad = null;

           using (SqlConnection conn = new SqlConnection(CadenaConexion))
           {
               try
               {
                   using (SqlCommand command = new SqlCommand(spName, conn))
                   {
                       command.Parameters.Add(ObjSqlParameter("@valores_id", valorId, ParameterDirection.Input, System.Data.DbType.Int32));
                       command.CommandType = CommandType.StoredProcedure;
                       conn.Open();

                       IDataReader dr = command.ExecuteReader();

                       while (dr.Read())
                       {
                           entidad = new Valor();
                           entidad.ValorId = dr.GetInt32(dr.GetOrdinal("valores_id"));
                           entidad.ActitudId = dr.GetInt32(dr.GetOrdinal("actitud_id"));
                           entidad.Actitud = dr.GetString(dr.GetOrdinal("actitud"));
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

       public int CrearActitud(Valor actitud)
       {
           string spName = "clase.sp_actitud_insert";
           int retVal = 0;

           using (SqlConnection conn = new SqlConnection(CadenaConexion))
           {
               try
               {
                   using (SqlCommand command = new SqlCommand(spName, conn))
                   {
                       command.CommandType = CommandType.StoredProcedure;

                       command.Parameters.Add(ObjSqlParameter("@actitud", actitud.Actitud, ParameterDirection.Input, System.Data.DbType.String));
                       command.Parameters.Add(ObjSqlParameter("@valores_id", actitud.ValorId, ParameterDirection.Input, System.Data.DbType.Int32));
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

       public int ActualizarActitud(Valor actitud)
       {
           string spName = "clase.sp_actitud_update";
           int retVal = 0;

           using (SqlConnection conn = new SqlConnection(CadenaConexion))
           {
               try
               {
                   using (SqlCommand command = new SqlCommand(spName, conn))
                   {
                       command.CommandType = CommandType.StoredProcedure;

                       command.Parameters.Add(ObjSqlParameter("@actitud_id", actitud.ActitudId, ParameterDirection.Input, System.Data.DbType.Int32));
                       command.Parameters.Add(ObjSqlParameter("@actitud", actitud.Actitud, ParameterDirection.Input, System.Data.DbType.String));
                       command.Parameters.Add(ObjSqlParameter("@valores_id", actitud.ValorId, ParameterDirection.Input, System.Data.DbType.Int32));
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

       public int DeleteActitud(Valor actitud)
       {

           string spName = "clase.sp_actitud_delete";
           int retVal = 0;
           using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
           {

               try
               {
                   SqlCommand command = new SqlCommand(spName, conn);
                   command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.Add(ObjSqlParameter("@actitud_id", actitud.ActitudId, ParameterDirection.Input, System.Data.DbType.Int32));
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

using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ClaseConfColumnaColegioData : BaseData
    {
        public int Crear(ClaseColColumnaColegio claseColColumnaColegio)
        {
            string spName = "clase.clase_conf_col_colegio_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@clase_id", claseColColumnaColegio.ClaseId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@confcolcolegio_id", claseColColumnaColegio.ConfColumnaColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

        public List<ItemNodo> ListByClase(ClaseColColumnaColegio busqueda)
        {

            string spName = "clase.clase_conf_col_colegio_lstByClase3Nodos";
            var lista = new List<ItemNodo>();
            ItemNodo entidad = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@clase_id", busqueda.ClaseId, ParameterDirection.Input, DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@columna_id", busqueda.ColumnaId, ParameterDirection.Input, DbType.Int32));
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
                            entidad.NodoId = dr.GetInt32(dr.GetOrdinal("clase_confcolcolegio_id"));
                            entidad.NombreColumna = dr.GetString(dr.GetOrdinal("nombre"));        
                    
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

        public int Eliminar(ClaseColColumnaColegio claseColColumnaColegio)
        {

            string spName = "clase.clase_conf_col_colegio_delete";
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString()))
            {

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@clase_confcolcolegio_id", claseColColumnaColegio.ClaseColColumnaColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
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

    }
}

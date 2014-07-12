using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class GradoData:BaseData
    {
        /// <summary>
        /// Obtener el listado de grados por niveles
        /// </summary>
        /// <param name="gradoId">Grado id</param>
        /// <returns></returns>
        public List<Grado> ListByNivel(int nivelId)
        {

            string spName = "clase.sp_grado_lstByNivel";
            var lista = new List<Grado>();
            Grado grado = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            grado = new Grado();
                            grado.GradoId = dr.GetInt32(dr.GetOrdinal("grado_id"));
                            grado.GradoDesc = dr.GetString(dr.GetOrdinal("grado"));
                            lista.Add(grado);
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

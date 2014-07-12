using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class NivelData:BaseData
    {
        /// <summary>
        /// Obtener el listado de niveles
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<Nivel> List()
        {

            string spName = "clase.sp_nivel_lst";
            var lista = new List<Nivel>();
            Nivel nivel = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            nivel = new Nivel();
                            nivel.NivelId = dr.GetInt32(dr.GetOrdinal("nivel_id"));
                            nivel.NivelDesc = dr.GetString(dr.GetOrdinal("nivel"));
                            lista.Add(nivel);
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

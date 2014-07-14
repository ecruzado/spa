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
        public List<Area> List()
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


    }
}

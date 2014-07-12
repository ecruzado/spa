using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ContenidoData:BaseData
    {
        /// <summary>
        /// Obtener el listado de contenido
        /// </summary>
        /// <param name="claseId"></param>
        /// <returns></returns>
        public List<Contenido> ListContenidoByColegioAndAreaAndNivelAndGrado(Contenido busqueda)
        {

            string spName = "clase.sp_organizador3_lstByColegioAndAreaAndNivelAndGrado";
            var lista = new List<Contenido>();
            Contenido contenido = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", busqueda.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@area", busqueda.Area, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@nivel_id", busqueda.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@grado_id", busqueda.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            contenido = new Contenido();
                            contenido.ConocimientoId = dr.GetInt32(dr.GetOrdinal("organi_id"));
                            contenido.Conocimiento = dr.GetString(dr.GetOrdinal("organi"));
                            contenido.DetalleId = dr.GetInt32(dr.GetOrdinal("organi2_id"));
                            contenido.Detalle = dr.GetString(dr.GetOrdinal("organi2"));
                            contenido.ContenidoId = dr.GetInt32(dr.GetOrdinal("organi3_id"));
                            contenido.ContenidoDesc = dr.GetString(dr.GetOrdinal("organi3"));
                            lista.Add(contenido);
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

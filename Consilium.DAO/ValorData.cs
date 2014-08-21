using Consilium.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ValorData : BaseData
    {
        public List<ItemNodo> ListByAreaAndColegio(ClaseValor deAreaBusqueda)
        {

            string spName = "clase.sp_dearea_lst";
            var lista = new List<DeArea>();

            //varaibles auxiliares para armar objeto anidado
            int deAreaIdAnterior = 0, deAreaId = 0;
            int especificaIdAnterior = 0, especificaId = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@area", deAreaBusqueda.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", deAreaBusqueda.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));

                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();
                        DeArea deArea = null;
                        Especifica especifica = null;
                        Operativa operativa = null;

                        while (dr.Read())
                        {
                            deAreaId = dr.GetInt32(dr.GetOrdinal("dearea_id"));
                            especificaId = dr.GetInt32(dr.GetOrdinal("especifica_id"));

                            if (deAreaId != deAreaIdAnterior)
                            {
                                deArea = new DeArea();
                                deArea.DeAreaId = deAreaId;
                                deArea.Nombre = dr.GetString(dr.GetOrdinal("dearea"));
                                deArea.Especificas = new List<Especifica>();
                                lista.Add(deArea);
                                deAreaIdAnterior = deArea.DeAreaId;
                            }

                            if (especificaId != especificaIdAnterior)
                            {
                                especifica = new Especifica();
                                especifica.EspecificaId = especificaId;
                                especifica.Nombre = dr.GetString(dr.GetOrdinal("especifica"));
                                especifica.Operativas = new List<Operativa>();
                                deArea.Especificas.Add(especifica);
                                especificaIdAnterior = especifica.EspecificaId;

                            }
                            operativa = new Operativa();
                            operativa.OperativaId = dr.GetInt32(dr.GetOrdinal("operativa_id"));
                            operativa.Nombre = dr.GetString(dr.GetOrdinal("operativa"));
                            especifica.Operativas.Add(operativa);
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

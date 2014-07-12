using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Data.SqlClient;
using Consilium.Entity;

using System.Configuration;
namespace Consilium.DAO
{
	public class ColegioDAO
	{

		private SqlParameter ObjSqlParameter(string pParameterName, object pValue, System.Data.ParameterDirection pDirection, DbType pDbType)
		{

			SqlParameter lSqlParameter = new SqlParameter();
			lSqlParameter.ParameterName = pParameterName;
			lSqlParameter.Value = pValue;
			lSqlParameter.Direction = pDirection;
			lSqlParameter.DbType = pDbType;
			return lSqlParameter;

		}

		public int _insertar_colegio(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_colegio_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@colegio_nombre", AreaEntity.colegio_nombre, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_dirección", AreaEntity.colegio_dirección, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_telefono", AreaEntity.colegio_telefono, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
					command.CommandType = CommandType.StoredProcedure;
					conn.Open();
					command.ExecuteNonQuery();
					retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
					return retVal;

				} catch (Exception ex) {
					throw ex;
				} finally {
					conn.Close();
				}

			}

		}

		public DataTable _listar_colegio()
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_colegio_listar";
				DataTable retVal = new DataTable();

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.CommandType = CommandType.StoredProcedure;
					conn.Open();
					IDataReader dr = command.ExecuteReader();
					retVal.Load(dr);
					return retVal;

				} catch (Exception ex) {
					throw ex;
				} finally {
					conn.Close();
				}

			}

		}

		public int _update_colegio(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_colegio_update";
				int retVal = 0;


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@colegio_nombre", AreaEntity.colegio_nombre, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_dirección", AreaEntity.colegio_dirección, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_telefono", AreaEntity.colegio_telefono, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					conn.Open();
					retVal = command.ExecuteNonQuery();
					return retVal;

				} catch (Exception ex) {
					throw ex;
				} finally {
					conn.Close();
				}

			}

		}


	}
}

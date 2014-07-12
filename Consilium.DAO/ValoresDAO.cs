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

	public class ValoresDAO
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

		public DataTable _lst_valores(AreaEntity AreaEntity)
		{

			string spName = "sp_valores_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.CommandType = CommandType.StoredProcedure;
					conn.Open();

					IDataReader dr = command.ExecuteReader();
					dt.Load(dr);
					return dt;

				} catch (Exception ex) {
					throw ex;
				} finally {
					conn.Close();
				}

			}

		}

		public DataTable _lst_actitud(AreaEntity AreaEntity)
		{

			string spName = "sp_actitud_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@valores_id", AreaEntity.valores_id, ParameterDirection.Input, System.Data.DbType.Int32));

					command.CommandType = CommandType.StoredProcedure;
					conn.Open();

					IDataReader dr = command.ExecuteReader();
					dt.Load(dr);
					return dt;

				} catch (Exception ex) {
					throw ex;
				} finally {
					conn.Close();
				}

			}

		}

		public DataTable _lst_valores_all(AreaEntity AreaEntity)
		{

			string spName = "sp_valores_all_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.CommandType = CommandType.StoredProcedure;
					conn.Open();
					IDataReader dr = command.ExecuteReader();
					dt.Load(dr);
					return dt;
				} catch (Exception ex) {
					throw ex;
				} finally {
					conn.Close();
				}

			}

		}

		public int _insertar_valores(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_valores_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@valores", AreaEntity.valores, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_valores(ArrayList delreg)
		{

			string spName = "sp_valores_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@valores_id", AreaEntity.valores_id, ParameterDirection.Input, System.Data.DbType.Int32));
						command.CommandType = CommandType.StoredProcedure;
						conn.Open();
						retVal = command.ExecuteNonQuery();

					} catch (Exception ex) {
						throw ex;
					} finally {
						conn.Close();
					}

				}
			}

			return retVal;

		}

		public int _update_valores(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_valores_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@valores", AreaEntity.valores, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@valores_id", AreaEntity.valores_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.CommandType = CommandType.StoredProcedure;
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






		public int _insertar_actitud(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_actitud_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actitud", AreaEntity.actitud, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@valores_id", AreaEntity.valores_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_actitud(ArrayList delreg)
		{

			string spName = "sp_actitud_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@actitud_id", AreaEntity.actitud_id, ParameterDirection.Input, System.Data.DbType.Int32));
						command.CommandType = CommandType.StoredProcedure;
						conn.Open();
						retVal = command.ExecuteNonQuery();

					} catch (Exception ex) {
						throw ex;
					} finally {
						conn.Close();
					}

				}
			}

			return retVal;

		}

		public int _update_actitud(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_actitud_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actitud", AreaEntity.actitud, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actitud_id", AreaEntity.actitud_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.CommandType = CommandType.StoredProcedure;
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

		public int _delete_clase_valor(ArrayList delreg)
		{

			string spName = "sp_delete_clase_valores";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@clase_valores_id", AreaEntity.id_unico, ParameterDirection.Input, System.Data.DbType.Int32));
						//command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32))
						command.CommandType = CommandType.StoredProcedure;
						conn.Open();
						retVal = command.ExecuteNonQuery();

					} catch (Exception ex) {
						throw ex;
					} finally {
						conn.Close();
					}

				}
			}

			return retVal;

		}

	}
}

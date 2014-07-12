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

	public class MetodosDAO
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

		public DataTable _lst_criterio(AreaEntity AreaEntity)
		{

			string spName = "sp_criterio_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_metecnica(AreaEntity AreaEntity)
		{

			string spName = "sp_metecnica_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@criterio_id", AreaEntity.criterio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_metodos(AreaEntity AreaEntity)
		{

			string spName = "sp_metodos_lst";
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

		public int _insertar_criterio(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_criterio_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@criterio", AreaEntity.criterio, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_criterio(ArrayList delreg)
		{

			string spName = "sp_criterio_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@criterio_id", AreaEntity.criterio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_criterio(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_criterio_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@criterio", AreaEntity.criterio, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@criterio_id", AreaEntity.criterio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _insertar_metecnica(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_metecnica_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@metecnica", AreaEntity.metecnica, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@criterio_id", AreaEntity.criterio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_metecnica(ArrayList delreg)
		{

			string spName = "sp_metecnica_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@metecnica_id", AreaEntity.metecnica_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_metecnica(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_metecnica_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@metecnica", AreaEntity.metecnica, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@metecnica_id", AreaEntity.metecnica_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_clase_metodo(ArrayList delreg)
		{

			string spName = "sp_delete_clase_metodo";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@clase_metodo_id", AreaEntity.id_unico, ParameterDirection.Input, System.Data.DbType.Int32));
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

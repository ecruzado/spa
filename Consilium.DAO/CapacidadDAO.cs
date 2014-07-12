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

	public class CapacidadDAO
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

		public DataTable _lst_dearea(AreaEntity AreaEntity)
		{

			string spName = "sp_dearea_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_especifica(AreaEntity AreaEntity)
		{

			string spName = "sp_especifica_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@dearea_id", AreaEntity.dearead_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_operativa(AreaEntity AreaEntity)
		{

			string spName = "sp_operativa_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@especifica_id", AreaEntity.especifica_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_capacidad(AreaEntity AreaEntity)
		{

			string spName = "sp_capacidad_lst";
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

		public int _insertar_dearea(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_dearea_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@dearea", AreaEntity.dearea, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@area", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _insertar_especifica(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_especifica_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@especifica", AreaEntity.especifica, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@dearea_id", AreaEntity.dearead_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _insertar_operativa(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_operativa_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@operativa", AreaEntity.operativa, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@especifica_id", AreaEntity.especifica_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_dearea(ArrayList delreg)
		{

			string spName = "sp_dearea_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@dearea_id", AreaEntity.dearead_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_dearea(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_dearea_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@dearea", AreaEntity.dearea, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@dearea_id", AreaEntity.dearead_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area", AreaEntity.area, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_especifica(ArrayList delreg)
		{

			string spName = "sp_especifica_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@especifica_id", AreaEntity.especifica_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_especifica(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_especifica_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@especifica", AreaEntity.especifica, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@dearea_id", AreaEntity.dearead_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@especifica_id", AreaEntity.especifica_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_operativa(ArrayList delreg)
		{

			string spName = "sp_operativa_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@operativa_id", AreaEntity.operativa_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_operativa(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_operativa_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@operativa", AreaEntity.operativa, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@especifica_id", AreaEntity.especifica_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@operativa_id", AreaEntity.operativa_id, ParameterDirection.Input, System.Data.DbType.Int32));
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


		public int _delete_clase_capa(ArrayList delreg)
		{

			string spName = "sp_delete_clase_capacidad";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@clase_capacidad_id", AreaEntity.id_unico, ParameterDirection.Input, System.Data.DbType.Int32));
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

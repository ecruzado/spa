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

	public class ContenidoDAO
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

		public DataTable _lst_organizador(AreaEntity AreaEntity)
		{

			string spName = "sp_organizador_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_organizador2(AreaEntity AreaEntity)
		{

			string spName = "sp_organizador2_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@organi_id", AreaEntity.Organizador_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", AreaEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", AreaEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));

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

		public DataTable _lst_organizador3(AreaEntity AreaEntity)
		{

			string spName = "sp_organizador3_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@organi2_id", AreaEntity.Organizador2_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_contenido(AreaEntity AreaEntity)
		{

			string spName = "sp_contenido_lst";
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

		public int _insertar_conocimiento(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_organizador_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi", AreaEntity.Organizador, ParameterDirection.Input, System.Data.DbType.String));
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

		public int _insertar_detalle(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_organizador2_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi2", AreaEntity.Organizador2, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@organi_id", AreaEntity.Organizador_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", AreaEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", AreaEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _insertar_contenido(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_organizador3_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi3", AreaEntity.Organizador3, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@organi2_id", AreaEntity.Organizador2_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_conocimiento(ArrayList delreg)
		{

			string spName = "sp_organizador_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@organi_id", AreaEntity.Organizador_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_detalle(ArrayList delreg)
		{

			string spName = "sp_organizador2_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@organi2_id", AreaEntity.Organizador2_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_contenido(ArrayList delreg)
		{

			string spName = "sp_organizador3_delete";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@organi3_id", AreaEntity.Organizador3_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_conocimiento(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_organizador_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi", AreaEntity.Organizador, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@organi_id", AreaEntity.Organizador_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_detalle(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_organizador2_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi2", AreaEntity.Organizador2, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@organi2_id", AreaEntity.Organizador2_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _update_contenido(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_organizador3_update";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi3", AreaEntity.Organizador3, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@organi3_id", AreaEntity.Organizador3_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_clase_conte(ArrayList delreg)
		{

			string spName = "sp_delete_clase_contenido";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@clase_cono_id", AreaEntity.id_unico, ParameterDirection.Input, System.Data.DbType.Int32));
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

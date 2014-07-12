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

	public class UsuarioDAO
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

		public DataTable _logeo_usuario(UsuarioEntity UsuarioEntity)
		{
			//validar usuario de acceso

			string spName = "sp_usuario_logeo";
			DataTable retVal = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@usuario", UsuarioEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@pass", UsuarioEntity.pass, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _logeo_usuario_conectado(UsuarioEntity UsuarioEntity)
		{
			//validar usuario de acceso

			string spName = "sp_usuario_acceso";
			DataTable retVal = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@usuario", UsuarioEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _listar_usuario(int colegio_id)
		{
			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_usuario_listar";
				DataTable retVal = new DataTable();

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@colegio_id", colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _listar_usuario_colegio(UsuarioEntity UsuarioEntity)
		{
			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_usuario_colegio_listar";
				DataTable retVal = new DataTable();

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@colegio_id", UsuarioEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));

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

		public int _insertar_usuario(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_usuario_insert";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@usuario", AreaEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@nombres", AreaEntity.nombres, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@apematerno", AreaEntity.apematerno, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@apepaterno", AreaEntity.apepaterno, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@pass", AreaEntity.pass, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@correo", AreaEntity.correo, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@estado", AreaEntity.estado, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@diseno", AreaEntity.diseno, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@historia", AreaEntity.historia, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@reporte", AreaEntity.reporte, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@mantenimiento", AreaEntity.mantenimiento, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@administrador", AreaEntity.administrador, ParameterDirection.Input, System.Data.DbType.Boolean));
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

		public int _update_usuario(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_usuario_update_datos";
				int retVal = 0;


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@usuario", AreaEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@nombres", AreaEntity.nombres, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@apematerno", AreaEntity.apematerno, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@apepaterno", AreaEntity.apepaterno, ParameterDirection.Input, System.Data.DbType.String));
					//command.Parameters.Add(ObjSqlParameter("@pass", AreaEntity., ParameterDirection.Input, System.Data.DbType.String))
					command.Parameters.Add(ObjSqlParameter("@correo", AreaEntity.correo, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@estado", AreaEntity.estado, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@diseno", AreaEntity.diseno, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@historia", AreaEntity.historia, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@reporte", AreaEntity.reporte, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@mantenimiento", AreaEntity.mantenimiento, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@administrador", AreaEntity.administrador, ParameterDirection.Input, System.Data.DbType.Boolean));
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

		public int _update_usuario_pass(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_usuario_update_clave";
				int retVal = 0;


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@usuario_id", AreaEntity.usuario_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@pass", AreaEntity.pass, ParameterDirection.Input, System.Data.DbType.String));
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

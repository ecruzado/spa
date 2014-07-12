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
	public class ReportesDAO
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

		public DataTable _reporte_capacidad(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_capacidad";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _reporte_contenido(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_contenido";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _reporte_metodos(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_metodos";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _reporte_valores(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_valores";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _reporte_indicadores(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_logro";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _reporte_tipo_conocimiento(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_tipo_conocimiento";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _reporte_prueba(AreaEntity AreaEntity)
		{

			string spName = "sp_reporte_prueba";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", AreaEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", AreaEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

	}
}

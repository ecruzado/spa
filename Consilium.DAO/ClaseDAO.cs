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

	public class ClaseDAO
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

		public int crear_clase(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_crear_clase";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.Add(ObjSqlParameter("@clase_titulo", ClaseEntity.clase_titulo, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_reg", DateTime.Now.ToString(), ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@formato", ClaseEntity.formato, ParameterDirection.Input, System.Data.DbType.String));
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

		public int crear_capacidad_clase(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_crear_capacidad_clase";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@operativa_id", AreaEntity.operativa_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int crear_contenido_clase(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_crear_contenido_clase";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@organi3_id", AreaEntity.Organizador3_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int crear_valores_clase(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_crear_valores_clase";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actitud_id", AreaEntity.actitud_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int crear_metodo_clase(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_crear_metodo_clase";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@metecnica_id", AreaEntity.metecnica_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int crear_item_registro_reactivo_clase(AreaEntity AreaEntity)
		{

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				string spName = "sp_crear_item_registro_reactivo_clase";
				int retVal = 0;

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@item_reg_act_id", AreaEntity.item_registro_reactivo_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int crear_matriz(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_matriz_clase";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@formativa", ClaseEntity.formativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@sumativa", ClaseEntity.sumativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@autoevaluativa", ClaseEntity.autoevaluativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@coevaluativa", ClaseEntity.coevaluativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@heteroevaluacion", ClaseEntity.heteroevaluacion, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@censal", ClaseEntity.censal, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@muestral", ClaseEntity.muestral, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@indicador_logro", ClaseEntity.indicador_logro, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@pruebatxt", ClaseEntity.pruebatxt, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@obsclase", ClaseEntity.obsclase, ParameterDirection.Input, System.Data.DbType.String));
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

		public int crear_actividades_clase(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_crear_actividades_clase";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actividades", ClaseEntity.actividad, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades_hora", ClaseEntity.actividad_hora, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades1", ClaseEntity.actividad1, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades_hora1", ClaseEntity.actividad_hora1, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades2", ClaseEntity.actividad2, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades_hora2", ClaseEntity.actividad_hora2, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int _delete_item_registro_reactivo_clase(ArrayList delreg)
		{

			string spName = "sp_delete_clase_item_registro_reactivo";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@clase_item_reg_act_id", AreaEntity.id_unico, ParameterDirection.Input, System.Data.DbType.Int32));
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


		public DataTable _lst_clase(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_lst";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));

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


		public int _delete_clase(ArrayList delreg)
		{

			string spName = "sp_delete_clase";
			int retVal = 0;


			foreach (AreaEntity AreaEntity in delreg) {
				using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

					try {
						SqlCommand command = new SqlCommand(spName, conn);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(ObjSqlParameter("@clase_id", AreaEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_clase_mod(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_mod";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int modificar_actividades_clase1(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_update_actividades_clase1";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actividades1", ClaseEntity.actividad1, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades_hora1", ClaseEntity.actividad_hora1, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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


		public int modificar_actividades_clase(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_update_actividades_clase";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actividades", ClaseEntity.actividad, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades_hora", ClaseEntity.actividad_hora, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int modificar_actividades_clase2(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_update_actividades_clase2";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@actividades2", ClaseEntity.actividad2, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@actividades_hora2", ClaseEntity.actividad_hora2, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int modificar_matriz_clase(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "sp_update_matriz_clase";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@formativa", ClaseEntity.formativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@sumativa", ClaseEntity.sumativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@autoevaluativa", ClaseEntity.autoevaluativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@coevaluativa", ClaseEntity.coevaluativa, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@heteroevaluacion", ClaseEntity.heteroevaluacion, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@censal", ClaseEntity.censal, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@muestral", ClaseEntity.muestral, ParameterDirection.Input, System.Data.DbType.Boolean));
					command.Parameters.Add(ObjSqlParameter("@indicador_logro", ClaseEntity.indicador_logro, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@pruebatxt", ClaseEntity.pruebatxt, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@obsclase", ClaseEntity.obsclase, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public int modificar_clase(AreaEntity ClaseEntity)
		{

			//validar usuario de acceso

			string spName = "proc_modificar_clase";
			int retVal = 0;


			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {

				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.Add(ObjSqlParameter("@clase_titulo", ClaseEntity.clase_titulo, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
					command.Parameters.Add(ObjSqlParameter("@clase_id", ClaseEntity.clase_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_clase_nivel_grado(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_nivel_grado";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_clase_area(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_area";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_clase_fecha(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_fecha";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
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

		public DataTable _lst_clase_usuario(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_usuario";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _lst_clase_nivel_area(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_nivel_area";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable _lst_clase_nivel_usuario(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_nivel_usuario";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _lst_clase_nivel_area_fecha(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_nivel_area_fecha";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
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

		public DataTable _lst_clase_nivel_fecha(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_nivel_fecha";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
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

		public DataTable _lst_clase_nivel_fecha_usuario(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_nivel_fecha_usuario";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", ClaseEntity.nivel_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", ClaseEntity.grado_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _lst_clase_area_fecha_usuario(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_area_fecha_usuario";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _lst_clase_area_fecha(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_area_fecha";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
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

		public DataTable _lst_clase_area_usuario(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_area_usuario";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@area_id", ClaseEntity.area_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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

		public DataTable _lst_clase_fecha_usuario(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_fecha_usuario";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@fecha_inicio", ClaseEntity.fecha_inicio, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@fecha_fin", ClaseEntity.fecha_fin, ParameterDirection.Input, System.Data.DbType.Date));
					command.Parameters.Add(ObjSqlParameter("@usuario", ClaseEntity.usuario, ParameterDirection.Input, System.Data.DbType.String));
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


		public DataTable _lst_clase_null(AreaEntity ClaseEntity)
		{

			string spName = "sp_clase_filtro_null";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(ObjSqlParameter("@colegio_id", ClaseEntity.colegio_id, ParameterDirection.Input, System.Data.DbType.Int32));
					conn.Open();
					command.CommandType = CommandType.StoredProcedure;
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

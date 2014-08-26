using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class ReporteData:BaseData
    {
		public DataTable ReporteCapacidad(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_capacidad";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable ReporteContendio(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_contenido";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable ReporteMetodos(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_metodos";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable ReporteValores(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_valores";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable ReporteIndicadores(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_logro";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable ReporteTipoConocimiento(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_tipo_conocimiento";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id",colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

		public DataTable ReportePrueba(int colegioId, int areaId, int nivelId, int gradoId)
		{

			string spName = "sp_reporte_prueba";
			DataTable dt = new DataTable();

			using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString())) {


				try {
					SqlCommand command = new SqlCommand(spName, conn);
					command.Parameters.Add(ObjSqlParameter("@area_id", areaId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@colegio_id",colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@nivel_id", nivelId, ParameterDirection.Input, System.Data.DbType.Int32));
					command.Parameters.Add(ObjSqlParameter("@grado_id", gradoId, ParameterDirection.Input, System.Data.DbType.Int32));
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

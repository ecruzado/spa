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

	public class UsuarioData:BaseData
	{
        public List<Usuario> List(int colegioId)
        {

            string spName = "clase.sp_usuario_lstByColegio";
            var lista = new List<Usuario>();
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@colegio_id", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(dr.GetOrdinal("usuario_id"));
                            usuario.Codigo = dr.GetString(dr.GetOrdinal("usuario"));
                            usuario.Nombre = dr.IsDBNull(dr.GetOrdinal("nombres")) ? "" : dr.GetString(dr.GetOrdinal("nombres"));
                            usuario.ApellidoMaterno = dr.IsDBNull(dr.GetOrdinal("apematerno")) ? "" : dr.GetString(dr.GetOrdinal("apematerno"));
                            usuario.ApellidoPaterno = dr.IsDBNull(dr.GetOrdinal("apepaterno")) ? "" : dr.GetString(dr.GetOrdinal("apepaterno"));
                            usuario.Correo = dr.IsDBNull(dr.GetOrdinal("correo")) ? "" : dr.GetString(dr.GetOrdinal("correo"));
                            usuario.ColegioId = dr.IsDBNull(dr.GetOrdinal("colegio_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            usuario.Estado = dr.IsDBNull(dr.GetOrdinal("estado")) ? false : dr.GetBoolean(dr.GetOrdinal("estado"));
                            usuario.DisenoClase = dr.IsDBNull(dr.GetOrdinal("diseno")) ? false : dr.GetBoolean(dr.GetOrdinal("diseno"));
                            usuario.HistorialClase = dr.IsDBNull(dr.GetOrdinal("historia")) ? false : dr.GetBoolean(dr.GetOrdinal("historia"));
                            usuario.Reporte = dr.IsDBNull(dr.GetOrdinal("reporte")) ? false : dr.GetBoolean(dr.GetOrdinal("reporte"));
                            usuario.Mantenimiento = dr.IsDBNull(dr.GetOrdinal("mantenimiento")) ? false : dr.GetBoolean(dr.GetOrdinal("mantenimiento"));
                            usuario.Administrador = dr.IsDBNull(dr.GetOrdinal("administrador")) ? false : dr.GetBoolean(dr.GetOrdinal("administrador"));
                            usuario.Colegio = dr.IsDBNull(dr.GetOrdinal("colegio")) ? "" : dr.GetString(dr.GetOrdinal("colegio"));
                            lista.Add(usuario);
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

        public Usuario GetByUsuarioAndPassword(string nombreUsuario, string password)
        {

            string spName = "clase.sp_usuario_lstByUsuarioAndPass";
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@usuario", nombreUsuario, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@pass", password, ParameterDirection.Input, System.Data.DbType.String));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(dr.GetOrdinal("usuario_id"));
                            usuario.Codigo = dr.GetString(dr.GetOrdinal("usuario"));
                            usuario.Nombre = dr.IsDBNull(dr.GetOrdinal("nombres"))? "": dr.GetString(dr.GetOrdinal("nombres"));
                            usuario.ApellidoMaterno = dr.IsDBNull(dr.GetOrdinal("apematerno")) ? "" : dr.GetString(dr.GetOrdinal("apematerno"));
                            usuario.ApellidoPaterno = dr.IsDBNull(dr.GetOrdinal("apepaterno")) ? "" : dr.GetString(dr.GetOrdinal("apepaterno"));
                            usuario.Correo = dr.IsDBNull(dr.GetOrdinal("correo")) ? "" : dr.GetString(dr.GetOrdinal("correo"));
                            usuario.ColegioId = dr.IsDBNull(dr.GetOrdinal("colegio_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            usuario.Estado = dr.IsDBNull(dr.GetOrdinal("estado")) ? false : dr.GetBoolean(dr.GetOrdinal("estado"));
                            usuario.DisenoClase = dr.IsDBNull(dr.GetOrdinal("diseno")) ? false : dr.GetBoolean(dr.GetOrdinal("diseno"));
                            usuario.HistorialClase = dr.IsDBNull(dr.GetOrdinal("historia")) ? false : dr.GetBoolean(dr.GetOrdinal("historia"));
                            usuario.Reporte = dr.IsDBNull(dr.GetOrdinal("reporte")) ? false : dr.GetBoolean(dr.GetOrdinal("reporte"));
                            usuario.Mantenimiento = dr.IsDBNull(dr.GetOrdinal("mantenimiento")) ? false : dr.GetBoolean(dr.GetOrdinal("mantenimiento"));
                            usuario.Administrador = dr.IsDBNull(dr.GetOrdinal("administrador")) ? false : dr.GetBoolean(dr.GetOrdinal("administrador"));
                            usuario.Colegio = dr.IsDBNull(dr.GetOrdinal("colegio")) ? "" : dr.GetString(dr.GetOrdinal("colegio"));
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
            return usuario;

        }

        public Usuario GetById(int usuarioId)
        {

            string spName = "clase.sp_usuario_getByid";
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@usuario_id", usuarioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(dr.GetOrdinal("usuario_id"));
                            usuario.Codigo = dr.GetString(dr.GetOrdinal("usuario"));
                            usuario.Nombre = dr.IsDBNull(dr.GetOrdinal("nombres")) ? "" : dr.GetString(dr.GetOrdinal("nombres"));
                            usuario.ApellidoMaterno = dr.IsDBNull(dr.GetOrdinal("apematerno")) ? "" : dr.GetString(dr.GetOrdinal("apematerno"));
                            usuario.ApellidoPaterno = dr.IsDBNull(dr.GetOrdinal("apepaterno")) ? "" : dr.GetString(dr.GetOrdinal("apepaterno"));
                            usuario.Correo = dr.IsDBNull(dr.GetOrdinal("correo")) ? "" : dr.GetString(dr.GetOrdinal("correo"));
                            usuario.ColegioId = dr.IsDBNull(dr.GetOrdinal("colegio_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            usuario.Estado = dr.IsDBNull(dr.GetOrdinal("estado")) ? false : dr.GetBoolean(dr.GetOrdinal("estado"));
                            usuario.DisenoClase = dr.IsDBNull(dr.GetOrdinal("diseno")) ? false : dr.GetBoolean(dr.GetOrdinal("diseno"));
                            usuario.HistorialClase = dr.IsDBNull(dr.GetOrdinal("historia")) ? false : dr.GetBoolean(dr.GetOrdinal("historia"));
                            usuario.Reporte = dr.IsDBNull(dr.GetOrdinal("reporte")) ? false : dr.GetBoolean(dr.GetOrdinal("reporte"));
                            usuario.Mantenimiento = dr.IsDBNull(dr.GetOrdinal("mantenimiento")) ? false : dr.GetBoolean(dr.GetOrdinal("mantenimiento"));
                            usuario.Administrador = dr.IsDBNull(dr.GetOrdinal("administrador")) ? false : dr.GetBoolean(dr.GetOrdinal("administrador"));
                            usuario.Colegio = dr.IsDBNull(dr.GetOrdinal("colegio")) ? "" : dr.GetString(dr.GetOrdinal("colegio"));
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
            return usuario;

        }

        public int Insert(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_usuario_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@usuario", usuario.Codigo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@nombres", usuario.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apematerno", usuario.ApellidoMaterno, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apepaterno", usuario.ApellidoPaterno, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@pass", usuario.Password, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@correo", usuario.Correo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", usuario.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@estado", usuario.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@diseno", usuario.DisenoClase, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@historia", usuario.HistorialClase, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@reporte", usuario.Reporte, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@mantenimiento", usuario.Mantenimiento, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@administrador", usuario.Administrador, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    command.ExecuteNonQuery();
                    retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                    return retVal;

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

        }

        public int Update(Usuario usuario)
        {

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_usuario_update";
                int retVal = 0;


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@usuario_id", usuario.UsuarioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@usuario", usuario.Codigo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@nombres", usuario.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apematerno", usuario.ApellidoMaterno, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apepaterno", usuario.ApellidoPaterno, ParameterDirection.Input, System.Data.DbType.String));
                    //command.Parameters.Add(ObjSqlParameter("@pass", AreaEntity., ParameterDirection.Input, System.Data.DbType.String))
                    command.Parameters.Add(ObjSqlParameter("@correo", usuario.Correo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", usuario.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@estado", usuario.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@diseno", usuario.DisenoClase, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@historia", usuario.HistorialClase, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@reporte", usuario.Reporte, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@mantenimiento", usuario.Mantenimiento, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add(ObjSqlParameter("@administrador", usuario.Administrador, ParameterDirection.Input, System.Data.DbType.Boolean));
                    conn.Open();
                    retVal = command.ExecuteNonQuery();
                    return retVal;

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

        }


	}
}

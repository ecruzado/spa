using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Consilium.DAO
{
    public class BaseData
    {
        protected string CadenaConexion 
        {
            get {
                return System.Configuration.ConfigurationManager.ConnectionStrings["base"].ToString();
            }
        }

        protected SqlParameter ObjSqlParameter(string pParameterName, object pValue, System.Data.ParameterDirection pDirection, DbType pDbType)
        {
            SqlParameter lSqlParameter = new SqlParameter();
            lSqlParameter.ParameterName = pParameterName;
            lSqlParameter.Value = pValue;
            lSqlParameter.Direction = pDirection;
            lSqlParameter.DbType = pDbType;
            return lSqlParameter;
        }

    }
}

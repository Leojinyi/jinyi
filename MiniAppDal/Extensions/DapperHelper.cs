using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DapperExtensions;
using Dapper;
using System.Data;
namespace MiniAppDal.Extensions
{
    public static class DapperHelper
    {
        public static bool Insert<T>(T parameter, string connectionString) where T : class
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Insert(parameter);
                sqlConnection.Close();
                return true;
            }
        }

        public static async Task<object> ExecuteScalarAsync(string sqlString, string connectionString, object param = null)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var result = await sqlConnection.ExecuteScalarAsync(sqlString, param);
                sqlConnection.Close();
                return result;
            }
        }
        /// <summary>
        ///Execute SQL Statement
        /// </summary> 
        public static async Task<int> ExecSqlAsync<T>(string sql, string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    return await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception ex)
            {
                //  SystemLog.WriteError(ex);
                return 0;
            }
        }

        public static async Task<IEnumerable<T>> GetListAsync<T>(string sql, string connectionString) where T : class, new()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    return await conn.QueryAsync<T>(sql, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                //  SystemLog.WriteError(ex);
                return null;
            }
        }

    }
}

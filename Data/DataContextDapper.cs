using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TaskAPI.Data
{
    public class DataContextDapper
    {
        private readonly string connectionString;

        public DataContextDapper(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<T> LoadData<T>(string sql, DynamicParameters? parameters = null)
        {
            IDbConnection dbConnection = new SqlConnection(connectionString);
            return dbConnection.Query<T>(sql, parameters);
        }

        public T LoadDataSingle<T>(string sql, DynamicParameters? parameters = null)
        {
            IDbConnection dbConnection = new SqlConnection(connectionString);
            return dbConnection.QuerySingle<T>(sql, parameters);
        }

        public int SaveDataWithRowCount<T>(string sql, DynamicParameters? parameters = null)
        {
            IDbConnection dbConnection = new SqlConnection(connectionString);
            return dbConnection.Execute(sql, parameters);
        }

        public bool SaveData<T>(string sql, DynamicParameters? parameters = null)
        {
            IDbConnection dbConnection = new SqlConnection(connectionString);
            return dbConnection.Execute(sql, parameters) > 0;
        }
    }
}
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TaskAPI.Data
{
    public class DataContextDapper
    {
        private readonly string ConnectionString = "DefualtConnection";
        private readonly IConfiguration _config;

        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                return cnn.Query<T>(sql, parameters);
            }
        }

        public T LoadDataSingle<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                return cnn.QuerySingle<T>(sql, parameters);
            }
        }

        public int SaveDataWithRowCount<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                return cnn.Execute(sql, parameters);
            }
        }

        public bool SaveData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                return cnn.Execute(sql, parameters) > 0;
            }
        }
    }
}
using Npgsql;
using System.Data;
namespace SGP.Data
{
    public class PostgresConnection
    {
        private readonly string _connectionString;

        public PostgresConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}

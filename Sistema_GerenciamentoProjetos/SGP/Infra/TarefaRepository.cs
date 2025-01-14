using Dapper;
using SGP.Data;
using SGP.Domain.Entities;
using SGP.Domain.IRepository;

namespace SGP.Infra
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly PostgresConnection _dbConnection;

        public TarefaRepository(PostgresConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Tarefas>> GetTarefas()
        {
            var query = "SELECT * FROM Tarefas";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.QueryAsync<Tarefas>(query);
            }
        }

        public async Task<Tarefas> GetTarefaById(int Tarefa_Id)
        {
            var query = "SELECT * FROM Tarefas WHERE Tarefa_Id = @Tarefa_Id";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Tarefas>(query, new { Tarefa_Id = Tarefa_Id }) ?? throw new InvalidOperationException("Tarefa não encontrado");
            }
        }

        public async Task<int> PostTarefa(Tarefas tarefa)
        {
            var query = "INSERT INTO Tarefas (Titulo, DescricaoT, Prazo, Responsavel_Id, ProjectKey) VALUES (@Titulo, @DescricaoT, @Prazo, @Responsavel_Id, @ProjectKey)";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.ExecuteAsync(query, tarefa);
            }
        }

        public async Task<int> PutTarefa(int id, Tarefas tarefa)
        {
            var query = "UPDATE Tarefas SET Titulo = @Titulo, DescricaoT = @DescricaoT, Prazo = @Prazo, Responsavel_Id = @Responsavel_Id, ProjectKey = @ProjectKey WHERE Tarefa_Id = @Tarefa_Id";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.ExecuteAsync(query, tarefa);
            }
        }

        public async Task<int> DeleteTarefa(long Tarefa_Id)
        {
            var query = "DELETE FROM Tarefas WHERE Tarefa_Id = @Tarefa_Id";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.ExecuteAsync(query, new { Tarefa_Id = Tarefa_Id });
            }
        }
    }
}

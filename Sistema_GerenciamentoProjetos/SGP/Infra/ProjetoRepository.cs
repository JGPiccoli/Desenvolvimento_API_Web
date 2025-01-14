using Dapper;
using SGP.Data;
using SGP.Domain.Entities;
using SGP.Domain.IRepository;

namespace SGP.Infra
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly PostgresConnection _dbConnection;

        public ProjetoRepository(PostgresConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Projeto>> GetProjetos()
        {
            var query = "SELECT * FROM Projetos";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.QueryAsync<Projeto>(query);
            }
        }

        public async Task<Projeto> GetProjetoById(int Project_Id)
        {
            var query = "SELECT * FROM Projetos WHERE project_id = @project_id";
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    return await connection.QuerySingleOrDefaultAsync<Projeto>(query, new { Project_Id = Project_Id });
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Erro ao buscar o projeto com id {Project_Id}.", ex);
            }
        }

        public async Task<int> PostProjeto(Projeto projeto)
        {
            var query = @"
            INSERT INTO Projetos (NomeProj, Descricao, Entrega, id_usuario) 
            VALUES (@NomeProj, @Descricao, @Entrega, @id_usuario)
            RETURNING Project_id;";

            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query, projeto);
            }
        }

        public async Task PutProjeto(int Project_Id, Projeto projeto)
        {
            var query = "UPDATE Projetos SET NomeProj = @NomeProj, Descricao = @Descricao, Entrega = @Entrega, id_usuario = @id_usuario WHERE Project_Id = @Project_Id";

            using (var connection = _dbConnection.GetConnection())
            {
                await connection.ExecuteAsync(query, projeto);
            }
        }


        public async Task<int> DeleteProjeto(int id)
        {
            try
            {
                var query = "DELETE FROM Projetos WHERE Project_Id = @Project_Id";
                using (var connection = _dbConnection.GetConnection())
                {
                    return await connection.ExecuteAsync(query, new { Project_id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o Projeto", ex);
            }
        }
    }
}

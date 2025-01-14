using Dapper;
using SGP.Data;
using SGP.Domain.Entities;
using SGP.Domain.IRepository;

namespace SGP.Infra
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PostgresConnection _dbConnection;

        public UsuarioRepository(PostgresConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var query = "SELECT * FROM Usuarios";
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.QueryAsync<Usuario>(query);
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int user_id)
        {
            var query = "SELECT * FROM Usuarios WHERE User_Id = @User_Id";
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    return await connection.QuerySingleOrDefaultAsync<Usuario>(query, new { User_Id = user_id });
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Erro ao buscar o usuário com ID {user_id}.", ex);
            }
        }

        public async Task<int> PostUsuario(Usuario usuario)
        {
            var query = @"
            INSERT INTO Usuarios (Nome, Email, Senha, Role) 
            VALUES (@Nome, @Email, @Senha, @Role)
            RETURNING User_Id;";

            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query, usuario);
            }
        }


        public async Task PutUsuarioAsync(int id, Usuario usuario)
        {
            var query = "UPDATE Usuarios SET Nome = @Nome, Email = @Email, Role = @Role WHERE User_Id = @User_Id";

            if (!string.IsNullOrEmpty(usuario.senha))
            {
                query = "UPDATE Usuarios SET Nome = @Nome, Email = @Email, Senha = @Senha, Role = @Role WHERE User_Id = @User_Id";
            }

            using (var connection = _dbConnection.GetConnection())
            {
                await connection.ExecuteAsync(query, usuario);
            }
        }

        public async Task<int> DeleteUsuario(int id)
        {
            try
            {
                var query = "DELETE FROM Usuarios WHERE User_Id = @User_Id";

                using (var connection = _dbConnection.GetConnection())
                {
                    return await connection.ExecuteAsync(query, new { User_Id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o usuário", ex);
            }
        }

    }
}

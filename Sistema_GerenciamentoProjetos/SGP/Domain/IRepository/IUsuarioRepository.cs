using SGP.Domain.Entities;

namespace SGP.Domain.IRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarioByIdAsync(int user_id);
        Task<int> PostUsuario(Usuario usuario);
        Task PutUsuarioAsync(int id, Usuario usuario);
        Task<int> DeleteUsuario(int id);
    }
}

using SGP.Application.DTO;
using SGP.Domain.Entities;

namespace SGP.Domain.IService
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuarios();
        Task<UsuarioDTO> GetUsuarioByIdAsync(int User_Id);
        Task<UsuarioDTO> PostUsuarioAsync(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> PutUsuarioAsync(int id, UsuarioDTO usuarioDTO);
        Task DeleteUsuarioAsync(int id);
    }
}

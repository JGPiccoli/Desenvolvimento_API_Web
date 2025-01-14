using SGP.Application.DTO;
using SGP.Domain.Entities;
using SGP.Domain.IRepository;
using SGP.Domain.IService;

namespace SGP.Application.ServicesApp
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProjetoRepository _projetoRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IProjetoRepository projetoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _projetoRepository = projetoRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            var usuario = await _usuarioRepository.GetUsuarios();
            return usuario.Select(usuario => new UsuarioDTO
            {
                User_Id = usuario.User_id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role.ToString()
            });
        }

        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            return new UsuarioDTO
            {
                User_Id = usuario.User_id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role.ToString(),
            };
        }

        public async Task<UsuarioDTO> PostUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                senha = usuarioDTO.Senha,
                Role = Enum.Parse<EType>(usuarioDTO.Role, ignoreCase: true)
            };

            var userId = await _usuarioRepository.PostUsuario(usuario);

            return new UsuarioDTO
            {
                User_Id = userId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role.ToString(),
            };
        }

        public async Task<UsuarioDTO> PutUsuarioAsync(int id, UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                User_id = id,
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Role = Enum.Parse<EType>(usuarioDTO.Role, ignoreCase: true)
            };

            await _usuarioRepository.PutUsuarioAsync(id, usuario);

            return new UsuarioDTO
            {
                User_Id = usuario.User_id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role.ToString(),
            };
        }
        public async Task DeleteUsuarioAsync(int id)
        {
            var result = await _usuarioRepository.DeleteUsuario(id);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SGP.Application.DTO;
using SGP.Domain.Entities;
using SGP.Domain.IService;

namespace SGP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Usuarios")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpGet("{User_Id}")]
        public async Task<IActionResult> GetUsuario(int User_Id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(User_Id);
            return Ok(usuario);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = await _usuarioService.PostUsuarioAsync(usuarioDTO);

                return Ok(new
                {
                    Message = "Usuário criado com sucesso",
                    Usuario = usuario
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = new Usuario
                {
                    User_id = id,
                    Nome = usuarioDTO.Nome,
                    Email = usuarioDTO.Email,
                    senha = usuarioDTO.Senha,
                    Role = Enum.Parse<EType>(usuarioDTO.Role, ignoreCase: true)
                };

                await _usuarioService.PutUsuarioAsync(id, usuarioDTO);
                return Ok(new { Message = "Usuario Atualizado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
                await _usuarioService.DeleteUsuarioAsync(id);
                return Ok(new { Message = "Usuario apagado com sucesso" });
        }
    }
}

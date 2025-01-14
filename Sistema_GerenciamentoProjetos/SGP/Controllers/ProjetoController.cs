using Microsoft.AspNetCore.Mvc;
using SGP.Application.DTO;
using SGP.Domain.Entities;
using SGP.Domain.IService;

namespace SGP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet("Projetos")]
        public async Task<IActionResult> GetAllProjetos()
        {
            try
            {
                var projetos = await _projetoService.GetProjetos();
                return Ok(projetos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{Project_Id}")]
        public async Task<IActionResult> GetProjeto(int Project_Id)
        {
            try
            {
                var projeto = await _projetoService.GetProjetoByIdAsync(Project_Id);
                if (projeto == null)
                {
                    return NotFound(new { Message = "Projeto não encontrado" });
                }
                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostProjeto([FromBody] ProjetoDTO projetoDTO)
        {
            try
            {
                var projeto = await _projetoService.PostProjetoAsync(projetoDTO);
                return Ok(new
                {
                    Message = "Projeto criado com sucesso",
                    Projeto = projeto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPut("Update/{Project_Id}")]
        public async Task<IActionResult> AtualizarProjeto(int Project_Id, [FromBody] ProjetoDTO projetoDTO)
        {
            try
            {
                var projeto = new Projeto
                {
                    project_id = Project_Id,
                    NomeProj = projetoDTO.NomeProj,
                    Descricao = projetoDTO.Descricao,
                    Entrega = projetoDTO.Entrega
                };

                await _projetoService.PutProjetoAsync(Project_Id, projetoDTO);
                return Ok(new { Message = "Projeto Atualizado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            try
            {
                await _projetoService.DeleteProjetoAsync(id);
                return Ok(new { Message = "Projeto apagado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
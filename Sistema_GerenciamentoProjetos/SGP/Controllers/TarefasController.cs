using Microsoft.AspNetCore.Mvc;
using SGP.Application.DTO;
using SGP.Domain.IService;

namespace SGP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasService _tarefasService;

        public TarefasController(ITarefasService tarefasService)
        {
            _tarefasService = tarefasService;
        }

        [HttpGet("Tarefas")]
        public async Task<IActionResult> GetAllTarefas()
        {
            try
            {
                var tarefas = await _tarefasService.GetTarefas();
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefa(int id)
        {
            try
            {
                var tarefa = await _tarefasService.GetTarefaByIdAsync(id);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostTarefa([FromBody] TarefasDTO tarefasDTO)
        {
            try
            {
                var tarefa = await _tarefasService.PostTarefaAsync(tarefasDTO);
                return Ok(new
                {
                    Message = "Tarefa criada com sucesso",
                    Tarefa = tarefa
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] TarefasDTO tarefasDTO)
        {
            try
            {
                await _tarefasService.PutTarefaAsync(id, tarefasDTO);
                return Ok(new { Message = "Tarefa atualizada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            try
            {
                await _tarefasService.DeleteTarefaAsync(id);
                return Ok(new { Message = "Tarefa apagada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
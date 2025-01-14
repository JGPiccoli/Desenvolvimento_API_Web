using SGP.Application.DTO;

namespace SGP.Domain.IService
{
    public interface ITarefasService
    {
        Task<IEnumerable<TarefasDTO>> GetTarefas();
        Task<TarefasDTO> GetTarefaByIdAsync(int id);
        Task<TarefasDTO> PostTarefaAsync(TarefasDTO tarefasDTO);
        Task<TarefasDTO> PutTarefaAsync(int id, TarefasDTO tarefasDTO);
        Task DeleteTarefaAsync(int id);
    }
}

using SGP.Domain.Entities;

namespace SGP.Domain.IRepository
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefas>> GetTarefas();
        Task<Tarefas> GetTarefaById(int id);
        Task<int> PostTarefa(Tarefas tarefa);
        Task<int> PutTarefa(int id, Tarefas tarefa);
        Task<int> DeleteTarefa(long id);
    }
}

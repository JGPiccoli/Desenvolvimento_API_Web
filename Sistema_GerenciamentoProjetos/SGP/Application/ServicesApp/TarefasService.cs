using SGP.Application.DTO;
using SGP.Domain.Entities;
using SGP.Domain.IRepository;
using SGP.Domain.IService;
using SGP.Infra;

namespace SGP.Application.ServicesApp
{
    public class TarefasService : ITarefasService
    {
        private readonly ITarefaRepository _tarefasRepository;

        public TarefasService(ITarefaRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public async Task<IEnumerable<TarefasDTO>> GetTarefas()
        {
            var tarefas = await _tarefasRepository.GetTarefas();
            return tarefas.Select(tarefa => new TarefasDTO
            {
                Tarefa_Id = tarefa.Tarefa_Id,
                Titulo = tarefa.Titulo,
                DescricaoT = tarefa.DescricaoT,
                Prazo = tarefa.Prazo
            });
        }

        public async Task<TarefasDTO> GetTarefaByIdAsync(int id)
        {
            var tarefa = await _tarefasRepository.GetTarefaById(id);
            return new TarefasDTO
            {
                Tarefa_Id = tarefa.Tarefa_Id,
                Titulo = tarefa.Titulo,
                DescricaoT = tarefa.DescricaoT,
                Prazo = tarefa.Prazo
            };
        }

        public async Task<TarefasDTO> PostTarefaAsync(TarefasDTO tarefasDTO)
        {
            var tarefa = new Tarefas
            {
                Titulo = tarefasDTO.Titulo,
                DescricaoT = tarefasDTO.DescricaoT,
                Prazo = tarefasDTO.Prazo
            };

            var tarefaId = await _tarefasRepository.PostTarefa(tarefa);

            return new TarefasDTO
            {
                Tarefa_Id = tarefaId,
                Titulo = tarefa.Titulo,
                DescricaoT = tarefa.DescricaoT,
                Prazo = tarefa.Prazo
            };
        }

        public async Task<TarefasDTO> PutTarefaAsync(int id, TarefasDTO tarefasDTO)
        {
            var tarefa = new Tarefas
            {
                Tarefa_Id = id,
                Titulo = tarefasDTO.Titulo,
                DescricaoT = tarefasDTO.DescricaoT,
                Prazo = tarefasDTO.Prazo
            };

            await _tarefasRepository.PutTarefa(id, tarefa);

            return new TarefasDTO
            {
                Tarefa_Id = tarefa.Tarefa_Id,
                Titulo = tarefa.Titulo,
                DescricaoT = tarefa.DescricaoT,
                Prazo = tarefa.Prazo
            };
        }

        public async Task DeleteTarefaAsync(int id)
        {
            await _tarefasRepository.DeleteTarefa(id);
        }
    }
}

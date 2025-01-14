using SGP.Application.DTO;
using SGP.Domain.Entities;
using SGP.Domain.IRepository;
using SGP.Domain.IService;

namespace SGP.Application.ServicesApp
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<IEnumerable<ProjetoDTO>> GetProjetos()
        {
            var projetos = await _projetoRepository.GetProjetos();
            return projetos.Select(projeto => new ProjetoDTO
            {
                project_id = projeto.project_id,
                NomeProj = projeto.NomeProj,
                Descricao = projeto.Descricao,
                Entrega = projeto.Entrega
            });
        }

        public async Task<ProjetoDTO> GetProjetoByIdAsync(int project_id)
        {
            var projeto = await _projetoRepository.GetProjetoById(project_id);
            return new ProjetoDTO
            {
                project_id = projeto.project_id,
                NomeProj = projeto.NomeProj,
                Descricao = projeto.Descricao,
                Entrega = projeto.Entrega
            };
        }

        public async Task<ProjetoDTO> PostProjetoAsync(ProjetoDTO projetoDTO)
        {
            var projeto = new Projeto
            {
                NomeProj = projetoDTO.NomeProj,
                Descricao = projetoDTO.Descricao,
                Entrega = projetoDTO.Entrega
            };

            var projectId = await _projetoRepository.PostProjeto(projeto);

            return new ProjetoDTO
            {
                project_id = projectId,
                NomeProj = projeto.NomeProj,
                Descricao = projeto.Descricao,
                Entrega = projeto.Entrega
            };
        }

        public async Task<ProjetoDTO> PutProjetoAsync(int Projeto_Id, ProjetoDTO projetoDTO)
        {
            var projeto = new Projeto
            {
                project_id = Projeto_Id,
                NomeProj = projetoDTO.NomeProj,
                Descricao = projetoDTO.Descricao,
                Entrega = projetoDTO.Entrega
            };

            await _projetoRepository.PutProjeto(Projeto_Id, projeto);

            return new ProjetoDTO
            {
                project_id = projeto.project_id,
                NomeProj = projeto.NomeProj,
                Descricao = projeto.Descricao,
                Entrega = projeto.Entrega
            };
        }

        public async Task DeleteProjetoAsync(int id)
        {
            await _projetoRepository.DeleteProjeto(id);
        }
    }
}

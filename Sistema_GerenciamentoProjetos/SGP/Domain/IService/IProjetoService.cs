using SGP.Application.DTO;

namespace SGP.Domain.IService
{
    public interface IProjetoService
    {
        Task<IEnumerable<ProjetoDTO>> GetProjetos();
        Task<ProjetoDTO> GetProjetoByIdAsync(int project_Id);
        Task<ProjetoDTO> PostProjetoAsync(ProjetoDTO projetoDTO);
        Task<ProjetoDTO> PutProjetoAsync(int id, ProjetoDTO projetoDTO);
        Task DeleteProjetoAsync(int id);
    }
}

using SGP.Domain.Entities;

namespace SGP.Domain.IRepository
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> GetProjetos();
        Task<Projeto> GetProjetoById(int project_Id);
        Task<int> PostProjeto(Projeto projeto);
        Task PutProjeto(int id, Projeto projeto);
        Task<int> DeleteProjeto(int id);
    }
}

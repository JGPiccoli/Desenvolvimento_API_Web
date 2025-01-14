using SGP.Domain.Entities;

namespace SGP.Application.DTO
{
    public class ProjetoDTO
    {
        public int project_id { get; set; }
        public string NomeProj { get; set; }
        public string Descricao { get; set; }
        public DateTime Entrega { get; set; }
    }
}

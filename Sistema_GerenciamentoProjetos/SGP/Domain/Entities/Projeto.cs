namespace SGP.Domain.Entities
{
    public class Projeto
    {
        public int project_id { get; set; }
        public string NomeProj { get; set; }
        public string Descricao { get; set; }
        public DateTime Entrega { get; set; }
        public int id_usuario { get; set; }

        public Projeto () {}
        public Projeto(int id, string nomeProj, string descricao, DateTime entrega, int id_Usuario)
        {
            project_id = id;
            NomeProj = nomeProj;
            Descricao = descricao;
            Entrega = entrega;
            id_usuario = id_Usuario;
        }

        public void dataEntrega(DateTime Entrega)
        {
            var entrega = Entrega.Subtract(DateTime.Now);
            Console.WriteLine($"Data de entrega do Projeto {NomeProj} é {Entrega.Date}");
        }
    }
}

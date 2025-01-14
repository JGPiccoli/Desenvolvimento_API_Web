namespace SGP.Domain.Entities
{
    public class Tarefas
    {
        public int Tarefa_Id { get; set; }
        public string Titulo { get; set; }
        public string DescricaoT { get; set; }
        public DateTime Prazo { get; set; }
        public int ProjectKey { get; set; }


        public Tarefas () {}

        public Tarefas (int id , string titulo, string descricaoT, DateTime prazo, int projectKey)
        {
            Tarefa_Id = id;
            Titulo = titulo;
            DescricaoT = descricaoT;
            Prazo = prazo;
            ProjectKey = projectKey;
        }

        public void prazoEntrega(DateTime Prazo)
        {
            var prazo = Prazo.Subtract(DateTime.Now);
            Console.WriteLine($"Data de entrega da tarefa {Titulo} é {Prazo.Date}");
        }
    }
}

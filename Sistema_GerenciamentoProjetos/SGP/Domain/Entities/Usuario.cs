namespace SGP.Domain.Entities
{
    public class Usuario
    {
        public int User_id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string senha { get; set; }
        public EType Role { get; set; }

        public Usuario () {}

        public Usuario(int user_id, string nome, string email, string Senha, EType role)
        {
            User_id = user_id;
            Nome = nome;
            Email = email;
            senha = Senha;
            Role = role;
        }
    }

    public enum EType
    {
        Admin = 1,
        User = 2,
        Menager = 3,
    }
}

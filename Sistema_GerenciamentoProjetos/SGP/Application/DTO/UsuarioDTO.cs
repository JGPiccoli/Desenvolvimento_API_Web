﻿using SGP.Domain.Entities;

namespace SGP.Application.DTO
{
    public class UsuarioDTO
    {
        public int User_Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}

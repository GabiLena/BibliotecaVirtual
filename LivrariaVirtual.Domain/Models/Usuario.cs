using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtual.Domain.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public PerfilUsuario Perfil { get; set; } //adm ou basico
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LivrariaVirtual.Domain.Models;
using LivrariaVirtual.Domain.DAO;

namespace LivrariaVirtual.Domain.Service
{
    public class UsuarioService
    {
        public void AdicionarNovoUsuario(Usuario usuarioASerCadastrado)
        {
            UsuarioDAO.ListaDeUsuarios.Add(usuarioASerCadastrado);
        }
        public void RemoverUsuario(string nomeUsuario)
        {
            Usuario usuarioASerRemovido = AcharUsuarioPeloNome(nomeUsuario);
            UsuarioDAO.ListaDeUsuarios.Remove(usuarioASerRemovido);
        }
        public Usuario AcharUsuarioPeloNome(string nomeUsuario)
        {
            Usuario usuarios = UsuarioDAO.ListaDeUsuarios
                .Where(usuario => usuario.Nome == nomeUsuario).First();
            return usuarios;
        }
        public List<Usuario> ListarUsuarios()
        {
            return UsuarioDAO.ListaDeUsuarios.
                OrderBy(usuario => usuario.Nome)
                .ToList();
        }
        public Usuario PermitirAcesso(string emailUsuario, string senhaUsuario)
        {
            Usuario usuarioASerEncontrado = UsuarioDAO.ListaDeUsuarios
                .Where(usuario => usuario.Email == emailUsuario).First();
            if (usuarioASerEncontrado.Senha == senhaUsuario)
                return usuarioASerEncontrado;
            return null; // entender dps pq o vi que fez
        }
        public bool VerificaChaveAdministradorParaCadastro(string chaveAcesso)
        {
            string chave = "alface";
            if (chave == chaveAcesso)
                return true;
            else 
                return false;
        }

       // public Usuario VerificaSeEhPerfilBasico(Perfis perfil) 
       // {
       //     Usuario usuarioPerfil = UsuarioDAO.ListaDeUsuarios
       //         .Where(usuario => usuario.Perfil == perfil).First();
       //     return usuarioPerfil;
       // }
    }
}

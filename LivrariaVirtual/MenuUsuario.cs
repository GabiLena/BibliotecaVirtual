using LivrariaVirtual.Domain.Models;
using LivrariaVirtual.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LivrariaVirtual
{
    public class MenuUsuario 
    {
        MenuLivraria _menuLivraria = new MenuLivraria();
        UsuarioService _usuarioService = new UsuarioService();
        public Usuario Cadastro()
        {
            Usuario novoUsuario = new Usuario
            {
                Perfil = VerificaPerfil()
            };

            WriteLine("NOME: ");
            string nomeUsuario = ReadLine();

            WriteLine("E-MAIL: ");
            string emailUsuario = ReadLine();

            WriteLine("SENHA: ");
            string senhaUsuario = ReadLine();

            novoUsuario.Senha = senhaUsuario;
            novoUsuario.Email = emailUsuario;
            novoUsuario.Nome = nomeUsuario;
            _usuarioService.AdicionarNovoUsuario(novoUsuario);
            return novoUsuario;
        }
        private PerfilUsuario VerificaPerfil()
        {
            WriteLine("SEU PERFIL É DE USUARIO OU ADMINISTRADOR ? ");

            string perfilUsuario = ReadLine();
            if (perfilUsuario != "administrador")
                return PerfilUsuario.Basico;

            WriteLine("Escreva  a chave: ");

            string chave = ReadLine();
            bool chaveEhValida = _usuarioService.VerificaChaveAdministradorParaCadastro(chave);

            if (chaveEhValida)
                return PerfilUsuario.Administrador;

            return PerfilUsuario.Basico;
        }
        public void Login()
        {
            Clear();
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.Red;

            WriteLine("*** E - M A I L ***");
            string emailUsuario = ReadLine();

            WriteLine("*** S E N H A ***");
            string senhaUsuario = ReadLine();
            var usuario = VerificaSeUsuarioEhValido(emailUsuario, senhaUsuario);
            ResetColor();

            EncaminhaParaMenuConformePerfilUsuario(usuario);
        }
        private void EncaminhaParaMenuConformePerfilUsuario(Usuario usuarioPerfil)
        {
            switch (usuarioPerfil.Perfil)
            {
                case PerfilUsuario.Basico:
                    MenuUsuarioBasico.MenuUsuarioBasicoAposOLogin();
                    break;

                case PerfilUsuario.Administrador:
                    _menuLivraria.MenuDaLivraria();
                    break;
            }
        }
        public Usuario VerificaSeUsuarioEhValido(string emailUsuario, string senhaUsuario)
        {
            var usuario = _usuarioService.PermitirAcesso(emailUsuario, senhaUsuario);

            if (usuario != null)
                return usuario;
            else
                throw new Exception("USUARIO INVÁLIDO");
        }
    }
}

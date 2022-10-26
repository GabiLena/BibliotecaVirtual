using LivrariaVirtual.Domain.Models;
using LivrariaVirtual.Domain.Service;
using System;
using System.Collections.Generic;
using static System.Console;

namespace LivrariaVirtual
{
    public class MenuUsuarioBasico
    {
        public static readonly LivrariaService _livrariaService = new LivrariaService();
        public static void MenuUsuarioBasicoAposOLogin()
        {
            WriteLine("OLÁ USUARIO! O QUE DESEJA? ");
            WriteLine("A - PESQUISAR LIVROS");
            WriteLine("B - CONTINUAR MINHA LEITURA");
            string resposta = ReadLine().ToLower().Trim();

            if (resposta == "a")
            {
                PesquisarLivrosPorTitulo();
            }
            else if (resposta == "b")
            {
                //livros lidos
            }
        }
        public static void PesquisarLivrosPorTitulo()
        {
            WriteLine("ESCREVA O TITULO: ");
            string titulo = ReadLine();
            Livro livro1 = _livrariaService.ObterLivroPeloTitulo(titulo);
            WriteLine("Titulo: " + livro1.Titulo);
            WriteLine("Vulome: " + livro1.Volume);
            WriteLine("Gênero: " + livro1.Genero);
        }
    }
}
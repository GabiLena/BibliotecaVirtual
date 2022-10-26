using LivrariaVirtual.Domain.Models;
using LivrariaVirtual.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtual
{
    public class MenuLivraria
    {
        public void MenuDaLivraria()
        {
            Console.WriteLine("OLÁ ADMINISTRADOR(A) ! ");
            Console.WriteLine("O QUE DESEJA? ");
            Console.WriteLine("A - CADASTRAR LIVRO");
            Console.WriteLine("B - VISUALIZAR LIVROS");
            Console.WriteLine("C - EXCLUIR LIVRO");

            string resposta = Console.ReadLine();

            switch (resposta.ToUpper())
            {
                case "A":
                    AdicionarLivro();
                    break;
                case "B":
                    VisualizarLivrosComTodasAsPropriedades();
                    break;
                case "C":
                    RemoveLivro();
                    break;
            }
        }

        public static readonly LivrariaService _livrariaService = new LivrariaService();

        public static Livro AdicionarLivro()
        {
            string tituloLivro, autorLivro, volumeLivro;
            decimal precoLivro;
            bool foiConvertido;
            GeneroDoLivro generoLivro;
            PropriedadesParaAdicionarLivro(out tituloLivro, out autorLivro, out volumeLivro, out precoLivro, out foiConvertido, out generoLivro);
            Livro novoLivro = new Livro();

            novoLivro.Autor = autorLivro;
            novoLivro.Volume = volumeLivro;
            novoLivro.Titulo = tituloLivro;
            novoLivro.Valor = precoLivro;

            if (foiConvertido)
                novoLivro.Genero = generoLivro;
            else
                throw new Exception("GENERO DIGITADO NÃO EXISTE");

            _livrariaService.AdicionarLivro(novoLivro);
            return novoLivro;
        }
        private static void PropriedadesParaAdicionarLivro(out string tituloLivro, out string autorLivro, out string volumeLivro, out decimal precoLivro, out bool foiConvertido, out GeneroDoLivro generoLivro)
        {
            Console.WriteLine("TITULO: ");
            tituloLivro = Console.ReadLine();
            Console.WriteLine("AUTOR: ");
            autorLivro = Console.ReadLine();
            Console.WriteLine("VOLUME: ");
            volumeLivro = Console.ReadLine();
            Console.WriteLine("PREÇO: ");
            precoLivro = decimal.Parse(Console.ReadLine());
            Console.WriteLine("GENERO DO LIVRO: ");
            foiConvertido = Enum.TryParse<GeneroDoLivro>(Console.ReadLine().ToLower(), out generoLivro);
        }
        public static void RemoveLivro()
        {
            VisualizarLivroPeloTitulo();
            Console.WriteLine("Escreva o titulo do livro que deseja excluir: ");
            string titulo = Console.ReadLine();
            _livrariaService.RemoverLivro(titulo);
        }
        public static void VisualizarLivroPeloTitulo()
        {
            List<Livro> livros = _livrariaService.ListarLivros();
            foreach (Livro livro in livros)
            {
                Console.WriteLine("TITULO: " + livro.Titulo);//testar
            }
        }
        public static void VisualizarLivrosComTodasAsPropriedades()
        {
            List<Livro> lista = _livrariaService.ListarLivros();
            foreach (Livro livro in lista)
            {
                PropriedadesDoLivro(livro);
            }
        }
        private static void PropriedadesDoLivro(Livro livro)
        {
            Console.WriteLine("GENERO : " + livro.Genero);
            Console.WriteLine("TITULO : " + livro.Titulo);
            Console.WriteLine("AUTOR : " + livro.Autor);
            Console.WriteLine("VOLUME : " + livro.Volume);
            Console.WriteLine("VALOR : " + livro.Valor);
        }
    }
}

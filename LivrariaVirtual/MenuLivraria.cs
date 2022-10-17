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
                    VisualizarLivros();
                    break;
                case "C":
                    RemoveLivro();
                    break;
            }
        }

        public static readonly LivrariaService _livrariaService = new LivrariaService();

        public static Livro AdicionarLivro()
        {
            Console.WriteLine("TITULO: ");
            var tituloLivro = Console.ReadLine();
            Console.WriteLine("AUTOR: ");
            var autorLivro = Console.ReadLine();
            Console.WriteLine("VOLUME: ");
            var volumeLivro = Console.ReadLine();
            Console.WriteLine("PREÇO: ");
            decimal precoLivro = decimal.Parse(Console.ReadLine());
            Console.WriteLine("GENERO DO LIVRO: ");
            var foiConvertido = Enum.TryParse<GeneroDoLivro>(Console.ReadLine().ToLower(), out var generoLivro);
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

        public static void RemoveLivro()
        {
            Console.WriteLine("Escreva o titulo do livro que deseja excluir: ");
            string titulo = Console.ReadLine();
            _livrariaService.RemoverLivro(titulo);
        }

        public static void VisualizarLivros()
        {
            List<Livro> lista = _livrariaService.ListarLivros();
            foreach (Livro livro in lista)
            {
                Console.WriteLine("GENERO : " + livro.Genero);//checar se funciona pq metodo no service ja separa por genero.
                Console.WriteLine("TITULO : " + livro.Titulo);
                Console.WriteLine("AUTOR : " + livro.Autor);
                Console.WriteLine("VOLUME : " + livro.Volume);// depois transferir estar propriedades para um método.
                Console.WriteLine("VALOR : " + livro.Valor);
            }
        }


    }
}

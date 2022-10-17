using System;

namespace LivrariaVirtual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CadastraOuFazLoginDoUsuario();
        }

        private static void CadastraOuFazLoginDoUsuario()
        {
            MenuUsuario menuUsuario = new MenuUsuario();

            bool pediuPraSair = false;
            do
            {
                MenuEntrada("OLÁ LEITOR(A)! ");
                {
                    Console.WriteLine("O QUE DESEJA? ");
                    Console.WriteLine("A - ME CADASTRAR");
                    Console.WriteLine("B - FAZER LOGIN"); // IF LOGIN == DADOS ADM "OLA ADM"
                    Console.WriteLine("X - PARA SAIR");
                    string resposta = Console.ReadLine();


                    switch (resposta.ToUpper())
                    {
                        case "A":
                            menuUsuario.Cadastro();
                            break;
                        case "B":
                            menuUsuario.Login();
                            break;
                        default:
                            pediuPraSair = true;
                            break;
                    }
                }
            } while (!pediuPraSair);
        }

        public static void MenuEntrada(string mensagem)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("**********************************");
            Console.WriteLine($"**********{mensagem}*********");
            Console.WriteLine("**********************************");


            Console.ResetColor();

        }
    }
}
//organizar menus e loops porque is freaking fucking my mind

//cadastro adm, talvez tenha uma chave de verificação para autorizar acesso == resolvido

// adm service == em construção
//criar menu p depois do login feito, ver livro de qual genero.. == em construção

//criar menu adm, para adicionar livros e preços


//fazer um teste unitario

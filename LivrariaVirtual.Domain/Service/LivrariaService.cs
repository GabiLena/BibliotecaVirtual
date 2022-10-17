using LivrariaVirtual.Domain.DAO;
using LivrariaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaVirtual.Domain.Service
{
    public class LivrariaService
    {

        public void AdicionarLivro(Livro livroASerCadastrado)
        {
            LivrosDAO.ListaDeLivros.Add(livroASerCadastrado);
        }
        public void RemoverLivro(string titulo)
        {
            Livro livroASerRemovido = ObterLivroPeloTitulo(titulo);
            LivrosDAO.ListaDeLivros.Remove(livroASerRemovido);
        }
        public Livro ObterLivroPeloTitulo(string titulo)
        {
            Livro livro = LivrosDAO.ListaDeLivros
                .Where(l => l.Titulo == titulo).First();
            return livro;
        }
        public List<Livro> ListarLivros() 
        {
            return LivrosDAO.ListaDeLivros
                .OrderBy(l => l.Genero)
                .ThenBy(g => g.Titulo).ToList();
        }
        public List<Livro> BuscarLivroPeloGenero(GeneroDoLivro generoDoLivro) 
        {
            return LivrosDAO.ListaDeLivros
                .Where(l => l.Genero == generoDoLivro).ToList();
       
        
        } //lembrar de enternder a diferenca de metodos com retorno e void, 
    }
}

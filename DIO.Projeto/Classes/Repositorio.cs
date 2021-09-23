using System;
using System.Collections.Generic;
using DIO.Projeto.Interface;
    

namespace DIO.Projeto
{
    public class Repositorio : IRepositorio<Livro>
    {
        private List<Livro> listLivro = new List<Livro>();   

        public List<Livro> Lista()
        {
            return listLivro;
        }

        public void Inserir(Livro livro)
        {
            listLivro.Add(livro);
        }

        public void Atualizar(int id, Livro livro)
        {
            listLivro[id] = livro;
        }

        public void Excluir(int id)
        {
            listLivro[id].Excluir();
        }
              
        public int ProximoId()
        {
            return listLivro.Count;
        }

        public Livro RetornaPorId(int id)
        {
            return listLivro[id];
        }
    }
}
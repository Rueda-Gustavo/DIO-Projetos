using System;

namespace DIO.Projeto
{
    public class Livro : EntidadeBase
    {
        private Linguagem Linguagem { get; set; }
        private string Titulo { get; set; }
        private string Nivel { get; set; } //Básico ou Iniciante, Médio ou Intermediário, Avançado
        private string Descricao { get; set; }        
        private int Ano { get; set; }

        private string EstadoExc { get; set; } //Excluido ou Nao Excluido

        public Livro(int id, Linguagem linguagem, string titulo, string nivel, string descricao, int ano)
        {
            this.id = id;
            Titulo = titulo;
            Linguagem = linguagem;
            Nivel = nivel;
            Descricao = descricao;
            Ano = ano;
            EstadoExc = "Nao Excluido";
        }

        public override string ToString()
        {
            string formated = "";
            formated += "Título: " + Titulo + Environment.NewLine;
            formated += "Linguagem de estudo: " + Linguagem + Environment.NewLine;
            formated += "Nível(Básico, Médio ou Intermediário): " + Nivel + Environment.NewLine;
            formated += "Descrição do livro: " + Descricao + Environment.NewLine;
            formated += "Ano de publicação: " + Ano + Environment.NewLine;
            formated += "Status do livro: " + EstadoExc + Environment.NewLine;
            return formated;
        }
        
        public string getTitulo(){
            return Titulo;
        }

        public int getId(){
            return id;
        }

        public string getEstadoE()
        {
            return EstadoExc;
        }

        public void Excluir() {
            EstadoExc = "Excluido";
        }
    }
}
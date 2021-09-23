using System;

namespace DIO.Projeto
{
    class Program
    {
        static Repositorio repositorio = new Repositorio();
        static void Main(string[] args)
        {
            Console.WriteLine();            
            Console.WriteLine("Seja Bem-Vindo(a) a nossa biblioteca online!");
            string userOpt = UserOption();
            while (userOpt != "X")
            {
                switch (userOpt)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        ExcluirLivro();
                        break;
                    case "5":
                        VisualizarLivro();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOpt = UserOption();
            }
        }

        private static void ListarLivros()
        {
            Console.WriteLine("Listando os livros...");               
            var aux = repositorio.Lista();

            if(aux.Count == 0)
            {
                Console.WriteLine("Não há séries em nosso repositório.");
            }

            foreach(var serie in aux)
            {
                var excluido = serie.getEstadoE();
                if(excluido == "Não Excluido")
                    Console.WriteLine("ID: {0} => Título: {1}", serie.getId(), serie.getTitulo());

            }
        }

        private static void InserirLivro()
        {
            Console.WriteLine("Digite as informações para inserir o novo livro.");                      
            repositorio.Inserir(EntradaDados());
        }

        private static void AtualizarLivro()
        {
            Console.Write("Digite o id do Livro para atualiza-lo: ");
            int indice = int.Parse(Console.ReadLine());
            repositorio.Atualizar(indice, EntradaDados());            
        }

        private static void ExcluirLivro()
        {
            Console.Write("Digite o Id do Livro: ");
            Console.WriteLine("Tem certeza que deseja excluir?");
            Console.WriteLine("S/N");
            if(Console.ReadLine().ToUpper() == "S"){
                int indice = int.Parse(Console.ReadLine());
                repositorio.Excluir(indice);
            }
        }
        private static void VisualizarLivro()
        {
            Console.Write("Digite o id do Livro");
            int indice = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indice);            
            Console.WriteLine(serie);
        }

        private static string UserOption()
        {
            Console.WriteLine();            
            Console.WriteLine("Escolha uma das ações abaixo:");
            Console.WriteLine();            

            Console.WriteLine("1 - Listar livros disponíveis.");
            Console.WriteLine("2 - Inserir novo livro.");
            Console.WriteLine("3 - Atualizar livro.");
            Console.WriteLine("4 - Excluir livro.");
            Console.WriteLine("5 - Visualizar livro.");            
            Console.WriteLine("L - Limpar tela");
            Console.WriteLine("X - Sair :(");
            Console.WriteLine();            
            string opt = Console.ReadLine().ToUpper();
            Console.WriteLine();                       
            return opt;
        }

        private static Livro EntradaDados()
        {
            Console.WriteLine();
            Console.WriteLine("Qual a linguagem de programação tratada no livro?");
            foreach(int i in Enum.GetValues(typeof(Linguagem)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Linguagem), i));                
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Escolha uma Linguagem dentre as opções acima: ");
            int ling = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Livro: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Nível de dificuldade do Livro(Básico, Médio, Avançado): ");
            string niv = Console.ReadLine();
            niv = char.ToUpper(niv[0]) + niv.Substring(1);
            if(!NivCorreto(niv))
            {               
                do
                {
                    Console.Write("Digite o Nível de dificuldade do Livro(Básico, Médio, Avançado): ");
                    niv = Console.ReadLine();
                    niv = char.ToUpper(niv[0]) + niv.Substring(1);
                } while(!NivCorreto(niv));                
            }                          

            Console.Write("Digite uma Descrição para o Livro: ");
            string desc = Console.ReadLine();

            Console.Write("Digite o Ano de Publicação do Livro: ");
            int anoPub = int.Parse(Console.ReadLine());
            if(!AnoCorreto(anoPub))
            {
                do
                {
                    Console.Write("Por favor, digite um ano válido!");
                    anoPub = int.Parse(Console.ReadLine());
                }
                while(!AnoCorreto(anoPub));
            }
            
            Livro novoLivro = new Livro(id: repositorio.ProximoId(),
                                        linguagem: (Linguagem)ling,
                                        titulo: entradaTitulo,
                                        nivel: niv,
                                        descricao: desc,
                                        ano: anoPub);
            return novoLivro;            
        }

        private static bool NivCorreto(string verif)
        {
            if (verif.Length == 0){
                System.Console.WriteLine("Erro, nada digitado!!"); 
                return false;            
            }
            else 
            {
                verif = char.ToUpper(verif[0]) + verif.Substring(1);
                if(verif == "Básico" || verif == "Basico" || verif == "Médio" || verif == "Medio" || verif == "Avançado" || verif == "Avancado")
                    return true;
                
                else
                {
                    Console.WriteLine("Nível de dificuldade Inválido!!");                    
                    return false;
                }
            }            
        }

        private static bool AnoCorreto(int ano)
        {
            if(ano <= DateTime.Now.Year)
            {                
                return true;
            }
            else
            {
                Console.WriteLine("O ano digitado é inválido!!");
                return false;
            }
            
        }
    }
}

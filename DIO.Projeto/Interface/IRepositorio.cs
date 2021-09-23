using System.Collections.Generic;

namespace DIO.Projeto.Interface
{
    public interface IRepositorio<L>
    {
        List<L> Lista();        
        void Inserir(L livro);
        void Atualizar(int id, L livro);
        void Excluir(int id);        
        L RetornaPorId(int id);
        int ProximoId();            
    }
}
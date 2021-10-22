using Livraria.Domain.Entidades;
using Livraria.Domain.Query;
using System.Collections.Generic;

namespace Livraria.Domain.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        long Inserir(Livro livro);
        void Atualizar(Livro livro);
        void Excluir(long id);
        List<LivroQueryResult> Listar();
        LivroQueryResult Obter(long id);
        bool CheckId(long id);
    }
}

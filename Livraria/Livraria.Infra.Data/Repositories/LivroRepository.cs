using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Query;
using Livraria.Infra.Data.DataContexts;
using Livraria.Infra.Data.Repositories.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Livraria.Infra.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public LivroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Atualizar(Livro livro)
        {
            _parameters.Add("Id", livro.Id, DbType.Int64);
            _parameters.Add("Nome", livro.Nome, DbType.String);
            _parameters.Add("Autor", livro.Autor, DbType.String);
            _parameters.Add("Edicao", livro.Edicao, DbType.Int32);
            _parameters.Add("Isbn", livro.Isbn, DbType.String);
            _parameters.Add("Imagem", livro.Imagem, DbType.String);

            _dataContext.SqlServerConexao.Execute(LivroQueries.Atualizar, _parameters);
        }

        public bool CheckId(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            return _dataContext.SqlServerConexao.Query<bool>(LivroQueries.CheckId, _parameters).FirstOrDefault();
        }

        public void Excluir(long id)
        {
            _parameters.Add("Id", id, DbType.Int64);

            _dataContext.SqlServerConexao.Execute(LivroQueries.Excluir, _parameters);
        }

        public long Inserir(Livro livro)
        {
            _parameters.Add("Nome", livro.Nome, DbType.String);
            _parameters.Add("Autor", livro.Autor, DbType.String);
            _parameters.Add("Edicao", livro.Edicao, DbType.Int32);
            _parameters.Add("Isbn", livro.Isbn, DbType.String);
            _parameters.Add("Imagem", livro.Imagem, DbType.String);

            return _dataContext.SqlServerConexao.ExecuteScalar<long>(LivroQueries.Inserir, _parameters);
        }

        public List<LivroQueryResult> Listar()
        {
            return _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Listar).ToList();
        }

        public LivroQueryResult Obter(long id)
        {

            _parameters.Add("Id", id, DbType.Int64);

            return _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Obter, _parameters).FirstOrDefault();
        }
    }
}

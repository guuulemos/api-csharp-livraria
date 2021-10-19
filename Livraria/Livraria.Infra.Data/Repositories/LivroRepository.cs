using Dapper;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Query;
using Livraria.Infra.Data.DataContexts;
using Livraria.Infra.Data.Repositories.Queries;
using System;
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
            try
            {
                _parameters.Add("Id", livro.Id, DbType.Int64);
                _parameters.Add("Nome", livro.Nome, DbType.String);
                _parameters.Add("Autor", livro.Autor, DbType.String);
                _parameters.Add("Edicao", livro.Edicao, DbType.Int32);
                _parameters.Add("Isbn", livro.Isbn, DbType.String);
                _parameters.Add("Imagem", livro.Imagem, DbType.String);

                _dataContext.SqlServerConexao.Execute(LivroQueries.Atualizar, _parameters);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContext.SqlServerConexao.Query<bool>(LivroQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                _dataContext.SqlServerConexao.Execute(LivroQueries.Excluir, _parameters);
            } 
            catch(Exception)
            {
                throw;
            }
        }

        public long Inserir(Livro livro)
        {
            try
            {
                _parameters.Add("Nome", livro.Nome, DbType.String);
                _parameters.Add("Autor", livro.Autor, DbType.String);
                _parameters.Add("Edicao", livro.Edicao, DbType.Int32);
                _parameters.Add("Isbn", livro.Isbn, DbType.String);
                _parameters.Add("Imagem", livro.Imagem, DbType.String);

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(LivroQueries.Inserir, _parameters);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<LivroQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Listar).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LivroQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContext.SqlServerConexao.Query<LivroQueryResult>(LivroQueries.Obter, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

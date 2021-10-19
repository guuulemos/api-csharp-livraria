namespace Livraria.Infra.Data.Repositories.Queries
{
    public static class LivroQueries
    {
        public static string Inserir = @"Insert Into Livro(Nome, Autor, Edicao, Isbn, Imagem) Values (@Nome, @Autor, @Edicao, @Isbn, @Imagem);
                                         Select SCOPE_IDENTITY();";

        public static string Atualizar = @"Update Livro Set Nome=@Nome, Autor=@Autor, Edicao=@Edicao, Isbn=@Isbn, Imagem=@Imagem Where Id=@Id";

        public static string Excluir = @"Delete From Livro Where Id=@Id";

        public static string Listar = @"Select
                                            Id as Id,
                                            Nome as Nome,
                                            Autor as Autor,
                                            Edicao as Edicao,
                                            Isbn as Isbn,
                                            Imagem as Imagem
                                        From Livro
                                        Order by Nome";

        public static string Obter = @"Select
                                            Id as Id,
                                            Nome as Nome,
                                            Autor as Autor,
                                            Edicao as Edicao,
                                            Isbn as Isbn,
                                            Imagem as Imagem
                                        From Livro
                                        Where Id=@id";

        public static string CheckId = @"Select Id From Livro Where Id=@Id";
    }
}

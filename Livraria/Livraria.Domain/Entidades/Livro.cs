namespace Livraria.Domain.Entidades
{
    public class Livro
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Autor { get; private set; }
        public int Edicao { get; private set; }
        public string Isbn { get; private set; }
        public string Imagem { get; private set; }

        public Livro(long id, string nome, string autor, int edicao, string isbn, string imagem)
        {
            Id = id;
            Nome = nome;
            Autor = autor;
            Edicao = edicao;
            Isbn = isbn;
            Imagem = imagem;
        }

        /* Método para definir um Id mantendo a integridade
        public void DefinirId(long id) => Id = id; */
    }
}

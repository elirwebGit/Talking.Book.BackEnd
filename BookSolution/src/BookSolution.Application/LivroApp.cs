using BookSolution.Domain;

namespace BookSolution.Application
{
    public class LivroApp
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroApp(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<IEnumerable<LivroResponse>> GetAllBooksAsync(LivroParametro livroParametro)
        {
            return await _livroRepositorio.GetAllAsync(livroParametro);
        }

        public async Task<LivroRequest> GetBookByIdAsync(int id)
        {
            return await _livroRepositorio.GetByIdAsync(id);
        }

        public async Task AddBookAsync(LivroRequest livro)
        {
            if (livro.TipoLivro.Equals("impressao"))
            {
                if (string.IsNullOrEmpty(livro.TipoEncadernacao!.Nome))
                    throw new Exception("Favor informar o nome da encardenação");

                if (string.IsNullOrEmpty(livro.TipoEncadernacao!.DescricaoEncardenação))

                    throw new Exception("Favor informar a descrição da encardenação");

                if (string.IsNullOrEmpty(livro.TipoEncadernacao!.Formato))

                    throw new Exception("Favor informar o Formato da encardenação");

            }
            else
            {
                await _livroRepositorio.AddAsync(livro);
            }
        }

        public async Task UpdateBookAsync(LivroRequest livro)
        {
            await _livroRepositorio.UpdateAsync(livro);
        }
       
    }
}

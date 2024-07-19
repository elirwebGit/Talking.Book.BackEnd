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

        public async Task AddBookAsync(LivroRequest  livro)
        {
            await _livroRepositorio.AddAsync(livro);
        }

        public async Task UpdateBookAsync(LivroRequest livro)
        {
            await _livroRepositorio.UpdateAsync(livro);
        }
       
    }
}

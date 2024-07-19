namespace BookSolution.Domain
{
    public interface ILivroRepositorio
    {
        Task<IEnumerable<LivroResponse>> GetAllAsync(LivroParametro livroParametro);
        Task<LivroResponse> GetByIdAsync(int livroId);
        Task AddAsync(LivroRequest livro);
        Task UpdateAsync(LivroRequest livro);
       
    }
}

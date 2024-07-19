namespace BookSolution.Domain
{
    public interface ILivroRepositorio
    {
        Task<IEnumerable<LivroResponse>> GetAllAsync(LivroParametro livroParametro);
        Task<LivroRequest> GetByIdAsync(int livroId);
        Task AddAsync(LivroRequest livro);
        Task UpdateAsync(LivroRequest livro);
       
    }
}

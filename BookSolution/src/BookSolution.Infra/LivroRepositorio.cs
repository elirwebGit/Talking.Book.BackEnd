using BookSolution.Domain;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookSolution.Infra
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly string _connectionString;

        public LivroRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(LivroRequest livro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("sp_AddBook", new { livro.Titulo, livro.Autor, livro.Lancamento, livro.TipoLivro, livro.Tag.Descricao }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<LivroResponse>> GetAllAsync(LivroParametro livroParametro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<LivroResponse>("sp_GetAllBooks", new { livroParametro.Ano, livroParametro.Mes, livroParametro.AnoLancamento }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<LivroResponse> GetByIdAsync(int livroId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<LivroResponse>("sp_GetBookById", new { Id = livroId}, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAsync(LivroRequest livro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("sp_UpdateBook", new { livro.Codigo, livro.Titulo, livro.Autor, livro.Lancamento }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
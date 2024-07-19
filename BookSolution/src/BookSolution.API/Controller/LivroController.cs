using BookSolution.Application;
using BookSolution.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookSolution.API.Controller
{
       [Route("api/[controller]")]
        [ApiController]
        public class LivroController : ControllerBase
        {
            private readonly LivroApp _livroApp;

            public LivroController(LivroApp livro)
            {
                _livroApp = livro;
            }

            [HttpGet()]
            public async Task<IActionResult> GetAll([FromQuery] LivroParametro livroParameter)
            {
                var books = await _livroApp.GetAllBooksAsync(livroParameter);
                return Ok(books);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var book = await _livroApp.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] LivroRequest livro)
            {
                await _livroApp.AddBookAsync(livro);
                return CreatedAtAction(nameof(GetById), new { id = livro.Codigo }, livro);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] LivroRequest livro)
            {
                if (id != livro.Codigo)
                {
                    return BadRequest();
                }
                await _livroApp.UpdateBookAsync(livro);
                return NoContent();
            }

           
        }
    }


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Livros")] 
public class LivrosController : ControllerBase
{
    /// <summary>
    /// Lista todos os livros cadastrados no acervo da biblioteca.
    /// </summary>
    /// <remarks>
    /// Este método retorna uma lista paginada de livros.
    /// Para refinar a busca, utilize os parâmetros de consulta (query parameters).
    /// </remarks>
    /// <returns>Lista de objetos Livro.</returns>
    /// <response code="200">Retorna a lista de livros com sucesso.</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<Livro>), StatusCodes.Status200OK)]
    public IActionResult ObterTodos()
    {
        // Lógica de negócio: Buscar todos os livros do banco
        var listaDeLivros = new List<Livro>
        {
            // Simulação de dados
            new Livro { Id = 1, Titulo = "Dom Casmurro", ISBN = "123456", AutorId = 1, AnoLancamento = 1899, Disponivel = true },
            new Livro { Id = 2, Titulo = "Memórias Póstumas", ISBN = "789012", AutorId = 1, AnoLancamento = 1881, Disponivel = false }
        };
        return Ok(listaDeLivros);
    }

    /// <summary>
    /// Obtém um livro específico pelo seu identificador único (ID).
    /// </summary>
    /// <param name="id">O ID único do livro a ser consultado.</param>
    /// <returns>Os dados completos do livro.</returns>
    /// <response code="200">Livro encontrado com sucesso.</response>
    /// <response code="404">Não foi encontrado nenhum livro com o ID especificado.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ObterPorId(int id)
    {
        // Lógica de negócio: Buscar livro por ID
        var livro = new Livro { Id = id, Titulo = "Dom Casmurro", ISBN = "123456", AutorId = 1, AnoLancamento = 1899, Disponivel = true };
        
        if (id <= 0)
        {
            return NotFound("Nenhum livro encontrado com este ID.");
        }
        return Ok(livro);
    }
    /// <summary>
    /// Cadastra um novo livro no acervo da biblioteca.
    /// </summary>
    /// <param name="livro">Os dados do livro a ser cadastrado. O ISBN e Título são obrigatórios.</param>
    /// <returns>O livro recém-criado, incluindo seu ID.</returns>
    /// <response code="201">Livro criado com sucesso.</response>
    /// <response code="400">Requisição com dados de validação inválidos (ex: título vazio).</response>
    [HttpPost]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Criar([FromBody] Livro livro)
    {
        // Lógica de negócio: Salvar o livro no banco e retornar o objeto criado
        // Se a validação falhar, o ModelState falha e retorna 400
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Simulação de criação
        livro.Id = 3; 
        return CreatedAtAction(nameof(ObterPorId), new { id = livro.Id }, livro);
    }
    
    /// <summary>
    /// Atualiza parcialmente um livro existente no acervo.
    /// </summary>
    /// <param name="id">ID do livro a ser atualizado.</param>
    /// <param name="dadosAtualizacao">Os dados que devem ser modificados.</param>
    /// <returns>O livro atualizado.</returns>
    /// <response code="200">Livro atualizado com sucesso.</response>
    /// <response code="404">Livro não encontrado.</response>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Atualizar(int id, [FromBody] Livro dadosAtualizacao)
    {
        // Lógica de negócio: Atualizar os dados no banco
        var livroAtualizado = new Livro { Id = id, Titulo = dadosAtualizacao.Titulo ?? "TBD", ISBN = dadosAtualizacao.ISBN ?? "TBD", Disponivel = true };
        return Ok(livroAtualizado);
    }
}

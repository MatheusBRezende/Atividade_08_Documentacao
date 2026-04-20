using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Empréstimos")] 
public class EmprestimosController : ControllerBase
{
    /// <summary>
    /// Realiza um novo registro de empréstimo de livro, alterando o status do acervo.
    /// </summary>
    /// <remarks>
    /// O livro deve estar disponível para emprestar (status = true).
    /// O prazo de devolução padrão é de 14 dias.
    ///
    /// Exemplo de requisição:
    ///
    ///     POST /api/emprestimos
    ///     {
    ///         "livroId": 1,
    ///         "nomeUsuario": "João Silva",
    ///         "dataDevolucaoEstimada": "2026-05-01" 
    ///     }
    ///
    /// </remarks>
    /// <param name="emprestimo">Os dados para iniciar o empréstimo.</param>
    /// <returns>O registro de empréstimo criado.</returns>
    /// <response code="201">Empréstimo realizado com sucesso, e o status do livro foi alterado.</response>
    /// <response code="409">Conflito de estado (O livro já está emprestado ou o ID não existe).</response>
    [HttpPost]
    [ProducesResponseType(typeof(Emprestimo), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)] // CONFLITO!
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Emprestar([FromBody] Emprestimo emprestimo)
    {
        // Lógica de negócio: Verificar disponibilidade, registrar, e atualizar o status do livro.
        // Se o livro não estiver disponível, lança o conflito 409
        
        // Simulação de falha de negócio (Ex: Livro já emprestado)
        if (emprestimo.LivroId == 2) 
        {
            return Conflict("Este livro já está emprestado e não está disponível para novo empréstimo.");
        }
        
        // Simulação de sucesso
        return CreatedAtAction(nameof(ObterPorId), new { id = 1 }, emprestimo);
    }

    /// <summary>
    /// Registra a devolução de um livro ao acervo, atualizando seu status.
    /// </summary>
    /// <remarks>
    /// Este endpoint deve ser chamado quando o livro for devolvido.
    /// O status do livro será resetado para 'disponível'.
    /// </remarks>
    /// <param name="id">ID do empréstimo a ser devolvido.</param>
    /// <returns>Confirmação de que a devolução foi processada.</returns>
    /// <response code="200">Devolução registrada com sucesso.</response>
    /// <response code="404">Registro de empréstimo não encontrado.</response>
    [HttpPatch("{id:int}/devolver")]
    public IActionResult Devolver(int id)
    {
        // Lógica para confirmar a devolução...
        return Ok($"Livro ID {id} devolvido com sucesso!");
    }
}

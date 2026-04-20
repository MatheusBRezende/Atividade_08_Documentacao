using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Models;

/// <summary>
/// Representa um empréstimo de livro no sistema da biblioteca.
/// </summary>
public class Emprestimo
{
    /// <summary>
    /// Identificador único do empréstimo.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// Identificador único do livro emprestado.
    /// </summary>
    /// <example>1</example>
    [Required]
    public int LivroId { get; set; }

    /// <summary>
    /// Nome do usuário que realizou o empréstimo.
    /// </summary>
    /// <example>João da Silva</example>
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    [StringLength(200)]
    public string NomeUsuario { get; set; } = string.Empty;

    /// <summary>
    /// Data e hora do empréstimo.
    /// </summary>
    /// <example>2026-04-17T10:00:00Z</example>
    public DateTime DataEmprestimo { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Data e hora prevista para devolução do livro.
    /// </summary>
    /// <example>2026-05-01T10:00:00Z</example>
    public DateTime DataDevolucaoPrevista { get; set; } = DateTime.UtcNow.AddDays(14);

    /// <summary>
    /// Data e hora efetiva de devolução do livro.
    /// </summary>
    /// <example>2026-05-01T10:00:00Z</example>
    public DateTime? DataDevolucaoEfetiva { get; set; }

    /// <summary>
    /// Status do empréstimo.
    /// </summary>
    /// <example>Ativo</example>
    public StatusEmprestimo Status { get; set; } = StatusEmprestimo.Ativo;
}

/// <summary>
/// Status do empréstimo.
/// </summary>
/// <example>Ativo</example>
/// <example>Devolvido</example>
/// <example>Atrasado</example>
public enum StatusEmprestimo
{
    Ativo,
    Devolvido,
    Atrasado
}

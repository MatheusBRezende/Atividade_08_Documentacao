namespace BibliotecaApi.Models;

/// <summary>
/// Representa uma resposta paginada de uma lista de itens.
/// </summary>
public class RespostaPaginada<T>
{
    /// <summary>
    /// Itens da resposta paginada.
    /// </summary>
    /// <example>List of Livro objects</example>
    public List<T> Itens { get; set; } = new();

    /// <summary>
    /// Número da página.
    /// </summary>
    /// <example>1</example>
    public int Pagina { get; set; }

    /// <summary>
    /// Tamanho da página.
    /// </summary>
    /// <example>10</example>
    public int TamanhoPagina { get; set; }

    /// <summary>
    /// Total de itens.
    /// </summary>
    /// <example>100</example>
    public int TotalItens { get; set; }

    /// <summary>
    /// Total de páginas.
    /// </summary>
    /// <example>10</example>
    public int TotalPaginas => (int)Math.Ceiling((double)TotalItens / TamanhoPagina);
}

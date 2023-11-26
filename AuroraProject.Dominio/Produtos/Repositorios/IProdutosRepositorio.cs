namespace AuroraProject.Dominio;

public interface IProdutosRepositorio
{
    IQueryable<Produto> Buscar();
    Produto Buscar(int id);
    Task InserirAsync(Produto produto);
    Task EditarAsync(Produto produto);
    Task DeletarAsync(Produto produto);
}

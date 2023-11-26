namespace AuroraProject.Dominio;

public interface IProdutosServico
{
    Produto Validar(int id);
    Task<Produto> InserirAsync(ProdutoComando comando);
    Task<Produto> EditarAsync(int id, string titulo);
    Task<Produto> DeletarAsync(int id);
}

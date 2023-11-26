
namespace AuroraProject.Dominio;

public class ProdutosServico : IProdutosServico
{
    public IProdutosRepositorio ProdutosRepositorio;

    public ProdutosServico(IProdutosRepositorio produtosRepositorio)
    {
        ProdutosRepositorio = produtosRepositorio;
    }

    public Produto Validar(int id)
    {
        Produto produto = ProdutosRepositorio.Buscar(id);

        if (produto is null)
        {
            throw new ArgumentException($"Entidade Produto não encontrado para o id: {id}");
        }

        return produto;
    }

    public async Task<Produto> InserirAsync(ProdutoComando comando)
    {
        Produto produto = new (comando.Titulo);

        await ProdutosRepositorio.InserirAsync(produto);

        return produto;
    }

    public async Task<Produto> EditarAsync(int id, string titulo)
    {
        Produto produto = Validar(id);

        produto.SetTitulo(titulo);

        await ProdutosRepositorio.EditarAsync(produto);

        return produto;
    }

    public async Task<Produto> DeletarAsync(int id)
    {
        Produto produto = Validar(id);

        await ProdutosRepositorio.DeletarAsync(produto);

        return produto;
    }
}

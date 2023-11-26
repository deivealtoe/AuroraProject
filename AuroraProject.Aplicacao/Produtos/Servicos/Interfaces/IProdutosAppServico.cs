using AuroraProject.DataTransfer;
using AuroraProject.Dominio;

namespace AuroraProject.Aplicacao;

public interface IProdutosAppServico
{
    ProdutoResponse BuscarPorId(int id);
    Task<ProdutoResponse> InserirAsync(ProdutoRequest request);
    Task<Produto> EditarAsync(int id, Produto request);
    Task<Produto> DeletarAsync(int id);
}

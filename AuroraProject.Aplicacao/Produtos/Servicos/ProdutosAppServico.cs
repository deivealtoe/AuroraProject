using AuroraProject.DataTransfer;
using AuroraProject.Dominio;
using AutoMapper;

namespace AuroraProject.Aplicacao;

public class ProdutosAppServico : IProdutosAppServico
{
    private IUnitOfWork UnitOfWork;
    private IMapper Mapper;
    private IProdutosServico ProdutosServico;

    public ProdutosAppServico(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IProdutosServico produtosServico
    )
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        ProdutosServico = produtosServico;
    }

    public ProdutoResponse BuscarPorId(int id)
    {
        Produto produto = ProdutosServico.Validar(id);

        ProdutoResponse response = Mapper.Map<ProdutoResponse>(produto);

        return response;
    }

    public async Task<ProdutoResponse> InserirAsync(ProdutoRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            ProdutoComando comando = Mapper.Map<ProdutoComando>(request);

            Produto produto = await ProdutosServico.InserirAsync(comando);

            ProdutoResponse response = Mapper.Map<ProdutoResponse>(produto);

            UnitOfWork.Commit();

            return response;
        }
        catch
        {
            UnitOfWork.Rollback();

            throw;
        }
    }

    public Task<Produto> EditarAsync(int id, Produto request)
    {
        throw new NotImplementedException();
    }

    public Task<Produto> DeletarAsync(int id)
    {
        throw new NotImplementedException();
    }
}

using AuroraProject.DataTransfer;
using AuroraProject.Dominio;
using AutoMapper;

namespace AuroraProject.Aplicacao;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ProdutoResponse>();
        CreateMap<ProdutoRequest, ProdutoComando>();
    }
}

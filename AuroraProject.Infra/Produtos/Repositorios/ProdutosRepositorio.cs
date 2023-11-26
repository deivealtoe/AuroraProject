using AuroraProject.Dominio;
using NHibernate;

namespace AuroraProject.Infra;

public class ProdutosRepositorio : IProdutosRepositorio
{
    private readonly ISession Session;
    
    public ProdutosRepositorio(ISession session)
    {
        Session = session;
    }

    public IQueryable<Produto> Buscar()
    {
        return Session.Query<Produto>();
    }

    public Produto Buscar(int id)
    {
        return Session.Query<Produto>().Where(x => x.Id == id).FirstOrDefault();
    }

    public async Task DeletarAsync(Produto produto)
    {
        await Session.DeleteAsync(produto);
    }

    public async Task EditarAsync(Produto produto)
    {
        await Session.UpdateAsync(produto);
    }

    public async Task InserirAsync(Produto produto)
    {
        await Session.SaveAsync(produto);
    }
}

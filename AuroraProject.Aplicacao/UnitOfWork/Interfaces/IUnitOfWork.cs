namespace AuroraProject.Aplicacao;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}

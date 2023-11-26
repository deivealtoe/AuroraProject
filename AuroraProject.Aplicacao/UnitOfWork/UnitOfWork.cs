using NHibernate;

namespace AuroraProject.Aplicacao;

public class UnitOfWork : IUnitOfWork
{
    private ISession Session;
    private ITransaction Transaction;

    public UnitOfWork(ISession session)
    {
        Session = session;

        Transaction = Session.BeginTransaction();
    }

    public void BeginTransaction()
    {
        if (Transaction == null)
        {
            Transaction = Session.BeginTransaction();
        }
    }

    public void Commit()
    {
        if (!Transaction.IsActive)
        {
            throw new InvalidOperationException("Transação não está ativa");
        }

        Transaction.Commit();
    }

    public void Rollback()
    {
        if (Transaction.IsActive)
        {
            Transaction.Rollback();
        }
    }
}

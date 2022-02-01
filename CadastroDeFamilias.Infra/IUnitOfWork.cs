using System;

namespace CadastroDeFamilias.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>() where TRepo : class;

        int SaveChanges();

        void StartTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}

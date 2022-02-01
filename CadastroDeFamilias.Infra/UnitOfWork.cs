using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Security.Claims;

namespace CadastroDeFamilias.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext Context { get; set; }

        private ClaimsPrincipal ClaimPrincipal { get; set; }

        private IDbContextTransaction Transaction { get; set; }

        public UnitOfWork(DbContext context) => Context = context;

        public UnitOfWork(DbContext context, ClaimsPrincipal principal)
        {
            Context = context;
            ClaimPrincipal = principal;
        }

        public void Dispose() => Context.Dispose();

        public TRepo GetRepository<TRepo>() where TRepo : class
        {
            TRepo repo = (TRepo)Activator.CreateInstance(typeof(TRepo), Context);
            return repo;
        }

        public int SaveChanges() => Context.SaveChanges();

        public void StartTransaction() => Transaction = Context.Database.BeginTransaction();

        public void CommitTransaction() => Transaction.Commit();

        public void RollbackTransaction()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }
    }
}

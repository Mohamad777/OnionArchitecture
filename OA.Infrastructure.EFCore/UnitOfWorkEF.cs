using OA.Domain;

namespace OA.Infrastructure.EFCore
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly MasterContext _masterContext;

        public UnitOfWorkEF(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        public void BeginTran()
        {
            _masterContext.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _masterContext.SaveChanges();
            _masterContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _masterContext.Database.RollbackTransaction();
        }
    }
}

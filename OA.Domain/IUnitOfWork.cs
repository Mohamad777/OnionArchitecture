namespace OA.Domain
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void Rollback();
    }
}

namespace Core.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        public void Commit();
        public void Rollback();
    }
}

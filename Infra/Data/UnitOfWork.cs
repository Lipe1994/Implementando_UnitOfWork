using Core.Contracts.Repositories;

namespace Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Commit()
        {
            dataContext.SaveChanges();
        }

        public void Rollback()
        {
            //
        }
    }
}

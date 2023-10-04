using Microsoft.EntityFrameworkCore;
using WebMappApplication.Interfaces;
using WebMappApplication.Model;

namespace WebMappApplication.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDataContext _dbcontext;
        public UnitOfWork(EFDataContext dbcontext) {  _dbcontext = dbcontext; }
        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
           return _dbcontext.Set<TEntity>();
        }
    }
}

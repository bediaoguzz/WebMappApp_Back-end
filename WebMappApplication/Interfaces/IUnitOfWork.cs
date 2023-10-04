using Microsoft.EntityFrameworkCore;

namespace WebMappApplication.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        void Save();
    }
}

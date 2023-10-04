using WebMappApplication.Model;

namespace WebMappApplication.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T p);
        List<T> GetAll();
        T Get(int id);
        List<T> Update(T p);
        List<T> Delete(int id);
    }
}

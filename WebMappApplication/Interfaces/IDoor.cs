using WebMappApplication.Model;

namespace WebMappApplication.Interfaces
{
    public interface IDoor
    {
        Door Add(Door _door);
        List<Door> GetAll();
        Door Get(int id);
        List<Door> Update(Door newDoorValue);
        List<Door> Delete(int id);
    }
}

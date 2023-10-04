using WebMappApplication.Interfaces;
using WebMappApplication.Model;

namespace WebMappApplication.Services
{
    public class DoorService : IRepository<Door>
    {
        private readonly IRepository<Door> _DoorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DoorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        public Door Add(Door p)
        {
            throw new NotImplementedException();
        }

        public List<Door> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Door Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Door> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Door> Update(Door p)
        {
            throw new NotImplementedException();
        }
    }
}

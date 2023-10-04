
using WebMappApplication.Interfaces;
using WebMappApplication.Model;

namespace WebMappApplication.Services
{
    public class StaticService : IDoor
    {
        private static List<Door> _doorList = new List<Door>();
        public Door Add(Door _door)
        {
            Random random = new Random();
            int rnd = random.Next(1, 201);
            // !! aynı random degerleri atayabilir  

            var _newDoor = new Door()
            {
                Id = rnd,
                X = _door.X,
                Y = _door.Y
            };

            _doorList.Add(_newDoor);
            return _newDoor;
        }

        public List<Door> Delete(int id)
        {

            var deletedDoor = _doorList.Find(x => x.Id == id);

            _doorList.Remove(deletedDoor);

            return _doorList;
        }

        public Door Get(int id)
        {

            var _door = _doorList.Find(x => x.Id == id);

            return _door;
        }

        public List<Door> GetAll()
        {
            return _doorList;
        }

        public List<Door> Update(Door newDoorValue)
        {

            var updatedDoor = _doorList.Find(x => x.Id == newDoorValue.Id);

            updatedDoor.Id = newDoorValue.Id;

            if (newDoorValue.X == 0) { updatedDoor.X = updatedDoor.X; }
            else { updatedDoor.X = newDoorValue.X; }

            if (newDoorValue.Y == 0) { updatedDoor.Y = updatedDoor.Y; }
            else { updatedDoor.Y = newDoorValue.Y; }

            // !! newDoorValue degerine 0 yazmak istersem eski degerine döndürüyo
            return _doorList;
        }
    }
}

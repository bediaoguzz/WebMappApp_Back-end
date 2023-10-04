using WebMappApplication.Interfaces;
using WebMappApplication.Model;

namespace WebMappApplication.Services
{
    public class EntityService : IDoor
    {
        private EFDataContext _context;
        public EntityService(EFDataContext context)
        {
            _context = context;
        }
        public Door Add(Door _door)
        {
            Random random = new Random();
            int rnd = random.Next(1, 201);

            var _newDoor = new Door()
            {
                Id = rnd,
                X = _door.X,
                Y = _door.Y
            };
            _context.Doors.Add(_newDoor);
            _context.SaveChanges();
            return _newDoor;
        }

        public List<Door> Delete(int id)
        {
            var _door = _context.Doors.Where(d => d.Id == id).FirstOrDefault();
            _context.Doors.Remove(_door);
            _context.SaveChanges();
            return GetAll();
        }

        public Door Get(int id)
        {
           var _door = _context.Doors.Where(d => d.Id == id).FirstOrDefault();
            return _door;
        }

        public List<Door> GetAll()
        {
            List<Door> result = new List<Door>();
            var doors = _context.Doors.ToList();
            doors.ForEach(row => result.Add(new Door()
            {
                Id = row.Id,
                X = row.X,
                Y = row.Y
            }
            ));
            return result;
        }

        public List<Door> Update(Door newDoorValue)
        {
            var updatedDoor = _context.Doors.Where(d => d.Id == newDoorValue.Id).FirstOrDefault();

            if (newDoorValue.X == 0) { updatedDoor.X = updatedDoor.X; }
            else { updatedDoor.X = newDoorValue.X; }

            if (newDoorValue.Y == 0) { updatedDoor.Y = updatedDoor.Y; }
            else { updatedDoor.Y = newDoorValue.Y; }

            _context.Doors.Update(updatedDoor);
            _context.SaveChanges();

            return GetAll();
        }
    }
}

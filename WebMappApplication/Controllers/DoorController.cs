using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebMappApplication.Interfaces;
using WebMappApplication.Model;
using WebMappApplication.Services;

namespace WebMappApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IRepository<Door> _door;
        public DoorController(IRepository<Door> _repository)
        {
            _door = _repository;
        }

        // private readonly IDoor _door;
        /*public DoorController(IDoor _repository)
        {
            _door = _repository;
        }*/

        //StaticService _door = new StaticService();
        //SqlService _door = new SqlService();

        [HttpPost]
        public Door Add(Door door)
        {
            Door d = _door.Add(door);
            return d;
        }

        [HttpGet]
        public List<Door> GetAll()
        {
            return _door.GetAll();
        }

        [HttpGet("{id}")]
        public Door? Get(int id)
        {
            return _door.Get(id);
        }

        [HttpPut]
        public List<Door> Update(Door door)
        {
            return _door.Update(door);
        }

        [HttpDelete("{id}")]
        public List<Door> Delete(int id)
        {
            return _door.Delete(id);
        }
    }
}

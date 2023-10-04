using WebMappApplication.Interfaces;
using WebMappApplication.Model;
using Npgsql;

namespace WebMappApplication.Services
{
    public class SqlService : IDoor
    {
        string connectDb = "Host= localhost; Port=5432; Database=MapApplicationDb; Username=postgres; Password=12345";
        private static List<Door> _doorList = new List<Door>();
        public Door Add(Door _door)
        {
            using (var connection = new NpgsqlConnection(connectDb))
            {
                //connection.Open();
                Random random = new Random();
                _door.Id = random.Next(1, 201);

                using (var query = new NpgsqlCommand("INSERT INTO public.door (id,x,y) VALUES (@id,@x,@y)", connection))
                {
                    query.Parameters.AddWithValue("@id", _door.Id);
                    query.Parameters.AddWithValue("@x", _door.X);
                    query.Parameters.AddWithValue("@y", _door.Y);

                    connection.Open();
                    query.ExecuteNonQuery();
                }
                connection.CloseAsync();
            }
            return _door;
        }

        public List<Door> Delete(int id)
        {
            _doorList.RemoveAll(door => door.Id == id);

            using (NpgsqlConnection connection = new NpgsqlConnection(connectDb))
            {
                connection.Open();

                string query = "DELETE FROM public.door WHERE id = @id";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return _doorList;
        }

        public Door Get(int id)
        {
            var door = _doorList.FirstOrDefault(door => door.Id == id);

            using (var connection = new NpgsqlConnection(connectDb))
            {
                connection.Open();

                using (var query = new NpgsqlCommand("SELECT * FROM public.door WHERE id = @id", connection))
                {
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            door = new Door
                            {
                                Id = (int)reader["id"],
                                X = (double)reader["x"],
                                Y = (double)reader["y"],
                            };
                            _doorList.Add(door);
                        }
                    }
                }
            }
            return door;
        }

        public List<Door> GetAll()
        {
            using (var connection = new NpgsqlConnection(connectDb))
            {
                connection.Open();

                using (var query = new NpgsqlCommand("SELECT * FROM public.door", connection))
                {
                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var door = new Door
                            {
                                Id = (int)reader["id"],
                                X = (double)reader["x"],
                                Y = (double)reader["y"],
                            };
                            _doorList.Add(door);
                        }
                    }
                }
            }
            return _doorList;
        }

        public List<Door> Update(Door newDoorValue)
        {
            var updatedDoor = _doorList.Find(x => x.Id == newDoorValue.Id);


            using (NpgsqlConnection connection = new NpgsqlConnection(connectDb))
            {
                connection.Open();

                string query = "UPDATE public.door SET x = @x, y = @y WHERE id = @id";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", newDoorValue.Id);

                    if (newDoorValue.X != 0)
                    { 
                        //swaggerda da yaptığım işlemleri görebilmek için
                       //updatedDoor.X = newDoorValue.X;
                        command.Parameters.AddWithValue("@x", newDoorValue.X);

                    }


                    if (newDoorValue.Y != 0)
                    {
                         //swaggerda da yaptığım işlemleri görebilmek için
                        //updatedDoor.Y = newDoorValue.Y;
                        command.Parameters.AddWithValue("@y", newDoorValue.Y);
                    }

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }


            return _doorList;
        }
    }
}

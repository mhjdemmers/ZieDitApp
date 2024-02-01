using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
    internal class RoomRepository : BaseRepository<Room>
    {
        public Room GetById(int id)
        {
            try
            {
                return connection.Table<Room>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<Room> GetAllRooms()
        {
            try
            {
                return connection.Table<Room>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }


        public void AddRoom(Room room)
        {
            try
            {
                SaveEntity(room);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeleteRoom(Room room)
        {
            try
            {
                DeleteEntity(room);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}

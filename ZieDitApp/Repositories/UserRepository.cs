using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public User GetUserByUsername(string username)
        {
            try
            {
                return connection.Table<User>().FirstOrDefault(x => x.Name == username);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Username and password cannot be empty");

            var existingUser = GetUserByUsername(user.Name);
            if (existingUser != null)
                throw new Exception("User already exists");

            SaveEntity(user);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                return connection.Table<User>().FirstOrDefault(x => x.Name == username && x.Password == password);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
    }
}

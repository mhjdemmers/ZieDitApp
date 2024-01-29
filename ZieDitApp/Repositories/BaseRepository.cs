using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Extensions;
using ZieDitApp.Abstractions;
using ZieDitApp.Model;

namespace ZieDitApp.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        protected SQLiteConnection connection;
        public string? StatusMessage { get; set; }

        public BaseRepository()
        {
            connection = new SQLiteConnection(
                Constants.DatabasePath,
                Constants.flags);
            connection.CreateTable<T>();
        }
        public void SaveEntity(T? entity)
        {
            int result = 0;
            try
            {
                if (entity.Id != 0)
                {
                    result = connection.Update(entity);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(entity);
                    StatusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
        public T? GetEntity(int id)
        {
            try
            {
                return connection.Table<T>().FirstOrDefault(x => x.Id == id);
                //return connection.Query<Student>("SELECT * FROM Students").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetEntities()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;

            throw new NotImplementedException();
        }

        public void DeleteEntity(T? entity)
        {
            try
            {
                if (entity != null)
                    connection.Delete(entity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }


        public void Dispose()
        {
            connection.Dispose();

        }

        public void DeleteEntitiy(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveEntityWithChildren(T entity, bool recursive = false)
        {
            connection.InsertWithChildren(entity, recursive);
        }

        public void DeleteEntityWithChildren(T entity)
        {
            try
            {
                connection.Delete(entity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<T>? GetEntitiesWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        internal void SaveEntityWithChildren(User? currentUser)
        {
            throw new NotImplementedException();
        }

        internal void DeleteEntityWithChildren(User? currentUser)
        {
            throw new NotImplementedException();
        }
    }
}

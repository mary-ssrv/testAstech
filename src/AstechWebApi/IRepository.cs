using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstechWebApi
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Метод для получения списка пользоваталей
        /// </summary>
        public List<User> GetUser();

        /// <summary>
        /// Метод для получения списка типов пользоваталей
        /// </summary>
        public List<UserType> GetUserType();

        /// <summary>
        /// Метод для обновления данных пользователя
        /// </summary>
        public void UpdateUser(User entity);

        /// <summary>
        /// Метод для добавления пользователя
        /// </summary>
        public int AddUser(User entity);

        /// <summary>
        /// Метод для удаления пользователя
        /// </summary>
        public int DeleteUser(int id);
    }
}

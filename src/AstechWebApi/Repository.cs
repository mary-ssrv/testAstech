using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AstechWebApi
{
    /// <summary>
    /// Репозиторий для пользователей и типов пользователей
    /// </summary>
    public class Repository: IRepository
    {
        private List<User> users = new List<User>();
        private List<UserType> userTypes = new List<UserType>();

        /// <summary>
        /// Метод для получения списка пользоваталей
        /// </summary>
        /// <returns>список пользоваталей</returns>
        public List<User> GetUser()
        {
            using (StreamReader reader = new StreamReader("Users.json"))
            {
                string jsonString = reader.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            }
            return users;
        }

        /// <summary>
        /// Метод для получения списка типов пользоваталей
        /// </summary>
        /// <returns>список типов пользователей</returns>
        public List<UserType> GetUserType()
        {
            using (StreamReader reader = new StreamReader("UserTypes.json"))
            {
                string jsonString = reader.ReadToEnd();
                userTypes = JsonConvert.DeserializeObject<List<UserType>>(jsonString);
            }
            return userTypes;
        }

        /// <summary>
        /// Метод для обновления данных пользователя
        /// </summary>
        /// <param name="entity">пользователь</param>
        public void UpdateUser(User entity)
        {
            users = GetUser();
            User user = users.SingleOrDefault(x => x.id == entity.id);
            if (user != null)
            {
                user.login = entity.login;
                user.name = entity.name;
                user.password = entity.password;
                user.last_visit_date = entity.last_visit_date;
                user.type_id = entity.type_id;
            }

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("Users.Json", json);
        }

        /// <summary>
        /// Метод для добавления пользователя
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Айди добавленного пользователя</returns>
        public int AddUser(User entity)
        {
            users = GetUser();
            User user = new User();
                
            user.id = users.Last().id+1;
            user.login = entity.login;
            user.password = entity.password;
            user.name = entity.name;
            user.type_id = entity.type_id;
            user.last_visit_date = System.DateTime.Now;
            
            users.Add(user);

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("Users.Json", json);

            return user.id;
        }

        /// <summary>
        /// Метод для удаления пользователя
        /// </summary>
        /// <param name="id">Айди пользователя для удаления</param>
        /// <returns>Айди удаленного пользователя</returns>
        public int DeleteUser(int id)
        {
            users = GetUser();
            if (users.SingleOrDefault(x => x.id == id) != null)
            {
                users.Remove(users.Find(x => x.id == id));
            }

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("Users.Json", json);

            return id;
        }
    }
}



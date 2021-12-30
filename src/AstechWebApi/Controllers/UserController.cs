using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstechWebApi.Controllers
{
    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IRepository _repository;
        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получить пользователей по фильтру
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet("Get")]
        public async Task<List<User>> GetByNameAsync(string name, int type)
        {
            List<User> users = _repository.GetUser();
            List<UserType> usersTypes = _repository.GetUserType();
            foreach (var user in users)
            {
                user.type = usersTypes.First(x => x.Id == user.type_id).Name;
            }

            if (name != null)
            {
                users.Where(x => x.name == name).ToList();
            }
            if (type != 0)
            {
                users.Where(x => x.type_id == type).ToList();
            }
            await Task.Delay(500);
            return users;
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <returns>ИД пользователя</returns>
        [HttpPost("AddUser")]
        public int Add([FromBody]User entity)
        {
            if (entity == null)
            {
                throw new Exception("Значения не введены");
            }

           return _repository.AddUser(entity);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <returns>ИД пользователя</returns>
        [HttpDelete("DeleteUser")]
        public int Delete([FromQuery]int id)
        {
            if (id == 0)
            {
                throw new Exception("Значение не введено");
            }
            _repository.DeleteUser(id);
            return id;
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        [HttpPut("UpdateUser")]
        public void Update([FromBody]User entity)
        {
            if (entity == null)
            {
                throw new Exception("Значения не введены");
            }
            _repository.UpdateUser(entity);
        }
    }
}

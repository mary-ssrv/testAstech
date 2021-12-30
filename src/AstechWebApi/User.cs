using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstechWebApi
{
    /// <summary>
    /// Класс пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// ИД типа пользователя
        /// </summary>
        public int type_id { get; set; }

        /// <summary>
        /// Тип пользователя
        /// </summary>
        [JsonIgnore]
        public string type { get; set; }

        /// <summary>
        /// Дата последнего визита
        /// </summary>
        public DateTime last_visit_date { get; set; }

    }
}

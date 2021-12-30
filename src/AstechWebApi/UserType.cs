using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstechWebApi
{
    /// <summary>
    /// Класс типа пользователя
    /// </summary>
    public class UserType
    {
        /// <summary>
        /// ИД типа пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Право на редактирование
        /// </summary>
        public bool Allow_edit { get; set; }
    }
}

using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public partial class User : BaseEntity
    {
        /// <summary>
        /// ИИН/БИН
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
		/// Контактный телефон
		/// </summary>
        public string Phone { get; set; }
        /// <summary>
		/// Контактный телефон
		/// </summary>
        public string AdditionPhone { get; set; }
        /// <summary>
        /// Электронный 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Заблокирован
        /// </summary>
        public bool IsBlocked { get; set; } = false;
        /// <summary>
        /// Зона доступа
        /// </summary>
        public UserAudienceType Audience { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Filal
        /// </summary>
        public string Filial { get; set; }
        /// <summary>
        /// Кол-во неудачных попыток ввода пароля
        /// </summary>
        public int PasswordTryCount { get; set; } = 0;
        /// <summary>
        /// RefreshToken
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// Пользователь физическое или юридическое лицо
        /// </summary>
        public bool IsPhysical { get; set; }
        
        /// <summary>
        /// Список ролей
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; private set; } = new HashSet<UserRole>();

        ///// <summary>
        ///// Список должностей
        ///// </summary>
        //public virtual ICollection<Position> Positions { get; private set; }

        ///// <summary>
        ///// Список филиалов
        ///// </summary>
        //public virtual ICollection<UserBranch> Branches { get; private set; }

        [NotMapped]
        public ICollection<Role> Roles => UserRoles.Select(x => x.Role).ToList();

        public string GetFullname() => $"{LastName} {FirstName} {MiddleName}".TrimEnd();
    }
}

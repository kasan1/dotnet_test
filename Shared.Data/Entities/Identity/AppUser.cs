using System;
using System.Collections.Generic;
using Agro.Shared.Data.Enums.Identity;
using Microsoft.AspNetCore.Identity;

namespace Agro.Shared.Data.Entities.Identity
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class AppUser : IdentityUser<Guid>
    {
        #region Public properties

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Тип пользователя (внутренний/внешний)
        /// </summary>
        public UserAudienceType UserAudienceType { get; set; }

        /// <summary>
        /// Тип сущности/субъекта (физическое/юридическое)
        /// </summary>
        public EssenceType EssenceType { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Навигационное свойство для <see cref="UserProfile.UserId"/>
        /// </summary>
        public UserProfile Profile { get; set; }

        /// <summary>
        /// Список филиалов
        /// </summary>
        public virtual ICollection<UserBranch> Branches { get; private set; }

        #endregion
    }
}

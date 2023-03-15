using System;
using Agro.Shared.Data.Enums.Identity;
using Microsoft.AspNetCore.Identity;

namespace Agro.Shared.Data.Entities.Identity
{
    /// <summary>
    /// Роль в приложении
    /// </summary>
    public class AppRole : IdentityRole<Guid>
    {
        #region Public Properties

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
        /// Наименование на русском
        /// </summary>
        public string NameRu { get; set; }

        /// <summary>
        /// Наименование на казахском
        /// </summary>
        public string NameKk { get; set; }

        /// <summary>
        /// Тип роли
        /// </summary>
        public RoleType RoleType { get; set; }

        #endregion
    }
}

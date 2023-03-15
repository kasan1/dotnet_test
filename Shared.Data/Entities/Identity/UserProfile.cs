using System;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Entities.Identity
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public class UserProfile : BaseEntity
    {
        #region Public properties

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// ИИН/БИН
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Дата создания ЭЦП
        /// </summary>
        public DateTime? CertificateStartDate { get; set; }

        /// <summary>
        /// Дата истечения ЭЦП
        /// </summary>
        public DateTime? CertificateEndDate { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Навигационное свойство для <see cref="UserId"/>
        /// </summary>
        public AppUser User { get; set; }

        #endregion

        #region Public functions

        public string GetFullName() => $"{LastName} {FirstName} {Patronymic}".Trim();

        public string GetShortName() => ($"{LastName} " +
            (!string.IsNullOrEmpty(FirstName) ? $"{FirstName.Substring(0, 1)}. " : "") +
            (!string.IsNullOrEmpty(Patronymic) ? $"{Patronymic.Substring(0, 1)}." : ""))
            .Trim();

        #endregion
    }
}

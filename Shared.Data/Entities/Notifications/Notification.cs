using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using System;
using System.Globalization;

namespace Agro.Shared.Data.Entities.Notifications
{
    public class Notification : BaseEntity
    {
        #region Public properties
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Прочитано?
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid? LoanApplicationTaskId { get; set; }

        /// <summary>
        /// Заголовок на казахском
        /// </summary>
        public string TitleKk { get; set; }

        /// <summary>
        /// Заголовок на русском
        /// </summary>
        public string TitleRu { get; set; }

        /// <summary>
        /// Тело уведомления на казахском
        /// </summary>
        public string BodyKk { get; set; }

        /// <summary>
        /// Тело уведомления на русском
        /// </summary>
        public string BodyRu { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Навигационное свойство для <see cref="UserId"/>
        /// </summary>
        public AppUser User { get; set; }

        /// <summary>
        /// Навигационное свойство для <see cref="LoanApplicationTaskId"/>
        /// </summary>
        public LoanApplicationTask LoanApplicationTask { get; set; }

        #endregion

        #region Public functions
        public string GetTitle() =>
            GetType()
                .GetProperty(
                    "Title"
                    + char.ToUpper(CultureInfo.CurrentCulture.TwoLetterISOLanguageName[0])
                    + CultureInfo.CurrentCulture.TwoLetterISOLanguageName[1..]
                )
                .GetValue(this, null)
                ?.ToString();

        public string GetBody() =>
            GetType()
                .GetProperty(
                    "Body"
                    + char.ToUpper(CultureInfo.CurrentCulture.TwoLetterISOLanguageName[0])
                    + CultureInfo.CurrentCulture.TwoLetterISOLanguageName[1..]
                )
                .GetValue(this, null)
                ?.ToString();

        #endregion
    }
}

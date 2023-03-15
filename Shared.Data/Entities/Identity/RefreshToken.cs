using System;

namespace Agro.Shared.Data.Entities.Identity
{
    public class RefreshToken
    {
        #region Public properties

        /// <summary>
        /// Токен
        /// </summary>
        public Guid Token { get; set; }

        /// <summary>
        /// Идентификатор токена
        /// </summary>
        public string JwtId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата истечения срока годности
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Навигационное свойство для <see cref="UserId"/>
        /// </summary>
        public AppUser User { get; set; }

        #endregion
    }
}

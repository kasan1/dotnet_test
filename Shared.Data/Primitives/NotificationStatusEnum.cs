using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Primitives
{
    public enum NotificationStatusEnum
    {
        /// <summary>
        /// Успешно 
        /// </summary>
        Success = 1,
        /// <summary>
        ///устраняемый
        /// </summary>
        Minor = 2,

        /// <summary>
        /// Критическая ошибка
        /// </summary>
        Critical = 3,
        /// <summary>
        ///ошибка
        /// </summary>
        Error,


    }
}

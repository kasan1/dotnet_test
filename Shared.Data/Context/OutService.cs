using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Сервис хранения ответов на внешние сервисы
    /// </summary>
    public class OutService : BaseEntity
    {
        /// <summary>
        /// Тип сервиса
        /// </summary>
        public OutServiceEnum Type { get; set; }

        /// <summary>
        /// ИИН или БИН заявителя
        /// </summary>
        public string IIN { get; set; }

        /// <summary>
        /// Запрос
        /// </summary>
        [MaxLength]
        public string RequestContent { get; set; }

        /// <summary>
        /// Ответ
        /// </summary>
        [MaxLength]
        public string ResponseContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Error { get; set; } = false;
        
        [MaxLength]
        public string ErrorContent { get; set; }
    }
}

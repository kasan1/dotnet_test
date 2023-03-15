using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Физический
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Полное имя    
        /// </summary>
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();

        /// <summary>
        /// Фамилия и инициалы    
        /// </summary>
        public string ShortName => ($"{LastName} " + 
            (!string.IsNullOrEmpty(FirstName) ? $"{FirstName.Substring(0, 1)}. " : "") +
            (!string.IsNullOrEmpty(MiddleName) ? $"{MiddleName.Substring(0, 1)}." : ""))
            .Trim();

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }
    }
}

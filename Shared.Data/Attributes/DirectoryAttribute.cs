using System;

namespace Agro.Shared.Data.Attributes
{
    /// <summary>
    /// Аттрибут для справочников
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DirectoryAttribute : Attribute
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Системное наименование
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="systemName">Системное наименование</param>
        public DirectoryAttribute(string id, string systemName)
        {
            Id = Guid.Parse(id);
            SystemName = systemName;
        }
    }
}

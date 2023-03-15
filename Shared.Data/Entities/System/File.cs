using System;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Entities.System
{
    public class File : BaseEntity
    {
        /// <summary>
        /// Идентификатор сущности, к которой пренадлежит файл
        /// </summary>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Идентификатор типа сущности
        /// </summary>
        public Guid EntityTypeId { get; set; }

        /// <summary>
        /// Название файла
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Размер файла в байтах
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Тип файла
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Содержимое файла в виде байтового массива
        /// </summary>
        public byte[] Content { get; set; }
    }
}

using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Entities.System
{
    public class EntityType : BaseEntity
    {
        /// <summary>
        /// Наименование используемая в системе
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Описание сущности
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор перечисления
        /// </summary>
        public Enums.System.EntityType EntityTypeId { get; set; }
    }
}

namespace Agro.Shared.Logic.Models.Common
{
    public interface ISortingFilter
    {
        /// <summary>
        /// Поле для сортировки
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Порядок сортировки
        /// </summary>
        public string Order { get; set; }
    }
}

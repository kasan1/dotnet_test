namespace Agro.Shared.Logic.Models.Common
{
    public class ListFilter : ISortingFilter, IPaginationFilter
    {
        public short Page { get; set; } = 1;
        public short PageLimit { get; set; } = 10;
        public string OrderBy { get; set; }
        public string Order { get; set; } = OrderDirection.Asc;
        public int Skip { get => (Page - 1) * PageLimit; }
    }
}

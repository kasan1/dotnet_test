namespace Agro.Shared.Logic.Models.Common
{
    public interface IPaginationFilter
    {
        public short Page { get; set; }
        public short PageLimit { get; set; }
    }
}

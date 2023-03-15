using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Phone : BaseEntity
    {
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
    }
}

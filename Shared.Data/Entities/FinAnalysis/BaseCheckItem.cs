using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Entities.FinAnalysis
{
    public class BaseCheckItem : BaseEntity
    {
        public string Identifier { get; set; }

        public string Fullname { get; set; }
    }
}

using Agro.Shared.Data.Entities.Base;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Shared.Data.Entities.Dictionaries
{
    public class DicVerificationStatus : BaseDictionary
    {
        public RejectStatuses Status { get; set; }
    }
}

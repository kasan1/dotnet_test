using Agro.Shared.Data.Context;

namespace Agro.Scoring.Logic.Scoring
{
    public interface ICheckAffilationLogic
    {
        PolicyRules.PolicyResult CheckAffilition(Person person);
    }
}
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.C1Service
{
    public interface IDictionarySyncLogic
    {
         Task<byte[]> GetJsonAsync(string dictionaryName);
         Task<byte[]> GetJsonAsync(string dictionaryNameRu, string filer);
         Task SyncCountries(byte[] bytes);
         Task SyncAffilationTypes(byte[] bytes);
         Task SyncAuthorizedOrgans(byte[] bytes);
         Task SyncIdDocTypes(byte[] bytes);
         Task SyncOrganizations(byte[] bytes);
         Task SyncCreditProgram(byte[] bytes);
         Task SyncMetricTypes(byte[] bytes);
         Task SyncBorrowerCategory(byte[] bytes);
         Task SyncCertTypes(byte[] bytes);
         Task SyncOPF(byte[] bytes);
         Task SyncEnsuringTypes(byte[] bytes);
         Task SyncLandCategories(byte[] bytes);
         Task SyncOKED(byte[] bytes);
         Task SyncPenalties(byte[] bytes);
         Task SyncClientTypes(byte[] bytes);
         Task SyncPledgeTypes(byte[] bytes);
         Task SyncLandPurposes(byte[] bytes);
         Task SyncFirstDocTypes(byte[] bytes);
         Task SyncFileTypes(byte[] bytes); 

    }
}
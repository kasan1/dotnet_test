using System;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class AffiliatedCompanies:BaseEntity
    {
        public string OrganizationNameAndAddress { get; set; }
        public string ServingBanksAndAccountNumber { get; set; }
        public string DolyaVacionernomKapitale { get; set; }
        public string SsudnyiZadolzhennostWithBanks { get; set; }
        public Guid? ClientDetailsId { get; set; }
        public ClientDetails ClientDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class ClientCredits:BaseEntity
    {
        public string OrganizationName { get; set; }
        public string SumdDebt { get; set; }
        public string CreateCreditDate { get; set; }
        public string ExpiredDate { get; set; }
        public string UnredeemedDebt { get; set; }
        public Guid? ClientDetailsId { get; set; }
        public ClientDetails ClientDetails { get; set; }

    }
}

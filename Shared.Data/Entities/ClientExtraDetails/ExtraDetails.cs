using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Entities.ClientExtraDetails
{
    public class ExtraDetails: BaseEntity
    {
        public Guid LoanApplicationId { get; set; }
        [ForeignKey(nameof(LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        public Guid? VatCertificateId { get; set; }
        [ForeignKey(nameof(VatCertificateId))]
        public Document VatCertificate { get; set; }
    }
}

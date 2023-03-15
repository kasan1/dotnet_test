using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Data.Entities.Identity
{
    public class Agreement : BaseEntity
    {
        #region Public properties

        public AgreementTypeEnum AgreementType { get; set; }
        public string SignedXml { get; set; }

        #endregion
    }
}

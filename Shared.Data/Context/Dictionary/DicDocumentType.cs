using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicDocumentType : BaseDictionary
    {
        public DocumentTypeEnum DocumentType { get; set; } = DocumentTypeEnum.Default;
    }
}

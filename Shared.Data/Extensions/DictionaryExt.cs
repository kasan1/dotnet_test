using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Models.Dictionary;

namespace Agro.Shared.Data.Extensions
{
    public static class DictionaryExt
    {
        public static BaseDictionaryDto ToDto(this BaseDictionary x)
        {
            if (x == null)
                return null;

            return new BaseDictionaryDto
            {
                Id = x.Id,
                Code = x.Code,
                NameRu = x.NameRu,
                NameKk = x.NameKk
            };
        }

        public static BaseDictionary ToEntity(this BaseDictionaryDto x)
        {
            if (x == null)
                return null;
            var _ = new BaseDictionary
            {
                Code = x.Code,
                NameRu = x.NameRu,
                NameKk = x.NameKk
            };
            if (x.Id != null)
                _.Id = x.Id.Value;
            return _;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{ /// <summary>
  /// Справочник местонахождения клиента
  /// </summary>
    public class DicClientLocationType : BaseDictionaryDerived
    {
        public DicClientLocationType()
        {
        }

        public DicClientLocationType(BaseDictionary parent) : base(parent)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Справочник типов клиентов
    /// </summary>
    public class DicClientType : BaseDictionaryDerived
    {
        public DicClientType()
        {
        }

        public DicClientType(BaseDictionary parent) : base(parent)
        {
        }
    }
}

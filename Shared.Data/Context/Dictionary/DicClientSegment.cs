using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Справочник сегментов клиента
    /// </summary>
    public class DicClientSegment : BaseDictionaryDerived
    {
        public DicClientSegment()
        {
        }

        public DicClientSegment(BaseDictionary parent) : base(parent)
        {
        }
    }
}

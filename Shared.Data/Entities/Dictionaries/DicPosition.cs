using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;

namespace Agro.Shared.Data.Entities.Dictionaries
{
    /// <summary>
    /// Справочник всех должностей
    /// </summary>
    public class DicPosition : BaseDictionary
    {
        #region Nagivation properties

        public ICollection<UserBranch> Users { get; set; }

        #endregion
    }
}

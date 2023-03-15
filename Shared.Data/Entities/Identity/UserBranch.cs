using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using System;

namespace Agro.Shared.Data.Entities.Identity
{

    /// <summary>
    /// Отношение между пользователями и филиалами (с должностью)
    /// </summary>
    public class UserBranch : BaseEntity
    {
        #region Public properties

        public Guid UserId { get; set; }

        public Guid BranchId { get; set; }

        public Guid? PositionId { get; set; }

        #endregion

        #region Navigation properties

        public AppUser User { get; set; }

        public Branch Branch { get; set; }

        public DicPosition Position { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.Users.DTOs
{
    public class UserBranchDto
    {
        public List<Guid> BranchIds { get; set; }
        public Guid? PositionId { get; set; }
    }
}

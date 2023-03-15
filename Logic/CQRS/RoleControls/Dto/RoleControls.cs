using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.RoleControls.Dto
{
    public class RoleControlsSettings
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsReadOnly { get; set; }

        public IEnumerable<RoleControlButton> Buttons { get; set; } = new List<RoleControlButton> { };
        public IEnumerable<RoleControlField> Fields { get; set; } = new List<RoleControlField> { };
    }

    public class RoleControlComponent
    {
        public string Name { get; set; }
    }

    public class RoleControlButton : RoleControlComponent
    { 
        public bool HasForm { get; set; }
        public Guid TaskStatusId { get; set; }
        public bool IsApply { get; set; }
        public string DialogTitle { get; set; }
        public string DialogMessage { get; set; }
    }

    public class RoleControlField : RoleControlComponent
    {
        public Guid Id { get; set; }
        public bool IsChecked { get; set; }
        public int CountOfComments { get; set; }
    }
}

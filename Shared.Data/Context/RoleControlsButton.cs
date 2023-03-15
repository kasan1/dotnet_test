using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Table(nameof(RoleControlsButton) + "s")]
    public class RoleControlsButton : BaseDictionary
    {
        [ForeignKey(nameof(RoleControlId))]
        public RoleControls RoleControls { get; set; }
        public Guid RoleControlId { get; set; }
        [ForeignKey(nameof(TaskStatusId))]
        public DicTaskStatus TaskStatus { get; set; }
        public Guid TaskStatusId { get; set; }
        public bool HasForm { get; set; }
        public bool IsApply { get; set; }
        public string DialogTitleRu { get; set; }
        public string DialogTitleKk { get; set; }
        public string DialogTitle() =>
            GetType()
                .GetProperty(
                    "DialogTitle"
                    + char.ToUpper(CultureInfo.CurrentCulture.TwoLetterISOLanguageName[0])
                    + CultureInfo.CurrentCulture.TwoLetterISOLanguageName[1..]
                )
                .GetValue(this, null)
                ?.ToString();

        public string DialogMessageRu { get; set; }
        public string DialogMessageKk { get; set; }
        public string DialogMessage() =>
            GetType()
                .GetProperty(
                    "DialogMessage"
                    + char.ToUpper(CultureInfo.CurrentCulture.TwoLetterISOLanguageName[0])
                    + CultureInfo.CurrentCulture.TwoLetterISOLanguageName[1..]
                )
                .GetValue(this, null)
                ?.ToString();
    }
}

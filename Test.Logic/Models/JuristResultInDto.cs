using System;
using Agro.Shared.Logic.Models;

namespace Agro.Okaps.Logic.Models
{
    public class JuristResultInDto
    {

        public Guid? JuristResultId { get; set; }
        public Guid? ApplicationId { get; set; }
        public Guid? WarningClassificationId { get; set; }
        public string Iin { get; set; }
        public Guid? ApplicationTaskId { get; set; }

        public string DocClassificationText { get; set; }
        public string SubtitleClassificationText { get; set; }
        public string WarningClassificationText { get; set; }
        public string Code { get; set; }
        public string FixReason { get; set; }
        public FileUploadEntry FixFile { get; set; }
        public Guid? FixFileId { get; set; }
        public bool IsFixed { get; set; }
        public bool IsConfirm { get; set; }

    }
}

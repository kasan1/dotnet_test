using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Logic.Models
{
    public class AppFilesInDto
    {
        public Guid? Id { get; set; }
        public Guid? AppId { get; set; }
        public ICollection<string> Codes { get; set; } = new HashSet<string>();
        public PageEnum? Page { get; set; }
        public Guid? BasePledgeId { get; set; }
    }
}

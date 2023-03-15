using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class TechActivity : BaseEntity
    {
        public string CultureName { get; set; }
        public string CreateDate { get; set; }
        public string Count { get; set; }
        public string WorkCorrectlyCount { get; set; }
        public string Obremeneniya { get; set; }
        public string WhomAndWhyZalozheno { get; set; }
        public Guid? AppActivesId { get; set; }
        public AppActives appActives { get; set; }
    }
}

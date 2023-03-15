using Agro.Shared.Data.Primitives;
using System;

namespace Agro.Okaps.Logic.Models
{
    public class LoanApplicationFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Skip => PageIndex * PageSize;
        public ApplicationTypeEnum Type { get; set; } = ApplicationTypeEnum.CMAll;
        public string Search { get; set; }
        public string Column { get; set; }
        public string Direction { get; set; }
        public Guid? ApplicationId { get; set; }
    }
}

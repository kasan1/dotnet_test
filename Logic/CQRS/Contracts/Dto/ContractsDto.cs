using Agro.Bpm.Logic.Models.Common;

namespace Agro.Bpm.Logic.CQRS.Contracts.Dto
{
    public class ContractsDto
    {
        public TableData Techniques { get; set; } = new TableData();
        public TableData Calculators { get; set; } = new TableData();
        public TableData Provisions { get; set; } = new TableData();
    }
}

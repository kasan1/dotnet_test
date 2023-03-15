using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class LoanApplicationDto
    {
        public Guid LoanApplicationId { get; set; }

        /// <summary>
        /// Регистрационный номер заявки
        /// </summary>
        public string RegisterNumber { get; set; }

        /// <summary>
        /// Процессный статус
        /// </summary>
        public string LoanStatusName { get; set; }
        public ApplicationTypeEnum LoanStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public LoanTypeEnum LoanType { get; set; }
        public string LoanTypeName { get; set; }

        public IEnumerable<ContractDto> Contracts { get; set; }
        
    }
}

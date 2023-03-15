using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class LoanApplicationStatusInDto
    {
        // Id заявки
        public Guid ApplicationId { get; set; }

        // Текущий статус
        public ApplicationTypeEnum Status { get; set; }
    }
}

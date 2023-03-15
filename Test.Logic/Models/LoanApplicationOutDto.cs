using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class LoanApplicationOutDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ClientFullName { get; set; }
        public string Purpose { get; set; }
        public string Number { get; set; }
        public string Iin { get; set; }
        public string DateCreated { get; set; }
        public ApplicationTypeEnum Status { get; set; }
        public string StatusTitle { get; set; }
        public string StatusCode { get; set; }
        public string Comment { get; set; }
        public string DecisionCode { get; set; }
        public string DecisionNameRu { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? FactEndDate { get; set; }
    }
}
using System;
namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{

    public class TechnicDto : TechnicBaseDto
    {
        public Guid TechTypeId { get; set; }
        public Guid TechSubtypeId { get; set; }
    }
}

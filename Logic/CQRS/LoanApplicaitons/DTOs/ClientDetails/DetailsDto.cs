using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class DetailsDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public OrganizationDto Organization { get; set; }

        /// <summary>
        /// руководитель
        /// </summary>
        public PersonDto Head { get; set; }

        /// <summary>
        /// бухгалтер
        /// </summary>
        public PersonDto Booker { get; set; }

        /// <summary>
        /// бенефициар
        /// </summary>
        public PersonDto Beneficiary { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public PersonDto Representative { get; set; }

        /// <summary>
        /// Контактные лица
        /// </summary>
        public List<PersonDto> Contacts { get; set; } = new List<PersonDto>();
    }

}

﻿using System;
using System.Collections.Generic;
using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
{
    public class DetailsDto
    {
        public Guid? Id { get; set; }

        public bool IsReadOnly { get; set; }

        public LoanTypeEnum LoanType { get; set; }

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

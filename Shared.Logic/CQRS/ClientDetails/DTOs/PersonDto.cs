using System;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
{

    public class PersonDto : PersonalityBaseDto
    {
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool IsResident { get; set; }

        public Guid? CountryId { get; set; }
        public Guid? MarriageStatusId { get; set; }
        /// <summary>
        /// супруг(а) руководителя
        /// </summary>
        public string Spouse { get; set; }
        public string Education { get; set; }
    }

}

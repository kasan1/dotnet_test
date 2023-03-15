using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{

    public class PersonDto : BaseDto
    {
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool IsResident { get; set; }

        public string Country { get; set; }
        public string MarriageStatus { get; set; }
        /// <summary>
        /// супруг(а) руководителя
        /// </summary>
        public string Spouse { get; set; }
        public string Education { get; set; }
    }

}

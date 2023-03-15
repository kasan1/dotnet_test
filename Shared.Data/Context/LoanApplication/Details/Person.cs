using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{

    public class Person : BaseEntity
    {
        public Guid PersonalityId { get; set; }
        public Personality Personality { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool IsResident { get; set; }

        public Guid? CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public DicCountry DicCountry { get; set; }

        public Guid? MariageStatusId { get; set; }
        [ForeignKey(nameof(MariageStatusId))]
        public DicMariageStatus DicMariageStatus { get; set; }
        public string Spouse { get; set; }
        public string Education { get; set; }
    }
}

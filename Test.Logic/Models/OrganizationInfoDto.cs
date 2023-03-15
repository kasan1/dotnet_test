using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class OrganizationInfoDto
    {
        public Guid ClientTypeId { get; set; }
        public string Name { get; set; }
        public Guid clientSegmentId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string KatoCode { get; set; }
        public string Adress { get; set; }
        public bool IsNDS { get; set; }
        public Guid UserId { get; set; }
    }
}

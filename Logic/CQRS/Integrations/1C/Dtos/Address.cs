using System;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Address
    {
        public Guid? Region { get; set; }
        public string Register { get; set; }
        public string Fact { get; set; }
    }
}

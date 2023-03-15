using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Envelope
    {
        public Company Contragent { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}

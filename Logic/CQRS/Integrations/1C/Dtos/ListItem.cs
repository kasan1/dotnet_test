using System;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class ListItem
    {
        public Guid Id { get; set; }

        public bool IsPrimary { get; set; }
    }
}

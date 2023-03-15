using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs
{
    public class NavigationDto
    {
        public Guid? RoleId { get; set; }
        public string Name { get; set; }
        public IEnumerable<NavigationItemDto> Items { get; set; } = new List<NavigationItemDto>();
    }

    public class NavigationItemDto
    {
        public Guid? StatusId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}

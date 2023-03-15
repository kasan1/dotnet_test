using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.Users.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public List<string> Positions { get; set; } = new List<string>();
    }
}

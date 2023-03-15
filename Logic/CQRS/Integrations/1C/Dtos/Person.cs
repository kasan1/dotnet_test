using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Person
    {
        public Guid Id { get; set; }

        /// <summary>
        /// ИИН
        /// </summary>
        public string Identifier { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// пол, M или F
        /// </summary>
        public string Sex { get; set; }

        public DocumentDto IdentificationDocument { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Agro.Okaps.Logic.Models
{
    public class LiterInDto
    {
        public Guid? Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Value { get; set; }
        public float? Area { get; set; }
    }
}
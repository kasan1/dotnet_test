using System;
using System.ComponentModel.DataAnnotations;

namespace Agro.Okaps.Logic.Models
{
    public class ChargeeInDto
    {
        public Guid? Id { get; set; }

        [MaxLength(20), Required]
        public string Iin { get; set; }

        [MaxLength(200), Required]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string DocumentNumber { get; set; }

        public DateTime? DocumentBeginDate { get; set; }
        public DateTime? DocumentEndDate { get; set; }

        [MaxLength(200)]
        public string DocumentOrganizationName { get; set; }

        public bool SamePerson { get; set; }

        public string LegalCommentVnd { get; set; }
        public bool LegalResultVnd { get; set; }
        public string LegalCommentRk { get; set; }
        public bool LegalResultRk { get; set; }
    }
}
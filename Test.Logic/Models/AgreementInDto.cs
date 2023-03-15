using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class AgreementInDto
    {
        [Required]
        public AgreementTypeEnum AgreementType { get; set; }

        [Required]
        public string SignedXml { get; set; }

        public Guid UserId { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Document : BaseEntity
    {
        public Guid DocumentTypeId { get; set; }
        [ForeignKey(nameof(DocumentTypeId))]
        public DicDocumentType DocumentType { get; set; }

        public string Number { get; set; }
        public string Issuer { get; set; }
        public DateTime DateIssue { get; set; }
    }
}

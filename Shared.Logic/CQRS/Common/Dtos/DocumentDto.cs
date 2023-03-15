using Agro.Shared.Data.Context;
using System;

namespace Agro.Shared.Logic.CQRS.Common.DTOs
{
    public class DocumentDto
    {
        public Guid? Id { get; set; }
        public string Number { get; set; }
        public string Issuer { get; set; }
        public DateTime DateIssue { get; set; }

        public DocumentDto()
        {

        }

        public DocumentDto(Document doc)
        {
            Id = doc.Id;
            DateIssue = doc.DateIssue;
            Issuer = doc.Issuer;
            Number = doc.Number;
        }
    }
}

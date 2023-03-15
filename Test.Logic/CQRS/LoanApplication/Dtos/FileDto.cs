using System;
namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class FileDto : Shared.Logic.CQRS.Files.DTOs.FileDto
    {
        public string ApplicationNumber { get; set; }
        public DateTime ApplicationDate { get; set; }

        public string DocumentType { get; set; }
    }
}

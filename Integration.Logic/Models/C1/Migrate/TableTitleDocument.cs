using System;
namespace Agro.Integration.Logic.Models.C1.Migrate
{
    public class TableTitleDocument
    {
        public string TitleDocumentType { get; set; }
        public string TitleDocumentOriginal_Copy { get; set; }
        public DateTime TitleDocumentDate { get; set; }
        public string TitleDocumentNumber { get; set; }
        public string TitleDocumentSheets { get; set; }
        public string TitleDocumentBail { get; set; }
        public string TitleDocumentFileId { get; set; }
    }
}
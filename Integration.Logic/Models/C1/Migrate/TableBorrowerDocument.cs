using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.C1.Migrate
{
    public class TableBorrowerDocument
    {
        public string DocumentType { get; set; }
        public string Original_Copy { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumenSheets { get; set; }
        public string DocumentFileId { get; set; }
    }
}

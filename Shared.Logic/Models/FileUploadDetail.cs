using Agro.Shared.Data.Primitives;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Logic.Models
{
    public class FileUploadEntry
    {
        public string Identifier { get; set; }
        public Guid? AppId { get; set; }
        public Guid? BasePledgeId { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public PageEnum Page { get; set; }
        public bool IsOriginal { get; set; }
        public string DataBase64 { get; set; }
    }
}

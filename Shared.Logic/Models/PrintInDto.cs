using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Logic.Models
{
    public class PrintInDto
    {

        public Guid AppId { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public bool HasXml { get; set; }
        public string XmlData { get; set; }
    }
}

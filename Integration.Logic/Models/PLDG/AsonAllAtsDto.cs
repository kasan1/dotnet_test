using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.PLDG
{
    public class AsonAllAtsDto
    {
        public List<AsonSimpleAtsDto> All { get; set; }

        public string Types { get; set; }
    }
}

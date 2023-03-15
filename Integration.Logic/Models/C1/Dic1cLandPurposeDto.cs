using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.C1
{
    class Dic1cLandPurposeDto : Dic1cBaseEntityDto
    {
        [JsonProperty("Description")]
        public string NameRu { get; set; }
      
    }
}

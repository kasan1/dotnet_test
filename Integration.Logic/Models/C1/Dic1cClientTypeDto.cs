using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cClientTypeDto: Dic1cBaseEntityDto
    {
        [JsonProperty("Description")]
        public string NameRu { get; set; }        
    }
}

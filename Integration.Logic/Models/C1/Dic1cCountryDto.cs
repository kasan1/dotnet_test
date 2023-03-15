using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cCountryDto : Dic1cBaseEntityDto
    {
        [JsonProperty("НаименованиеПолное")]
        public string NameRu { get; set; }
    }
}
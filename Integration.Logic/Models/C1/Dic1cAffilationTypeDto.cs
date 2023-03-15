using Newtonsoft.Json;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cAffilationTypeDto : Dic1cBaseEntityDto
    {
        [JsonProperty("НаименованиеПолное")]
        public string NameRu { get; set; }
        [JsonProperty("КодАФН2")]
        public string CodeAfn2 { get; set; }

        [JsonProperty("Казагро_Код")]
        public string CodeKazAgro { get; set; }
    }
}
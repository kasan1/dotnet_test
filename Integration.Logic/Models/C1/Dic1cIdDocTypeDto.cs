using Newtonsoft.Json;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cIdDocTypeDto : Dic1cBaseEntityDto
    {
        [JsonProperty("НаименованиеКаз")]
        public string NameKz { get; set; }
    }
}
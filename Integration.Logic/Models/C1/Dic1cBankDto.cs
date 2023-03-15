using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cBankDto : Dic1cBaseEntityDto
    {
        [JsonProperty("КодВПлатежнойСистеме")]
        public string PaymentSystemCode { get; set; }
        [JsonProperty("БИК")]
        public string BIK { get; set; }
    }
}
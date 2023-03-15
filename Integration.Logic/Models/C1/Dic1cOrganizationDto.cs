using System;
using Newtonsoft.Json;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cOrganizationDto : Dic1cBaseEntityDto
    {
        // [JsonProperty("")]
        // public string AddressKz { get; set; }
        // [JsonProperty("")]
        // public string AddressRu { get; set; }
        [JsonProperty("ИдентификационныйНомер")]
        public string Bin { get; set; }
        // [JsonProperty("")]
        // public string CodeGBDFL { get; set; }
        // [JsonProperty("КАТО_Key")]
        public string CodeKato { get; set; }
        [JsonProperty("Code")]
        public string CodeOCA { get; set; }
        [JsonProperty("ГоловнаяОрганизация_Key")]
        public Guid? ParentId { get; set; }
        // [JsonProperty("")]
        // public string Phone { get; set; }

    }
}
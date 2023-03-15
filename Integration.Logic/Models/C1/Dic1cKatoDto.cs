using System;
using Newtonsoft.Json;

namespace Agro.Integration.Logic.Models.C1
{
    public class Dic1cKatoDto : Dic1cBaseEntityDto
    {
        [JsonProperty("Parent_Key")]
        public Guid? ParentId { get; set; }

        [JsonProperty("НаименованиеКаз")]
        public string NameKz { get; set; }

        [JsonProperty("Область_Key")]
        public Guid? OblastId { get; set; }

        [JsonProperty("Район_Key")]
        public Guid? RegionId { get; set; }

        [JsonProperty("СтарыйКод")]
        public string OldCode { get; set; }

        public int Ab()
        {
            int _;
            int.TryParse(Code.Substring(0, 2), out _);
            return _;
        }

        public int Cd()
        {
            int _;
            int.TryParse(Code.Substring(2, 2), out _);
            return _;
        }

        public int Ef()
        {
            int _;
            int.TryParse(Code.Substring(4, 2), out _);
            return _;
        }

        public int Hij()
        {
            int _;
            int.TryParse(Code.Substring(6, 3), out _);
            return _;
        }
    }
}
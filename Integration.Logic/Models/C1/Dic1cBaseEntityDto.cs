using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Agro.Integration.Logic.Models.C1
{
    public abstract class Dic1cBaseEntityDto
    {
        [JsonProperty("Ref_Key")]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DataVersion { get; set; }
        public bool DeletionMark { get; set; }
        public string Code { get; set; }
        public bool Predefined { get; set; }
        public string PredefinedDataName { get; set; }
    }
}
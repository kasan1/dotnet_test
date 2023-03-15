using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class DicBranch : BaseDictionary
    {
        public string Prefix { get; set; }
        public bool IsParent { get; set; }
        public string CodeKato { get; set; }
        public string OgranizationId { get; set; }
        public string StructSubdivisionId { get; set; }
        public string OrgDevisionId { get; set; }
        public string Bin { get; set; }
        public string AddressKz { get; set; }
        public string AddressRu { get; set; }
        public string Phone { get; set; }
        public string CodeGBDFL { get; set; }
        public string CodeOCA { get; set; }

   
        public Guid? RegionId { get; set; }
    }
}
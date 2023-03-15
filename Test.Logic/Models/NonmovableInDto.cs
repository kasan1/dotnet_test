using System;

namespace Agro.Okaps.Logic.Models
{
    public class NonmovableInDto
    {
        public Guid? Id { get; set; }
        public string CadastralNumber { get; set; }
        public Guid? WallMaterialId { get; set; }
        public int RoomCount { get; set; }
        public float TotalArea { get; set; }
        public float LivingArea { get; set; }
        public double FloorNumber { get; set; }
        public double FloorCount { get; set; }
        public short BuiltYear { get; set; }
        public float LandArea { get; set; }
        public Guid? LiterId { get; set; }
        public Guid? DicLandPurposeId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? DicСommercialОbjectTypeId { get; set; }
        public Guid? DicСommercialОbjectNameId { get; set; }
        public Guid? DicСommercialОbjectPurposeId { get; set; }
        public string Address { get; set; }
        public string Cato { get; set; }
        public short Rent { get; set; }
        public short RentedFor { get; set; }
        public short CommercialType { get; set; }
    }
}

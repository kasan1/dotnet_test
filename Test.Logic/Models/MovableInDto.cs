using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class MovableInDto
    {
        public Guid? Id { get; set; }
        public string NameRus { get; set; }
        public string NameKaz { get; set; }
        public string IssuedYear { get; set; }
        public string IssuedBy { get; set; }
        public string AdditionalEquipment { get; set; }
        public string FactoryNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string RegAddress { get; set; }
        public Guid? DicAgriculturalMachineryPurposeId { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Birthdate { get; set; }
        public string FactAddress { get; set; }
        public string AgeGroup { get; set; }
        public string IdNumber { get; set; }
        public string Certificate { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid? DicEquipmentPurposeId { get; set; }
        public string EquipmentType { get; set; }
        public string ObtainYear { get; set; }
        public string ConfirmDoc { get; set; }
        public string ConfirmDocNumber { get; set; }
        public string Specification { get; set; }
        public string TechPassport { get; set; }
        public string QualificationAkt { get; set; }
        public decimal DepositAmount { get; set; }
        public string DepositCurrency { get; set; }
        public string BankName { get; set; }
        public DateTime? DepositOpen { get; set; }
        public Guid? DicStockTypeId { get; set; }
        public string FullName { get; set; }
        public string DocNumber { get; set; }
        public DateTime? DateIssue { get; set; }
        public string AvailabilityRes { get; set; }
        public string AvailabilityNoRes { get; set; }
        public string VPNumber { get; set; }
        public string RegNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Guid? DicTransportTypeId { get; set; }
        public Guid? DicTransportBodyTypeId { get; set; }
        public string BodyNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public Guid? DicTransportFuelId { get; set; }
        public string Color { get; set; }
        public string RegYear { get; set; }
        public string ImporterCountry { get; set; }
        public string VINNumber { get; set; }
        public Guid? DicTransportSteeringWheelId { get; set; }
        public DateTime? TechnicalPassportIssuedDate { get; set; }
        public string TechnicalPassportNumber { get; set; }
        public decimal NOKPrice { get; set; }
    }
}

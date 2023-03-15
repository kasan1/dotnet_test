using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class BasePledgeInDto
    {
        public Guid? Id { get; set; }
        public PledgeFirstLevel FirstLevel { get; set; }
        public PledgeSecondLevel? SecondLevel { get; set; }
        public PledgeThirdLevel? ThirdLevel { get; set; }
        public Guid? CoreId { get; set; }
        public Guid? ApplicationId { get; set; }
        public bool IsOwner { get; set; }
        public Guid? LiquidityId { get; set; }

        public decimal? AsonSum { get; set; }
        public decimal? NokSum { get; set; }
        public decimal? ExpertSum { get; set; }
        public decimal? ExpertiseSum { get; set; }
        public decimal FinalSum { get; set; }
        public string NokName { get; set; }
        public Guid? DicNokId { get; set; }
        public float? Coefficient { get; set; }
        public bool Agreement { get; set; }

        public string LegalCommentVnd { get; set; }
        public bool LegalResultVnd { get; set; }
        public string LegalCommentRk { get; set; }
        public bool LegalResultRk { get; set; }

        public ICollection<ChargeeInDto> Chargees { get; set; } = new HashSet<ChargeeInDto>();
        public ICollection<LiterInDto> Liters { get; set; } = new HashSet<LiterInDto>();


        #region Nonmovable
        /// <summary>
        /// Кадастровый номер. 
        /// </summary>

        [MaxLength(200)]
        public string CadastralNumber { get; set; }

        /// <summary>
        /// Общая площадь
        /// </summary>
        public float? TotalArea { get; set; }
        public float? LivingArea { get; set; }
        public short? BuiltYear { get; set; }
        public float? LandArea { get; set; }

        [MaxLength(40)]
        public string LandPurpose { get; set; }

        [MaxLength(400)]
        public string Address { get; set; }
        public long? Level1 { get; set; }
        public long? Level2 { get; set; }
        public long? Level3 { get; set; }
        public long? Level4 { get; set; }
        public long? Level5 { get; set; }
        public int? RoomNumber { get; set; }
        public int? HouseNumber { get; set; }
        public long? GeonimId { get; set; }
        public long? AtsId { get; set; }

        [MaxLength(100)]
        public string Cato { get; set; }

        public short? WallMaterial { get; set; }

        [MaxLength(200)]
        public string CommercialName { get; set; }
        public short? Rent { get; set; }
        public short? RentedFor { get; set; }
        public bool HasLiters { get; set; }
        #endregion

        #region Guarantee
        public DateTime? Date { get; set; }
        public short? ValidFor { get; set; }

        [MaxLength(50)]
        public string GuaranteeCode { get; set; }
        #endregion

        #region Movable
        [MaxLength(200)]
        public string Name { get; set; }
        public short? Year { get; set; }

        [MaxLength(100)]
        public string GovNumber { get; set; }

        [MaxLength(100)]
        public string RegisterNumber { get; set; }
        public DateTime? RegisterDate { get; set; }

        [MaxLength(100)]
        public string Vin { get; set; }

        [MaxLength(100)]
        public string Bvu { get; set; }

        [MaxLength(400)]
        public string Mark { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        [MaxLength(200)]
        public string Company { get; set; }

        [MaxLength(50)]
        public string CountryCode { get; set; }

        [MaxLength(50)]
        public string TransportCode { get; set; }

        public DateTime? DepositDate { get; set; }
        public decimal? DepositTotal { get; set; }

        [MaxLength(200)]
        public string DepositNumber { get; set; }
        #endregion
    }
}

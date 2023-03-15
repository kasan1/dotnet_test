using System.ComponentModel.DataAnnotations;

namespace Agro.Shared.Data.Primitives
{
    public enum PledgeThirdLevel
    {
        [Display(Name = "Дом")]
        House = 1,
        [Display(Name = "Квартира")]
        Flat = 2,
        [Display(Name = "Автотранспорт")]
        AutoTransport = 3,
        [Display(Name = "Сельхозтехника")]
        LandTransport = 4
    }
}
